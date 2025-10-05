using System;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace MeuSuporte
{
    internal class WinUserUAC_State
    {        
        public async Task Notification(bool State, int ValueUniProgressBar)
        {
            int consentPrompt = State ? 2 : 0;
            int promptOnSecureDesktop = State ? 1 : 0;
            int enableLUA = State ? 1 : 0;
  
            WinGlobal_UIService.Instance.ProgressBarADD(ValueUniProgressBar / 2);
            try
            {
                using (RegistryKey CurrentVersion = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies", writable: true))
                using (RegistryKey key = CurrentVersion.OpenSubKey("System", writable: true))
                {
                    key.SetValue("ConsentPromptBehaviorAdmin", consentPrompt, RegistryValueKind.DWord); // Volta ao padrão (pedir confirmação) = Ativado(2) Desativado(0)
                    key.SetValue("PromptOnSecureDesktop", promptOnSecureDesktop, RegistryValueKind.DWord); // Ativa a Área de Trabalho Segura = Ativado(1) Desativado(0)
                    key.SetValue("EnableLUA", enableLUA, RegistryValueKind.DWord); // Ativa o UAC = Ativado(1) Desativado(0)
                    
                    await WinGlobal_UIService.Instance.Log_MensagemAsync("Notificações do Usuario UAC: Alterado", true);                 
                }
                await WinGlobal_UIService.Instance.ProgressBarADD(ValueUniProgressBar / 2);
                WinGlobal_UIService.Instance.Sucesso++;
            }
            catch (Exception)
            {
                await WinGlobal_UIService.Instance.Log_MensagemAsync("Notificações do Usuario UAC: Erro!", true);
                WinGlobal_UIService.Instance.Erro++;
            }
        }
    }
}
