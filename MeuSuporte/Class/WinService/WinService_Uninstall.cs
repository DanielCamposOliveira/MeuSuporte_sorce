using System;
using System.Configuration.Install;
using System.ServiceProcess;
using System.Threading.Tasks;

namespace MeuSuporte
{
    internal class WinService_Uninstall
    {
        private readonly WinService_Stop _serviceStopper;

        public WinService_Uninstall()
        {
            _serviceStopper = new WinService_Stop(); // criada apenas uma vez
        }

        public async Task<bool> TryUninstallAsync(ServiceController service)
        {

            bool isServiceStopped = await _serviceStopper.WaitForServiceToStop(service); // para o serviço

            if (!isServiceStopped)
            {
                await WinGlobal_UIService.Instance.AddMessage($"Serviço: {service.DisplayName} não pode ser removido devido ainda está em execução.");
                return false;
            }

            try
            {
                using (var serviceInstaller = new ServiceInstaller())
                {
                    serviceInstaller.Context = new InstallContext(null, null);
                    serviceInstaller.ServiceName = service.ServiceName;
                    serviceInstaller.Uninstall(null);

                    await WinGlobal_UIService.Instance.AddMessage($"Serviço: {service.DisplayName} - Deleted");
                    return true;
                }
            }
            catch (Exception ex)
            {
                WinGlobal_UIService.Instance.Erro++;
                await WinGlobal_UIService.Instance.AddMessage($"Serviço: Ocorreu um Erro ao tentar desinstalar o Serviço - {service.DisplayName}");
                return false;
            }
        }
    }
}
