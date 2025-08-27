namespace MeuSuporte
{
    internal class WinUser_CurrentUser
    {
        private readonly Credential_Public Credential_Publ;
        private readonly Credential_Private Credential_Priv;

        private string user = "";
        private string password = "";



        public WinUser_CurrentUser()
        {
            Credential_Publ = new Credential_Public();
            Credential_Priv = new Credential_Private();


            user = Credential_Priv.User; //Credential_Priv.User;    Credential_Publ.User;
            password = Credential_Priv.Password; //Credential_Priv.Password;   Credential_Publ.Password;

        }

        public string User // propriedade pública
        {
            get { return user; } // retorna o valor            
        }

        public string Password // propriedade pública
        {
            get { return password; } // retorna o valor            
        }
    }
}
