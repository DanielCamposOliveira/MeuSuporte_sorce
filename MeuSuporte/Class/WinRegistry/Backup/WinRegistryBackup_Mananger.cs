using System.Threading.Tasks;

namespace MeuSuporte
{
    internal class WinRegistryBackup_Mananger
    {
        WinRegistryBackup_All_Mananger Backup_All_Mananger;
        WinRegistryBackup_Single_Mananger Backup_Single_Mananger;
        
        public WinRegistryBackup_Mananger()
        {
            Backup_All_Mananger = new WinRegistryBackup_All_Mananger();
            Backup_Single_Mananger = new WinRegistryBackup_Single_Mananger();            
        }

        public async Task Mananger(bool isAll)
        {
            if (isAll)
            {
              await  Backup_All_Mananger.Mananger();
            }
            else
            {
                await Backup_Single_Mananger.Mananger();
            }
        }
    }
}
