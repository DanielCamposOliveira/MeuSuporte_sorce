using Microsoft.Win32;
using System;
using System.Threading.Tasks;

namespace MeuSuporte
{
    /// <summary>
    /// Desativa o ícone Saiba, que fica na Area de Trabalhor
    /// 1 = Oculta
    /// 0 = Exibe o Icone
    /// </summary>
    internal class WinTaskbar_IconLearn
    {
        public async Task State(bool State, RegistryKey rootKey, string subKeyPath, string usuario, int ValueUniProgressBar)
        {
            int _state = State ? 1 : 0;

            try
            {
                WinGlobal_UIService.Instance.token.ThrowIfCancellationRequested();

                using (RegistryKey? searchKey = rootKey.CreateSubKey(subKeyPath, writable: true))
                {
                    if (searchKey != null)
                    {
                        searchKey?.SetValue("{2cc5ca98-6485-489a-920e-b3e88a6ccce3}", _state, RegistryValueKind.DWord);
                    }
                }

                await WinGlobal_UIService.Instance.ProgressBarADD(ValueUniProgressBar);
                WinGlobal_UIService.Instance.Sucesso++;
            }
            catch (Exception)
            {
                await WinGlobal_UIService.Instance.Log_MensagemAsync($"Optimiza Barra de Tarefas: Ocorreu um Erro ao tentar alterar ícone Saiba. para o usuário {usuario}.", true);
                WinGlobal_UIService.Instance.Erro++;
            }
        }
    }
}
