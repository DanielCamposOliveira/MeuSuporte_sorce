using System.Threading.Tasks;

namespace MeuSuporte
{
    internal class WinCleanTemp_UserSingle
    {
        private WinDirectory_ListFiles Directory_ListFiles;
        private WinCleanTemp_ProfilePathSingle ProfilePathSingle;
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

            await WinGlobal_UIService.Instance.AddMessage($"Clean Temp: limpando diretorio: {profilePath}");
            await WinGlobal_UIService.Instance.AddMessage("");
            await Task.Delay(500);


            // funcao de apagar os arquivos
            await Directory_ListFiles.Remove(WinGlobal_UIService.Instance.ValueUniProgressBar, profilePath, "%Temp%");

        }
    }
}
