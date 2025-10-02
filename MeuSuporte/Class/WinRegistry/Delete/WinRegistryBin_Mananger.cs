using System.Threading.Tasks;

namespace MeuSuporte
{
    internal class WinRegistryBin_Mananger
    {
        WinRegistryBin_All_Mananger RegistryBin_All_Mananger;
        WinRegistryBin_Single_Mananger RegistryBin_Single_Mananger;

        public WinRegistryBin_Mananger()
        {
            RegistryBin_All_Mananger = new WinRegistryBin_All_Mananger();
            RegistryBin_Single_Mananger = new WinRegistryBin_Single_Mananger();
        }
        public async Task Delete(bool isAll)
        {
            if (isAll)
            {                
                await RegistryBin_All_Mananger.Delete();
            }
            else 
            {                
                await RegistryBin_Single_Mananger.Delete();
            }
        }

    }
}
