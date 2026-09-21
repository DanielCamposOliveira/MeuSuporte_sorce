using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskScheduler;

namespace MeuSuporte
{
    // 3

    internal class WinTask_Bin
    {
        WinTask_State Task_State;
        public WinTask_Bin() 
        {
            Task_State = new WinTask_State();
        }

        public async Task Delete(string[] ListTask, ITaskFolder rootFolder, IRegisteredTask task, int ValueUniProgressBar)
        {
            try
            {
                WinGlobal_UIService.Instance.token.ThrowIfCancellationRequested(); // Checa se o cancelamento foi solicitado antes de começar



                bool isProtected = false;

                // Percorre todas as ações da tarefa
                foreach (IAction action in task.Definition.Actions)
                {
                    // Verifica se a ação é de execução de executável (TASK_ACTION_EXEC = 0)
                    if (action.Type == _TASK_ACTION_TYPE.TASK_ACTION_EXEC)
                    {
                        var execAction = (IExecAction)action;

                        // Compara o caminho do executável sem diferenciar maiúsculas/minúsculas
                        foreach (string protectedPath in ListTask)
                        {
                            if (!string.IsNullOrEmpty(execAction.Path) &&
                                execAction.Path.Equals(protectedPath, StringComparison.OrdinalIgnoreCase))
                            {
                                isProtected = true;
                                break;
                            }
                        }
                    }

                    if (isProtected) 
                        break;
                }
                // Condição para ignorar ou apagar
                if (isProtected)
                {
                    await WinGlobal_UIService.Instance.AddMessage($"Clean Task: Tarefa Protegida Ignorada - {task.Name}");
                }
                else
                {
                    rootFolder.DeleteTask(task.Name, 0); // deleta a tarefa
                    await WinGlobal_UIService.Instance.AddMessage($"Clean Task: Tarefa Apagada - {task.Name}");
                    await Task.Delay(500);
                } 
               
            }
            catch (Exception e)
            {
                WinGlobal_UIService.Instance.Erro++;
                await WinGlobal_UIService.Instance.AddMessage($"Clean Task: Tarefa não Apagada - {task.Name} - {e.Message}");
                await Task.Delay(500);
            }

            await WinGlobal_UIService.Instance.ProgressBarADD(ValueUniProgressBar);
        }


         

        public async Task Desabilitar(ITaskFolder rootFolder, IRegisteredTask task, int ValueUniProgressBar)
        {
            // Define a lista de nomes de tarefas que você QUER desativar
            var tasksToDisable = new List<string> {
                "Schedule Scan",
                "Reboot"
            };

            if (tasksToDisable.Contains(task.Name))
            {
                // 2. AÇÃO: Se estiver na lista, chama a função para desativar.
              //  await WinTask_State.State(rootFolder, task, ValueUniProgressBar);
            }
            else
            {
                // 3. LOG: (Opcional) Registra que a tarefa foi ignorada, se necessário.
                await WinGlobal_UIService.Instance.AddMessage($"Tarefa Ignorada: {task.Name} (Não está na lista de desativação)");
                await WinGlobal_UIService.Instance.ProgressBarADD(ValueUniProgressBar);
            }

        }


    }
}
