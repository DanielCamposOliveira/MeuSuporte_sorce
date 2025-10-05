using System;
using System.Threading.Tasks;

namespace MeuSuporte
{
    internal class WinDirectory_AssignsPathPermission
    {
       private readonly WinDirectory_Security Directory_Security;
        public WinDirectory_AssignsPathPermission()
        {
            Directory_Security = new WinDirectory_Security();
        }

        public async Task<bool> AssignsPermission(string tempPath)
        {
            try
            {
                bool success = Directory_Security.ForceFolderSecurity(tempPath);

                if (!success)
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
