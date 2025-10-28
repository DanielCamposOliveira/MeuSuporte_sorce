using System.Threading.Tasks;

namespace MeuSuporte
{
    internal class WinTaskbar_All_Mananger
    {
        private readonly WinTaskbar_All_Security All_Security;
        private readonly WinTaskbar_All_ProfileList Taskbar_All_ProfileList;

        public WinTaskbar_All_Mananger()
        {            
            All_Security = new WinTaskbar_All_Security();  
            Taskbar_All_ProfileList = new WinTaskbar_All_ProfileList();
        }

        public async Task Mananger(bool state, int ValueUniProgressBar)
        {
            if (await All_Security.Privilege(true))
            {
                try
                {
                    await Taskbar_All_ProfileList.ProfilesMananger(state, ValueUniProgressBar);
                }
                finally
                {
                    await All_Security.Privilege(false);
                }
            }
        }

    }
}
