using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskScheduler;

namespace MeuSuporte
{
    // 1

    internal class WinTask_Mananger
    {
        private readonly WinTask_Bin WinTask_Bin;
        private readonly WinTask_State WinTask_State;
        private readonly WinTask_Connection WinTask_Connection;

        public WinTask_Mananger()
        {
            WinTask_Bin = new WinTask_Bin();
            WinTask_State = new WinTask_State();
            WinTask_Connection = new WinTask_Connection();
        }

        public async Task Mananger(string[] ListTask)
        {
            WinGlobal_UIService.Instance.token.ThrowIfCancellationRequested(); // Checa se o cancelamento foi solicitado antes de começar

            // conectar com a agenda de tarefas
            if (!await WinTask_Connection.Connect())
                return;

            // verifica se existe tarefas
            if (WinTask_Connection.tasks.Count == 0)
            {
                await WinGlobal_UIService.Instance.AddMessage("Clean Task: Nenhuma Tarefa foi encontrada ");
                await WinGlobal_UIService.Instance.ProgressBarADD(WinGlobal_UIService.Instance.ValueUniProgressBar);
                return;
            }

            // Apaga as tarefas encontradas
            int ValueUniProgressBar = WinGlobal_UIService.Instance.ValueUniProgressBar / WinTask_Connection.tasks.Count;
            foreach (IRegisteredTask task in WinTask_Connection.tasks) // Verifica a quantidade de tarefas no diretório
            {
                await WinTask_Bin.Delete(ListTask,WinTask_Connection.rootFolder, task, ValueUniProgressBar); // apaga a tarefa                                                                                                    
                // await WinTask_State.State(WinTask_Connection.rootFolder, task, ValueUniProgressBar); // desabilita a tarefa para uso futuro
            }
            WinGlobal_UIService.Instance.Sucesso++;


            // Define a lista de nomes de tarefas que você QUER desativar
            //var tasksToDisable = new List<string> {
            //    "Schedule Work",
            //    "Schedule Maintenance Work",
            //    "Schedule Wake To Work"
            //};

            //foreach (IRegisteredTask task in WinTask_Connection.tasks) // Verifica a quantidade de tarefas no diretório
            //{
            //    // 1. FILTRO: Checa se o nome da tarefa ATUAL está na lista de tarefas a desativar
            //    if (tasksToDisable.Contains(task.Name))
            //    {
            //        // 2. AÇÃO: Se estiver na lista, chama a função para desativar.
            //        await WinTask_State.State(WinTask_Connection.rootFolder, task, ValueUniProgressBar);

                   
            //    }
            //    else
            //    {
            //        // 3. LOG: (Opcional) Registra que a tarefa foi ignorada, se necessário.
            //      //  await WinGlobal_UIService.Instance.Log_MensagemAsync($"Tarefa Ignorada: {task.Name} (Não está na lista de desativação)", true);
            //      //  WinGlobal_UIService.Instance.ProgressBarADD(ValueUniProgressBar);
            //    }
            //}


       
        }
    }
}
