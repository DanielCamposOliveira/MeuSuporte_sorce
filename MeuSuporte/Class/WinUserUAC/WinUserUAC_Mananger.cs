using System.Threading.Tasks;

namespace MeuSuporte
{
    class WinUserUAC_Mananger
    {
        private  WinUserUAC_State UAC_State;
     
        public WinUserUAC_Mananger()
        {
            UAC_State = new WinUserUAC_State();
        }
        public async Task Mananger(bool State)
        {           
            await UAC_State.Notification(State, WinGlobal_UIService.Instance.ValueUniProgressBar);
        }
    }
}
