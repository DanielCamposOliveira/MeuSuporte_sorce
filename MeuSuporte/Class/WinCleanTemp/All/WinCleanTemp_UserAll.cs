using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeuSuporte
{
    internal class WinCleanTemp_UserAll
    {
        private WinDirectory_ListFiles Directory_ListFiles;
        private WinCleanTemp_ProfilePathAll CleanTemp_ProfilePath;
        private WinDirectory_AssignsPathPermission AssignsPathPermission;

        public WinCleanTemp_UserAll()
        {
            CleanTemp_ProfilePath = new WinCleanTemp_ProfilePathAll();
            Directory_ListFiles = new WinDirectory_ListFiles();
            AssignsPathPermission = new WinDirectory_AssignsPathPermission();
        }

        public async Task Clear()
        {
            // Obtem a lista dos caminhos de perfis de todos os usuarios
            List<string> profilePaths = await CleanTemp_ProfilePath.GetUserProfilePathsAsync();

            if (profilePaths.Count == 0)
            {
                return;
            }

            int ValueUniProgressBar = WinGlobal_UIService.Instance.ValueUniProgressBar / profilePaths.Count;

            foreach (string path in profilePaths)
            {
                WinGlobal_UIService.Instance.token.ThrowIfCancellationRequested(); // Checa se o cancelamento foi solicitado antes de começar

                // atribui as permissões de segurança
                if (!await AssignsPathPermission.AssignsPermission(path))
                {
                    return;
                }

                // funcao de apagar os arquivos
                // await ListFiles.Remove(ValueUniProgressBar, DirectoryFolder, _NameFolder);
                
                await Directory_ListFiles.Remove(ValueUniProgressBar, path, "%Temp% Users");          
                //  await WinGlobal_UIService.Instance.Log_MensagemAsync("\r\n", true);
                //  await WinGlobal_UIService.Instance.Log_MensagemAsync($"{applicant}: Limpeza da pasta {_NameFolder} : {ListFiles.countFoldersDeleted} Pasta(s) Apagada(s) e {ListFiles.countFileDeleted} Arquivo(s) Apagado(s)", false);

            }            
        }
    }
}
