using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MeuSuporte
{    
     /// <summary>
     /// Class responsavel por verificar se Google Driver esta logado atraves do diretorio
     /// </summary>

    internal class WinRegistryBin_IsGoogleDriveLoggedIn
    {
        WinGlobal_DirectoryCheck DirectoryCheck;
        public WinRegistryBin_IsGoogleDriveLoggedIn()
        {
            DirectoryCheck = new WinGlobal_DirectoryCheck();
        }
        public async Task<bool> IsConnected(string Local)
        {
            string basePath = Path.Combine(Local, "Google", "DriveFS");

            if(!DirectoryCheck.Check(basePath))
            {
                return false;
            }
       
            // Procura pastas que são só números (IDs de conta)
            var dirs = Directory.GetDirectories(basePath)
                                .Select(Path.GetFileName)
                                .Where(name => Regex.IsMatch(name ?? "", @"^\d+$"))
                                .ToList();

            if (dirs.Any())
            {
                return true;
            }

            return false;
        }
    }
}
