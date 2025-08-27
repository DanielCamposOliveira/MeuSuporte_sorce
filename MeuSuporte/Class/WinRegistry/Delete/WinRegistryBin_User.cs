using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace MeuSuporte
{
    internal class WinRegistryBin_User
    {       
        public async Task Delete(string[] RegistryList, int ValueUniProgressBar)
        {
            using (RegistryKey Pasta_USER_Run = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run"))
            using (RegistryKey Pasta_USER_CurrentVersion = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true))
            {
                if (Pasta_USER_Run?.ValueCount > 0)
                {
                    // Itera sobre todas as chaves dentro da pasta Run
                    foreach (string NomeChave in Pasta_USER_Run.GetValueNames())
                    {
                        WinGlobal_UIService.Instance.token.ThrowIfCancellationRequested(); // Checa se o cancelamento foi solicitado antes de começar

                        if (!RegistryList.Contains(NomeChave, StringComparer.OrdinalIgnoreCase))
                        {
                            try
                            {
                                // Deleta a chave do registro
                                Pasta_USER_CurrentVersion.DeleteValue(NomeChave);
                                await WinGlobal_UIService.Instance.Log_MensagemAsync($"Registro: {NomeChave} Apagado !", true);
                                WinGlobal_UIService.Instance.Sucesso++;
                            }
                            catch (Exception e)
                            {
                                await WinGlobal_UIService.Instance.Log_MensagemAsync($"Erro ao Apagar Registro: {NomeChave}", true);
                                WinGlobal_UIService.Instance.Erro++;
                            }
                        }
                        else
                        {
                            // Apenas logando os que foram ignorados
                            await WinGlobal_UIService.Instance.Log_MensagemAsync(
                                $"Registro USER preservado: {NomeChave}", true);
                        }
                    }
                    WinGlobal_UIService.Instance.ProgressBarADD(ValueUniProgressBar);
                }
                else
                {
                    await WinGlobal_UIService.Instance.Log_MensagemAsync("Sem chave no Registro: USER", true);
                }
            }
        }
    }
}
