namespace MeuSuporte
{
    internal class WinRegistryBin_List
    {
        // somente o Diretorio faz como que todas chaves que use esse diretorio não seja apagado
        //C:\Windows\System32           

        // Diretorio + Executavel faz com que todas as chaves que não tenha o Executavel e que use o diretorio seja apagado
        //C:\Windows\System32\teste.exe   

        public readonly string[] KeyDirectory = {
        @"C:\Windows\System32\DriverStore", //Driver do Windows
        @"C:\Program Files\NVIDIA Corporation",
        @"C:\Program Files\Realtek",  // Driver de Audio
        @"C:\Program Files\Wave",
        @"C:\Program Files\GO-Signer",
        @"C:\Program Files\Leucotron Telecom",
        @"C:\Program Files (x86)\Wave",        
        @"C:\Program Files (x86)\GO-Signer",
        @"C:\Program Files (x86)\Leucotron Telecom",
        @"C:\Program Files (x86)\NVIDIA",   // Driver de Video   
        @"C:\Program Files (x86)\AnyDesk",
        @"C:\Program Files\AnyDesk",
        };


        public readonly string[] KeyName = {
        "AgenteExecucaoAssistente",
        "ConsultaNF-e_SEFAZ_RS",
        "WebServicePortalFederal",
        "Lightshot",
        "Wave",
        "GestaoPlugin",
        "GestaoPluginx64",
        "DANFEViewMon",
        "DANFEViewWatch",
        "DANFEViewUniNFe",
        "Tecnobyte Agenda",
        "Agente de Execução do Assistente Virtual",
        "CriptoCNS",
        "Valid Agent Server", // auxilia na emissão de certificados digitais do tipo A1 através do navegador Google Chrome
        };

        //
        public readonly string[] KeyCloud = {
            "OneDrive",
            "GoogleDriveFS"
        };
    }
}
