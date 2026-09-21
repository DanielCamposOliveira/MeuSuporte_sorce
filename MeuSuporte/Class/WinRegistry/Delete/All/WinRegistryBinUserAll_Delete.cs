using Microsoft.Win32;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MeuSuporte
{
    // 4
    /// <summary>
    /// Class responsavel por apagar todos os registro do Usuario
    /// </summary>
    
    internal class WinRegistryBinUserAll_Delete
    {
        private readonly WinRegistryBin_List RegistryBin_List;// = new WinRegistryBin_List();
        private WinRegistryBin_CloudManager CloudManager;

        public WinRegistryBinUserAll_Delete()
        {
            RegistryBin_List = new WinRegistryBin_List();
            CloudManager = new WinRegistryBin_CloudManager();
        }

        public async Task Delete(string tempHiveName, string Usuario, int ValueUniProgressBar)
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
                        if (RegistryBin_List.KeyDirectory.Any(caminhoBase => conteudoChave.ToString().StartsWith(caminhoBase, StringComparison.OrdinalIgnoreCase)))
                        {
                            await WinGlobal_UIService.Instance.AddMessage($"Registro: User \"{Usuario}\" - Chave Preservada - Nome chave: \"{NomeChave}\" Valor: \"{caminhoRegistro}\" Tipo: \"{tipoChave}\"");
                            continue;
                        }

                        // verifica se existe exeçoes
                        if (RegistryBin_List.KeyName.Any(caminhoBase => NomeChave.ToString().StartsWith(caminhoBase, StringComparison.OrdinalIgnoreCase)))
                        {
                            await WinGlobal_UIService.Instance.AddMessage($"Registro: User \"{Usuario}\" - Chave Preservada - Nome chave: \"{NomeChave}\" Valor: \"{caminhoRegistro}\" Tipo: \"{tipoChave}\"");
                            continue;
                        }


                        // verifica se os Apps estão logados, caso exteja não apaga a chave de registro
                        if (RegistryBin_List.KeyCloud.Any(caminhoBase => NomeChave.ToString().StartsWith(caminhoBase, StringComparison.OrdinalIgnoreCase)))
                        {
                            if (NomeChave.ToString() == "GoogleDriveFS")
                            {
                                string usersFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile); // C:\Users\Usuario
                                string baseUsersPath = Path.GetDirectoryName(usersFolderPath); // C:\Users

                                // Monta o caminho para a pasta Temp do usuário específico
                                string tempPath = Path.Combine(baseUsersPath, Usuario, "AppData", "Local");

                                if (await CloudManager.GetGoogleDrive(tempPath) == true)
                                {
                                    await WinGlobal_UIService.Instance.AddMessage($"Registro: USER \"{Environment.UserName}\" - Chave Preservada (App Conectado) - Nome chave: \"{NomeChave}\"");
                                    continue;
                                }

                            }

                            if (NomeChave.ToString() == "OneDrive")
                            {   
                                string searchKeyPathOneDrive = @$"{tempHiveName}\Software\Microsoft\OneDrive\Accounts";
                                using (RegistryKey? Chave = Registry.Users.CreateSubKey(searchKeyPathOneDrive, true)) 
                                {
                                    if (await CloudManager.GetOneDrive(Chave) == true)
                                    {
                                        await WinGlobal_UIService.Instance.AddMessage($"Registro: USER \"{Environment.UserName}\" - Chave Preservada (App Conectado) - Nome chave: \"{NomeChave}\"");
                                        continue;
                                    }
                                }               
                            }
                        }


                        try
                        {
                           // Deleta a chave do registro
                            searchKey.DeleteValue(NomeChave);

                            await WinGlobal_UIService.Instance.ProgressBarADD(ValueUniProgressBar);
                            await WinGlobal_UIService.Instance.AddMessage($"Registro: User \"{Usuario}\" - Chave Apagada - Nome chave: \"{NomeChave}\" Valor: \"{caminhoRegistro}\" Tipo: \"{tipoChave}\"");
                            WinGlobal_UIService.Instance.Sucesso++;
                        }
                        catch (Exception e)
                        {
                            await WinGlobal_UIService.Instance.AddMessage($"Registro: User \"{Usuario}\" - Ocorreu um Erro ao tentar apagar Chave - Nome chave: \"{NomeChave}\" Valor: \"{caminhoRegistro}\" Tipo: \"{tipoChave}\"");
                            WinGlobal_UIService.Instance.Erro++;
                        }
                    }
                }
                else
                {
                    await WinGlobal_UIService.Instance.ProgressBarADD(ValueUniProgressBar);
                    await WinGlobal_UIService.Instance.AddMessage($"Registro: User \"{Usuario}\" - Sem registro.");
                }
            }
        }
    }
}
