using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuSuporte
{
    internal class WinRegistryBin_Global_Key
    {
        WinRegistryBin_List RegistryBin_List;
        private WinRegistryBin_CloudManager CloudManager;
        public WinRegistryBin_Global_Key()
        {
            RegistryBin_List = new WinRegistryBin_List();
            CloudManager = new WinRegistryBin_CloudManager();
        }

        public async Task Delete(string RegistryName, RegistryKey rootKey, int ValueUniProgressBar)
        {
            // Usando o método OpenSubKey para acessar as chaves do registro
          //  using (RegistryKey Pasta_Node_Run = Registry.LocalMachine.OpenSubKey(@"Software\WOW6432Node\Microsoft\Windows\CurrentVersion\Run"))
            using (RegistryKey? searchKey = rootKey)
            {
                if (searchKey?.ValueCount > 0)
                {
                    // Itera sobre todas as chaves dentro da pasta Run
                    foreach (string NomeChave in searchKey.GetValueNames())
                    {
                        WinGlobal_UIService.Instance.token.ThrowIfCancellationRequested(); // Checa se o cancelamento foi solicitado antes de começar


                        object conteudoChave = searchKey.GetValue(NomeChave);
                        string caminhoRegistro = conteudoChave?.ToString() ?? string.Empty; // Converte o valor para string

                        RegistryValueKind tipoChaveEnum = searchKey.GetValueKind(NomeChave);
                        string tipoChave = tipoChaveEnum.ToString(); // Converte o tipo para string

                        // verifica se existe exeçoes
                        if (RegistryBin_List.KeyDirectory.Any(caminhoBase => conteudoChave.ToString().StartsWith(caminhoBase, StringComparison.OrdinalIgnoreCase)))
                        {
                            await WinGlobal_UIService.Instance.AddMessage($"Registro: {RegistryName} \"{Environment.UserName}\" - Chave Preservada - Nome chave: \"{NomeChave}\" Valor: \"{caminhoRegistro}\" Tipo: \"{tipoChave}\"");
                            continue;
                        }

                        // verifica se existe exeçoes
                        if (RegistryBin_List.KeyName.Any(caminhoBase => NomeChave.ToString().StartsWith(caminhoBase, StringComparison.OrdinalIgnoreCase)))
                        {
                            await WinGlobal_UIService.Instance.AddMessage($"Registro: {RegistryName} \"{Environment.UserName}\" - Chave Preservada - Nome chave: \"{NomeChave}\" Valor: \"{caminhoRegistro}\" Tipo: \"{tipoChave}\"");
                            continue;
                        }

                        // verifica se os Apps estão logados, caso exteja não apaga a chave de registro
                        if (RegistryBin_List.KeyCloud.Any(caminhoBase => NomeChave.ToString().StartsWith(caminhoBase, StringComparison.OrdinalIgnoreCase)))
                        {
                            if (NomeChave.ToString() == "GoogleDriveFS")
                            {
                                string basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

                                if (await CloudManager.GetGoogleDrive(basePath) == true)
                                {
                                    continue;
                                }
                            }

                            if (NomeChave.ToString() == "OneDrive")
                            {
                                RegistryKey chave = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\OneDrive\Accounts");

                                if (await CloudManager.GetOneDrive(chave) == true)
                                {
                                    continue;
                                }
                            }
                        }

                        // Deleta a chave do registro
                        try
                        {
                            searchKey.DeleteValue(NomeChave);
                            await WinGlobal_UIService.Instance.AddMessage($"Registro: {RegistryName} \"{Environment.UserName}\" - Chave Apagada - Nome chave: \"{NomeChave}\" Valor: \"{caminhoRegistro}\" Tipo: \"{tipoChave}\"");
                            WinGlobal_UIService.Instance.Sucesso++;
                        }
                        catch (Exception e)
                        {
                            await WinGlobal_UIService.Instance.AddMessage($"Registro: {RegistryName} \"{Environment.UserName}\" - Ocorreu um Erro ao tentar apagar Chave - Nome chave: \"{NomeChave}\" Valor: \"{caminhoRegistro}\" Tipo: \"{tipoChave}\"");
                            WinGlobal_UIService.Instance.Erro++;
                        }
                    }
                    WinGlobal_UIService.Instance.ProgressBarADD(ValueUniProgressBar);
                }
                else
                {
                    await WinGlobal_UIService.Instance.AddMessage($"Registro: {RegistryName} - Sem registro.");
                    WinGlobal_UIService.Instance.Sucesso++;
                }
            }
        }
    }
}
