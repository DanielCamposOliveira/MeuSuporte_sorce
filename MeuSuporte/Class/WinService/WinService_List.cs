namespace MeuSuporte
{
    internal class WinService_List
    {
        public readonly string[] Google = {
            "GoogleUpdateService",  //Atualizações do Google em versões antigas
            "GoogleUpdateServiceGlobal",  //Versão global do serviço de atualização
            "gupdate",  //Agendadores de atualização do Chrome
            "gupdatem",  //Agendadores de atualização do Chrome
            "GoogleChromeElevationService", //Permite ações elevadas no Chrome  atualizações silenciosas
            "GoogleCrashHandler",  //Envio de falhas do Chrome/Drive para o Google
            "GoogleCrashHandler64",  //Envio de falhas do Chrome/Drive para o Google
            "gusvc",  //Google Update Service legados
        };

        public readonly string[] WindowsUpdate =
        {
            "InstallService", // Serviço de Instalação da Microsoft Store
            "wuauserv",  // Serviço de Windows Update
            "WSearch",        // Se não usa a pesquisa do Windows com frequência, pode desativar para reduzir o uso do disco.
            "WaaSMedicSvc",   // Permite a correção e a proteção dos componentes do Windows Update.
            "UsoSvc"

        };

        public readonly string[] All =
        {
            "AdobeUpdateService", // serviço da adobe
            "AGSService",         // serviço da adobe
            "AdobeARMservice",    // serviço da adobe
            "Microsoft Office Groove Audit Service", // serviço do Office
            "DbxSvc",   // Dropbox Service
            "SysMain",  // Pode ajudar em SSDs, mas em HDs pode ser útil.
            "UsoSvc", // Atualizar o Serviço Orchestrator    
            "XboxGipSvc", // Xbox Accessory Management Service
            "vmicvmsession", // Serviço Direto do Hyper-V PowerShell
            "vmicrdv", // Serviço de Virtualização de Área de Trabalho Remota do Hyper-V
            "UevAgentService", // Serviço de User Experience Virtualization
            "vmickvpexchange", // Serviço de Troca de Dados do Hyper-V
            "PhoneSvc", // Serviço de Telefonia
            "vmictimesync", // Serviço de Sincronização de Data/Hora do Hyper-V
            "perceptionsimulation", // Serviço de Simulação de Percepção do Windows
            "SensorService", // Serviço de Sensor rotação automática
            "XboxNetApiSvc", // Serviço de Rede Xbox Live
            "vmicheartbeat", // Serviço de Pulsação do Hyper-V
            "HvHost", // Serviço de Host HV
            "cloudidsvc", // Serviço de identidade Microsoft Cloud
            "icssvc", // Serviço de Hotspot Móvel do Windows
            "fhsvc", // Serviço de Histórico de Arquivos
            "lfsvc", // Serviço de Geolocalização
            "refsdedupsvc", // Serviço de duplicação do ReFS
            "vmicshutdown", // Serviço de Desligamento de Convidado do Hyper-V
            "WMPNetworkSvc", // Serviço de Compartilhamento de Rede do Windows Media Player
            "WbioSrvc", // Serviço de Biometria do Windows
            "Fax", // Se você não usa fax, pode desativar.           
            "SEMgrSvc", // Serviço de Gerenciador de NFC/SE e Pagamentos
            "MapsBroker", // Serviço de Mapas
            "WpnService", // Serviço de Notificações Push do Windows
            "XblAuthManager", // Serviço de Autenticação Xbox Live
            "vmicvss" // Solicitante de Cópia de Sombra de Volume do Hyper-V
        };
    }
}
