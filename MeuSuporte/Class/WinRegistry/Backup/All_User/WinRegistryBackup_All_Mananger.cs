using System.Threading.Tasks;

namespace MeuSuporte
{
    internal class WinRegistryBackup_All_Mananger
    {
        //  - 2
        /// <summary>
        /// Class responsavel por atribuir a segurança no processo de leitura do arquivo Regedit
        /// </summary>
        private readonly WinTaskbar_All_Security All_Security; 
        private readonly WinRegistryBackup_All_ProfileList RegistryBackup_All_ProfileList;

        public WinRegistryBackup_All_Mananger()
        {
            All_Security = new WinTaskbar_All_Security();
            RegistryBackup_All_ProfileList = new WinRegistryBackup_All_ProfileList();
        }


        public async Task Mananger(int ValueUniProgressBar)
        {

            if (await All_Security.Privilege(true))
            {
                try
                {
                    await RegistryBackup_All_ProfileList.ProfilesMananger(ValueUniProgressBar);
                }
                finally
                {
                    await All_Security.Privilege(false);
                }
            }
        }
    }
}
