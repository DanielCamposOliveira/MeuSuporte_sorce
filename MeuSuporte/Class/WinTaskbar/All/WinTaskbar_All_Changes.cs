using Microsoft.Win32;
using System;
using System.Drawing;
using System.Threading.Tasks;

namespace MeuSuporte
{
    // 3
    /// <summary>
    /// Class responsavel por Alterar todos os registro do Usuario
    /// </summary>
    
    internal class WinTaskbar_All_Changes
    {
        public WinTaskbar_All_Changes() 
        {
        }

        public async Task Changes(bool State, string tempHiveName, string usuario, int ValueUniProgressBar)
        {
            await Searchbox(State, tempHiveName, ValueUniProgressBar / 3);
            await IconLearn(State, tempHiveName, ValueUniProgressBar / 3);
            await TaskView(State, tempHiveName, ValueUniProgressBar / 3);

            await WinGlobal_UIService.Instance.Log_MensagemAsync($"Optimiza Barra de Tarefas: User \"{usuario}\" - Configurações Alteradas", true);
        }

        private async Task Searchbox(bool State, string tempHiveName, int ValueUniProgressBar)
        {
            int _state = State ? 0 : 2;

            try
            {
                WinGlobal_UIService.Instance.token.ThrowIfCancellationRequested(); // Checa se o cancelamento foi solicitado antes de começar

                string searchKeyPath = @$"{tempHiveName}\Software\Microsoft\Windows\CurrentVersion\Search";
                using (RegistryKey? searchKey = Registry.Users.CreateSubKey(searchKeyPath))
                {
                    searchKey?.SetValue("SearchboxTaskbarMode", _state, RegistryValueKind.DWord);
                    searchKey?.SetValue("SearchboxTaskbarModeCache", _state, RegistryValueKind.DWord);
                }

                await WinGlobal_UIService.Instance.ProgressBarADD(ValueUniProgressBar);
                WinGlobal_UIService.Instance.Sucesso++;
            }
            catch (Exception)
            {
                await WinGlobal_UIService.Instance.Log_MensagemAsync("Optimiza Barra de Tarefas: Ocorreu um Erro ao tentar alterar a Barra de Pesquisa.", true);
                WinGlobal_UIService.Instance.Erro++;
            }
        }

        // Removendo ícone Saiba mais sobre esta imagem da Área de Trabalho
        private async Task IconLearn(bool State, string tempHiveName, int ValueUniProgressBar)
        {
            int _state = State ? 0 : 1;

            try
            {
                WinGlobal_UIService.Instance.token.ThrowIfCancellationRequested(); // Checa se o cancelamento foi solicitado antes de começar


                string NewStartPanelKeyPath = @$"{tempHiveName}\Software\Microsoft\Windows\CurrentVersion\Explorer\HideDesktopIcons\NewStartPanel";
                using (RegistryKey? NewStartPaneKey = Registry.Users.CreateSubKey(NewStartPanelKeyPath))
                {
                    NewStartPaneKey?.SetValue("{2cc5ca98-6485-489a-920e-b3e88a6ccce3}", _state, RegistryValueKind.DWord);
                }

                await WinGlobal_UIService.Instance.ProgressBarADD(ValueUniProgressBar);
                WinGlobal_UIService.Instance.Sucesso++;
            }
            catch (Exception)
            {
                await WinGlobal_UIService.Instance.Log_MensagemAsync("Optimiza Barra de Tarefas: Ocorreu um Erro ao tentar alterar ícone Saiba.", true);
                WinGlobal_UIService.Instance.Erro++;
            }
        }

        // Desativa o Botão de Visão de Tarefas
        private async Task TaskView(bool State, string tempHiveName, int ValueUniProgressBar)
        {
            int _state = State ? 0 : 1;

            try
            {
                WinGlobal_UIService.Instance.token.ThrowIfCancellationRequested(); // Checa se o cancelamento foi solicitado antes de começar

                // Desativa o Botão de Visão de Tarefas
                string TaskViewButtonPath = @$"{tempHiveName}\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced";
                using (RegistryKey? TaskViewButtonKey = Registry.Users.CreateSubKey(TaskViewButtonPath))
                {
                    TaskViewButtonKey?.SetValue("ShowTaskViewButton", _state, RegistryValueKind.DWord);
                }

                await WinGlobal_UIService.Instance.ProgressBarADD(ValueUniProgressBar);
                WinGlobal_UIService.Instance.Sucesso++;
            }
            catch (Exception)
            {
                await WinGlobal_UIService.Instance.Log_MensagemAsync("Optimiza Barra de Tarefas: Ocorreu um Erro ao tentar alterar Visão de Tarefas.", true);
                WinGlobal_UIService.Instance.Erro++;
            }
        }



    }
}
