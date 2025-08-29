using System;
using System.Management;
using System.Threading.Tasks;

namespace MeuSuporte
{
    internal class WinRestorePoint_Create
    {
        public async Task<bool> CreatePoint(string description, int ValueUniProgressBar)
        {
            try
            {
                WinGlobal_UIService.Instance.token.ThrowIfCancellationRequested(); // Checa se o cancelamento foi solicitado antes de começar

                ManagementScope oScope = new ManagementScope("\\\\localhost\\root\\default");
                ManagementPath oPath = new ManagementPath("SystemRestore");
                ObjectGetOptions oGetOp = new ObjectGetOptions();
                ManagementClass oProcess = new ManagementClass(oScope, oPath, oGetOp);

                ManagementBaseObject oInParams = oProcess.GetMethodParameters("CreateRestorePoint");
                oInParams["Description"] = description;
                oInParams["RestorePointType"] = 0; 
                oInParams["EventType"] = 100;

                //Define o tipo de ponto de restauração. Os valores possíveis são:
                // Microsoft recomenda 0 (Undefined) ou 10 (Application Install).
                // 0 – Um ponto de restauração indefinido.
                // 10 – Instalação do sistema operacional.
                // 12 – Instalação de aplicativo (padrão para criar manualmente).
                // 13 – Modificação do sistema.

                ManagementBaseObject oOutParams = oProcess.InvokeMethod("CreateRestorePoint", oInParams, null);
                int returnValue = Convert.ToInt32(oOutParams["ReturnValue"]);

                switch (returnValue)
                {
                    case 0:
                        WinGlobal_UIService.Instance.Sucesso++;
                        WinGlobal_UIService.Instance.ProgressBarADD(ValueUniProgressBar);
                        await WinGlobal_UIService.Instance.Log_MensagemAsync($"Proteção do Sistema: Ponto de restauração [{description}] Criado com sucesso.", true);
                        return true;
                        break;

                    case 5:
                        await WinGlobal_UIService.Instance.Log_MensagemAsync("Proteção do Sistema: A Proteção do Sistema está desativada no disco C: não sendo possivel de criar o Ponto de restauração.", true);
                        WinGlobal_UIService.Instance.Erro++;
                        return false;
                        break;

                    case 13:
                        await WinGlobal_UIService.Instance.Log_MensagemAsync("Proteção do Sistema: Já existe um ponto recente (menos de 24h).", true);
                        WinGlobal_UIService.Instance.Erro++;
                        return false;
                        break;

                    default:
                        await WinGlobal_UIService.Instance.Log_MensagemAsync($"Proteção do Sistema: Erro ao criar ponto de restauração.", true);
                        WinGlobal_UIService.Instance.Erro++;
                        return false;
                        break;
                }

                
                // 0 = Sucesso
                // 1 = Falha genérica
                // 2 = Serviço não está rodando
                // 3 = Espaço insuficiente
                // 5 = A proteção do sistema está desativada
                // 13 = Já existe um ponto recente (limite de tempo)
            }
            catch (Exception ex)
            {
                WinGlobal_UIService.Instance.Erro++;
                await WinGlobal_UIService.Instance.Log_MensagemAsync($"Proteção do Sistema: Ocorreu um Erro ao tentar criar ponto de restauração." + ex.Message, true);
                return false;
            }     
        }
    }
}
