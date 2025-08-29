using System;
using System.Threading.Tasks;
using TaskScheduler;

namespace MeuSuporte
{
    internal class WinTask_Bin
    {        
        public async Task Delete(ITaskFolder rootFolder, IRegisteredTask task, int ValueUniProgressBar)
        {
            try
            {
                WinGlobal_UIService.Instance.token.ThrowIfCancellationRequested(); // Checa se o cancelamento foi solicitado antes de começar

                rootFolder.DeleteTask(task.Name, 0); // deleta a tarefa
                await WinGlobal_UIService.Instance.Log_MensagemAsync($"Clean Task: Tarefa Apagada - {task.Name}", true);
                await Task.Delay(500);
            }
            catch (Exception e)
            {
                WinGlobal_UIService.Instance.Erro++;
                await WinGlobal_UIService.Instance.Log_MensagemAsync($"Clean Task: Tarefa não Apagada - {task.Name} - {e.Message}", true);
                await Task.Delay(500);
            }

            WinGlobal_UIService.Instance.ProgressBarADD(ValueUniProgressBar);
        }
    }
}
