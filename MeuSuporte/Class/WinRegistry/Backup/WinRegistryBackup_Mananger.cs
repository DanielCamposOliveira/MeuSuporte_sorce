using Microsoft.Win32;
using System;
using System.Threading.Tasks;

namespace MeuSuporte
{
    internal class WinRegistryBackup_Mananger
    {           
        private WinRegistryBackup_LOCAL_MACHINE_Mananger Backup_LOCAL_MACHINE_Mananger;
        private WinRegistryBackup_All_Mananger RegistryBackup_All_Mananger;
        private WinRegistryBackup_Single_Mananger RegistryBackup_Single_Mananger;

        public WinRegistryBackup_Mananger()
        {    
            Backup_LOCAL_MACHINE_Mananger = new WinRegistryBackup_LOCAL_MACHINE_Mananger();
            RegistryBackup_All_Mananger = new WinRegistryBackup_All_Mananger();       
            RegistryBackup_Single_Mananger = new WinRegistryBackup_Single_Mananger();
        }

        public async Task Mananger(bool isAll)
        {
            if (isAll)
            {

                // Salva os Registros da Maquina Local
                await Backup_LOCAL_MACHINE_Mananger.Backup(WinGlobal_UIService.Instance.ValueUniProgressBar / 3);

                // Salvar o Registros do Usuario
                string NameUserRun = Environment.UserName;
                RegistryKey RegistryCurrentUserRun = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run");
                await RegistryBackup_Single_Mananger.Mananger(NameUserRun, RegistryCurrentUserRun, WinGlobal_UIService.Instance.ValueUniProgressBar / 3);

                // Salvar todos os Registros dos Usuarios
                await RegistryBackup_All_Mananger.Mananger(WinGlobal_UIService.Instance.ValueUniProgressBar / 3);

                await WinGlobal_UIService.Instance.Log_MensagemAsync("Backup Registry concluído", true);
            }
            else
            {            
                // Salva os Registros da Maquina Local
                await Backup_LOCAL_MACHINE_Mananger.Backup(WinGlobal_UIService.Instance.ValueUniProgressBar / 2);

                // Salvar o Registros do Usuario
                string NameUserRun = Environment.UserName;
                RegistryKey RegistryCurrentUserRun = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run");
                await RegistryBackup_Single_Mananger.Mananger(NameUserRun, RegistryCurrentUserRun, WinGlobal_UIService.Instance.ValueUniProgressBar / 2);

                await WinGlobal_UIService.Instance.Log_MensagemAsync("Backup Registry concluído", true);
            }
        }
    }
}
