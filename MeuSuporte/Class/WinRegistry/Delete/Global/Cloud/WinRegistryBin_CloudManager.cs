using Microsoft.Win32;
using System.Threading.Tasks;

namespace MeuSuporte
{
    /// <summary>
    /// Class responsavel por verificar se os Apps de Cloud esta logado no Usuario
    /// </summary>
    internal class WinRegistryBin_CloudManager
    {
        WinRegistryBin_IsOneDriveSignedIn IsOneDriveSignedIn;
        WinRegistryBin_IsGoogleDriveLoggedIn IsGoogleDriveLoggedIn;

        public WinRegistryBin_CloudManager() 
        {
            IsOneDriveSignedIn = new WinRegistryBin_IsOneDriveSignedIn();
            IsGoogleDriveLoggedIn = new WinRegistryBin_IsGoogleDriveLoggedIn();
        }

        public async Task<bool> GetOneDrive(RegistryKey registro)
        {
            return await IsOneDriveSignedIn.IsConnected(registro);
        }

        public async Task<bool> GetGoogleDrive(string localAppDataPath)
        {
            return await IsGoogleDriveLoggedIn.IsConnected(localAppDataPath);
        }
    }
}
