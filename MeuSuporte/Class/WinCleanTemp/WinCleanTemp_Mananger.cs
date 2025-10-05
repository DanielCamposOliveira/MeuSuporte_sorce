using System.Threading.Tasks;

namespace MeuSuporte
{
    internal class WinCleanTemp_Mananger
    {
        private  WinCleanTemp_UserAll UserAll;
        private  WinCleanTemp_UserSingle UserSingle;

        public WinCleanTemp_Mananger()
        {
            UserAll = new WinCleanTemp_UserAll();
            UserSingle = new WinCleanTemp_UserSingle();
        }

        public async Task Mananger(bool isAll)
        {
            if (isAll)
            {                
               await UserAll.Clear();
            }
            else 
            {                
                await UserSingle.Clear();
            }
        }
    }
}
