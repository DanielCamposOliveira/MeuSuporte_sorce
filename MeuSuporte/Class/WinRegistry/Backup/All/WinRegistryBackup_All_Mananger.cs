using Microsoft.Win32;
using System;
using System.Threading.Tasks;


namespace MeuSuporte
{
    internal class WinRegistryBackup_All_Mananger
    {
        private WinRegistryBackup_Key WinRegistryBackup_All_Key;
        private WinRegistryBackup_All_SecurityRegistry RegistryBackup_All_SecurityRegistry;

        public async Task Mananger()
        {
            WinRegistryBackup_All_Key = new WinRegistryBackup_Key();
            RegistryBackup_All_SecurityRegistry = new WinRegistryBackup_All_SecurityRegistry();

            WinGlobal_UIService.Instance.token.ThrowIfCancellationRequested(); // Checa se o cancelamento foi solicitado antes de começar

            string NameMachineRun = "LocalMachineRun.reg";
            string NameWOW6432Node = "WOW6432Node.reg";
            string NameUserRun = $"{Environment.UserName}_LocalUserRun.reg";


            RegistryKey RegistryLocalMachineRun = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run");
            RegistryKey RegistryCurrentUserRun = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run");
            RegistryKey RegistryWOW6432Node = Registry.LocalMachine.OpenSubKey(@"Software\WOW6432Node\Microsoft\Windows\CurrentVersion\Run");

            await WinRegistryBackup_All_Key.Backup(NameMachineRun, RegistryLocalMachineRun, WinGlobal_UIService.Instance.ValueUniProgressBar / 4);
            await WinRegistryBackup_All_Key.Backup(NameWOW6432Node, RegistryWOW6432Node, WinGlobal_UIService.Instance.ValueUniProgressBar / 4);
            await WinRegistryBackup_All_Key.Backup(NameUserRun, RegistryCurrentUserRun, WinGlobal_UIService.Instance.ValueUniProgressBar / 4);

            // Salvar todos os registros dos usuarios
            await RegistryBackup_All_SecurityRegistry.Backup(WinGlobal_UIService.Instance.ValueUniProgressBar / 4);

            WinGlobal_UIService.Instance.Log_MensagemAsync("Backup Registry concluído", true);
        }
    }
}
