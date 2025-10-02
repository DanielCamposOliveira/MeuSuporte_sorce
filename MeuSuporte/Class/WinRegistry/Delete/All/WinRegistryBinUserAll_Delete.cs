using Microsoft.Win32;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MeuSuporte
{
    internal class WinRegistryBinUserAll_Delete
    {
        /// <summary>
        /// Class responsavel por apagar todos os registro do Usuario
        /// </summary>
              
        private readonly WinRegistryBin_List RegistryBin_List = new WinRegistryBin_List();

        public WinRegistryBinUserAll_Delete()
        {
            RegistryBin_List = new WinRegistryBin_List();
        }

        public async Task Delete(string tempHiveName, string Usuario)
        {
            string searchKeyPath = @$"{tempHiveName}\Software\Microsoft\Windows\CurrentVersion\Run";
            using (RegistryKey Pasta_USER_Runss = Registry.Users.CreateSubKey(searchKeyPath))
            using (RegistryKey? searchKey = Registry.Users.CreateSubKey(searchKeyPath, true))
            {
                if (Pasta_USER_Runss?.ValueCount > 0)
                {
                    foreach (string NomeChave in Pasta_USER_Runss.GetValueNames())
                    {
                        WinGlobal_UIService.Instance.token.ThrowIfCancellationRequested(); // Checa se o cancelamento foi solicitado antes de começar

                        object conteudoChave = Pasta_USER_Runss.GetValue(NomeChave);
                        string caminhoRegistro = conteudoChave?.ToString() ?? string.Empty; // Converte o valor para string

                        RegistryValueKind tipoChaveEnum = Pasta_USER_Runss.GetValueKind(NomeChave);
                        string tipoChave = tipoChaveEnum.ToString(); // Converte o tipo para string


                        // verifica se existe exeçoes
                        if (RegistryBin_List.KeyData.Any(caminhoBase => conteudoChave.ToString().StartsWith(caminhoBase, StringComparison.OrdinalIgnoreCase)))
                        {
                            await WinGlobal_UIService.Instance.Log_MensagemAsync($"Registro: User \"{Usuario}\" - Chave Preservada - Nome chave: \"{NomeChave}\" Valor: \"{caminhoRegistro}\" Tipo: \"{tipoChave}\"", true);
                            continue;
                        }

                        if (RegistryBin_List.KeyName.Any(caminhoBase => NomeChave.ToString().StartsWith(caminhoBase, StringComparison.OrdinalIgnoreCase)))
                        {
                            await WinGlobal_UIService.Instance.Log_MensagemAsync($"Registro: User \"{Usuario}\" - Chave Preservada - Nome chave: \"{NomeChave}\" Valor: \"{caminhoRegistro}\" Tipo: \"{tipoChave}\"", true);
                            continue;
                        }
                        
                        try
                        {
                            // Deleta a chave do registro
                            searchKey.DeleteValue(NomeChave);
                            
                            await WinGlobal_UIService.Instance.Log_MensagemAsync($"Registro: User \"{Usuario}\" - Chave Apagada - Nome chave: \"{NomeChave}\" Valor: \"{caminhoRegistro}\" Tipo: \"{tipoChave}\"", true);
                            WinGlobal_UIService.Instance.Sucesso++;
                        }
                        catch (Exception e)
                        {
                            await WinGlobal_UIService.Instance.Log_MensagemAsync($"Registro: User \"{Usuario}\" - Ocorreu um Erro ao tentar apagar Chave - Nome chave: \"{NomeChave}\" Valor: \"{caminhoRegistro}\" Tipo: \"{tipoChave}\"", true);
                            WinGlobal_UIService.Instance.Erro++;
                        }
                    }
                }
                else
                {
                    await WinGlobal_UIService.Instance.Log_MensagemAsync($"Registro: User \"{Usuario}\" - Sem registro.", true);
                }
            }
        }
    }
}
