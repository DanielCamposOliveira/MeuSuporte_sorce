using System;
using System.IO;
using System.Linq;
using System.Management;

namespace MeuSuporte
{
    internal class GetInformacaoDoUsuario
    {
        public void Coletar(WinExportInventory_AdicionarLinha inventario)
        {
            inventario.Adicionar("--- PASTAS PADRAO DO USUARIO ---");
            ExibirTamanhoPasta(inventario,"Desktop", Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            ExibirTamanhoPasta(inventario,"Downloads", Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads"));
            ExibirTamanhoPasta(inventario, "Documentos", Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
            ExibirTamanhoPasta(inventario, "Pictures", Environment.GetFolderPath(Environment.SpecialFolder.MyPictures));
            ExibirTamanhoPasta(inventario, "Music", Environment.GetFolderPath(Environment.SpecialFolder.MyMusic));
            ExibirTamanhoPasta(inventario, "Videos", Environment.GetFolderPath(Environment.SpecialFolder.MyVideos));
            inventario.AdicionarVazia();    
        }

        private void ExibirTamanhoPasta(WinExportInventory_AdicionarLinha inventario, string nome, string caminho)
        {
            if (Directory.Exists(caminho))
            {
                try
                {
                    long bytes = Directory.GetFiles(caminho, "*", SearchOption.TopDirectoryOnly).Sum(f => new FileInfo(f).Length);
                    inventario.Adicionar($"{nome}: {FormatBytes(bytes)}");
                    inventario.Adicionar($"{caminho}");
                    inventario.AdicionarVazia();
                }
                catch
                {
                    inventario.Adicionar($"{nome}: Acesso Negado");
                }
            }
            else
            {
                inventario.Adicionar($"{nome}: Nao encontrado");
            }
        }

        private static string FormatBytes(long bytes)
        {
            string[] suffixes = { "B", "KB", "MB", "GB", "TB" };
            int counter = 0;
            decimal readable = bytes;
            while (readable >= 1024 && counter < suffixes.Length - 1)
            {
                readable /= 1024;
                counter++;
            }
            return $"{readable:N2} {suffixes[counter]}";
        }


     

    }
}
