using System.Threading.Tasks;

namespace MeuSuporte
{
    internal class WinCleanTemp_UserSingle
    {
        private WinDirectory_ListFiles Directory_ListFiles;
        WinCleanTemp_ProfilePathSingle ProfilePathSingle;
        private WinDirectory_AssignsPathPermission AssignsPathPermission;

        public WinCleanTemp_UserSingle()
        {
            ProfilePathSingle = new WinCleanTemp_ProfilePathSingle();
            Directory_ListFiles = new WinDirectory_ListFiles();
            AssignsPathPermission = new WinDirectory_AssignsPathPermission();
        }

        public async Task Clear()
        {
            WinGlobal_UIService.Instance.token.ThrowIfCancellationRequested(); // Checa se o cancelamento foi solicitado antes de começar

            string profilePath;
            profilePath = await ProfilePathSingle.GetUserProfilePathsAsync();

            //validar que a string realmente é utilizável
            if (string.IsNullOrWhiteSpace(profilePath))
            {
                return;
            }

            // atribui as permissões de segurança
            if (!await AssignsPathPermission.AssignsPermission(profilePath))
            {
                return;
            }

            // funcao de apagar os arquivos
            // await ListFiles.Remove(ValueUniProgressBar, DirectoryFolder, _NameFolder);
            await Directory_ListFiles.Remove(WinGlobal_UIService.Instance.ValueUniProgressBar, profilePath, "%Temp%");

            //  await WinGlobal_UIService.Instance.Log_MensagemAsync("\r\n", true);
            //  await WinGlobal_UIService.Instance.Log_MensagemAsync($"{applicant}: Limpeza da pasta {_NameFolder} : {ListFiles.countFoldersDeleted} Pasta(s) Apagada(s) e {ListFiles.countFileDeleted} Arquivo(s) Apagado(s)", false);

        }
    }
}
