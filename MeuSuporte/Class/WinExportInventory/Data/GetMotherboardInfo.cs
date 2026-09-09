using System.Linq;
using System.Management;

namespace MeuSuporte
{
    internal class GetMotherboardInfo
    {
        public void Coletar(WinExportInventory_AdicionarLinha inventario) 
        {
            inventario.Adicionar("--- PLACA-MAE ---");
            try
            {
                using var searcher = new ManagementObjectSearcher("SELECT Manufacturer, Product, SerialNumber FROM Win32_BaseBoard");
                var mb = searcher.Get().Cast<ManagementObject>().FirstOrDefault();
                if (mb != null)
                {
                    inventario.Adicionar($"Fabricante: {mb["Manufacturer"]}");
                    inventario.Adicionar($"Modelo: {mb["Product"]}");
                    inventario.Adicionar($"Serial: {mb["SerialNumber"]}");
                }
            }
            catch { }
            inventario.AdicionarVazia();
        }
    }
}
