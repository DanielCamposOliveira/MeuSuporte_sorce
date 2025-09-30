using Microsoft.Win32;
using System;
using System.IO;
using System.Security.Principal;

namespace MeuSuporte
{
    /// <summary>
    /// Essa class sera responsavel por lista todos os perfis dos usuarios e repassar para class de processamento
    /// </summary>


    internal class WinRegistryBackup_All_ProfileList
    {
        private const string PROFILE_LIST_PATH = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\ProfileList";

        // Dependências injetadas
        private readonly WinRegistryBackup_All_HiveLoader _hiveLoader;
        private readonly WinRegistryBackup_All_SaveRegistry RegistryBackup_All_SaveRegistry;

        // Construtor para RECEBER as dependências do orquestrador
        public WinRegistryBackup_All_ProfileList(WinRegistryBackup_All_HiveLoader hiveLoader, WinRegistryBackup_All_SaveRegistry registryBackupList)
        {
            _hiveLoader = hiveLoader;
            RegistryBackup_All_SaveRegistry = registryBackupList;
        }

        // Método principal, agora público ou interno, dependendo da necessidade
        public void ProfilesMananger(int ValueUniProgressBar)
        {
            // Obtém o Security Identifier (SID) do usuário logado
            string currentUserSid = WindowsIdentity.GetCurrent().User.Value;

            using (RegistryKey? profileListKey = Registry.LocalMachine.OpenSubKey(PROFILE_LIST_PATH))
            {
                if (profileListKey == null) return;

                // percorre por todos os usuarios encontrado no PROFILE_LIST_PATH
                foreach (string sid in profileListKey.GetSubKeyNames())
                {
                    WinGlobal_UIService.Instance.token.ThrowIfCancellationRequested(); // Checa se o cancelamento foi solicitado antes de começar

                    // Verifica se é um usuário válido e não o usuário logado
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

                        // 2. Verificações de caminho e arquivo
                        if (string.IsNullOrEmpty(ntUserDatPath) || !Directory.Exists(ntUserDatPath)) continue;

                        string usuario = Path.GetFileName(ntUserDatPath);
                        ntUserDatPath = Path.Combine(ntUserDatPath, "NTUSER.DAT");

                        if (!File.Exists(ntUserDatPath)) continue;

                        // 3. Carregar o hive usando a dependência
                        _hiveLoader.LoadHive(tempHiveName, ntUserDatPath);

                        // 4. Aplicar as configurações usando a dependência
                        RegistryBackup_All_SaveRegistry.Backup(tempHiveName, usuario);
                    }
                    catch (Exception ex)
                    {
                        WinGlobal_UIService.Instance.Log_MensagemAsync($"Backup Registry: USER - Ocorreu um Erro ao tentar acessar registro do  SID {sid}", true);
                        WinGlobal_UIService.Instance.Erro++;
                    }
                    finally
                    {
                        // 5. Descarregar o hive usando a dependência
                        _hiveLoader.UnloadHive(tempHiveName);
                    }
                }
            }
        }
    }
}