using System.Threading.Tasks;

namespace MeuSuporte
{
    internal class WinDeleteReportError_Mananger
    {
        private string ApplicationReportError = @"C:\ProgramData\Microsoft\Windows\WER\ReportQueue\"; //Relatório de Sistema
        private string SystemReportError = @"C:\ProgramData\Microsoft\Windows\WER\ReportArchive\";  //Relatório de Aplicacao
       
        private WinDeleteReportError_Recycle DeleteReportError_Recycle;
        

        public async Task Mananger()
        {
            DeleteReportError_Recycle = new WinDeleteReportError_Recycle();
            
            await DeleteReportError_Recycle.Clean(ApplicationReportError, "ReportQueue", "Relatório de Sistema", WinGlobal_UIService.Instance.ValueUniProgressBar / 2);
            await Task.Delay(500);
            await DeleteReportError_Recycle.Clean(SystemReportError, "ReportArchive", "Relatório de Aplicação", WinGlobal_UIService.Instance.ValueUniProgressBar / 2);
        }
    }
}
