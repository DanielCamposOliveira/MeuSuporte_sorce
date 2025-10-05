using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MeuSuporte
{
    internal class WinDirectory_ListFiles
    {
        private readonly WinDirectory_File _WinDirectory_File;
        private readonly WinDirectory_Folder _WinDirectory_Folder;
        private int CountFileDeleted = 0;
        private int CountFoldersDeleted = 0;
                
        public WinDirectory_ListFiles()
        {
            _WinDirectory_File = new WinDirectory_File();
            _WinDirectory_Folder = new WinDirectory_Folder();
        }

        public async Task Remove(int ValueUniProgressBar, string PathFolder, string _NameFolder )
        {
            try
            {
                DirectoryInfo directory = new DirectoryInfo(PathFolder);
                var files = directory.EnumerateFiles("*.*", SearchOption.AllDirectories);
                var folders = directory.EnumerateDirectories();
                     
                int ValueUniBar = ValueUniProgressBar;
                int total = directory.EnumerateFiles("*.*", SearchOption.AllDirectories).Count() + folders.Count();// + pastas.Count;
                float valorUnidade = (float)ValueUniBar / total;
                float valorAcumulado = 0f;
                int loop = 0;

                foreach (var file in files)
                {
                    WinGlobal_UIService.Instance.token.ThrowIfCancellationRequested(); // Checa se o cancelamento foi solicitado antes de começar

                    loop++;
                    valorAcumulado += valorUnidade;
                    if (valorAcumulado >= 1)
                    {
                        await WinGlobal_UIService.Instance.ProgressBarADD(1);
                        valorAcumulado -= 1;
                        await WinGlobal_UIService.Instance.Log_MensagemAsyncSobrescrever($"Apagando arquivos {total} / {loop} da Pasta: {_NameFolder}");
                        await Task.Delay(20);
                    }                    
                    // apaga o arquivo, se retorna = true converta para 1 e false para 0
                    CountFileDeleted += await _WinDirectory_File.Delete(file.FullName) ? 1 : 0;
                }


                foreach (var folder in folders)
                {
                    WinGlobal_UIService.Instance.token.ThrowIfCancellationRequested(); // Checa se o cancelamento foi solicitado antes de começar

                    loop++;
                    valorAcumulado += valorUnidade;
                    if (valorAcumulado >= 1)
                    {
                        await WinGlobal_UIService.Instance.ProgressBarADD(1);
                        valorAcumulado -= 1;
                        await WinGlobal_UIService.Instance.Log_MensagemAsyncSobrescrever($"Apagando arquivos {total} / {loop} da Pasta: {_NameFolder}");
                        await Task.Delay(20);
                    }
                    // apaga o arquivo, se retorna = true converta para 1 e false para 0
                    CountFoldersDeleted += await _WinDirectory_Folder.Delete(folder.FullName) ? 1 : 0;
                }
                                
                WinGlobal_UIService.Instance.Sucesso++;
                await Task.Delay(1000);
            }
            catch (Exception ex)
            {
                WinGlobal_UIService.Instance.Erro++;
            }
        }


        public int countFileDeleted
        {
            get { return CountFileDeleted; } // retorna o valor
        }                

        public int countFoldersDeleted
        {
            get { return CountFoldersDeleted; } // retorna o valor
        }

    }
}
