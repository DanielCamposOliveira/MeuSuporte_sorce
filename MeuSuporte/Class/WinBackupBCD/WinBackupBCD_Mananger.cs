using System.Threading;
using System.Threading.Tasks;

namespace MeuSuporte
{
    internal class WinBackupBCD_Mananger
    {
        private readonly  WinBackupBCD_ProcessController ProcessController;

        public WinBackupBCD_Mananger()
        {
            ProcessController = new WinBackupBCD_ProcessController();
        }
        public async Task Mananger()
        {
            await ProcessController.Create(WinGlobal_UIService.Instance.ValueUniProgressBar);
        }       
    }  
    
}
