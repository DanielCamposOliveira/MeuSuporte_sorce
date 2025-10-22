using Microsoft.Win32;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MeuSuporte
{
    internal class WinRegistryBin_UserSingle
    {
        /// <summary>
        /// Class responsavel por excluir os registros
        /// </summary>
        private readonly WinRegistryBin_List RegistryBin_List; // = new WinRegistryBin_List();      
        private WinRegistryBin_CloudManager CloudManager;

        public WinRegistryBin_UserSingle() 
        {
            RegistryBin_List = new WinRegistryBin_List();
            CloudManager = new WinRegistryBin_CloudManager();
        }

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
                        if (RegistryBin_List.KeyDirectory.Any(caminhoBase => conteudoChave.ToString().StartsWith(caminhoBase, StringComparison.OrdinalIgnoreCase)))
                        {
                            await WinGlobal_UIService.Instance.Log_MensagemAsync($"Registro: USER \"{Environment.UserName}\" - Chave Preservada - Nome chave: \"{NomeChave}\" Valor: \"{caminhoRegistro}\" Tipo: \"{tipoChave}\"", true);
                            continue;
                        }

                        // verifica se existe exeçoes
                        if (RegistryBin_List.KeyName.Any(caminhoBase => NomeChave.ToString().StartsWith(caminhoBase, StringComparison.OrdinalIgnoreCase)))
                        {
                            await WinGlobal_UIService.Instance.Log_MensagemAsync($"Registro: USER \"{Environment.UserName}\" - Chave Preservada - Nome chave: \"{NomeChave}\" Valor: \"{caminhoRegistro}\" Tipo: \"{tipoChave}\"", true);
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

                        
                        try
                        {
                            // Deleta a chave do registro
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
                    await WinGlobal_UIService.Instance.ProgressBarADD(ValueUniProgressBar);
                }
                else
                {
                    await WinGlobal_UIService.Instance.Log_MensagemAsync($"Registro: USER \"{Environment.UserName}\" - Sem registro.", true);
                }
            }
        }

    }
}
