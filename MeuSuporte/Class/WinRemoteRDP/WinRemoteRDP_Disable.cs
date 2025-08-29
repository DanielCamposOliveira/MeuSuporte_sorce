using System;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace MeuSuporte
{
    internal class WinRemoteRDP_Disable
    {
        public async Task Disable()
        {
            try
            {
                WinGlobal_UIService.Instance.token.ThrowIfCancellationRequested(); // Checa se o cancelamento foi solicitado antes de começar
             
                // Habilita o Remote Desktop no registro
                using (RegistryKey chave = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\Terminal Server", true))
                {
                    if (chave != null)
                    {
                        chave.SetValue("fDenyTSConnections", 1, RegistryValueKind.DWord); // 1 = Desabilita
                        await WinGlobal_UIService.Instance.Log_MensagemAsync($"Acesso Remoto Desativado", true);
                    }
                }                        
            }
            catch (Exception ex)
            {
                await WinGlobal_UIService.Instance.Log_MensagemAsync($"Erro: " + ex.Message, true);
            }
        }
    }
}
