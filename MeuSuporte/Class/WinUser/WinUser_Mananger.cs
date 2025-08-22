using System.Threading;
using System.Threading.Tasks;

namespace MeuSuporte
{
    internal class WinUser_Mananger
    {
        private readonly WinUser_Account WinUser_Account;
        private readonly WinUser_AccountUpdate WinUser_AccountUpdate;
        private readonly WinUser_AccountCreate WinUser_AccountCreate;
        private readonly WinUser_CurrentUser CurrentUser;

        public WinUser_Mananger()
        {
            WinUser_Account = new WinUser_Account();
            WinUser_AccountUpdate = new WinUser_AccountUpdate();
            WinUser_AccountCreate = new WinUser_AccountCreate();
            CurrentUser = new WinUser_CurrentUser();
        }

        public async Task Mananger()
        {
            // verifica se existe usuario
            if (await WinUser_Account.IsEnabled(CurrentUser.User))
            {
                await WinUser_AccountUpdate.Update(WinGlobal_UIService.Instance.ValueUniProgressBar, CurrentUser.User, CurrentUser.Password);
                return;
            }   
            await WinUser_AccountCreate.Create(WinGlobal_UIService.Instance.ValueUniProgressBar, CurrentUser.User, CurrentUser.Password);
        }
    }
}
