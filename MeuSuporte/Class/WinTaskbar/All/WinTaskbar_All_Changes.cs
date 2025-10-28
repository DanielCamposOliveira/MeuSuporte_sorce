using Microsoft.Win32;
using System.Threading.Tasks;

namespace MeuSuporte
{
    // 3
    /// <summary>
    /// Class responsavel por chamar todas as alterações no registro do Usuario
    /// </summary>
    
    internal class WinTaskbar_All_Changes
    {
        private readonly WinTaskbar_Searchbox Searchbox;
        private readonly WinTaskbar_TaskView TaskView;
        private readonly WinTaskbar_IconLearn IconLearn;
        public WinTaskbar_All_Changes() 
        {
            Searchbox = new WinTaskbar_Searchbox();
            TaskView = new WinTaskbar_TaskView();
            IconLearn = new WinTaskbar_IconLearn();
        }

        public async Task Changes(bool State, string tempHiveName, string usuario, int ValueUniProgressBar)
        {
            string SearchboxPath = $@"{tempHiveName}\Software\Microsoft\Windows\CurrentVersion\Search";
            await Searchbox.Changes(State, Registry.Users, SearchboxPath, usuario, ValueUniProgressBar / 3);

            string TaskViewPath = $@"{tempHiveName}\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced";            
            await TaskView.Changes(State, Registry.Users, TaskViewPath, usuario, ValueUniProgressBar / 3);

            string IconLearnPath = $@"{tempHiveName}\Software\Microsoft\Windows\CurrentVersion\Explorer\HideDesktopIcons\NewStartPanel";
            await IconLearn.Changes(State, Registry.Users, IconLearnPath, usuario, ValueUniProgressBar / 3);

            await WinGlobal_UIService.Instance.Log_MensagemAsync($"Optimiza Barra de Tarefas: User \"{usuario}\" - Configurações Alteradas", true);
        }

    }
}
