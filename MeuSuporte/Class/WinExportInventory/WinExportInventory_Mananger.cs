using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace MeuSuporte
{
    internal class WinExportInventory_Mananger
    {
        public async Task Mananger()
        {
            try
            {
                await WinGlobal_UIService.Instance.Log_MensagemAsync($"ExportInventory: Colentando dados....", true);

                // 1. Instancia o acumulador de linhas
                var inventario = new WinExportInventory_AdicionarLinha();

                // Linhas iniciais de cabeçalho
                inventario.Adicionar("==================================================================");
                inventario.Adicionar($"RELATORIO DE INVENTARIO - {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
                inventario.Adicionar("==================================================================");
                inventario.AdicionarVazia();

                // 2. Executa a classe GetOsInfo (e outras futuras classes de coleta)
                var osInfo = new GetOsInfo();
                osInfo.Coletar(inventario);

                var CpuInfo = new GetCpuInfo();
                CpuInfo.Coletar(inventario);

                var RamInfo = new GetRamInfo();
                RamInfo.Coletar(inventario);

                var MotherboardInfo = new GetMotherboardInfo();
                MotherboardInfo.Coletar(inventario);

                var MachineUUID = new GetMachineUUID();
                MachineUUID.Coletar(inventario);

                var GpuInfo = new GetGpuInfo();
                GpuInfo.Coletar(inventario);

                var DriveInfo = new GetDriveInfo();
                DriveInfo.Coletar(inventario);

                var NetworkInfo = new GetNetworkInfo();
                NetworkInfo.Coletar(inventario);

                var BatteryInfo = new GetBatteryInfo();
                BatteryInfo.Coletar(inventario);

                var MonitorCount = new GetMonitorCount();
                MonitorCount.Coletar(inventario);

                var SystemUptime = new GetSystemUptime();
                SystemUptime.Coletar(inventario);

                var InformacaoDoUsuario = new GetInformacaoDoUsuario();
                InformacaoDoUsuario.Coletar(inventario);

                var ProgramInstalled = new GetProgramInstalled();
                ProgramInstalled.Coletar(inventario);

                // 3. Define o caminho e passa tudo para o gravador de PDF
                //string caminhoArquivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"Relatorio_{DateTime.Now:yyyyMMdd_HHmmss}.pdf");

                var pdfWriter = new EscreverPdfNativo();
               await pdfWriter.Gerar(inventario);

                await WinGlobal_UIService.Instance.Log_MensagemAsync($"ExportInventory: pdf gerado", true);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro durante o processo: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
    }
}
