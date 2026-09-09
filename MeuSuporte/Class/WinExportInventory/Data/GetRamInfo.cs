using System;
using System.Linq;
using System.Management;

namespace MeuSuporte
{
    internal class GetRamInfo
    {
        public void Coletar(WinExportInventory_AdicionarLinha inventario) 
        {
            inventario.Adicionar("--- MEMORIA RAM ---");
            try
            {
                using var searcher = new ManagementObjectSearcher("SELECT DeviceLocator, Capacity, ConfiguredClockSpeed FROM Win32_PhysicalMemory");
                long totalBytes = 0;
                foreach (var obj in searcher.Get())
                {
                    long cap = Convert.ToInt64(obj["Capacity"]);
                    totalBytes += cap;
                    inventario.Adicionar($"Modulo {obj["DeviceLocator"]}: {(cap / (1024.0 * 1024 * 1024)):F2} GB ({obj["ConfiguredClockSpeed"]} MHz)");
                }
                inventario.Adicionar($"Capacidade Total Instalada: {(totalBytes / (1024.0 * 1024 * 1024)):F2} GB");

                using var osSearcher = new ManagementObjectSearcher("SELECT TotalVisibleMemorySize, FreePhysicalMemory FROM Win32_OperatingSystem");
                var osRam = osSearcher.Get().Cast<ManagementObject>().FirstOrDefault();
                if (osRam != null)
                {
                    double freeGb = Convert.ToDouble(osRam["FreePhysicalMemory"]) / (1024.0 * 1024.0);
                    double totalGb = Convert.ToDouble(osRam["TotalVisibleMemorySize"]) / (1024.0 * 1024.0);
                    inventario.Adicionar($"Memoria Usada / Livre: {(totalGb - freeGb):F2} GB / {freeGb:F2} GB");
                }
            }
            catch { }
            inventario.AdicionarVazia();
        }
    }
}
