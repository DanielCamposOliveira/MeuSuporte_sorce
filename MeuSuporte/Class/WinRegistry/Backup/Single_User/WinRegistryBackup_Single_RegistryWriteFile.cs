using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace MeuSuporte
{
    // 4
    /// <summary>
    /// Class Responsavel por gravar o arquivo do registro no Disco
    /// </summary>

    internal class WinRegistryBackup_Single_RegistryWriteFile
    {        
        private readonly WinGlobal_DirectoryMananger DirectoryManange;

        public WinRegistryBackup_Single_RegistryWriteFile()
        {
            DirectoryManange = new WinGlobal_DirectoryMananger();
        }

        public async Task Write(string Name, StringBuilder regFile, int ValueUniProgressBar )
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

                string NameFile = $"{Name}_LocalUserRun.reg";

                // Salva o arquivo 
                File.WriteAllText(DirectoryManange.GetDirectory("BackupRegistry") + "\\" + NameFile, regFile.ToString(), Encoding.Unicode);
                WinGlobal_UIService.Instance.Sucesso++;
                await WinGlobal_UIService.Instance.ProgressBarADD(ValueUniProgressBar);

                await WinGlobal_UIService.Instance.Log_MensagemAsync($"Backup Registry: User \"{Name}\" - Backup Chave Criada", true);
            }
            catch(Exception ex)
            {
                WinGlobal_UIService.Instance.Erro++;
                await WinGlobal_UIService.Instance.Log_MensagemAsync("Ocorreu um erro ao BackupRegistry: " + ex.Message, true);
            }
        }
    }
}
