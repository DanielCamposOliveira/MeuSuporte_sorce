using Microsoft.Win32;
using System.Threading.Tasks;

namespace MeuSuporte
{
    /// <summary>
    /// Class responsavel por verificar se OneDrive esta logado atraves chaves de registro
    /// </summary>
    internal class WinRegistryBin_IsOneDriveSignedIn
    {
        public async Task<bool> IsConnected(RegistryKey registro)
        {
            if (registro == null)
                return false;

            foreach (var subName in registro.GetSubKeyNames())
            {
                using (var sub = registro.OpenSubKey(subName))
                {
                    if (sub == null) continue;
                    
                    var email = sub.GetValue("UserEmail") as string;
                    if (!string.IsNullOrEmpty(email))
                        return true;                    
                }
            }
            return false;
        }
    }
}
