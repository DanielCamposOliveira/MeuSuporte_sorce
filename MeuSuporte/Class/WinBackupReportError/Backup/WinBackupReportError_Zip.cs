using System;
using System.IO.Compression;
using System.Threading.Tasks;

namespace MeuSuporte
{
    internal class WinBackupReportError_Zip
    {
        public async Task Zip(string OriginPath, string DestinationPath, string TypeReport)
        {
            try
            {
                ZipFile.CreateFromDirectory(OriginPath, DestinationPath, CompressionLevel.Optimal, false);
                await Task.Delay(500);

                await WinGlobal_UIService.Instance.Log_MensagemAsync("Backup Report Error: Arquivos de Backup do Relatorio Criado.", true);
                await Task.Delay(500);
            }
            catch (Exception)
            {
                await WinGlobal_UIService.Instance.Log_MensagemAsync("Backup Report Error: Ocorreu um Erro ao tentar criar Backup do Relatorio", true);
                await Task.Delay(500);
                WinGlobal_UIService.Instance.Erro++;
            }
        }
    }
}
