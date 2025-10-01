using Microsoft.Win32;
using System.Text;
using System.Threading.Tasks;

namespace MeuSuporte
{
    internal class WinRegistryBackup_All_ProcessSubkey
    {
        /// <summary>
        /// Class responsavel por montar o arquivo (StringBuilder regFile) com as informacoes dos registros
        /// </summary>

        private WinRegistryBackup_FormatRegister RegistryBackup_FormatRegister;

        public WinRegistryBackup_All_ProcessSubkey()
        {
            RegistryBackup_FormatRegister = new WinRegistryBackup_FormatRegister();
        }

        public async Task RegistryCatalog(RegistryKey Key, StringBuilder regFile)
        {
            regFile.AppendLine(@"[HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run]");

            // Processa todos os valores dentro da chave atual
            foreach (string NameValue in Key.GetValueNames())
            {
                object valor = Key.GetValue(NameValue);
                RegistryValueKind TypeValue = Key.GetValueKind(NameValue);

                // Formatar o valor conforme o tipo de dado
                string FormattedValue = await RegistryBackup_FormatRegister.Format(TypeValue, valor);

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
