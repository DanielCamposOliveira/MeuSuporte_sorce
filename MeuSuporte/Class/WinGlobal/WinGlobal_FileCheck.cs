using System.IO;

namespace MeuSuporte
{
    internal class WinGlobal_FileCheck
    {
        public bool Check(string Path)
        {
            return File.Exists(Path);
        }
    }
}
