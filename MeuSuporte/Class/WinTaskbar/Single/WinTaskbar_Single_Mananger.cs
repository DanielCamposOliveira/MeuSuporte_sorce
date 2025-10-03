using Microsoft.Win32;
using System;
using System.Threading.Tasks;

namespace MeuSuporte
{
    // 3
    /// <summary>
    /// Class responsavel por Alterar todos os registro do Usuario
    /// </summary>
    
    internal class WinTaskbar_Single_Mananger
    {
        public async Task Changes(bool State, int ValueUniProgressBar)
        {
            await Searchbox(State, ValueUniProgressBar / 3);
            await IconLearn(State, ValueUniProgressBar / 3);
            await TaskView(State, ValueUniProgressBar / 3);

            await WinGlobal_UIService.Instance.Log_MensagemAsync($"Optimiza Barra de Tarefas: User \"{Environment.UserName}\" - Configurações Alteradas", true);
        }

        //Barra de Pesquisa
        private async Task Searchbox(bool State, int ValueUniProgressBar)
        {
            int _state = State ? 0 : 2;

            try
            {
                WinGlobal_UIService.Instance.token.ThrowIfCancellationRequested(); // Checa se o cancelamento foi solicitado antes de começar

                using (RegistryKey CurrentVersion = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion", writable: true))
                using (RegistryKey key = CurrentVersion.OpenSubKey("Search", writable: true))
                {
                    key.SetValue("SearchboxTaskbarMode", _state, RegistryValueKind.DWord); 
                    key.SetValue("SearchboxTaskbarModeCache", _state, RegistryValueKind.DWord); 
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
        private async Task IconLearn(bool State, int ValueUniProgressBar)
        {
            int _state = State ? 0 : 1;

            try
            {
                WinGlobal_UIService.Instance.token.ThrowIfCancellationRequested(); // Checa se o cancelamento foi solicitado antes de começar

                using (RegistryKey CurrentVersion = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Explorer\HideDesktopIcons", writable: true))
                using (RegistryKey key = CurrentVersion.OpenSubKey("NewStartPanel", writable: true))
                {
                    key.SetValue("2cc5ca98-6485-489a-920e-b3e88a6ccce3", _state, RegistryValueKind.DWord); 
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
        private async Task TaskView(bool State, int ValueUniProgressBar)
        {
            int _state = State ? 0 : 1;

            try
            {
                WinGlobal_UIService.Instance.token.ThrowIfCancellationRequested(); // Checa se o cancelamento foi solicitado antes de começar

                using (RegistryKey CurrentVersion = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Explorer", writable: true))
                using (RegistryKey key = CurrentVersion.OpenSubKey("Advanced", writable: true))
                {
                    key.SetValue("ShowTaskViewButton", _state, RegistryValueKind.DWord);                   
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
