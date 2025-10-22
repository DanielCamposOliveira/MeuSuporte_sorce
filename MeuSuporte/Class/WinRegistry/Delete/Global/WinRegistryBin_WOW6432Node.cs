using Microsoft.Win32;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MeuSuporte
{
    internal class WinRegistryBin_WOW6432Node
    {
        /// <summary>
        /// Class responsavel por excluir os registros
        /// </summary>
 
        WinRegistryBin_List RegistryBin_List = new WinRegistryBin_List();

        public WinRegistryBin_WOW6432Node()
        {
            RegistryBin_List = new WinRegistryBin_List();
        }
        public async Task Delete(int ValueUniProgressBar)
        {
            // Usando o método OpenSubKey para acessar as chaves do registro
            using (RegistryKey Pasta_Node_Run = Registry.LocalMachine.OpenSubKey(@"Software\WOW6432Node\Microsoft\Windows\CurrentVersion\Run"))
            using (RegistryKey Pasta_MACH_CurrentVersion = Registry.LocalMachine.OpenSubKey(@"Software\WOW6432Node\Microsoft\Windows\CurrentVersion\Run", true))
            {
                if (Pasta_Node_Run?.ValueCount > 0)
                {
                    // Itera sobre todas as chaves dentro da pasta Run
                    foreach (string NomeChave in Pasta_Node_Run.GetValueNames())
                    {
                        WinGlobal_UIService.Instance.token.ThrowIfCancellationRequested(); // Checa se o cancelamento foi solicitado antes de começar


                        object conteudoChave = Pasta_Node_Run.GetValue(NomeChave);
                        string caminhoRegistro = conteudoChave?.ToString() ?? string.Empty; // Converte o valor para string

                        RegistryValueKind tipoChaveEnum = Pasta_Node_Run.GetValueKind(NomeChave);
                        string tipoChave = tipoChaveEnum.ToString(); // Converte o tipo para string

                        // verifica se existe exeçoes
                        if (RegistryBin_List.KeyDirectory.Any(caminhoBase => conteudoChave.ToString().StartsWith(caminhoBase, StringComparison.OrdinalIgnoreCase)))
                        {
                            await WinGlobal_UIService.Instance.Log_MensagemAsync($"Registro: WOW6432Node \"{Environment.UserName}\" - Chave Preservada - Nome chave: \"{NomeChave}\" Valor: \"{caminhoRegistro}\" Tipo: \"{tipoChave}\"", true);
                            continue;
                        }

                        // verifica se existe exeçoes
                        if (RegistryBin_List.KeyName.Any(caminhoBase => NomeChave.ToString().StartsWith(caminhoBase, StringComparison.OrdinalIgnoreCase)))
                        {
                            await WinGlobal_UIService.Instance.Log_MensagemAsync($"Registro: WOW6432Node \"{Environment.UserName}\" - Chave Preservada - Nome chave: \"{NomeChave}\" Valor: \"{caminhoRegistro}\" Tipo: \"{tipoChave}\"", true);
                            continue;
                        }

                        // Deleta a chave do registro
                        try
                        {                            
                            Pasta_MACH_CurrentVersion.DeleteValue(NomeChave);
                            await WinGlobal_UIService.Instance.Log_MensagemAsync($"Registro: WOW6432Node \"{Environment.UserName}\" - Chave Apagada - Nome chave: \"{NomeChave}\" Valor: \"{caminhoRegistro}\" Tipo: \"{tipoChave}\"", true);
                            WinGlobal_UIService.Instance.Sucesso++;
                        }
                        catch (Exception e)
                        {
                            await WinGlobal_UIService.Instance.Log_MensagemAsync($"Registro: WOW6432Node \"{Environment.UserName}\" - Ocorreu um Erro ao tentar apagar Chave - Nome chave: \"{NomeChave}\" Valor: \"{caminhoRegistro}\" Tipo: \"{tipoChave}\"", true);
                            WinGlobal_UIService.Instance.Erro++;
                        }
                    }
                    WinGlobal_UIService.Instance.ProgressBarADD(ValueUniProgressBar);
                }
                else
                {
                    await WinGlobal_UIService.Instance.Log_MensagemAsync("Registro: WOW6432Node - Sem registro.", true);
                }
            }
        }
    }
}
