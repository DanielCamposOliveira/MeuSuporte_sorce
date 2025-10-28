using System.Threading.Tasks;

namespace MeuSuporte
{    
    internal class WinRegistryBin_All_Mananger
    {
        private readonly WinRegistryBin_All_ProfileList RegistryBin_All_ProfileList;
        private readonly WinTaskbar_All_Security All_Security;

        public WinRegistryBin_All_Mananger()
        {
            RegistryBin_All_ProfileList = new WinRegistryBin_All_ProfileList();
            All_Security = new WinTaskbar_All_Security();
        }
          
        public async Task Mananger(int ValueUniProgressBar)
        {
            if (await All_Security.Privilege(true))
            {
                try
                {
                    await RegistryBin_All_ProfileList.ProfilesMananger(ValueUniProgressBar);
                }
                finally
                {
                    await All_Security.Privilege(false);
                }
            }
        }
    }
}
