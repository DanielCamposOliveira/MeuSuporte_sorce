using System;
using System.Linq;
using System.Management;

namespace MeuSuporte
{
    internal class GetBatteryInfo
    {
        public void Coletar(WinExportInventory_AdicionarLinha inventario) 
        {
            inventario.Adicionar("--- BATERIA ---");
            try
            {
                using var searcher = new ManagementObjectSearcher("SELECT EstimatedChargeRemaining, BatteryStatus FROM Win32_Battery");
                var bat = searcher.Get().Cast<ManagementObject>().FirstOrDefault();
                if (bat != null)
                {
                    inventario.Adicionar($"Carga: {bat["EstimatedChargeRemaining"]}%");
                    inventario.Adicionar($"Estado: {GetBatteryStatus(Convert.ToInt16(bat["BatteryStatus"]))}");
                }
                else
                {
                    inventario.Adicionar("Sem bateria (Desktop / Ligado na Tomada)");
                }
            }
            catch
            {
                inventario.Adicionar("Informacao de bateria indisponivel.");
            }
            inventario.AdicionarVazia();
        }

        private static string GetBatteryStatus(short status)
        {
            return status switch
            {
                1 => "Descarregando",
                2 => "Carregando",
                3 => "Totalmente Carregada",
                4 => "Baixa",
                5 => "Critica",
                _ => "Desconhecido"
            };
        }
    }
}
