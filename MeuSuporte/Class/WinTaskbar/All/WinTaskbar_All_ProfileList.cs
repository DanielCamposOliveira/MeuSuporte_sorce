using Microsoft.Win32;
using System;
using System.IO;
using System.Security.Principal;
using System.Threading.Tasks;

namespace MeuSuporte
{
    //  2
    /// <summary>
    /// Essa class sera responsavel por 
    /// Lista todos os Usuarios
    /// Repassar o caminho do perfil do usuario para class de WinRegistryBackup_All_Key
    /// </summary>

    internal class WinTaskbar_All_ProfileList
    {
        private const string PROFILE_LIST_PATH = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\ProfileList";

        // Dependências injetadas
        private readonly WinTaskbar_HiveLoader RegistryBackup_All_HiveLoader;

        private readonly WinGlobal_FileCheck FileCheck;

        private readonly WinTaskbar_All_Changes Taskbar_All_Changes;

        public WinTaskbar_All_ProfileList(WinTaskbar_HiveLoader _hiveLoader)
        {
            RegistryBackup_All_HiveLoader = _hiveLoader;

            FileCheck = new WinGlobal_FileCheck();
            Taskbar_All_Changes = new WinTaskbar_All_Changes();
        }

    
        public async Task ProfilesMananger(bool state, int ValueUniProgressBar)
        {
            // Obtém o Security Identifier (SID) do usuário que está executando o script, para evitar tentar carregar e modificar seu próprio perfil de registro.
            string currentUserSid = WindowsIdentity.GetCurrent().User.Value;

            using (RegistryKey? profileListKey = Registry.LocalMachine.OpenSubKey(PROFILE_LIST_PATH))
            {
                if (profileListKey == null) return;

                //Divide o valor ValueUniProgressBar pela QTD de Usuarios
                int _ValueUniProgressBar = ValueUniProgressBar / profileListKey.ValueCount;

                foreach (string sid in profileListKey.GetSubKeyNames())
                {
                    WinGlobal_UIService.Instance.token.ThrowIfCancellationRequested(); // Checa se o cancelamento foi solicitado antes de começar

                    // verifica se o usuario é do sistema ou do usuario logado
                    if (!sid.StartsWith("S-1-5-21-") || sid == currentUserSid) continue;

                    string tempHiveName = $"TempHive_{sid}";
                    string? ntUserDatPath = null;

                    try
                    {
                        // Abre a subchave de registro específica do usuário (identificada pelo SID) dentro de ProfileList para ler o caminho do seu perfil.
                        using (RegistryKey? sidKey = profileListKey.OpenSubKey(sid))
                        {
                            ntUserDatPath = sidKey?.GetValue("ProfileImagePath")?.ToString();
                        }

                        // Verifica o caminho do perfil se ele existe, caso contrário, pula este SID
                        if (string.IsNullOrEmpty(ntUserDatPath) || !Directory.Exists(ntUserDatPath)) continue;

                        string usuario = Path.GetFileName(ntUserDatPath);
                        ntUserDatPath = Path.Combine(ntUserDatPath, "NTUSER.DAT");

                        // Verifia se arquivo NTUSER.DAT existe
                        if (!FileCheck.Check(ntUserDatPath))
                        {
                            continue;
                        }

                        // 5. Usa a instância do HiveLoader para carregar
                        RegistryBackup_All_HiveLoader.LoadHive(tempHiveName, ntUserDatPath);

                        // 6. Aplica as configurações                        
                       // await RegistryBinUserAll_Delete.Delete(tempHiveName, usuario, _ValueUniProgressBar);
                        await Taskbar_All_Changes.Changes(state,tempHiveName, usuario, _ValueUniProgressBar);
                    }
                    catch (Exception ex)
                    {
                        await WinGlobal_UIService.Instance.Log_MensagemAsync($"Registro do Usuario - Ocorreu um Erro ao tentar acessar registro do  SID {sid}", true);
                        WinGlobal_UIService.Instance.Erro++;
                    }
                    finally
                    {
                        // 7. Usa a instância do HiveLoader para descarregar
                        RegistryBackup_All_HiveLoader.UnloadHive(tempHiveName);
                    }
                }
            }

            await WinGlobal_UIService.Instance.ProgressBarADD(ValueUniProgressBar);
        }


    }
}
