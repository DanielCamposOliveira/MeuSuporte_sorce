using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace MeuSuporte
{
    /// <summary>
    /// Class responsavel por gravar o arquivo no Disco
    /// </summary>
    internal class WinRegistryBackup_All_WriteFile
    {
        private readonly WinGlobal_DirectoryMananger DirectoryManange;
        public WinRegistryBackup_All_WriteFile()
        {
            DirectoryManange = new WinGlobal_DirectoryMananger();
        }

        public async Task Write(string NameUser, StringBuilder regFile, int ValueUniProgressBar)
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
          
                string NameFile = $"{NameUser}_LocalUserRun.reg";

                // Salva o arquivo 
                File.WriteAllText(DirectoryManange.GetDirectory("BackupRegistry") + "\\" + NameFile, regFile.ToString(), Encoding.Unicode);
                WinGlobal_UIService.Instance.Sucesso++;   
                await WinGlobal_UIService.Instance.Log_MensagemAsync($"Backup Registry: USER \"{NameUser}\" - Backup Chave Criada", true);

                WinGlobal_UIService.Instance.ProgressBarADD(ValueUniProgressBar);

            }
            catch (Exception ex)
            {
                WinGlobal_UIService.Instance.Erro++;
                await WinGlobal_UIService.Instance.Log_MensagemAsync($"Backup Registry: USER \"{NameUser}\" - Ocorreu um erro ao tentar criar Backup da chave", true);
            }
        }
    }
}
