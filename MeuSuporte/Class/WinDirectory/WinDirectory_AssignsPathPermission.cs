using System;
using System.Threading.Tasks;

namespace MeuSuporte
{
    internal class WinDirectory_AssignsPathPermission
    {
        WinDirectory_Security Directory_Security;
        public async Task<bool> AssignsPermission(string tempPath)
        {
            Directory_Security = new WinDirectory_Security();

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
