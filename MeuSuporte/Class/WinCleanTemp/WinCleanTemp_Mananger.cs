using System.Threading.Tasks;

namespace MeuSuporte
{
    internal class WinCleanTemp_Mananger
    {
        private  WinCleanTemp_UserAll UserAll;
        private  WinCleanTemp_UserSingle UserSingle;

        public async Task Mananger(bool isAll)
        {
            if (isAll)
            {
                UserAll = new WinCleanTemp_UserAll();
               await UserAll.Clear();
            }
            else 
            {
                UserSingle = new WinCleanTemp_UserSingle();
                await UserSingle.Clear();
            }
        }
    }
}
