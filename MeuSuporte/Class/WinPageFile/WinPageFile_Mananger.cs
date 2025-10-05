using System.Threading.Tasks;

namespace MeuSuporte
{
    internal class WinPageFile_Mananger
    {
        private readonly WinPageFile_KeyRegistry KeyRegistry;
              
        public WinPageFile_Mananger()
        {
            KeyRegistry = new WinPageFile_KeyRegistry();
        }

        public async Task Mananger(bool state)
        {            
            KeyRegistry.State(state, WinGlobal_UIService.Instance.ValueUniProgressBar);       
        }
    }
}
