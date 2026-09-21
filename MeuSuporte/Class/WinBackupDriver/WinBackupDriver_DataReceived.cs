using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MeuSuporte
{
    internal class WinBackupDriver_DataReceived
    {
        private  WinBackupDriver_ExtractData ExtractProgress;

        //Trata a saida do Processo
        public async Task Received(Process process)
        {
            ExtractProgress = new WinBackupDriver_ExtractData();

            process.OutputDataReceived += async (sender, e) =>
            {
                if (!string.IsNullOrEmpty(e.Data))
                {
                    await ExtractProgress.DriverBackup_ExtractProgress(e.Data);
                }
            };

            process.ErrorDataReceived += (sender, e) =>
            {
                if (!string.IsNullOrEmpty(e.Data))
                {
                    WinGlobal_UIService.Instance.Erro++;
                    Task task = WinGlobal_UIService.Instance.AddMessage("Erro DISM: " + e.Data);
                }
            };
        }

    }
}
