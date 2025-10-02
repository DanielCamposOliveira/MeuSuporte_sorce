using System.Threading.Tasks;

namespace MeuSuporte
{
    internal class WinRegistryBackup_All_SecurityRegistry
    {
        //  - 2
        /// <summary>
        /// Class responsavel por atribuir a segurança no processo de leitura do arquivo Regedit
        /// </summary>

        private readonly WinRegistryBackup_All_Privilege _privilegeManager;
        private readonly WinRegistryBackup_All_HiveLoader _hiveLoader;
        private readonly WinRegistryBackup_All_ProfileList RegistryBackup_All_ProfileList;

        public WinRegistryBackup_All_SecurityRegistry()
        {
            _privilegeManager = new WinRegistryBackup_All_Privilege();
            _hiveLoader = new WinRegistryBackup_All_HiveLoader();

            // 2. Instanciar a nova classe, INJETANDO as dependências necessárias
            RegistryBackup_All_ProfileList = new WinRegistryBackup_All_ProfileList(_hiveLoader);
        }


        public async Task Backup(int ValueUniProgressBar)
        {
            // Habilitar os privilégios
            bool restoreEnabled = _privilegeManager.SetPrivilege(WinRegistryBinUserAll_Privilege.SE_RESTORE_NAME, true);
            bool backupEnabled = _privilegeManager.SetPrivilege(WinRegistryBinUserAll_Privilege.SE_BACKUP_NAME, true);

            if (!restoreEnabled || !backupEnabled)
            {
                return;
            }

            try
            {
                RegistryBackup_All_ProfileList.ProfilesMananger(ValueUniProgressBar);
            }
            finally
            {
                // Desabilitar os privilégios
                _privilegeManager.SetPrivilege(WinRegistryBinUserAll_Privilege.SE_RESTORE_NAME, false);
                _privilegeManager.SetPrivilege(WinRegistryBinUserAll_Privilege.SE_BACKUP_NAME, false);
            }
        }
    }
}
