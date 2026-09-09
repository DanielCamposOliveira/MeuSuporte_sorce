using System;
using System.Linq;
using System.Management;
using System.Security.Principal;

namespace MeuSuporte
{
    internal class GetOsInfo
    {
        public void Coletar(WinExportInventory_AdicionarLinha inventario)
        {
            inventario.AdicionarCabecalho("Sistema Operacional");

            try
            {
                using var searcher = new ManagementObjectSearcher("SELECT Caption, Version FROM Win32_OperatingSystem");
                var os = searcher.Get().Cast<ManagementObject>().FirstOrDefault();
                if (os != null)
                {
                    inventario.Adicionar($"SO: {os["Caption"]}");
                    inventario.Adicionar($"Versao: {os["Version"]}");
                }
            }
            catch (Exception ex)
            {
                inventario.Adicionar($"Erro ao consultar SO: {ex.Message}");
            }

            bool windowsAtivado = false;
            using var buscar = new ManagementObjectSearcher(
            "SELECT LicenseStatus FROM SoftwareLicensingProduct " +
            "WHERE PartialProductKey IS NOT NULL");
            foreach (ManagementObject product in buscar.Get())
            {
                if (Convert.ToInt32(product["LicenseStatus"]) == 1)
                {
                    windowsAtivado = true;
                    break;
                }
            }
            inventario.Adicionar($"Windows ativado: {(windowsAtivado ? "Sim" : "Não")}");

            string arquitetura = Environment.Is64BitOperatingSystem ? "x64" : "x86";
            inventario.Adicionar($"Arquitetura: {arquitetura}");
            inventario.Adicionar($"Nome do Computador: {Environment.MachineName}");
            inventario.Adicionar($"Dominio: {Environment.UserDomainName}");
            inventario.Adicionar($"Usuario: {Environment.UserName}");
            inventario.Adicionar($"Admin: {(IsAdministrator() ? "Sim" : "Nao")}");
            inventario.AdicionarVazia();
        }

        private static bool IsAdministrator()
        {
            using var identity = WindowsIdentity.GetCurrent();
            var principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

    }
}
