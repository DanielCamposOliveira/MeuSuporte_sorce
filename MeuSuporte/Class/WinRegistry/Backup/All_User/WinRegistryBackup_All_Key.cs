using Microsoft.Win32;
using System.Text;
using System.Threading.Tasks;

namespace MeuSuporte
{
    internal class WinRegistryBackup_All_Key
    {
        // 4
        /// <summary>
        /// Class Responsavel por
        /// Criar o arquivo (StringBuilder regFile) do registro
        /// Chamada do metado de adicionar os regsitro no arquivo 
        /// Chamada do metado de gravar o arquivo no Disco
        /// </summary>

        private WinRegistryBackup_All_RegistryWriteFile RegistryBackup_All_RegistryWriteFile;
        private WinRegistryBackup_All_ProcessSubkey RegistryBackup_All_ProcessSubkey;

        public WinRegistryBackup_All_Key()
        {
            RegistryBackup_All_RegistryWriteFile = new WinRegistryBackup_All_RegistryWriteFile();
            RegistryBackup_All_ProcessSubkey = new WinRegistryBackup_All_ProcessSubkey();
        }

        public async Task Backup(string tempHiveName, string UserName, int ValueUniProgressBar)
        {
            string KeyPath = @$"{tempHiveName}\Software\Microsoft\Windows\CurrentVersion\Run";
            RegistryKey Key = Registry.Users.CreateSubKey(KeyPath);

            // cria uma nova instância de StringBuilder.
            StringBuilder regFile = new StringBuilder();
            regFile.AppendLine("Windows Registry Editor Version 5.00");
            regFile.AppendLine("");

            // Lista todas as chaves e adiciona no arquivo "regFile"       
            await RegistryBackup_All_ProcessSubkey.RegistryCatalog(Key, regFile);

            // Salva o arquivo
            RegistryBackup_All_RegistryWriteFile.Write(UserName, regFile, ValueUniProgressBar);

        }      
    }
}
