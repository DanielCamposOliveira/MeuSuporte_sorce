using System.Security.Principal;

namespace MeuSuporte.Class.WinApp
{
    internal class EnsureAdministrator
    {
        public bool IsAdministrator()
        {
            using (WindowsIdentity identity = WindowsIdentity.GetCurrent())
            {
                WindowsPrincipal principal = new WindowsPrincipal(identity);
                bool isAdmin = principal.IsInRole(WindowsBuiltInRole.Administrator);

                if (!isAdmin)
                {
                    return false;
                }
                return true;
            }
        }
    }
}
