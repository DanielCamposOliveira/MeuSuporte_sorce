using System;
using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;

namespace MeuSuporte
{
    internal class WinDirectory_Security
    {
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
