using Microsoft.Win32;
using System.Threading.Tasks;

namespace MeuSuporte
{
    internal class WinRegistryBin_MACHINE_Mananger
    {
        WinRegistryBin_Global_Key LOCAL_MACHINE_Key;

        public WinRegistryBin_MACHINE_Mananger()
        {
            LOCAL_MACHINE_Key = new WinRegistryBin_Global_Key();
        }
    
        public async Task Mananger(int ValueUniProgressBar)
        {
            WinGlobal_UIService.Instance.token.ThrowIfCancellationRequested(); // Checa se o cancelamento foi solicitado antes de começar

            string NameMachineRun = "MachineRun";
            string NameWOW6432Node = "WOW6432Node";

            RegistryKey RegistryLocalMachineRun = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run");
            RegistryKey RegistryWOW6432Node = Registry.LocalMachine.CreateSubKey(@"Software\WOW6432Node\Microsoft\Windows\CurrentVersion\Run");

            await LOCAL_MACHINE_Key.Delete(NameMachineRun, RegistryLocalMachineRun, ValueUniProgressBar / 2);
            await LOCAL_MACHINE_Key.Delete(NameWOW6432Node, RegistryWOW6432Node, ValueUniProgressBar / 2);
        }
    }
}
