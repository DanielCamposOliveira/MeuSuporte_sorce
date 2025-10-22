using System;
using System.IO;

namespace MeuSuporte
{
    internal class Class_Temporaria
    {
        public static void LerArquivoComUsing(string caminhoDoArquivo)
        {
            Console.WriteLine("--- Iniciando a Leitura do Arquivo ---");

            // 1. O 'using' é aplicado ao objeto 'reader' que implementa IDisposable (StreamReader)
            try
            {
                using (StreamReader reader = new StreamReader(caminhoDoArquivo))
                {
                    // Este bloco de código usa o recurso (o arquivo aberto).
                    string linha1 = reader.ReadLine();
                    Console.WriteLine($"Conteúdo da Linha 1: {linha1}");

                    // Imagine que algo dê errado aqui...
                    // int divisor = 0;
                    // int resultado = 10 / divisor; // Isso causaria um erro (exceção).

                    // Mesmo que ocorra uma exceção, o arquivo será fechado.

                    string linha2 = reader.ReadLine();
                    Console.WriteLine($"Conteúdo da Linha 2: {linha2}");

                } // 2. Ao sair deste bloco 'using', o método reader.Dispose() é chamado AUTOMATICAMENTE.
                  // Isso garante que o arquivo no disco seja FECHADO e liberado.

                Console.WriteLine("Arquivo foi fechado e liberado pelo 'using'.");

            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"ERRO: Arquivo não encontrado em: {caminhoDoArquivo}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro, mas o arquivo foi fechado: {ex.Message}");
            }
        }


        // Para fins de comparação, o código ACIMA é equivalente a este código MAIS LONGO:

        public static void LerArquivoSemUsing(string caminhoDoArquivo)
        {
            StreamReader reader = null; // Inicializa a variável fora do try
            try
            {
                reader = new StreamReader(caminhoDoArquivo);
                // ... código para ler o arquivo ...
            }
            catch (Exception)
            {
                // ... tratamento de erro ...
            }
            finally
            {
                // O 'finally' garante que esta parte seja executada,
                // independentemente de o 'try' ter sido bem-sucedido ou ter falhado.
                if (reader != null)
                {
                    reader.Dispose(); // Fechamento manual do recurso.
                }
            }
        }

    }
}
