using System.Security.AccessControl;
using System;
using System.Threading.Tasks;

namespace MeuSuporte
{
    internal class WinDeleteReportError_Recycle
    {
        private WinGlobal_DirectoryMananger DirectoryManange;
        private WinDirectory_Security WinDirectory_FileSecurity;
        private FileSecurity _FileSecurity = new FileSecurity();
        private DirectorySecurity _DirectorySecurity = new DirectorySecurity();
        private WinDirectory_ListFiles ListFiles;

        public async Task Clean( string Path, string NameFolder, string TypeReport, int ValueUniProgressBar)
        {
            DirectoryManange = new WinGlobal_DirectoryMananger();
            WinDirectory_FileSecurity = new WinDirectory_Security();
            ListFiles = new WinDirectory_ListFiles();

            // verifica se diretorio existe
            if (!DirectoryManange.Check(Path))
            {
                WinGlobal_UIService.Instance.Erro++;
                await WinGlobal_UIService.Instance.Log_MensagemAsync($"Ocorreu um erro ao tentar acessa o diretório {NameFolder}", true);
                return;
            }

            // verifica se o diretorio dos relatorios esta vazio
            if (!DirectoryManange.GetFileListing(Path))
            {
                await WinGlobal_UIService.Instance.Log_MensagemAsync($"Limpar Relatório de Erro Windows: Não existe {TypeReport} para Limpar", true);
                return;
            }

            // atribui as permissões de segurança
            if (await WinDirectory_FileSecurity.SecurityAsync(_FileSecurity, _DirectorySecurity, Environment.UserName.ToString()) == false)
            {
                WinGlobal_UIService.Instance.Erro++;
                await WinGlobal_UIService.Instance.Log_MensagemAsync("Erro ao fazer atribuição de Segurança nos Arquivos", true);
                return;
            }

            // funcao de apagar os arquivos
            await ListFiles.Remove(ValueUniProgressBar, Path, NameFolder);
            await WinGlobal_UIService.Instance.Log_MensagemAsync("\r\n", true);          
        }
    }
}
