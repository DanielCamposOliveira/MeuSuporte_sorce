using System.ServiceProcess;
using System;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace MeuSuporte
{
    internal class WinService_Disabled
    {

        private readonly WinService_Stop _serviceStopper;

        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern bool ChangeServiceConfig(
        IntPtr hService, uint nServiceType, uint nStartType,
        uint nErrorControl, string lpBinaryPathName, string lpLoadOrderGroup,
        IntPtr lpdwTagId, [In] char[] lpDependencies, string lpServiceStartName,
        string lpPassword, string lpDisplayName);

        private const uint SERVICE_NO_CHANGE = 0xFFFFFFFF;

        public WinService_Disabled()
        {
            _serviceStopper = new WinService_Stop(); // criada apenas uma vez
        }

        public async Task WaitForServiceToDisabled(ServiceController service)
        {
            bool isServiceStopped = await _serviceStopper.WaitForServiceToStop(service); // Para o serviço   

            if (!isServiceStopped)
            {                
                await WinGlobal_UIService.Instance.AddMessage($"Serviço: {service.DisplayName} não pode ser desabilitado devido ainda está em execução.");
                await Task.Delay(500);
                WinGlobal_UIService.Instance.Erro++;
                return;
            }

            if (service.StartType != ServiceStartMode.Disabled)
            {
                try
                {
                    using (var serviceHandle = service.ServiceHandle)
                    {
                        ChangeServiceConfig(
                            serviceHandle.DangerousGetHandle(),
                            SERVICE_NO_CHANGE, (uint)ServiceStartMode.Disabled,
                            SERVICE_NO_CHANGE, null, null,
                            IntPtr.Zero, null, null, null, null
                            );
                    }

                    await WinGlobal_UIService.Instance.AddMessage($"Serviço:  {service.DisplayName} - Disabled");
                    await Task.Delay(500);
                    WinGlobal_UIService.Instance.Sucesso++;
                }
                catch (Exception ex)
                {
                    await WinGlobal_UIService.Instance.AddMessage($"Serviço: Ocorreu um Erro ao tentar mudar o Modo de Inicialização do Serviço - {service.DisplayName}");                  
                    await Task.Delay(500);
                    WinGlobal_UIService.Instance.Erro++;
                }
            }

        }
    }
}
