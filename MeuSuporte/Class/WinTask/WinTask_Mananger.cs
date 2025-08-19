using System;
using System.Threading.Tasks;
using TaskScheduler;

namespace MeuSuporte
{
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
              
        public async Task Mananger()
        {
            try
            {
                WinGlobal_UIService.Instance.token.ThrowIfCancellationRequested(); // Checa se o cancelamento foi solicitado antes de começar

                await WinTask_Connection.Connect2();

                // verifica se existe tarefas
                if (WinTask_Connection.tasks.Count == 0)
                {
                    await WinGlobal_UIService.Instance.Log_MensagemAsync("Nenhuma Tarefa foi encontrada ", true);
                    WinGlobal_UIService.Instance.ProgressBarADD(WinGlobal_UIService.Instance.ValueUniProgressBar);
                    return;
                }

              

                int ValueUniProgressBar = WinGlobal_UIService.Instance.ValueUniProgressBar / WinTask_Connection.tasks.Count;

                foreach (IRegisteredTask task in WinTask_Connection.tasks) // Verifica a quantidade de tarefas no diretório
                {
                    // await WinTask_Bin.Delete(WinTask_Connection.rootFolder, task, ValueUniProgressBar); // apaga a tarefa
                    await WinTask_State.State(WinTask_Connection.rootFolder, task, ValueUniProgressBar); // apaga a tarefa
                }
                WinGlobal_UIService.Instance.Sucesso++;
            }
            catch (Exception ex)
            {
                WinGlobal_UIService.Instance.Erro++;
                await WinGlobal_UIService.Instance.Log_MensagemAsync($"Gerou um erro na execução Clean Task\r\n: {ex.Message}", true);
            }
        }
    }
}
