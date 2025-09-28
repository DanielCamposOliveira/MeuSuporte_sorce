using System;
using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Threading.Tasks;

namespace MeuSuporte
{
    internal class WinDirectory_Security
    {
        public async Task<bool> SecurityAsync(FileSecurity fileSecurity, DirectorySecurity directorySecurity, string User) // atribui as permissões de segurança
        {
            bool retorno = false;

            try
            {
                directorySecurity.AddAccessRule(new FileSystemAccessRule(User, FileSystemRights.Modify, AccessControlType.Allow));
                directorySecurity.SetAccessRuleProtection(false, false);
                directorySecurity.AddAccessRule(new FileSystemAccessRule(User, FileSystemRights.Modify, AccessControlType.Allow));
                directorySecurity.SetAccessRuleProtection(false, false);
                retorno = true;
            }
            catch (Exception e)
            {
                retorno = false;
            }
            return retorno;
        }





        public bool ForceFolderSecurity(string folderPath)
        {
            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(folderPath);
                DirectorySecurity dSecurity = dirInfo.GetAccessControl();

                // 1. Tomar Posse (Take Ownership)
                // Define o grupo "Administradores" como o novo dono.
                var adminSid = new SecurityIdentifier(WellKnownSidType.BuiltinAdministratorsSid, null);
                dSecurity.SetOwner(adminSid);
                dirInfo.SetAccessControl(dSecurity);

                // 2. Conceder Controle Total (Grant Full Control)
                // Recarrega as permissões após a mudança de dono.
                dSecurity = dirInfo.GetAccessControl();
                var fullControlRule = new FileSystemAccessRule(adminSid,
                                                               FileSystemRights.FullControl,
                                                               InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit,
                                                               PropagationFlags.None,
                                                               AccessControlType.Allow);
                dSecurity.AddAccessRule(fullControlRule);
                dirInfo.SetAccessControl(dSecurity);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }






















    }
}
