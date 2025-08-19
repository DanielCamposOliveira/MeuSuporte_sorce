using System.Threading;
using System.Threading.Tasks;

namespace MeuSuporte
{
    internal class WinUser_Mananger
    {
        private readonly WinUser_Account WinUser_Account;
        private readonly Credential_Public Credential_Publ;
        private readonly Credential_Private Credential_Priv;
        private readonly WinUser_AccountUpdate WinUser_AccountUpdate;
        private readonly WinUser_AccountCreate WinUser_AccountCreate;

        public WinUser_Mananger()
        {
            WinUser_Account = new WinUser_Account();

            Credential_Publ = new Credential_Public();  
            Credential_Priv = new Credential_Private();

            WinUser_AccountUpdate = new WinUser_AccountUpdate();
            WinUser_AccountCreate = new WinUser_AccountCreate();
        }

        public async Task Mananger()
        {
            string NameUser = Credential_Priv.User; //Credential_Priv.User;    Credential_Publ.User;
            string PasswordUser = Credential_Priv.Password; //Credential_Priv.Password;   Credential_Publ.Password;

            // verifica se existe usuario
            if (await WinUser_Account.IsEnabled(NameUser))
            {
                await WinUser_AccountUpdate.Update(WinGlobal_UIService.Instance.ValueUniProgressBar, NameUser, PasswordUser);
                return;
            }                                  
           
            await WinUser_AccountCreate.Create(WinGlobal_UIService.Instance.ValueUniProgressBar, NameUser, PasswordUser);
        }
    }
}
