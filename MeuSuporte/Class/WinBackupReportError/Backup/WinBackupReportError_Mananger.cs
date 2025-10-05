using System.Threading.Tasks;

namespace MeuSuporte
{
    internal class WinBackupReportError_Mananger
    {
        
        private WinBackupReportError_Processo BackupReportError_Processo;
        private string ApplicationReportError = @"C:\ProgramData\Microsoft\Windows\WER\ReportQueue\"; //Relatório de Sistema       
        private string SystemReportError = @"C:\ProgramData\Microsoft\Windows\WER\ReportArchive\";  //Relatório de Aplicacao

        public WinBackupReportError_Mananger()
        {
            BackupReportError_Processo = new WinBackupReportError_Processo();
        }
        public async Task Mananger()
        {
            await WinGlobal_UIService.Instance.ProgressBarADD(WinGlobal_UIService.Instance.ValueUniProgressBar / 2);
            await BackupReportError_Processo.backup(ApplicationReportError, "ReportQueue", "Relatório de Sistema");
            await Task.Delay(800);

            await WinGlobal_UIService.Instance.ProgressBarADD(WinGlobal_UIService.Instance.ValueUniProgressBar / 2);
            await BackupReportError_Processo.backup(SystemReportError, "ReportArchive", "Relatório de Aplicação");
            await Task.Delay(800);

        }
    }
}
