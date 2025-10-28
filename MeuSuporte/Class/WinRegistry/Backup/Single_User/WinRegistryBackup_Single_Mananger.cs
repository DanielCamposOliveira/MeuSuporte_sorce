using Microsoft.Win32;
using System.Text;
using System.Threading.Tasks;

namespace MeuSuporte
{
    // 1
    /// <summary>
    /// Class Responsavel por
    /// Criar o arquivo do registro
    /// Chamada do metado de adicionar os regsitro no arquivo 
    /// Chamada do metado de gravar o arquivo no Disco
    /// </summary>

    internal class WinRegistryBackup_Single_Mananger
    {
        private WinRegistryBackup_Single_RegistryWriteFile RegistryBackup_RegistryWriteFile;
        private WinRegistryBackup_Single_ProcessSubkey RegistryBackup_ProcessSubkey;
        public WinRegistryBackup_Single_Mananger() 
        {
            RegistryBackup_RegistryWriteFile = new WinRegistryBackup_Single_RegistryWriteFile();
            RegistryBackup_ProcessSubkey = new WinRegistryBackup_Single_ProcessSubkey();
        }
        public async Task Mananger(string NameFolder, RegistryKey RegistryCurrent, int ValueUniProgressBar)
        {
            WinGlobal_UIService.Instance.token.ThrowIfCancellationRequested(); // Checa se o cancelamento foi solicitado antes de começar

            // cria uma nova instância de StringBuilder.
            StringBuilder regFile = new StringBuilder();
            regFile.AppendLine("Windows Registry Editor Version 5.00");
            regFile.AppendLine("");

            //passa a REFERÊNCIA desse objeto(regFile) para o Subkey.
            await RegistryBackup_ProcessSubkey.Subkey(RegistryCurrent, regFile);

            // Grava o objeto(regFile) em um arquivo no Disco
            await RegistryBackup_RegistryWriteFile.Write(NameFolder, regFile, ValueUniProgressBar);  // Chama a Função de grava a chave no Disco            
        }
    }
}
