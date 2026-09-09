using System;

namespace MeuSuporte
{
    internal class GetSystemUptime
    {
        public void Coletar(WinExportInventory_AdicionarLinha inventario)
        {
            var uptime = TimeSpan.FromMilliseconds(Environment.TickCount);
            inventario.Adicionar($"Tempo de Atividade (Uptime): {uptime.Days} dias, {uptime.Hours} horas e {uptime.Minutes} minutos ({uptime.TotalHours:F2} horas)");
            inventario.AdicionarVazia();
        }
    }
}
