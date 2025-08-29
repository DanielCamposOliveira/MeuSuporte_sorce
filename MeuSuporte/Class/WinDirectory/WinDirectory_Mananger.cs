using System;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace MeuSuporte
{
    internal class WinDirectory_Mananger
    {
        private FileSecurity _FileSecurity = new FileSecurity();
        private DirectorySecurity _DirectorySecurity = new DirectorySecurity();

        private  WinDirectory_ListFiles ListFiles;
        private  WinDirectory_Security WinDirectory_FileSecurity;
        private  WinGlobal_DirectoryMananger DirectoryManange;
                  
        public async Task Mananger(string applicant, string DirectoryFolder, string _NameFolder, int ValueUniProgressBar ) // Método principal assíncrono
        {
            ListFiles = new WinDirectory_ListFiles();
            WinDirectory_FileSecurity = new WinDirectory_Security();
            DirectoryManange = new WinGlobal_DirectoryMananger();

            // verifica se diretorio existe
            if (!DirectoryManange.Check(DirectoryFolder))
            {
                WinGlobal_UIService.Instance.Erro++;    
                await WinGlobal_UIService.Instance.Log_MensagemAsync($"{applicant}: Ocorreu um erro ao tentar acessa o diretório {_NameFolder}", true);
                return;
            }

            // atribui as permissões de segurança
            if (await WinDirectory_FileSecurity.SecurityAsync(_FileSecurity, _DirectorySecurity, Environment.UserName.ToString()) == false)
            {
                WinGlobal_UIService.Instance.Erro++;
                await WinGlobal_UIService.Instance.Log_MensagemAsync($"{applicant}: Ocorreu um Erro ao tentar atribuir de Segurança nos Arquivos", true);
                return;
            }

            // funcao de apagar os arquivos
            await ListFiles.Remove(ValueUniProgressBar, DirectoryFolder, _NameFolder);          
            await WinGlobal_UIService.Instance.Log_MensagemAsync("\r\n", true);           
            await WinGlobal_UIService.Instance.Log_MensagemAsync($"{applicant}: Limpeza da pasta {_NameFolder} : {ListFiles.countFoldersDeleted} Pasta(s) Apagada(s) e {ListFiles.countFileDeleted} Arquivo(s) Apagado(s)", false);          
        }

    }
}
