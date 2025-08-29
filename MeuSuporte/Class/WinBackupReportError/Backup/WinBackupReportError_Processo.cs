using System;
using System.Threading.Tasks;

namespace MeuSuporte
{
    internal class WinBackupReportError_Processo
    {
        private WinGlobal_DirectoryMananger DirectoryManange;
        private WinBackupReportError_Zip BackupReportError_Zip;
        private string NameFolder = "Backup Relatorio Sistema";
        public async Task backup(string Path, string NameFile, string TypeReport)
        {
            WinGlobal_UIService.Instance.token.ThrowIfCancellationRequested(); // Checa se o cancelamento foi solicitado antes de começar
            DirectoryManange = new WinGlobal_DirectoryMananger();
            BackupReportError_Zip = new WinBackupReportError_Zip();


            // verifica se diretorio dos relatorios existe
            if (!DirectoryManange.Check(Path))
            {
                WinGlobal_UIService.Instance.Erro++;
                await WinGlobal_UIService.Instance.Log_MensagemAsync($"Backup Report Error: Ocorreu um erro ao tentar acessa o diretório {TypeReport}", true);
                return;
            }

            // verifica se o diretorio dos relatorios esta vazio
            if (!DirectoryManange.GetFileListing(Path))
            {
                await WinGlobal_UIService.Instance.Log_MensagemAsync($"Backup Report Error: Não existe {TypeReport} para gera Backup", true);
                return;
            }

            // Cria o diretorio
            if (DirectoryManange.Create(NameFolder) == false)
            {
                await WinGlobal_UIService.Instance.Log_MensagemAsync($"Backup Report Error: Ocorreu um erro ao tentar criar Pasta {NameFolder}", true);
                return;
            }
            
            // gera o nome do Zip
            string FullDestinationPath = DirectoryManange.GetDirectory(NameFolder) +"\\"+ NameFile + " - " + DateTime.Now.ToString("yyyy-MM-dd_HH.mmssff") + ".zip";

            // Compacta todos os arquivos do diretorio do relatorio
            await BackupReportError_Zip.Zip(Path, FullDestinationPath, TypeReport);

        }

      
    }
}
