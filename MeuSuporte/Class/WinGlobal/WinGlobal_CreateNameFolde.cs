using System;
using System.IO;

namespace MeuSuporte
{
    internal class WinGlobal_CreateNameFolde
    {
        private readonly WinGlobal_ValidNameFolde ValidNameFolde;

        public WinGlobal_CreateNameFolde()
        {
            ValidNameFolde = new WinGlobal_ValidNameFolde();
        }

        public string Folder(string NameFolder)
        {
            string _Directory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + $@"Preventiva {DateTime.Now.ToString("dd-MM-yyyy")}");

            string Nome = Environment.MachineName;
            if (!ValidNameFolde.Valid(Nome))
            {
                Nome = "Desktop";     //Nome de pasta inválido para os padroes de pasta do Windows
            }

            _Directory += @"\" + Nome + @"\" + NameFolder;    //Cria a pasta com o nome do computador

            return _Directory;
        }
    }
}
