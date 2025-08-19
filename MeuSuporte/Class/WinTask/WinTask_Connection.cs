using System.Threading.Tasks;
using TaskScheduler;

namespace MeuSuporte
{
    internal class WinTask_Connection
    {
        public ITaskService taskService;
        public ITaskFolder rootFolder;
        public IRegisteredTaskCollection tasks;

        public async Task Connect()
        {
            taskService = new TaskScheduler.TaskScheduler();// cria uma instância
            taskService.Connect(); // conecta

            rootFolder = taskService.GetFolder(@"\"); // passa o diretório raiz
            tasks = rootFolder.GetTasks(0);
        }

        public async Task Connect2()
        {
            taskService = new TaskScheduler.TaskScheduler();// cria uma instância
            taskService.Connect(); // conecta

            rootFolder = taskService.GetFolder(@"\Microsoft\Windows\WindowsUpdate"); // passa o diretório raiz
            tasks = rootFolder.GetTasks(0);
        }
    }
}
