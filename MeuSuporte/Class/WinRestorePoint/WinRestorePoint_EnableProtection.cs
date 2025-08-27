using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MeuSuporte
{
    internal class WinRestorePoint_EnableProtection
    {
        public async Task<bool> EnableProtection(int ValueUniProgressBar)
        {
            try
            {
                // Habilita a Proteção do Sistema no disco C:
                if (!await RunCommandPowershell("Enable-ComputerRestore -Drive c:\\"))
                    return false;

                await Task.Delay(2000);
                await WinGlobal_UIService.Instance.Log_MensagemAsync(@"Proteção do sistema: Ativado", true);

                // Se não conseguir   Redimensiona o espaço de armazenamento da sombra para 10%
                if (!await RunCommandPowershell("-Command \"& 'C:\\Windows\\System32\\vssadmin.exe' resize shadowstorage /for=C: /on=C: /maxsize=10%\""))
                    return false;

                await Task.Delay(2000);
                await WinGlobal_UIService.Instance.Log_MensagemAsync(@"Uso do Espaço do Disco definido para 10% para Proteção do Sistema", true);
                
                WinGlobal_UIService.Instance.ProgressBarADD(ValueUniProgressBar);
                await Task.Delay(2000);

                return true;
            }
            catch (Exception ex)
            {
                WinGlobal_UIService.Instance.Erro++;
                await WinGlobal_UIService.Instance.Log_MensagemAsync(@"Ocorreu um erro ao tentar ativar a configuração de Proteção do sistema", true);
                return false;
            }          
        }

        private async Task<bool> RunCommandPowershell(string arguments)
        {
            ProcessStartInfo psi = new ProcessStartInfo()
            {
                FileName = "powershell",
                Arguments = arguments,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true,
                Verb = "runas" // Executa como Administrador
            };

            using (Process process = new Process() { StartInfo = psi })
            {
                process.Start();
                string output = await process.StandardOutput.ReadToEndAsync();
                string error = await process.StandardError.ReadToEndAsync();
                process.WaitForExit();

                if (!string.IsNullOrWhiteSpace(output))
                    Console.WriteLine("Saída: " + output);
                if (!string.IsNullOrWhiteSpace(error))
                    Console.WriteLine("Erro: " + error);

                // Se ExitCode for 0 e não tiver erro, consideramos sucesso
                return process.ExitCode == 0 && string.IsNullOrWhiteSpace(error);
            }
        }
    }
}
