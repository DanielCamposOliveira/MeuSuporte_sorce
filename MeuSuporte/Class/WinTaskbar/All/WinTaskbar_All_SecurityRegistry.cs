using System.Threading.Tasks;

namespace MeuSuporte
{
    //  - 1
    /// <summary>
    /// Class responsavel por atribuir a segurança no processo de leitura do arquivo Regedit
    /// </summary>

    internal class WinTaskbar_All_SecurityRegistry
    {
        private readonly WinTaskbar_Privilege _privilegeManager;
        private readonly WinTaskbar_HiveLoader _hiveLoader;
        private readonly WinTaskbar_All_ProfileList Taskbar_All_ProfileList;

        public WinTaskbar_All_SecurityRegistry()
        {
            _privilegeManager = new WinTaskbar_Privilege();
            _hiveLoader = new WinTaskbar_HiveLoader();
            // 2. Instanciar a nova classe, INJETANDO as dependências necessárias
            Taskbar_All_ProfileList = new WinTaskbar_All_ProfileList(_hiveLoader);
        }

        public async Task Changes(bool state, int ValueUniProgressBar)
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
                await Taskbar_All_ProfileList.ProfilesMananger(state, ValueUniProgressBar);
            }
            finally
            {
                // 4. Desabilita os privilégios no final
                _privilegeManager.SetPrivilege(WinRegistryBinUserAll_Privilege.SE_RESTORE_NAME, false);
                _privilegeManager.SetPrivilege(WinRegistryBinUserAll_Privilege.SE_BACKUP_NAME, false);
                //  MessageBox.Show("Configuração aplicada a todos os usuários com sucesso.", "Concluído", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}
