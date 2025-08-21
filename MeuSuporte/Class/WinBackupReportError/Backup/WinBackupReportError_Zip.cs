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
                await WinGlobal_UIService.Instance.Log_MensagemAsync("BackupReportError: Gerando Zip dos arquivos do Relatorio...", true);
                await Task.Delay(500);

                ZipFile.CreateFromDirectory(OriginPath, DestinationPath, CompressionLevel.Optimal, false);
                await Task.Delay(500);

                await WinGlobal_UIService.Instance.Log_MensagemAsync("BackupReportError: Zip dos arquivos do Relatorio Criado ...", true);
                await Task.Delay(500);
            }
            catch (Exception)
            {
                await WinGlobal_UIService.Instance.Log_MensagemAsync("BackupReportError: Erro ao tentar Gerar Zip dos arquivos do Relatorio...", true);
                await Task.Delay(500);
                WinGlobal_UIService.Instance.Erro++;
            }
        }
    }
}
