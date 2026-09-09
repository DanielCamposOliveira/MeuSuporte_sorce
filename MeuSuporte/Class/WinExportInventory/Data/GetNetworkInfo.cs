using Microsoft.VisualBasic.Devices;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace MeuSuporte
{
    internal class GetNetworkInfo
    {
        public void Coletar(WinExportInventory_AdicionarLinha inventario) 
        {
            inventario.Adicionar("--- PLACAS DE REDE ---");
            try
            {
                foreach (var ni in NetworkInterface.GetAllNetworkInterfaces().Where(n => n.OperationalStatus == OperationalStatus.Up && n.NetworkInterfaceType != NetworkInterfaceType.Loopback))
                {
                    double speedMbps = ni.Speed / 1000000.0;

                    var ipProperties = ni.GetIPProperties();
                    var ipv4Properties = ipProperties.GetIPv4Properties();

                    var ipv4 = ipProperties.UnicastAddresses
                    .Where(a => a.Address.AddressFamily == AddressFamily.InterNetwork)
                    .Select(a => a.Address.ToString())
                    .FirstOrDefault() ?? "N/A";
                    string dhcp = ipv4Properties?.IsDhcpEnabled == true ? "Ativo" : "Desativado";

                    var gateways = ipProperties.GatewayAddresses
                    .Where(g => g.Address.AddressFamily == AddressFamily.InterNetwork)
                    .Select(g => g.Address.ToString());

                    var dns = ipProperties.DnsAddresses
                    .Where(d => d.AddressFamily == AddressFamily.InterNetwork)
                    .Select(d => d.ToString());


                    inventario.Adicionar($"Interface: {ni.Name}");
                    inventario.Adicionar($"Descrição: {ni.Description}");
                    inventario.Adicionar($"Tipo: {ni.NetworkInterfaceType}");
                    inventario.Adicionar($"Status: {ni.OperationalStatus}");
                    inventario.Adicionar($"IP: {ipv4}");
                    inventario.Adicionar($"Gateway: {string.Join(", ", gateways)}");
                    inventario.Adicionar($"DNS: {string.Join(", ", dns)}");
                    inventario.Adicionar($"DHCP: {dhcp}");
                    inventario.Adicionar($"Velocidade: {speedMbps:F0} Mbps");
                    inventario.Adicionar($"MAC: {ni.GetPhysicalAddress().ToString()}");
                    inventario.AdicionarVazia();
                }
            }
            catch { }
            inventario.AdicionarVazia();
        }
    }
}
