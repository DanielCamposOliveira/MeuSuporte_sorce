using Microsoft.Win32;
using System;
using System.Threading.Tasks;


namespace MeuSuporte
{
    // 1
    /// <summary>
    /// Class responsavel por chamar a Class que realiza a montagem do registro e a gravação no disco
    /// </summary>
    internal class WinRegistryBackup_All_Mananger
    {    
        private WinRegistryBackup_All_SecurityRegistry RegistryBackup_All_SecurityRegistry;
        private WinRegistryBackup_LOCAL_MACHINE_Mananger RegistryBackup_LOCAL_MACHINE_Mananger;
        private WinRegistryBackup_Single_Key RegistryBackup_Single_Key;

        public WinRegistryBackup_All_Mananger()
        {
            RegistryBackup_All_SecurityRegistry = new WinRegistryBackup_All_SecurityRegistry();
            RegistryBackup_LOCAL_MACHINE_Mananger = new WinRegistryBackup_LOCAL_MACHINE_Mananger();
            RegistryBackup_Single_Key = new WinRegistryBackup_Single_Key();
        }
        public async Task Mananger()
        {
            WinGlobal_UIService.Instance.token.ThrowIfCancellationRequested(); // Checa se o cancelamento foi solicitado antes de começar
            
            // Salva os Registros da Maquina Local
            await RegistryBackup_LOCAL_MACHINE_Mananger.Backup(WinGlobal_UIService.Instance.ValueUniProgressBar / 3);

            // Salvar o Registros do Usuario
            string NameUserRun = Environment.UserName;
            RegistryKey RegistryCurrentUserRun = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run");
            await RegistryBackup_Single_Key.Backup(NameUserRun, RegistryCurrentUserRun, WinGlobal_UIService.Instance.ValueUniProgressBar / 3);

            // Salvar todos os Registros dos Usuarios
            await RegistryBackup_All_SecurityRegistry.Backup(WinGlobal_UIService.Instance.ValueUniProgressBar / 3);

            await WinGlobal_UIService.Instance.Log_MensagemAsync("Backup Registry concluído", true);
        }
    }
}
