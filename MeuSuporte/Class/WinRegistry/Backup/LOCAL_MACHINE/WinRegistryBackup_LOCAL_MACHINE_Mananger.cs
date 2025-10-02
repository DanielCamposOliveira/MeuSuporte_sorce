using Microsoft.Win32;
using System.Threading.Tasks;

namespace MeuSuporte
{
    // 1
    /// <summary>
    /// Class responsavel por chamar a Class que realiza a montagem do registro e a gravação no disco
    /// </summary>
    
    internal class WinRegistryBackup_LOCAL_MACHINE_Mananger
    {
        private WinRegistryBackup_LOCAL_MACHINE_Key RegistryBackup_LOCAL_MACHINE_Key;
        public WinRegistryBackup_LOCAL_MACHINE_Mananger()
        {
            RegistryBackup_LOCAL_MACHINE_Key = new WinRegistryBackup_LOCAL_MACHINE_Key();
        }

        public async Task Backup(int ValueUniProgressBar)
        {
            WinGlobal_UIService.Instance.token.ThrowIfCancellationRequested(); // Checa se o cancelamento foi solicitado antes de começar

            string NameMachineRun = "MachineRun";
            string NameWOW6432Node = "WOW6432Node";            

            RegistryKey RegistryLocalMachineRun = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run");            
            RegistryKey RegistryWOW6432Node = Registry.LocalMachine.OpenSubKey(@"Software\WOW6432Node\Microsoft\Windows\CurrentVersion\Run");

            await RegistryBackup_LOCAL_MACHINE_Key.Backup(NameMachineRun, RegistryLocalMachineRun, ValueUniProgressBar / 2);            
            await RegistryBackup_LOCAL_MACHINE_Key.Backup(NameWOW6432Node, RegistryWOW6432Node, ValueUniProgressBar / 2);
        }
    }
}
