using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace MeuSuporte
{
    /// <summary>
    /// Class Responsavel por
    /// Criar o arquivo do registro
    /// Chamada do metado de adicionar os regsitro no arquivo 
    /// Chamada do metado de gravar o arquivo no Disco
    /// </summary>

    internal class WinRegistryBackup_Key
    {
        private  WinRegistryBackup_RegistryFile RegistryFile;
        private  WinRegistryBackup_ProcessSubkey ProcessSubkey;

        public WinRegistryBackup_Key()
        {
            RegistryFile = new WinRegistryBackup_RegistryFile();
            ProcessSubkey = new WinRegistryBackup_ProcessSubkey();
        }
        public async Task Backup(string NameFolder, RegistryKey RegistryCurrent, int ValueUniProgressBar)
        {
            WinGlobal_UIService.Instance.token.ThrowIfCancellationRequested(); // Checa se o cancelamento foi solicitado antes de começar

            // cria uma nova instância de StringBuilder.
            StringBuilder regFile = new StringBuilder();
            regFile.AppendLine("Windows Registry Editor Version 5.00");
            regFile.AppendLine("");

            //passa a REFERÊNCIA desse objeto(regFile) para o Subkey.
            await ProcessSubkey.Subkey(RegistryCurrent, regFile);

            // Grava o objeto(regFile) em um arquivo no Disco
            await RegistryFile.Write(NameFolder, regFile, ValueUniProgressBar);  // Chama a Função de grava a chave no Disco            
        }
    }
}
