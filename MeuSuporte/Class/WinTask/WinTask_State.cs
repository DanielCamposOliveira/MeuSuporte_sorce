using System;
using System.Threading.Tasks;
using TaskScheduler;

namespace MeuSuporte
{
    // 4
    internal class WinTask_State
    {
        public async Task State(ITaskFolder rootFolder, IRegisteredTask task, int ValueUniProgressBar)
        {
            try
            {
                WinGlobal_UIService.Instance.token.ThrowIfCancellationRequested(); // Checa se o cancelamento foi solicitado antes de começar

                //   task.Definition.Settings.Enabled = false; // Desativa a tarefa
                //task.RegisterChanges(); // Salva as alterações na tarefa

                ITaskDefinition definition = task.Definition;
                definition.Settings.Enabled = false;

                _TASK_LOGON_TYPE originalLogonType = definition.Principal.LogonType;

                rootFolder.RegisterTaskDefinition(
     task.Name,
     definition,
     (int)_TASK_CREATION.TASK_CREATE_OR_UPDATE,
     null,
     null,
     originalLogonType);




                //  rootFolder.DeleteTask(task.Name, 0); // deleta a tarefa
                await WinGlobal_UIService.Instance.AddMessage($"Tarefa Desativada: {task.Name}");
                await Task.Delay(500);
            }
            catch (Exception e)
            {
                WinGlobal_UIService.Instance.Erro++;
                await WinGlobal_UIService.Instance.AddMessage($"Erro ao Desativar Tarefa: {task.Name} - {e.Message}");
                await Task.Delay(500);
            }
            await WinGlobal_UIService.Instance.ProgressBarADD(ValueUniProgressBar);
        }
    }
}
