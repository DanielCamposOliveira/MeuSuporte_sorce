using System.Linq;
using System.Management;

namespace MeuSuporte
{
    internal class GetMachineUUID
    {
        public void Coletar(WinExportInventory_AdicionarLinha inventario) 
        {
            try
            {
                using var searcher = new ManagementObjectSearcher("SELECT UUID FROM Win32_ComputerSystemProduct");
                var obj = searcher.Get().Cast<ManagementObject>().FirstOrDefault();
                if (obj != null)
                {
                    inventario.Adicionar($"UUID da Maquina: {obj["UUID"]}");
                    inventario.AdicionarVazia();
                }
            }
            catch { }
        }
    }
}
