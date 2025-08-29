using System;
using System.Threading.Tasks;
using TaskScheduler;

namespace MeuSuporte
{
    internal class WinTask_Connection
    {
        public ITaskService taskService;
        public ITaskFolder rootFolder;
        public IRegisteredTaskCollection tasks;

        public async Task<bool> Connect()
        {
            try
            {
                taskService = new TaskScheduler.TaskScheduler();// cria uma instância
                taskService.Connect(); // conecta

                rootFolder = taskService.GetFolder(@"\"); // passa o diretório raiz
                tasks = rootFolder.GetTasks(0);
                return true;
            }
            catch (Exception ex)
            {
                WinGlobal_UIService.Instance.Erro++;
                await WinGlobal_UIService.Instance.Log_MensagemAsync("Clean Task: Ocorreu um erro ao tentar se conectar com Agendador de Tarefas do Windows", true);
                return false;
            }
        }

        //// sera usado para desativar tarefas no futuro
        //public async Task Connect2()
        //{
        //    taskService = new TaskScheduler.TaskScheduler();// cria uma instância
        //    taskService.Connect(); // conecta

        //    rootFolder = taskService.GetFolder(@"\Microsoft\Windows\WindowsUpdate"); // passa o diretório raiz
        //    tasks = rootFolder.GetTasks(0);
        //}
    }
}
