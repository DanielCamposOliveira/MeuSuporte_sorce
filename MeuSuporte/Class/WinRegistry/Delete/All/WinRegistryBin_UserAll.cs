using Microsoft.Win32;
using System;
using System.IO;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MeuSuporte
{
    internal class WinRegistryBin_UserAll
    {
        private const string PROFILE_LIST_PATH = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\ProfileList";
        
        private readonly WinRegistryBinUserAll_Privilege _privilegeManager;
        private readonly WinRegistryBinUserAll_HiveLoader _hiveLoader;

        private WinRegistryBinUserAll_Delete RegistryBin_UserAll;

        public WinRegistryBin_UserAll()
        {
            _privilegeManager = new WinRegistryBinUserAll_Privilege();
            _hiveLoader = new WinRegistryBinUserAll_HiveLoader();
            RegistryBin_UserAll = new WinRegistryBinUserAll_Delete();
        }

        public async Task Delete(int ValueUniProgressBar)
        {           
            // Habilitar o privilégio 'SeRestorePrivilege', necessário para carregar hives (perfis) de registro de outros usuários.
            bool restoreEnabled = _privilegeManager.SetPrivilege(WinRegistryBinUserAll_Privilege.SE_RESTORE_NAME, true);
            // Habilitar o privilégio 'SeBackupPrivilege', geralmente necessário em conjunto com o Restore para manipulação de arquivos de sistema como NTUSER.DAT.
            bool backupEnabled = _privilegeManager.SetPrivilege(WinRegistryBinUserAll_Privilege.SE_BACKUP_NAME, true);


            if (!restoreEnabled || !backupEnabled)
            {
               // MessageBox.Show("Falha crítica: Não foi possível obter os privilégios de Backup/Restore.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Itera sobre os perfis de usuário
                ConfigureExistingUserProfiles(ValueUniProgressBar);
            }
            finally
            {
                // 4. Desabilita os privilégios no final
                _privilegeManager.SetPrivilege(WinRegistryBinUserAll_Privilege.SE_RESTORE_NAME, false);
                _privilegeManager.SetPrivilege(WinRegistryBinUserAll_Privilege.SE_BACKUP_NAME, false);
              //  MessageBox.Show("Configuração aplicada a todos os usuários com sucesso.", "Concluído", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ConfigureExistingUserProfiles(int ValueUniProgressBar)
        {
            // Obtém o Security Identifier (SID) do usuário que está executando o script, para evitar tentar carregar e modificar seu próprio perfil de registro.
            string currentUserSid = WindowsIdentity.GetCurrent().User.Value;

            using (RegistryKey? profileListKey = Registry.LocalMachine.OpenSubKey(PROFILE_LIST_PATH))
            {
                if (profileListKey == null) return;

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
                        // Mota o caminho do arvido NTUSER.DAT do usuario selecionado
                        ntUserDatPath = Path.Combine(ntUserDatPath, "NTUSER.DAT");

                        // Verifia se arquivo NTUSER.DAT existe
                        if (!File.Exists(ntUserDatPath)) continue;

                        // 5. Usa a instância do HiveLoader para carregar
                        _hiveLoader.LoadHive(tempHiveName, ntUserDatPath);


                        // 6. Aplica as configurações
                        RegistryBin_UserAll.Delete(tempHiveName, usuario);
                    }
                    catch (Exception ex)
                    {
                        WinGlobal_UIService.Instance.Log_MensagemAsync($"Registro do Usuario - Ocorreu um Erro ao tentar acessar registro do  SID {sid}", true);
                        WinGlobal_UIService.Instance.Erro++;
                    }
                    finally
                    {
                        // 7. Usa a instância do HiveLoader para descarregar
                        _hiveLoader.UnloadHive(tempHiveName);
                    }
                }
            }

            WinGlobal_UIService.Instance.ProgressBarADD(ValueUniProgressBar);
        }







        // Faz as auteracoes no registro 
        private void ApplySettingsToUserHive(string tempHiveName)
        {
            // O código desta função permanece o mesmo, usando Registry.Users.CreateSubKey
            // Desativa a Pesquisa (0: Ocultar)
            string searchKeyPath = @$"{tempHiveName}\Software\Microsoft\Windows\CurrentVersion\Search";
            using (RegistryKey? searchKey = Registry.Users.CreateSubKey(searchKeyPath))
            {
                searchKey?.SetValue("SearchboxTaskbarMode", 0, RegistryValueKind.DWord);
                searchKey?.SetValue("SearchboxTaskbarModeCache", 0, RegistryValueKind.DWord);
            }

            // Removendo ícone Saiba mais sobre esta imagem da Área de Trabalho
            string NewStartPanelKeyPath = @$"{tempHiveName}\Software\Microsoft\Windows\CurrentVersion\Explorer\HideDesktopIcons\NewStartPanel";
            using (RegistryKey? NewStartPaneKey = Registry.Users.CreateSubKey(NewStartPanelKeyPath))
            {
                NewStartPaneKey?.SetValue("{2cc5ca98-6485-489a-920e-b3e88a6ccce3}", 1, RegistryValueKind.DWord);
            }

            // Desativa o Botão de Visão de Tarefas
            string TaskViewButtonPath = @$"{tempHiveName}\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced";
            using (RegistryKey? TaskViewButtonKey = Registry.Users.CreateSubKey(TaskViewButtonPath))
            {
                TaskViewButtonKey?.SetValue("ShowTaskViewButton", 0, RegistryValueKind.DWord);
            }
        }
    }
}
