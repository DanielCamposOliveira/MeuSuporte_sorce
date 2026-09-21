using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MeuSuporte
{
    internal class WinBackupBCD_ProcessController
    {
        private readonly  WinGlobal_DirectoryMananger DirectoryManange;
        private readonly  WinBackupBCD_ProcessInfo BCD_ProcessInfo;

        public WinBackupBCD_ProcessController()
        {
            DirectoryManange = new WinGlobal_DirectoryMananger();
            BCD_ProcessInfo = new WinBackupBCD_ProcessInfo();
        }

        public async Task Create(int ValueUniProgressBar)
        {
            string NameFolder = "BCD_Backup";

            try
            {
                WinGlobal_UIService.Instance.token.ThrowIfCancellationRequested(); // Checa se o cancelamento foi solicitado antes de começar

                // Cria o diretorio
                if (DirectoryManange.Create(NameFolder) == false)
                {
                    await WinGlobal_UIService.Instance.AddMessage($"Backup BCD: Ocorreu um erro ao tentar criar Pasta {NameFolder}");
                    return;
                }

                WinGlobal_UIService.Instance.ProgressBarADD(ValueUniProgressBar / 2);

                //Cria um processo para executar
                var processStartInfo = BCD_ProcessInfo.Create(DirectoryManange.GetDirectory(NameFolder));

                using (var process = new Process { StartInfo = await processStartInfo.ConfigureAwait(false) })
                {
                    process.Start();
                    await WaitForExitAsync(process);
                    await Task.Delay(500);                    
                    await WinGlobal_UIService.Instance.AddMessage("Backup BCD: Criado com Sucesso");
                }

                WinGlobal_UIService.Instance.Sucesso++;
                await WinGlobal_UIService.Instance.ProgressBarADD(ValueUniProgressBar / 2);
            }
            catch (Exception ex)
            {
                WinGlobal_UIService.Instance.Erro++;
                await WinGlobal_UIService.Instance.AddMessage("Backup BCD: Erro - " + ex.Message);
                await Task.Delay(500);
            }
        }

        // Executa a tarefa async em uma nova thread
        private async Task WaitForExitAsync(Process process)
        {
            await Task.Run(() => process.WaitForExit());
        }

    }
}
