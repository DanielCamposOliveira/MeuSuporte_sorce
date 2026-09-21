using System.Threading.Tasks;

namespace MeuSuporte
{
    internal class WinDirectory_Mananger
    {
        private  WinDirectory_ListFiles ListFiles;
        private  WinGlobal_DirectoryMananger DirectoryManange;
        private WinDirectory_AssignsPathPermission AssignsPathPermission;

        public WinDirectory_Mananger()
        {
            ListFiles = new WinDirectory_ListFiles();
            DirectoryManange = new WinGlobal_DirectoryMananger();
            AssignsPathPermission = new WinDirectory_AssignsPathPermission();
        }

        public async Task Mananger(string applicant, string DirectoryFolder, string _NameFolder, int ValueUniProgressBar ) // Método principal assíncrono
        {
            // verifica se diretorio existe
            if (!DirectoryManange.Check(DirectoryFolder))
            {
                WinGlobal_UIService.Instance.Erro++;    
                await WinGlobal_UIService.Instance.AddMessage($"{applicant}: Ocorreu um erro ao tentar acessa o diretório {_NameFolder}");
                return;
            }       

            // atribui as permissões de segurança
            if (!await AssignsPathPermission.AssignsPermission(DirectoryFolder))
            {
                WinGlobal_UIService.Instance.Erro++;
                await WinGlobal_UIService.Instance.AddMessage($"{applicant}: Ocorreu um Erro ao tentar atribuir de Segurança nos Arquivos");
                return;
            }       

            // funcao de apagar os arquivos
            await ListFiles.Remove(ValueUniProgressBar, DirectoryFolder, _NameFolder);  
            await WinGlobal_UIService.Instance.AddUpdatedMessage($"{applicant}: Limpeza da pasta {_NameFolder} : {ListFiles.countFoldersDeleted} Pasta(s) Apagada(s) e {ListFiles.countFileDeleted} Arquivo(s) Apagado(s)");          
        }
    }
}
