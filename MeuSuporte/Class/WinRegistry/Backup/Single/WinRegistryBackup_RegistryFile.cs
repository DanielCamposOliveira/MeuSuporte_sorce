using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MeuSuporte
{
    internal class WinRegistryBackup_RegistryFile
    {

        private readonly WinGlobal_DirectoryMananger DirectoryManange;

        public WinRegistryBackup_RegistryFile()
        {
            DirectoryManange = new WinGlobal_DirectoryMananger();
        }

        public async Task Write(string NameFolder, StringBuilder regFile, int ValueUniProgressBar )
        {
            try
            {
                WinGlobal_UIService.Instance.token.ThrowIfCancellationRequested(); // Checa se o cancelamento foi solicitado antes de começar

                // Cria o diretorio
                if (!DirectoryManange.Create("BackupRegistry"))
                {
                    await WinGlobal_UIService.Instance.Log_MensagemAsync("Ocorreu um erro ao tentar criar Pasta BackupRegistry", true);
                    return;
                }
                
                // Salva o arquivo 
                File.WriteAllText(DirectoryManange.GetDirectory("BackupRegistry") + "\\" + NameFolder, regFile.ToString(), Encoding.Unicode);
                WinGlobal_UIService.Instance.Sucesso++;
                WinGlobal_UIService.Instance.ProgressBarADD(ValueUniProgressBar);

                await WinGlobal_UIService.Instance.Log_MensagemAsync($"Backup Registry: \"{NameFolder}\" - Backup Chave Criada", true);
            }
            catch(Exception ex)
            {
                WinGlobal_UIService.Instance.Erro++;
                await WinGlobal_UIService.Instance.Log_MensagemAsync("Ocorreu um erro ao BackupRegistry: " + ex.Message, true);
            }
        }
    }
}
