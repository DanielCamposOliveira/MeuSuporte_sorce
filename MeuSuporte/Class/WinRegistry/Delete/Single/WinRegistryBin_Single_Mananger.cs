using Microsoft.Win32;
using System.Threading.Tasks;

namespace MeuSuporte
{
    internal class WinRegistryBin_Single_Mananger
    {
        /// <summary>
        /// Class responsavel por chamar as class de exclusao da chaves de registro
        /// </summary>
        WinRegistryBin_Global_Key LOCAL_MACHINE_Key;

        public WinRegistryBin_Single_Mananger()
        {
            LOCAL_MACHINE_Key = new WinRegistryBin_Global_Key();
        }

        public async Task Mananger(int ValueUniProgressBar)
        {
            string NameCurrent_User = "USER";                        
            RegistryKey RegistrCurrent_User = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run");
            await LOCAL_MACHINE_Key.Delete(NameCurrent_User, RegistrCurrent_User, ValueUniProgressBar);
        }
    }
}
