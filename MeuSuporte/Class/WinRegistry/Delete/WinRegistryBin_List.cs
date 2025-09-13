namespace MeuSuporte
{
    internal class WinRegistryBin_List
    {
        // somente o Diretorio faz como que todas chaves que use esse diretorio não seja apagado
        //C:\Windows\System32           

        // Diretorio + Executavel faz com que todas as chaves que não tenha o Executavel e que use o diretorio seja apagado
        //C:\Windows\System32\teste.exe   

        public readonly string[] RootPath = {
        @"C:\Windows\System32\DriverStore", //Driver do Windows
        };
    }
}
