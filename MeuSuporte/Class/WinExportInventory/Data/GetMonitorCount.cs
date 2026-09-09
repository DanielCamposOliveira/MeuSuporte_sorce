using System.Windows.Forms;

namespace MeuSuporte
{
    internal class GetMonitorCount
    {
        public void Coletar(WinExportInventory_AdicionarLinha inventario)
        {
            inventario.Adicionar("--- MONITORES ---");
            int idx = 1;
            foreach (var screen in Screen.AllScreens)
            {
                inventario.Adicionar($"Monitor {idx++}: {screen.Bounds.Width}x{screen.Bounds.Height} {(screen.Primary ? "[Principal]" : "")}");
            }
            inventario.AdicionarVazia();
        }
    }
}
