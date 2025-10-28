using System.Threading.Tasks;

namespace MeuSuporte
{
    internal class WinTaskbar_Mananger
    {
        WinTaskbar_All_Mananger Taskbar_All_Mananger;
        WinTaskbar_Single_Mananger Taskbar_Single_Mananger;
        public WinTaskbar_Mananger()
        {
            Taskbar_All_Mananger = new WinTaskbar_All_Mananger();
            Taskbar_Single_Mananger = new WinTaskbar_Single_Mananger();
        }
        public async Task Mananger(bool State)
        {
            await Taskbar_Single_Mananger.Changes(State, WinGlobal_UIService.Instance.ValueUniProgressBar / 2);
            await  Taskbar_All_Mananger.Mananger(State, WinGlobal_UIService.Instance.ValueUniProgressBar / 2);

            await WinGlobal_UIService.Instance.Log_MensagemAsync("Optimiza Barra de Tarefas: Configurações Alteradas", true);
        }
    }
}
