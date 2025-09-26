using System.Threading.Tasks;

namespace MeuSuporte
{
    internal class WinRegistryBin_Mananger
    {
        private  WinRegistryBin_WOW6432Node RegistryBin_WOW6432Node;
        private  WinRegistryBin_MACHINE RegistryBin_MACHINE;
        private  WinRegistryBin_User RegistryBin_User;

        public async Task DeleteRegistry()
        {
            RegistryBin_WOW6432Node = new WinRegistryBin_WOW6432Node();
            RegistryBin_MACHINE = new WinRegistryBin_MACHINE();
            RegistryBin_User = new WinRegistryBin_User();

            await Task.WhenAll(
                RegistryBin_WOW6432Node.Delete(WinGlobal_UIService.Instance.ValueUniProgressBar / 3),
                RegistryBin_MACHINE.Delete(WinGlobal_UIService.Instance.ValueUniProgressBar / 3),
                RegistryBin_User.Delete(WinGlobal_UIService.Instance.ValueUniProgressBar / 3)
            );
        }
    }
}
