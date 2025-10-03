using System.Threading.Tasks;

namespace MeuSuporte
{
    /// <summary>
    /// Class responsavel por chamar as class de exclusao da chaves de registro
    /// </summary>
    /// 
    internal class WinRegistryBin_All_Mananger
    {
        private WinRegistryBin_WOW6432Node RegistryBin_WOW6432Node;
        private WinRegistryBin_MACHINE RegistryBin_MACHINE;
        private WinRegistryBin_UserSingle RegistryBin_UserSingle;
        private WinRegistryBin_All_SecurityRegistry RegistryBin_All_SecurityRegistry;

        public WinRegistryBin_All_Mananger()
        {
            RegistryBin_WOW6432Node = new WinRegistryBin_WOW6432Node();
            RegistryBin_MACHINE = new WinRegistryBin_MACHINE();
            RegistryBin_UserSingle = new WinRegistryBin_UserSingle();
            RegistryBin_All_SecurityRegistry = new WinRegistryBin_All_SecurityRegistry();
        }

        public async Task Delete()
        {
            await Task.WhenAll(
                RegistryBin_WOW6432Node.Delete(WinGlobal_UIService.Instance.ValueUniProgressBar / 4),
                RegistryBin_MACHINE.Delete(WinGlobal_UIService.Instance.ValueUniProgressBar / 4),
                RegistryBin_UserSingle.Delete(WinGlobal_UIService.Instance.ValueUniProgressBar / 4),
               RegistryBin_All_SecurityRegistry.Delete(WinGlobal_UIService.Instance.ValueUniProgressBar / 4)
            );
        }

    }
}
