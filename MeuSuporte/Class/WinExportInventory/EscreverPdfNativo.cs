using MeuSuporte;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuSuporte
{
    internal class EscreverPdfNativo
    {
        private readonly WinGlobal_DirectoryMananger DirectoryManange;

        private const int LinhasPorPagina = 52;

        public EscreverPdfNativo()
        {
            DirectoryManange = new WinGlobal_DirectoryMananger();
        }


        public async Task Gerar(WinExportInventory_AdicionarLinha inventario)
        {
            // string caminhoArquivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"Relatorio_{DateTime.Now:yyyyMMdd_HHmmss}.pdf");
            string NameFile = $"Inventario_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
            string caminhoArquivo;

            try
            {
                WinGlobal_UIService.Instance.token.ThrowIfCancellationRequested(); // Checa se o cancelamento foi solicitado antes de começar

                // Cria o diretorio
                if (!DirectoryManange.Create("Inventario"))
                {
                    await WinGlobal_UIService.Instance.AddMessage("Ocorreu um erro ao tentar criar Pasta Inventario");
                    return;
                }

                caminhoArquivo = DirectoryManange.GetDirectory("Inventario") + "\\" + NameFile;

                List<string> linhas = inventario.ObterTodasLinhas();

                var paginas = new List<List<string>>();
                for (int i = 0; i < linhas.Count; i += LinhasPorPagina)
                {
                    paginas.Add(linhas.Skip(i).Take(LinhasPorPagina).ToList());
                }

                int totalPaginas = paginas.Count == 0 ? 1 : paginas.Count;
                if (paginas.Count == 0) paginas.Add(new List<string> { "Nenhum dado coletado." });

                using (var fs = new FileStream(caminhoArquivo, FileMode.Create, FileAccess.Write))
                using (var writer = new StreamWriter(fs, Encoding.ASCII))
                {
                    var offsets = new List<long>();

                    void GravarObj(string conteudo)
                    {
                        writer.Flush();
                        offsets.Add(fs.Position);
                        writer.Write(conteudo);
                        writer.Flush();
                    }

                    writer.Write("%PDF-1.4\n");
                    writer.Flush();

                    // Obj 1: Catalog
                    GravarObj("1 0 obj\n<< /Type /Catalog /Pages 2 0 R >>\nendobj\n");

                    var pageObjIds = new List<int>();
                    var contentObjIds = new List<int>();
                    int idCounter = 3;

                    for (int i = 0; i < totalPaginas; i++)
                    {
                        pageObjIds.Add(idCounter++);
                        contentObjIds.Add(idCounter++);
                    }
                    int fontObjId = idCounter++;

                    // Obj 2: Árvore de Páginas
                    string kidsStr = string.Join(" ", pageObjIds.Select(id => $"{id} 0 R"));
                    GravarObj($"2 0 obj\n<< /Type /Pages /Kids [{kidsStr}] /Count {totalPaginas} >>\nendobj\n");

                    // Páginas individuais
                    for (int i = 0; i < totalPaginas; i++)
                    {
                        int pId = pageObjIds[i];
                        int cId = contentObjIds[i];

                        GravarObj($"{pId} 0 obj\n<< /Type /Page /Parent 2 0 R /MediaBox [0 0 595 842] /Contents {cId} 0 R /Resources << /Font << /F1 {fontObjId} 0 R >> >> >>\nendobj\n");

                        var sbContent = new StringBuilder();
                        sbContent.Append("BT\n/F1 10 Tf\n");

                        int yAtual = 800;
                        foreach (string linha in paginas[i])
                        {
                            string safeLinha = LimparParaAscii(linha);
                            sbContent.Append($"40 {yAtual} Td\n({safeLinha}) Tj\n-40 -{yAtual} Td\n");
                            yAtual -= 14;
                        }

                        string rodape = $"Pagina {i + 1} de {totalPaginas}";
                        sbContent.Append($"480 30 Td\n({rodape}) Tj\n-480 -30 Td\n");
                        sbContent.Append("ET");

                        string streamStr = sbContent.ToString();
                        GravarObj($"{cId} 0 obj\n<< /Length {streamStr.Length} >>\nstream\n{streamStr}\nendstream\nendobj\n");
                    }

                    // Fonte Monospaced Courier
                    GravarObj($"{fontObjId} 0 obj\n<< /Type /Font /Subtype /Type1 /BaseFont /Courier >>\nendobj\n");

                    writer.Flush();
                    long startXref = fs.Position;
                    int totalObjetos = offsets.Count + 1;

                    writer.Write($"xref\n0 {totalObjetos}\n");
                    writer.Write("0000000000 65535 f \n");
                    foreach (long off in offsets)
                    {
                        writer.Write($"{off:D10} 00000 n \n");
                    }

                    writer.Write($"trailer\n<< /Size {totalObjetos} /Root 1 0 R >>\nstartxref\n{startXref}\n%%EOF");
                    writer.Flush();
                }

            }
            catch (Exception ex) 
            {
                WinGlobal_UIService.Instance.Erro++;
                await WinGlobal_UIService.Instance.AddMessage("Ocorreu um erro ao ExportInventory: " + ex.Message);
            }            
        }

        private static string LimparParaAscii(string texto)
        {
            if (string.IsNullOrEmpty(texto)) return "";
            string normalizada = texto.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();
            foreach (char c in normalizada)
            {
                if (System.Globalization.CharUnicodeInfo.GetUnicodeCategory(c) != System.Globalization.UnicodeCategory.NonSpacingMark)
                {
                    if (c == '(' || c == ')' || c == '\\') sb.Append('\\');
                    if (c >= 32 && c <= 126) sb.Append(c);
                    else sb.Append(' ');
                }
            }
            return sb.ToString();
        }
    }
}