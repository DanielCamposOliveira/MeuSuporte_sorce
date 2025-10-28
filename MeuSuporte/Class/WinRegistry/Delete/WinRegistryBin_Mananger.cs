using System.Threading.Tasks;

namespace MeuSuporte
{
    internal class WinRegistryBin_Mananger
    {
        private WinRegistryBin_Single_Mananger Single_Mananger;
        private WinRegistryBin_All_Mananger All_Mananger;
        private WinRegistryBin_MACHINE_Mananger MACHINE_Mananger;
            
        public WinRegistryBin_Mananger()
        {           
            Single_Mananger = new WinRegistryBin_Single_Mananger();
            MACHINE_Mananger = new WinRegistryBin_MACHINE_Mananger();
            All_Mananger = new WinRegistryBin_All_Mananger();
        }
        public async Task Mananger(bool isAll)
        {
            if (isAll)
            {
                await MACHINE_Mananger.Mananger(WinGlobal_UIService.Instance.ValueUniProgressBar / 3);
                await Single_Mananger.Mananger(WinGlobal_UIService.Instance.ValueUniProgressBar / 3);

                await All_Mananger.Mananger(WinGlobal_UIService.Instance.ValueUniProgressBar / 3);
            }
            else
            {
                await MACHINE_Mananger.Mananger(WinGlobal_UIService.Instance.ValueUniProgressBar / 2);
                await Single_Mananger.Mananger(WinGlobal_UIService.Instance.ValueUniProgressBar / 2);
            }
        }

    }
}
