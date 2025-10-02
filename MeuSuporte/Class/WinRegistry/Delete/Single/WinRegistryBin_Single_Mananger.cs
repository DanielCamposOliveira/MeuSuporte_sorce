using System.Threading.Tasks;

namespace MeuSuporte
{
    internal class WinRegistryBin_Single_Mananger
    {
        /// <summary>
        /// Class responsavel por chamar as class de exclusao da chaves de registro
        /// </summary>
        private WinRegistryBin_WOW6432Node RegistryBin_WOW6432Node;
        private WinRegistryBin_MACHINE RegistryBin_MACHINE;
        private WinRegistryBin_UserSingle RegistryBin_UserSingle;

        public WinRegistryBin_Single_Mananger()
        {
            RegistryBin_WOW6432Node = new WinRegistryBin_WOW6432Node();
            RegistryBin_MACHINE = new WinRegistryBin_MACHINE();
            RegistryBin_UserSingle = new WinRegistryBin_UserSingle();
        }
        public async Task Delete()
        {
            await Task.WhenAll(
                RegistryBin_WOW6432Node.Delete(WinGlobal_UIService.Instance.ValueUniProgressBar / 3),
                RegistryBin_MACHINE.Delete(WinGlobal_UIService.Instance.ValueUniProgressBar / 3),
                RegistryBin_UserSingle.Delete(WinGlobal_UIService.Instance.ValueUniProgressBar / 3)
            );
        }
    }
}
