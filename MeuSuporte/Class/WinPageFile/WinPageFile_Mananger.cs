using System.Threading.Tasks;

namespace MeuSuporte
{
    internal class WinPageFile_Mananger
    {
        private  WinPageFile_KeyRegistry KeyRegistry;
                        
        public async Task Mananger(bool state)
        {
            KeyRegistry = new WinPageFile_KeyRegistry();
            KeyRegistry.State(state, WinGlobal_UIService.Instance.ValueUniProgressBar);       
        }
    }
}
