using System.IO;
using System.Security.AccessControl;
using System.Threading;
using System.Threading.Tasks;

namespace MeuSuporte
{
    internal class WinDirectory_File
    {
        private readonly FileSecurity _FileSecurity = new FileSecurity();
        private FileInfo file;

        public async Task<bool> Delete(string txt) // deleta o arquivo de forma assíncrona
        {
            file = new FileInfo(txt); // atribui o arquivo
            file.SetAccessControl(_FileSecurity); // atribui o acesso

            try
            {
                var file = new FileInfo(txt);

                if (file.Exists)
                {
                    WinGlobal_UIService.Instance.token.ThrowIfCancellationRequested(); // Checa se o cancelamento foi solicitado antes de começar
                    file.Delete(); // deleta o arquivo
                    return true;
                }
            }
            catch
            {
                // silenciar os erros
            }

            return false;
        }
    }
}
