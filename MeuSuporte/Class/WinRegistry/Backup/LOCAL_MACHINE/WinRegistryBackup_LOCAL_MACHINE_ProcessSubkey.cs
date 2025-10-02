using Microsoft.Win32;
using System.Text;
using System.Threading.Tasks;

namespace MeuSuporte
{
    // 3
    /// <summary>
    /// Class responsavel por montar o arquivo StringBuilder regFile com as informacoes dos registros
    /// </summary>
    
    internal class WinRegistryBackup_LOCAL_MACHINE_ProcessSubkey
    {        
        private readonly WinRegistryBackup_FormatRegister FormatRegister;

        public WinRegistryBackup_LOCAL_MACHINE_ProcessSubkey()
        {
            FormatRegister = new WinRegistryBackup_FormatRegister();   
        }

        public async Task Subkey(RegistryKey Key, StringBuilder regFile)
        {
            // Adiciona a chave atual ao arquivo de backup
            // Todas as chamadas AppendLine estão MODIFICANDO 
            // DIRETAMENTE o objeto 'regFile' (a referência) que foi passado.
            regFile.AppendLine("");
            regFile.AppendLine($"[{Key.Name}]");

            // Processa todos os valores dentro da chave atual
            foreach (string NameValue in Key.GetValueNames())
            {
                object valor = Key.GetValue(NameValue);
                RegistryValueKind TypeValue = Key.GetValueKind(NameValue);

                // Formatar o valor conforme o tipo de dado
                string FormattedValue = await FormatRegister.Format(TypeValue, valor);

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
                    Subkey(subChave, regFile);
                }
            }
        }
    }
}
