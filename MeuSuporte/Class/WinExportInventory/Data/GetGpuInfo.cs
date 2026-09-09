using System;
using System.Management;

namespace MeuSuporte
{
    internal class GetGpuInfo
    {
        public void Coletar(WinExportInventory_AdicionarLinha inventario) 
        {
            inventario.Adicionar("--- PLACA DE VIDEO (GPU) ---");
            try
            {
                using var searcher = new ManagementObjectSearcher("SELECT Name, AdapterRAM FROM Win32_VideoController");
                foreach (var obj in searcher.Get())
                {
                    long ram = Convert.ToInt64(obj["AdapterRAM"] ?? 0) / (1024 * 1024);
                    inventario.Adicionar($"Dispositivo: {obj["Name"]} (VRAM: {ram} MB)");
                }
            }
            catch { }
            inventario.AdicionarVazia();
        }
    }
}
