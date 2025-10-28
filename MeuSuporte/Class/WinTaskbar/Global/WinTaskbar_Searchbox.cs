using Microsoft.Win32;
using System;
using System.Threading.Tasks;

namespace MeuSuporte
{
    /// <summary>
    /// Desativa a barra de pesquisa
    /// 0 = Oculta
    /// 1 = Exibe o Icone
    /// 2 = Exibe a Barra de Pesquisa
    /// </summary>

    internal class WinTaskbar_Searchbox
    {
        public async Task State(bool State, RegistryKey rootKey, string subKeyPath, string usuario, int ValueUniProgressBar)
        {
            int _state = State ? 0 : 2;

            try
            {
                WinGlobal_UIService.Instance.token.ThrowIfCancellationRequested();

                using (RegistryKey? searchKey = rootKey.CreateSubKey(subKeyPath, writable: true))
                {
                    if (searchKey != null)
                    {
                        searchKey.SetValue("SearchboxTaskbarMode", _state, RegistryValueKind.DWord);
                        searchKey.SetValue("SearchboxTaskbarModeCache", _state, RegistryValueKind.DWord);
                    }
                }

                await WinGlobal_UIService.Instance.ProgressBarADD(ValueUniProgressBar);
                WinGlobal_UIService.Instance.Sucesso++;
            }
            catch (Exception)
            {
                await WinGlobal_UIService.Instance.Log_MensagemAsync($"Optimiza Barra de Tarefas: Ocorreu um Erro ao tentar alterar a Barra de Pesquisa para o usuário {usuario}.", true);
                WinGlobal_UIService.Instance.Erro++;
            }
        }
    }
}
