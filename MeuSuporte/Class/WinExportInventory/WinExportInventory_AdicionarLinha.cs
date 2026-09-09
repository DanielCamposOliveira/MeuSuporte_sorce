using System.Collections.Generic;

namespace MeuSuporte
{
    internal class WinExportInventory_AdicionarLinha
    {
        private readonly List<string> _linhas = new List<string>();

        public void Adicionar(string linha)
        {
            _linhas.Add(linha);
        }

        public void AdicionarVazia()
        {
            _linhas.Add(string.Empty);
        }

        public void AdicionarCabecalho(string titulo)
        {
            _linhas.Add($"--- {titulo.ToUpper()} ---");
        }

        public List<string> ObterTodasLinhas()
        {
            return _linhas;
        }

        public void Limpar()
        {
            _linhas.Clear();
        }

    }
}
