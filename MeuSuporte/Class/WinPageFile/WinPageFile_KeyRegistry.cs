using System;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace MeuSuporte
{
    internal class WinPageFile_KeyRegistry
    {
        public async Task State(bool state , int ValueUniProgressBar)
        {
            try
            {
                int value = Convert.ToInt32(state);

                WinGlobal_UIService.Instance.token.ThrowIfCancellationRequested(); // Checa se o cancelamento foi solicitado antes de começar
                await WinGlobal_UIService.Instance.ProgressBarADD(ValueUniProgressBar / 2);

                Microsoft.Win32.RegistryKey PastaCurrentVersion = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\Session Manager");

                using (RegistryKey RegistrySettings = PastaCurrentVersion.OpenSubKey("Memory Management", true))
                {
                    RegistrySettings.SetValue("ClearPageFileAtShutdown", Convert.ToInt32(state), RegistryValueKind.DWord);
                }

                WinGlobal_UIService.Instance.Sucesso++;
                await WinGlobal_UIService.Instance.Log_MensagemAsync("PageFile.sys:  Limpesa altomatico: Ativado !", true);
                await Task.Delay(500);
                await WinGlobal_UIService.Instance.ProgressBarADD(ValueUniProgressBar / 2);
            }
            catch (Exception e)
            {
                WinGlobal_UIService.Instance.Erro++;
                await WinGlobal_UIService.Instance.Log_MensagemAsync($"PageFile.sys: Não foi possivel realizara a Alteração", true);
            }
        }
    }
}
