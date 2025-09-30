using Microsoft.Win32;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MeuSuporte
{
    internal class WinRegistryBin_MACHINE
    {
        WinRegistryBin_List RegistryBin_List = new WinRegistryBin_List();

        public async Task Delete(int ValueUniProgressBar)
        {
            // Usando o método OpenSubKey para acessar as chaves do registro
            using (RegistryKey Pasta_MACH_Run = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run"))
            using (RegistryKey Pasta_MACH_CurrentVersion = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true))
            {
                if (Pasta_MACH_Run?.ValueCount > 0)
                {
                    // Itera sobre todas as chaves dentro da pasta Run
                    foreach (string NomeChave in Pasta_MACH_Run.GetValueNames())
                    {
                        WinGlobal_UIService.Instance.token.ThrowIfCancellationRequested(); // Checa se o cancelamento foi solicitado antes de começar

                        object conteudoChave = Pasta_MACH_Run.GetValue(NomeChave);
                        string caminhoRegistro = conteudoChave?.ToString() ?? string.Empty; // Converte o valor para string

                        RegistryValueKind tipoChaveEnum = Pasta_MACH_Run.GetValueKind(NomeChave);
                        string tipoChave = tipoChaveEnum.ToString(); // Converte o tipo para string

                        // verifica se existe exeçoes
                        if (RegistryBin_List.KeyData.Any(caminhoBase => conteudoChave.ToString().StartsWith(caminhoBase, StringComparison.OrdinalIgnoreCase)))
                        {
                            await WinGlobal_UIService.Instance.Log_MensagemAsync($"Registro: MACHINE \"{Environment.UserName}\" - Chave Preservada - Nome chave: \"{NomeChave}\" Valor: \"{caminhoRegistro}\" Tipo: \"{tipoChave}\"", true);
                            continue;
                        }

                        if (RegistryBin_List.KeyName.Any(caminhoBase => NomeChave.ToString().StartsWith(caminhoBase, StringComparison.OrdinalIgnoreCase)))
                        {
                            await WinGlobal_UIService.Instance.Log_MensagemAsync($"Registro: MACHINE \"{Environment.UserName}\" - Chave Preservada - Nome chave: \"{NomeChave}\" Valor: \"{caminhoRegistro}\" Tipo: \"{tipoChave}\"", true);
                            continue;
                        }

                        // Deleta a chave do registro
                        try
                        {                            
                            Pasta_MACH_CurrentVersion.DeleteValue(NomeChave);
                            await WinGlobal_UIService.Instance.Log_MensagemAsync($"Registro: MACHINE \"{Environment.UserName}\" - Chave Apagada - Nome chave: \"{NomeChave}\" Valor: \"{caminhoRegistro}\" Tipo: \"{tipoChave}\"", true);
                            WinGlobal_UIService.Instance.Sucesso++;
                        }
                        catch (Exception e)
                        {
                            await WinGlobal_UIService.Instance.Log_MensagemAsync($"Registro: MACHINE \"{Environment.UserName}\" - Ocorreu um Erro ao tentar apagar Chave - Nome chave: \"{NomeChave}\" Valor: \"{caminhoRegistro}\" Tipo: \"{tipoChave}\"", true);
                            WinGlobal_UIService.Instance.Erro++;
                        }


                    }
                    WinGlobal_UIService.Instance.ProgressBarADD(ValueUniProgressBar);
                }
                else
                {
                    await WinGlobal_UIService.Instance.Log_MensagemAsync("Registro: MACHINE - Sem registro.", true);
                }
            }
        }
    }
}
