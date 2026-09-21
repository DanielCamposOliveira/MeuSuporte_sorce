using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuSuporte
{
    internal class WinApp_Log
    {
        private readonly WinGlobal_DirectoryMananger DirectoryManange;

        public readonly List<string> linhasRelatorio = new List<string>();

        public WinApp_Log()
        {
            DirectoryManange = new WinGlobal_DirectoryMananger();
        }


        public async Task SalvarPDF()
        {
            string NameFolder = "Log";

            // Cria o diretorio
            if (DirectoryManange.Create(NameFolder) == false)
            {
                return;
            }
            string FileName = $"log_{DateTime.Now:yyyyMMdd-HHmm}.pdf";
            string caminhoArquivo = Path.Combine(DirectoryManange.GetDirectory(NameFolder), FileName);


            const int linhasPorPagina = 52;
            var paginas = new List<List<string>>();

            for (int i = 0; i < linhasRelatorio.Count; i += linhasPorPagina)
            {
                paginas.Add(linhasRelatorio.Skip(i).Take(linhasPorPagina).ToList());
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

                // Identificadores de objetos das páginas
                var pageObjIds = new List<int>();
                var contentObjIds = new List<int>();
                int idCounter = 3;

                for (int i = 0; i < totalPaginas; i++)
                {
                    pageObjIds.Add(idCounter++);
                    contentObjIds.Add(idCounter++);
                }
                int fontObjId = idCounter++;

                // Obj 2: Pages Tree
                string kidsStr = string.Join(" ", pageObjIds.Select(id => $"{id} 0 R"));
                GravarObj($"2 0 obj\n<< /Type /Pages /Kids [{kidsStr}] /Count {totalPaginas} >>\nendobj\n");

                // Criação de cada página e seu conteúdo
                for (int i = 0; i < totalPaginas; i++)
                {
                    int pId = pageObjIds[i];
                    int cId = contentObjIds[i];

                    // Objeto Page
                    GravarObj($"{pId} 0 obj\n<< /Type /Page /Parent 2 0 R /MediaBox [0 0 595 842] /Contents {cId} 0 R /Resources << /Font << /F1 {fontObjId} 0 R >> >> >>\nendobj\n");

                    // Montagem dos comandos visuais (PostScript)
                    var sbContent = new StringBuilder();
                    sbContent.Append("BT\n/F1 10 Tf\n");

                    int yAtual = 800;
                    foreach (string linha in paginas[i])
                    {
                        string safeLinha = LimparParaAscii(linha);
                        sbContent.Append($"40 {yAtual} Td\n({safeLinha}) Tj\n-40 -{yAtual} Td\n");
                        yAtual -= 14;
                    }

                    // Rodapé com numeração
                    string rodape = $"Pagina {i + 1} de {totalPaginas}";
                    sbContent.Append($"480 30 Td\n({rodape}) Tj\n-480 -30 Td\n");
                    sbContent.Append("ET");

                    string streamStr = sbContent.ToString();
                    GravarObj($"{cId} 0 obj\n<< /Length {streamStr.Length} >>\nstream\n{streamStr}\nendstream\nendobj\n");
                }

                // Objeto Fonte (Courier Monoespaçada - alinha tabelas perfeitamente)
                GravarObj($"{fontObjId} 0 obj\n<< /Type /Font /Subtype /Type1 /BaseFont /Courier >>\nendobj\n");

                // XRef Table
                writer.Flush();
                long startXref = fs.Position;
                int totalObjetos = offsets.Count + 1;

                writer.Write($"xref\n0 {totalObjetos}\n");
                writer.Write("0000000000 65535 f \n");
                foreach (long off in offsets)
                {
                    writer.Write($"{off:D10} 00000 n \n");
                }

                // Trailer
                writer.Write($"trailer\n<< /Size {totalObjetos} /Root 1 0 R >>\nstartxref\n{startXref}\n%%EOF");
                writer.Flush();
            }
        }
              
        // --- MOTOR DE GERAÇÃO PDF PURO (COM SUPORTE A MÚLTIPLAS PÁGINAS) ---
        private static string LimparParaAscii(string texto)
        {
            if (string.IsNullOrEmpty(texto)) return "";
            string normalizada = texto.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();
            foreach (char c in normalizada)
            {
                if (System.Globalization.CharUnicodeInfo.GetUnicodeCategory(c) != System.Globalization.UnicodeCategory.NonSpacingMark)
                {
                    // Trata caracteres especiais de escape de string do PDF
                    if (c == '(' || c == ')' || c == '\\') sb.Append('\\');
                    if (c >= 32 && c <= 126) sb.Append(c);
                    else sb.Append(' ');
                }
            }
            return sb.ToString();
        }



        public async Task AdicionarLinha(string texto)
        {
            linhasRelatorio.Add(texto);
        }


        public async Task AtualizarUltimaLinha(string texto)
        {
            if (linhasRelatorio.Count == 0)
            {
                AdicionarLinha(texto);
                return;
            }

            linhasRelatorio[linhasRelatorio.Count - 1] = texto;

        }

        public async Task Limpar()
        {
            linhasRelatorio.Clear();
        }



    }
}
