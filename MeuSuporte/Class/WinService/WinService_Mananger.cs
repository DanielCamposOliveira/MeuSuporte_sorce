using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;

namespace MeuSuporte
{
    internal class WinService_Mananger
    {
        private  WinService_Uninstall WinService_Uninstall;
        private  WinService_Disabled WinService_Disabled;

        public WinService_Mananger()
        {
            WinService_Uninstall = new WinService_Uninstall();
            WinService_Disabled = new WinService_Disabled();
        }
        public async Task Mananger(string[] ListService, int ValueUniProgressBar, bool isDisableService)
        {

            WinGlobal_UIService.Instance.token.ThrowIfCancellationRequested(); // Checa se o cancelamento foi solicitado antes de começar

            int total = ListService.Length;
            float valorUnidade = (float)ValueUniProgressBar / total;
            bool foundServices = false;

            foreach (string serviceName in ListService)
            {
                WinGlobal_UIService.Instance.token.ThrowIfCancellationRequested();

                var service = ServiceController.GetServices().FirstOrDefault(s => s.ServiceName == serviceName);

                int NewValor = await ValueUnit(valorUnidade);
                if (NewValor >= 1)
                {
                    await WinGlobal_UIService.Instance.ProgressBarADD(NewValor);
                    await Task.Delay(20);
                }

                if (!isDisableService & service != null)
                {
                    await WinService_Uninstall.TryUninstallAsync(service);
                    foundServices = true;
                }

                if (isDisableService & service != null)
                {
                    await WinService_Disabled.WaitForServiceToDisabled(service);
                    foundServices = true;
                }
            }

            if (!foundServices)
            {
                await WinGlobal_UIService.Instance.ProgressBarADD(ValueUniProgressBar);
                await WinGlobal_UIService.Instance.Log_MensagemAsync("Serviço: No listings found!", true);
                await Task.Delay(500);
            }
        }

        // Funcao que envia a porcentagem para ProgressBar
        private static float accumulator = 0f; // Variável para armazenar o valor acumulado    
        private static async Task<int> ValueUnit(float valor)
        {
            accumulator += valor;

            // Extrai a parte inteira e armazena na ProgressBar
            int parteInteira = (int)accumulator;

            if (parteInteira > 0)
            {
                accumulator -= parteInteira;
                return parteInteira;
            }
            return 0;
        }

    }
}
