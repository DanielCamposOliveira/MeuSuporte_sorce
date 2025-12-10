using System.Threading.Tasks;

namespace MeuSuporte
{
    internal class WinTaskbar_All_Security
    {
        private readonly WinGlobal_Registre_Privilege _privilegeManager;

        public WinTaskbar_All_Security()
        {
            _privilegeManager = new WinGlobal_Registre_Privilege();
        }
        public async Task<bool> Privilege(bool state)
        {
            try
            {
                // Habilitar o privilégio 'SeRestorePrivilege', necessário para carregar hives (perfis) de registro de outros usuários.
                bool restoreEnabled = _privilegeManager.SetPrivilege(WinGlobal_Registre_Privilege.SE_RESTORE_NAME, state);
                // Habilitar o privilégio 'SeBackupPrivilege', geralmente necessário em conjunto com o Restore para manipulação de arquivos de sistema como NTUSER.DAT.
                bool backupEnabled = _privilegeManager.SetPrivilege(WinGlobal_Registre_Privilege.SE_BACKUP_NAME, state);
                
                if (restoreEnabled || backupEnabled)
                {
                    return true;
                }

                return true;
            }
            catch 
            {
                return false;
            }

        }
    }
}
