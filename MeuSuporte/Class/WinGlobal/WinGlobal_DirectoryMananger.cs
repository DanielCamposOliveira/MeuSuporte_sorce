using System.IO;

namespace MeuSuporte
{
    internal class WinGlobal_DirectoryMananger
    {
        private readonly WinGlobal_DirectoryCheck DirectoryCheck;
        private readonly WinGlobal_DirectoryCreate DirectoryCreate;
        private readonly WinGlobal_CreateNameFolde CreateNameFolde;

        public WinGlobal_DirectoryMananger()
        {
            DirectoryCreate = new WinGlobal_DirectoryCreate();
            CreateNameFolde = new WinGlobal_CreateNameFolde();
            DirectoryCheck = new WinGlobal_DirectoryCheck();
        }

        // verifica diretorio
        public bool Check(string Path)
        {
            return DirectoryCheck.Check(Path);
        }

        // cria diretorio
        public bool Create(string NameFolder)
        {
            return DirectoryCreate.Create(NameFolder); 
        }

        public string GetDirectory(string NameFolder)
        {
            return CreateNameFolde.Folder(NameFolder); ;
        }

        // verifica se existe arquivos dentro do diretorio
        public bool GetFileListing(string path)
        {
            return Directory.EnumerateFileSystemEntries(path).GetEnumerator().MoveNext() == true;
        }
    }
}
