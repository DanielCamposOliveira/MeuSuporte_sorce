using Microsoft.Win32;
using System;
using System.Threading.Tasks;

namespace MeuSuporte
{    
    internal class WinTaskbar_Single_Mananger
    {
        WinTaskbar_TaskView TaskView;
        WinTaskbar_IconLearn IconLearn;
        WinTaskbar_Searchbox Searchbox;
        public WinTaskbar_Single_Mananger()
        {
            TaskView = new WinTaskbar_TaskView();
            IconLearn = new WinTaskbar_IconLearn();
            Searchbox = new WinTaskbar_Searchbox();
        }

        public async Task Changes(bool State, int ValueUniProgressBar)
        {  
            string PathSearchbox = @"Software\Microsoft\Windows\CurrentVersion\Search";
            await Searchbox.Changes(State, Registry.CurrentUser, PathSearchbox, Environment.UserName, ValueUniProgressBar / 3);

            string TaskViewPath = @"Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced";
            await TaskView.Changes(State, Registry.CurrentUser, TaskViewPath, Environment.UserName, ValueUniProgressBar / 3);

            string IconLearnPath = @"Software\Microsoft\Windows\CurrentVersion\Explorer\HideDesktopIcons\NewStartPanel";
            await IconLearn.Changes(State, Registry.CurrentUser, IconLearnPath, Environment.UserName, ValueUniProgressBar / 3);

            await WinGlobal_UIService.Instance.AddMessage($"Optimiza Barra de Tarefas: User \"{Environment.UserName}\" - Configurações Alteradas");
        }
    }
}
