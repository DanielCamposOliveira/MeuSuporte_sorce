using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;

namespace MeuSuporte
{
    internal class GetDriveInfo
    {
        public void Coletar(WinExportInventory_AdicionarLinha inventario)
        {
            inventario.Adicionar("--- ARMAZENAMETO ---");

            try
            {
                // Unidades lógicas
                foreach (var drive in DriveInfo.GetDrives().Where(d => d.IsReady))
                {
                    double livre = drive.AvailableFreeSpace / (1024.0 * 1024.0 * 1024.0);
                    double total = drive.TotalSize / (1024.0 * 1024.0 * 1024.0);

                    inventario.Adicionar($"Unidade: {drive.Name}");
                    inventario.Adicionar($"  Formato: {drive.DriveFormat}");
                    inventario.Adicionar($"  Livre: {livre:F2} GB");
                    inventario.Adicionar($"  Total: {total:F2} GB");
                    inventario.AdicionarVazia();
                }

                inventario.AdicionarVazia();
                
                using var searcher = new ManagementObjectSearcher(
               "SELECT Model, Manufacturer, SerialNumber, InterfaceType, MediaType, Size " +
               "FROM Win32_DiskDrive");

                foreach (ManagementObject disk in searcher.Get())
                {
                
                    string modelo = disk["Model"]?.ToString() ?? "";
                    string fabricante = disk["Manufacturer"]?.ToString() ?? "";
                    string serial = disk["SerialNumber"]?.ToString()?.Trim() ?? "";
                    string interfaceType = disk["InterfaceType"]?.ToString() ?? "";
                    string mediaType = disk["MediaType"]?.ToString() ?? "";


                    double tamanho = 0;

                    if (disk["Size"] != null)
                    {
                        tamanho = Convert.ToDouble(disk["Size"]) /
                                  (1024.0 * 1024.0 * 1024.0);
                    }

                    inventario.Adicionar($"Disco Físico: {modelo}");
                    inventario.Adicionar($"  Fabricante: {fabricante}");
                    inventario.Adicionar($"  Serial: {serial}");
                    inventario.Adicionar($"  Interface: {interfaceType}");
                    inventario.Adicionar($"  Tipo: {mediaType}");
                    inventario.Adicionar($"  Capacidade: {tamanho:F2} GB");

                    inventario.AdicionarVazia();
                }
            }
            catch (Exception ex)
            {
                inventario.Adicionar($"Erro ao coletar discos: {ex.Message}");
            }

            inventario.AdicionarVazia();
        }

    }
}
