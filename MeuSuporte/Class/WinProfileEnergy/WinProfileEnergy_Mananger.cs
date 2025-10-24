using System.Threading.Tasks;

namespace MeuSuporte
{
    internal class WinProfileEnergy_Mananger
    {
        WinProfileEnergy_State Energy_State;
        public WinProfileEnergy_Mananger() 
        {
            Energy_State = new WinProfileEnergy_State();
        }

        public async Task Mananger(int option)
        {
            await Energy_State.State(option);
        }       
    }
}
