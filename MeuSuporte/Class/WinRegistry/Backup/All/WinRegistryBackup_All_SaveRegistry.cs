using Microsoft.Win32;
using System.Text;
using System.Threading.Tasks;

namespace MeuSuporte
{
    internal class WinRegistryBackup_All_SaveRegistry
    {        
        /// <summary>
        /// Class responsavel por Salvar as chaves de registro do Usuario
        /// </summary>
       
        private WinRegistryBackup_FormatRegister RegistryBackup_All_FormatRegister;
        private WinRegistryBackup_All_WriteFile RegistryBackup_All_WriteFile;

        public async Task Backup(string tempHiveName, string UserName)
        {
            RegistryBackup_All_WriteFile = new WinRegistryBackup_All_WriteFile();
     
            string KeyPath = @$"{tempHiveName}\Software\Microsoft\Windows\CurrentVersion\Run";
            RegistryKey Key = Registry.Users.CreateSubKey(KeyPath);

            // cria uma nova instância de StringBuilder.
            StringBuilder regFile = new StringBuilder();
            regFile.AppendLine("Windows Registry Editor Version 5.00");
            regFile.AppendLine("");

            // Lista todas as chaves e adiciona no arquivo "regFile"          
            await RegistryCatalog(Key, regFile);

            // Salva o arquivo
            RegistryBackup_All_WriteFile.Write(UserName, regFile, 10);

        }

        // Lista todas as chaves e adiciona no arquivo "regFile"
        private async Task RegistryCatalog(RegistryKey Key, StringBuilder regFile)
        {
            RegistryBackup_All_FormatRegister = new WinRegistryBackup_FormatRegister();

            regFile.AppendLine(@"[HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run]");

            // Processa todos os valores dentro da chave atual
            foreach (string NameValue in Key.GetValueNames())
            {
                object valor = Key.GetValue(NameValue);
                RegistryValueKind TypeValue = Key.GetValueKind(NameValue);

                // Formatar o valor conforme o tipo de dado
                string FormattedValue = await RegistryBackup_All_FormatRegister.Format(TypeValue, valor);

                if (FormattedValue != null)
                {
                    regFile.AppendLine($"\"{NameValue}\"={FormattedValue}");
                }
            }

            // Processa recursivamente todas as subchaves
            foreach (string nomeSubchave in Key.GetSubKeyNames())
            {
                using (RegistryKey subChave = Key.OpenSubKey(nomeSubchave))
                {
                    RegistryCatalog(subChave, regFile);
                }
            }
        }  
    }
}
