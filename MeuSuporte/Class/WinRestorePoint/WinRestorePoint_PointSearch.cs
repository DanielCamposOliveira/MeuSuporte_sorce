using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MeuSuporte
{
    internal class WinRestorePoint_PointSearch
    {
        private readonly string[] TypePoint = {
            "Install", "Modified", "Uninstall", "Driver Install",
            "Checkpoint", "Critical Update", "Security Update",
            "Manual", "System"
        };

        public async Task<bool> IsPointCreatedAsync(string NamePoint)
        {
            List<string> ListaNamePoint = new List<string>();
            WinRestorePoint_SystemPoints systemRestorePoints = new WinRestorePoint_SystemPoints();
            bool pontoValido = false;

            // Gera as descrições esperadas
            foreach (string tipo in TypePoint)
            {
                WinGlobal_UIService.Instance.token.ThrowIfCancellationRequested(); // Checa se o cancelamento foi solicitado antes de começar
                ListaNamePoint.Add($"{tipo}: {NamePoint}");
            }

            // Procura se já existe um ponto com essas descrições
            foreach (WinRestorePoint_Item sri in systemRestorePoints)
            {
                WinGlobal_UIService.Instance.token.ThrowIfCancellationRequested(); // Checa se o cancelamento foi solicitado antes de começar

                foreach (string descricao in ListaNamePoint)
                {
                    WinGlobal_UIService.Instance.token.ThrowIfCancellationRequested(); // Checa se o cancelamento foi solicitado antes de começar

                    if (sri.Description == descricao)
                    {
                        pontoValido = true;
                        break;
                    }
                }

                if (pontoValido)
                {
                    break;
                }
            }
            return pontoValido;
        }

        public async Task<bool> PointSearch(string NamePoint, int ValueUniProgressBar)
        {
            // Procura pelo Ponto de Restauração recém-criado
            if (await IsPointCreatedAsync(NamePoint))
            {
                WinGlobal_UIService.Instance.ProgressBarADD(ValueUniProgressBar);
                await WinGlobal_UIService.Instance.Log_MensagemAsync($"Proteção do Sistema: Ponto [{NamePoint}] validado com sucesso.", true);
            }
            else
            {
                WinGlobal_UIService.Instance.Erro++;
                await WinGlobal_UIService.Instance.Log_MensagemAsync($"Proteção do Sistema: Ponto [{NamePoint}] não validado.", true);
            }
            return false;
        }
    }
}
