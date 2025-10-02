using Microsoft.Win32;
using System;
using System.Threading.Tasks;

namespace MeuSuporte
{
    // 1
    /// <summary>
    /// Class responsavel por chamar a Class que realiza a montagem do registro e a gravação no disco
    /// </summary>
    internal class WinRegistryBackup_Single_Mananger
    {
        private WinRegistryBackup_Single_Key RegistryBackup_Key;
        private WinRegistryBackup_LOCAL_MACHINE_Mananger Backup_LOCAL_MACHINE_Mananger;

        public WinRegistryBackup_Single_Mananger()
        {
            RegistryBackup_Key = new WinRegistryBackup_Single_Key();
            Backup_LOCAL_MACHINE_Mananger = new WinRegistryBackup_LOCAL_MACHINE_Mananger();
        }

        public async Task Mananger()
        {            
            WinGlobal_UIService.Instance.token.ThrowIfCancellationRequested(); // Checa se o cancelamento foi solicitado antes de começar

            string NameUserRun = Environment.UserName;
            RegistryKey RegistryCurrentUserRun = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run");

            // Salva os Registros da Maquina Local
            await Backup_LOCAL_MACHINE_Mananger.Backup(WinGlobal_UIService.Instance.ValueUniProgressBar / 2);

            // Salvar o Registros do Usuario
            await RegistryBackup_Key.Backup(NameUserRun, RegistryCurrentUserRun, WinGlobal_UIService.Instance.ValueUniProgressBar / 2);

            await WinGlobal_UIService.Instance.Log_MensagemAsync("Backup Registry concluído", true);
        }
    }
}
