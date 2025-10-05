using System.IO;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace MeuSuporte
{
    internal class WinDirectory_Folder
    {
        private readonly DirectorySecurity _DirectorySecurity = new DirectorySecurity();
        private DirectoryInfo folder;
        
        public async Task<bool> Delete(string txt ) // deleta o arquivo de forma assíncrona
        {
            folder = new System.IO.DirectoryInfo(txt); // atribui a pasta
            folder.SetAccessControl(_DirectorySecurity); // atribui o acesso para a pasta

            try
            {
                WinGlobal_UIService.Instance.token.ThrowIfCancellationRequested(); // Checa se o cancelamento foi solicitado antes de começar
                folder.Delete(true); // deleta a pasta
                return true;
            }
            catch
            {
                // silenciar os erros
            }

            return false;
        }

    }
}
