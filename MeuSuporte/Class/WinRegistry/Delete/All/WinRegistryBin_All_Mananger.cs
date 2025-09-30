using System.Threading.Tasks;

namespace MeuSuporte
{
    internal class WinRegistryBin_All_Mananger
    {
        private WinRegistryBin_WOW6432Node RegistryBin_WOW6432Node;
        private WinRegistryBin_MACHINE RegistryBin_MACHINE;
        private WinRegistryBin_UserSingle RegistryBin_UserSingle;
        private WinRegistryBin_UserAll RegistryBin_UserAll;

        public async Task Delete()
        {
            RegistryBin_WOW6432Node = new WinRegistryBin_WOW6432Node();
            RegistryBin_MACHINE = new WinRegistryBin_MACHINE();
            RegistryBin_UserSingle = new WinRegistryBin_UserSingle();
            RegistryBin_UserAll = new WinRegistryBin_UserAll();


            await Task.WhenAll(
                RegistryBin_WOW6432Node.Delete(WinGlobal_UIService.Instance.ValueUniProgressBar / 4),
                RegistryBin_MACHINE.Delete(WinGlobal_UIService.Instance.ValueUniProgressBar / 4),
                RegistryBin_UserSingle.Delete(WinGlobal_UIService.Instance.ValueUniProgressBar / 4),
                RegistryBin_UserAll.Delete(WinGlobal_UIService.Instance.ValueUniProgressBar / 4)
            );
        }

    }
}
