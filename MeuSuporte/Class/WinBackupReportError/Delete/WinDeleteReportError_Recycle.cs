using System.Threading.Tasks;

namespace MeuSuporte
{
    internal class WinDeleteReportError_Recycle
    {
        private WinGlobal_DirectoryMananger DirectoryManange;
        private WinDirectory_AssignsPathPermission AssignsPathPermission;
        private WinDirectory_ListFiles ListFiles;

        public WinDeleteReportError_Recycle()
        {
            DirectoryManange = new WinGlobal_DirectoryMananger();
            AssignsPathPermission = new WinDirectory_AssignsPathPermission();
            ListFiles = new WinDirectory_ListFiles();
        }

        public async Task Clean( string Path, string NameFolder, string TypeReport, int ValueUniProgressBar)
        {
            await WinGlobal_UIService.Instance.AddMessage("Clean Report Error: verificando...");
            // verifica se diretorio existe
            if (!DirectoryManange.Check(Path))
            {
                WinGlobal_UIService.Instance.Erro++;
                await WinGlobal_UIService.Instance.AddMessage($"Clean Report Error: Ocorreu um erro ao tentar acessa o diretório {NameFolder}");
                return;
            }

            // verifica se o diretorio dos relatorios esta vazio
            if (!DirectoryManange.GetFileListing(Path))
            {
                await WinGlobal_UIService.Instance.AddMessage($"Clean Report Error: Não existe {TypeReport} para Limpar");
                return;
            }

            // atribui as permissões de segurança
            if (!await AssignsPathPermission.AssignsPermission(Path))
            {
                WinGlobal_UIService.Instance.Erro++;
                await WinGlobal_UIService.Instance.AddMessage("Clean Report Error: Ocorreu um Erro ao tentar atribuir de Segurança nos Arquivos");
                return;
            }

            // funcao de apagar os arquivos
            await ListFiles.Remove(ValueUniProgressBar, Path, NameFolder);
            
        }
    }
}
