using System.Diagnostics;
using System.Threading.Tasks;

namespace MeuSuporte
{
    internal class WinRemoteRDP_Firewall
    {
        public async Task Rule()
        {
            await Task.Delay(200);          
            ProcessStartInfo psi = new ProcessStartInfo("netsh", $"advfirewall firewall add rule name=\"Remote Desktop - TCP\" dir=in action=allow protocol=TCP localport=3389 profile=Domain,Private,Public")
            {
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                Verb = "runas"
            };

            using (Process processo = Process.Start(psi))
            {
                processo.WaitForExit();
                string saida = processo.StandardOutput.ReadToEnd();

                if (processo.ExitCode == 0)
                {
                    await WinGlobal_UIService.Instance.AddMessage($"Regra [Remote Desktop - TCP] adicionada com sucesso.");
                }
                else
                {
                    await WinGlobal_UIService.Instance.AddMessage($"Erro ao tentar adicionar a regra [Remote Desktop - TCP] no firewall.");
                }
            }
        }
    }
}
