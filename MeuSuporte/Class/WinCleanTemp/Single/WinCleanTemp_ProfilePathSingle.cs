using System;
using System.IO;
using System.Threading.Tasks;

namespace MeuSuporte
{
    internal class WinCleanTemp_ProfilePathSingle
    {
        public async Task<string> GetUserProfilePathsAsync()
        {
            string usersFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile); // C:\Users\Usuario  
            string tempPath = Path.Combine(usersFolderPath, "AppData", "Local", "Temp");
            return tempPath;
        }
    }
}
