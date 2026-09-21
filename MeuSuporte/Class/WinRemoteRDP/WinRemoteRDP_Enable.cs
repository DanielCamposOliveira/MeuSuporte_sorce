using System;
using System.Threading.Tasks;

namespace MeuSuporte
{
    internal class WinRemoteRDP_Enable
    {
        private  WinRemoteRDP_Registry RemoteRDP_Registry;
        private  WinRemoteRDP_Service RemoteRDP_Service;
        private  WinRemoteRDP_Firewall RemoteRDP_Firewall;
    
        public WinRemoteRDP_Enable()
        {
            RemoteRDP_Registry = new WinRemoteRDP_Registry();
            RemoteRDP_Service = new WinRemoteRDP_Service();
            RemoteRDP_Firewall = new WinRemoteRDP_Firewall();
        }

        public async Task Enable()
        {
            try
            {             
                WinGlobal_UIService.Instance.token.ThrowIfCancellationRequested(); // Checa se o cancelamento foi solicitado antes de começar

                //Habilita registro 
                await RemoteRDP_Registry.Enable();
                await WinGlobal_UIService.Instance.AddMessage($"Acesso Remoto Ativado");
                await Task.Delay(200);
                                
                RemoteRDP_Service.ServiceEnable(); //Inicia o Serviço TermService
                RemoteRDP_Firewall.Rule(); // Habilita as regras do Firewall para RDP (porta 3389)

            }
            catch (Exception ex)
            {
                await WinGlobal_UIService.Instance.AddMessage($"Erro: " + ex.Message);
            }
        }
    }
}
