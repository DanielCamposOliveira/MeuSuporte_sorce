using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace MeuSuporte
{
    internal class WinRegistryBin_UserSingle
    {
        WinRegistryBin_List RegistryBin_List = new WinRegistryBin_List();

        public async Task Delete(int ValueUniProgressBar)
        {
            using (RegistryKey Pasta_USER_Run = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run"))
            using (RegistryKey Pasta_USER_CurrentVersion = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true))
            {
                if (Pasta_USER_Run?.ValueCount > 0)
                {
                    foreach (string NomeChave in Pasta_USER_Run.GetValueNames())
                    {
                        WinGlobal_UIService.Instance.token.ThrowIfCancellationRequested(); // Checa se o cancelamento foi solicitado antes de começar
                                             
                        object conteudoChave = Pasta_USER_Run.GetValue(NomeChave);                        
                        string caminhoRegistro = conteudoChave?.ToString() ?? string.Empty; // Converte o valor para string

                        RegistryValueKind tipoChaveEnum = Pasta_USER_Run.GetValueKind(NomeChave);
                        string tipoChave = tipoChaveEnum.ToString(); // Converte o tipo para string

                        // verifica se existe exeçoes
                        if (RegistryBin_List.KeyData.Any(caminhoBase => conteudoChave.ToString().StartsWith(caminhoBase, StringComparison.OrdinalIgnoreCase)))
                        {
                            await WinGlobal_UIService.Instance.Log_MensagemAsync($"Registro: USER \"{Environment.UserName}\" - Chave Preservada - Nome chave: \"{NomeChave}\" Valor: \"{caminhoRegistro}\" Tipo: \"{tipoChave}\"", true);
                            continue;
                        }

                        if (RegistryBin_List.KeyName.Any(caminhoBase => NomeChave.ToString().StartsWith(caminhoBase, StringComparison.OrdinalIgnoreCase)))
                        {
                            await WinGlobal_UIService.Instance.Log_MensagemAsync($"Registro: USER \"{Environment.UserName}\" - Chave Preservada - Nome chave: \"{NomeChave}\" Valor: \"{caminhoRegistro}\" Tipo: \"{tipoChave}\"", true);
                            continue;
                        }

                        // Deleta a chave do registro
                        try
                        {                            
                            Pasta_USER_CurrentVersion.DeleteValue(NomeChave);
                            await WinGlobal_UIService.Instance.Log_MensagemAsync($"Registro: USER \"{Environment.UserName}\" - Chave Apagada - Nome chave: \"{NomeChave}\" Valor: \"{caminhoRegistro}\" Tipo: \"{tipoChave}\"", true);
                            WinGlobal_UIService.Instance.Sucesso++;
                        }
                        catch (Exception e)
                        {
                            await WinGlobal_UIService.Instance.Log_MensagemAsync($"Registro: USER \"{Environment.UserName}\" - Ocorreu um Erro ao tentar apagar Chave - Nome chave: \"{NomeChave}\" Valor: \"{caminhoRegistro}\" Tipo: \"{tipoChave}\"", true);
                            WinGlobal_UIService.Instance.Erro++;
                        }
                    }
                    WinGlobal_UIService.Instance.ProgressBarADD(ValueUniProgressBar);
                }
                else
                {
                    await WinGlobal_UIService.Instance.Log_MensagemAsync($"Registro: USER \"{Environment.UserName}\" - Sem registro.", true);
                }
            }
        }

    }
}
