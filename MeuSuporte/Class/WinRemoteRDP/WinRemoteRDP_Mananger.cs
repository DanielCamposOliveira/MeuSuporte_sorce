using System.Threading.Tasks;

namespace MeuSuporte
{
    internal class WinRemoteRDP_Mananger
    {
        private  WinRemoteRDP_Disable RemoteRDP_Disable;
        private  WinRemoteRDP_Enable RemoteRDP_Enable;

        public WinRemoteRDP_Mananger()
        {
            RemoteRDP_Enable = new WinRemoteRDP_Enable();
            RemoteRDP_Disable = new WinRemoteRDP_Disable();
        }

        public async Task Mananger(bool state)
        {   
            await WinGlobal_UIService.Instance.ProgressBarADD(WinGlobal_UIService.Instance.ValueUniProgressBar / 2);

            if (state)
            {
                await RemoteRDP_Enable.Enable();
            }
            else
            {
                await RemoteRDP_Disable.Disable();
            }

            await WinGlobal_UIService.Instance.ProgressBarADD(WinGlobal_UIService.Instance.ValueUniProgressBar / 2);
        }

    }
}
