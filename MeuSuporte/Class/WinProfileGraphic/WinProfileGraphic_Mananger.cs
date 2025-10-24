using MeuSuporte.Class.WinProfileGraphic;
using System.Threading.Tasks;

namespace MeuSuporte
{
    internal class WinProfileGraphic_Mananger
    {
        WinProfileGraphic_State Graphic_State;
        public WinProfileGraphic_Mananger() 
        {
            Graphic_State = new WinProfileGraphic_State();
        }
        public async Task Mananger(bool performance)
        {
            if(performance == true)
            {
                await Graphic_State.State(0,2, "Desempenho"); //MELHOR DESEMPENHO
            }
            else
            {
                await Graphic_State.State(1, 1, "Aparência"); //MELHOR APARÊNCIA
            }
        }
    }
}
