using Microsoft.Win32;
using System;
using System.Threading.Tasks;

namespace MeuSuporte
{
    /// <summary>
    /// Desativa o Botão de Visão de Tarefas
    /// 0 = Oculta
    /// 1 = Exibe o Icone
    /// </summary>

    internal class WinTaskbar_TaskView
    {
        public async Task Changes(bool State, RegistryKey rootKey, string subKeyPath, string usuario, int ValueUniProgressBar)
        {
            int _state = State ? 0 : 1;

            try
            {
                WinGlobal_UIService.Instance.token.ThrowIfCancellationRequested();

                using (RegistryKey? searchKey = rootKey.CreateSubKey(subKeyPath, writable: true))
                {
                    if (searchKey != null)
                    {
                        searchKey.SetValue("ShowTaskViewButton", _state, RegistryValueKind.DWord);
                    }
                }

                await WinGlobal_UIService.Instance.ProgressBarADD(ValueUniProgressBar);
                WinGlobal_UIService.Instance.Sucesso++;
            }
            catch (Exception)
            {
                await WinGlobal_UIService.Instance.AddMessage($"Optimiza Barra de Tarefas: Ocorreu um Erro ao tentar alterar o Icone Visão de Tarefas para o usuário {usuario}.");
                WinGlobal_UIService.Instance.Erro++;
            }
        }
    }
}
