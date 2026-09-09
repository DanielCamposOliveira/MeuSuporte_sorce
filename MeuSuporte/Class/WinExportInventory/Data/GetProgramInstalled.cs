using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace MeuSuporte
{
    internal class GetProgramInstalled
    {
        public void Coletar(WinExportInventory_AdicionarLinha inventario)
        {
            inventario.Adicionar("--- PROGRAMAS INSTALADOS ---");

            var programas = new List<ProgramaInstalado>();

            var registryKeys = new[]
            {
                Registry.LocalMachine.OpenSubKey(
                    @"Software\Microsoft\Windows\CurrentVersion\Uninstall"),

                Registry.LocalMachine.OpenSubKey(
                    @"Software\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall"),

                Registry.CurrentUser.OpenSubKey(
                    @"Software\Microsoft\Windows\CurrentVersion\Uninstall")
            };

            var trustedList = new trustedProgramList();

            foreach (var key in registryKeys.Where(k => k != null))
            {
                using (key)
                {
                    foreach (string subKeyName in key.GetSubKeyNames())
                    {
                        using (RegistryKey subKey = key.OpenSubKey(subKeyName))
                        {
                            if (subKey == null)
                                continue;

                            string displayName =
                                subKey.GetValue("DisplayName") as string;

                            string displayVersion =
                                subKey.GetValue("DisplayVersion") as string;

                            string installDateString =
                                subKey.GetValue("InstallDate") as string;

                            // Ignora entradas sem nome
                            if (string.IsNullOrWhiteSpace(displayName))
                                continue;

                            displayName = displayName.Trim();
                            displayVersion = displayVersion?.Trim();

                            // Ignora programas confiáveis/sistema
                            if (trustedList.Name.Any(trustedName =>
                                displayName.Contains(
                                    trustedName,
                                    StringComparison.OrdinalIgnoreCase)))
                            {
                                continue;
                            }

                            DateTime installDate = DateTime.MinValue;

                            if (!string.IsNullOrWhiteSpace(installDateString))
                            {
                                DateTime.TryParseExact(
                                    installDateString,
                                    "yyyyMMdd",
                                    CultureInfo.InvariantCulture,
                                    DateTimeStyles.None,
                                    out installDate);
                            }

                            programas.Add(new ProgramaInstalado
                            {
                                DisplayName = displayName,
                                DisplayVersion = displayVersion,
                                InstallDate = installDate
                            });
                        }
                    }
                }
            }

            // Remove duplicados por Nome + Versão
            programas = programas
                .GroupBy(p => new
                {
                    Nome = p.DisplayName,
                    Versao = p.DisplayVersion
                })
                .Select(g => g.First())
                .OrderBy(p => p.DisplayName)
                .ToList();

            // Agora grava no arquivo
            foreach (var programa in programas)
            {
                inventario.Adicionar(
                    $"Nome: {programa.DisplayName}");

                inventario.Adicionar(
                    $"Versão: {programa.DisplayVersion}");

                inventario.Adicionar(
                    $"Data de instalação: " +
                    (programa.InstallDate == DateTime.MinValue
                        ? "Não informada"
                        : programa.InstallDate.ToString("dd/MM/yyyy")));

                inventario.AdicionarVazia();
            }
        }

        private class ProgramaInstalado
        {
            public string DisplayName { get; set; }
            public string DisplayVersion { get; set; }
            public DateTime InstallDate { get; set; }
        }

        private class trustedProgramList
        {
            public readonly string[] Name =
            {
                "Microsoft",
                "Windows",
                "SDK",
                "vs_",
                "VS",
                ".NET",
                "Framework"
            };
        }
    }
}
