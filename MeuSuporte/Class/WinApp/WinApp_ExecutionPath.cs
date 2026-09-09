using System;
using System.IO;
using System.Reflection;

namespace MeuSuporte
{
    class WinApp_ExecutionPath
    { 
        public bool getDiscoverNetwork()
        {
            //string exePath = Assembly.GetExecutingAssembly().Location;      
            //string rootPath = Path.GetPathRoot(exePath);

            string appPath = Environment.ProcessPath ?? AppContext.BaseDirectory;
            string root = Path.GetPathRoot(appPath);

            if (appPath.StartsWith(@"\\"))
            {
                return true; // Executado a partir pasta compartilhamentos de rede (\\servidor\pasta\)             
            }

            DriveInfo drive = new DriveInfo(root);
            if (drive.DriveType == DriveType.Network)
            {
                return true; // Executado a partir de um Drive de rede ex. Z:\
            }

            return false;
        }
    }
}
