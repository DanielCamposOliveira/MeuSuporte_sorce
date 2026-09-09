using System.Linq;
using System.Management;

namespace MeuSuporte
{
    internal class GetCpuInfo
    {
        public void Coletar(WinExportInventory_AdicionarLinha inventario)
        {
            inventario.Adicionar("--- PROCESSADOR (CPU) ---");
            try
            {
                using var searcher = new ManagementObjectSearcher("SELECT Name, Manufacturer, CurrentClockSpeed, NumberOfCores, NumberOfLogicalProcessors FROM Win32_Processor");
                var cpu = searcher.Get().Cast<ManagementObject>().FirstOrDefault();
                if (cpu != null)
                {
                    inventario.Adicionar($"Processador: {cpu["Name"]?.ToString()?.Trim()}");
                    inventario.Adicionar($"Fabricante: {cpu["Manufacturer"]}");
                    inventario.Adicionar($"Clock: {cpu["CurrentClockSpeed"]} MHz");
                    inventario.Adicionar($"Nucleos/Threads: {cpu["NumberOfCores"]} Cores / {cpu["NumberOfLogicalProcessors"]} Threads");
                }
            }
            catch { }
            inventario.AdicionarVazia();
        }
    }
}
