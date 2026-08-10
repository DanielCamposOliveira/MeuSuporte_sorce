# Assistente de Manutenção Preventiva - Código-fonte

O Assistente de Manutenção Preventiva é uma ferramenta desenvolvida para auxiliar na manutenção e otimização do Windows, permitindo realizar diversas tarefas automáticas, como limpeza de arquivos temporários, desativação de processos e backup de configurações importantes.

#
<img width="969" height="720" alt="image" src="https://github.com/user-attachments/assets/123cef07-d6ee-4841-bb52-a16aa739759c" />

## Clone este repositório:
``` bash
git clone https://github.com/DanielCampos2017/MeuSuporte.git
```

## Contribuição
Sinta-se à vontade para sugerir melhorias ou relatar problemas através do Email
``` bash
Daniel_cpd2017@HotMail.com
```
## Requisitos
- Windows 10 ou superior
- Permissões de administrador para executar
- .NET Framework 4.8 ou superior



## Funcionalidades Implementada
- [x] Otimiza Barra de Tarefas
- [x] Notificação UAC ao Usuário
- [x] Limpar tarefas Agendadas
- [x] Limpar Lixeira
- [x] Desativar Processos
- [x] Limpar Pasta %Temp%
- [x] Desativar o Windows Update
- [x] Limpar Google Update
- [x] Backup Registro
- [x] Pagefile.sys
- [x] Backup de Driver
- [x] Limpar Registros
- [x] Usuário "Suporte"
- [x] Limpar Prefetch
- [x] Backup do BootBCD
- [x] Criar Ponto de Restauração
- [x] Acesso Remoto RDP
- [ ] ~~Remover Bloatware~~
- [x] Backup Relatorio de Erros do Windows
- [x] Limpar Relatorio de Erros do Windows
- [ ] ~~Exportar inventario~~
- [x] Perfil Graphic
- [x] Perfil de Energia
- [x] Salva Log dos processos executados

---

# Documentação das funcionalidade do programa


## Otimiza Barra de Tarefas 
 
Remove os Icones da Barra de Terefas, Aumentando o espaço útil da Barra de Terefas do **Usuário** atual e tendo a opção de escolha de **Todos Usuário**

- Ocultar o icone de **barra de pesquisa do Windows**
- Ocultar o icone de **Visão de Tarefas**
- Ocultar o icone de **Saiba mais sobre esta imagem**




## Notificação UAC ao Usuário 
 
Ativa\Desativa notificação **Pop-Up de Controle de Conta de Usuário (UAC)** para o **Usuário** atual e tendo a opção de escolha de **Todos Usuário**

Esse é recurso de segurança do Windows. Que solicita permissão para que um aplicativo faça alterações no sistema
Essa notificação aparece quando um programa precisa de privilégios administrativos, como ao instalar software ou modificar configurações





## Limpar tarefas Agendadas 

Remove tarefas agendadas desnecessárias que podem estar consumindo recursos ou afetando o desempenho do sistema.




## Limpar Lixeira 

Exclui permanentemente os arquivos armazenados na Lixeira do usuário atual para liberar espaço em disco.




## Desativar Processos

Remove os processos que roda em segundo plano que podem estar consumindo recursos Desnecessários.

**Serviços**
- **AdobeUpdateService** = Serviço da Adobe
- **AGSService** = Serviço da Adobe
- **AdobeARMservice** = Serviço da Adobe
- **DbxSvc** = Dropbox
- **Microsoft Office Groove Audit Service** = Serviço do Office
- **SysMain** = Pode ajudar em SSDs, mas em HDs pode ser útil
- **UsoSvc** = Atualização do Serviço Orchestrator
- **XboxGipSvc** = Xbox Accessory Management Service
- **vmicvmsession** = Serviço Direto do Hyper-V PowerShell
- **vmicrdv** = Serviço de Virtualização de Área de Trabalho Remota do Hyper-V
- **UevAgentService** = User Experience Virtualization
- **vmickvpexchange** = Serviço de Troca de Dados do Hyper-V
- **PhoneSvc** = Serviço de Telefonia
- **vmictimesync** = Serviço de Sincronização de Data/Hora do Hyper-V
- **perceptionsimulation** = Serviço de Simulação de Percepção do Windows
- **SensorService** = Serviço de Sensor rotação automática
- **XboxNetApiSvc** = Serviço de Rede Xbox Live
- **vmicheartbeat** = Serviço de Pulsação do Hyper-V
- **HvHost = Serviço** de Host HV
- **cloudidsvc** = Serviço de identidade Microsoft Cloud
- **icssvc** = Serviço de Hotspot Móvel do Windows
- **fhsvc** = Serviço de Histórico de Arquivos
- **lfsvc** = Serviço de Geolocalização
- **refsdedupsvc** = Serviço de duplicação do ReFS
- **vmicshutdown** = Serviço de Desligamento de Convidado do Hyper-V
- **WMPNetworkSvc** = Serviço de Compartilhamento de Rede do Windows Media Player
- **WbioSrvc** = Serviço de Biometria do Windows
- **Fax** = Se você não usa fax, pode desativar
- **SEMgrSvc** = Serviço de Gerenciador de NFC/SE e Pagamentos
- **MapsBroker** = Serviço de Mapas
- **WpnService** = Serviço de Notificações Push do Windows
- **XblAuthManager** = Serviço de Autenticação Xbox Live




## Limpar Pasta %Temp% 

Remove arquivos temporários do **Usuário** atual e tendo a opção de escolha de **Todos** para liberar espaço e melhorar o desempenho.
``` bash
%LOCALAPPDATA%\Temp

```



## Desativar o Windows Update

Desativa serviço do Windows Update para evitar atualizações automáticas que podem impactar o desempenho ou causar reinicializações indesejadas para o **Usuario Atual**

**Serviços**
- **InstallService** = Serviço de Instalação da Microsoft Store
- **svsvc** = Serviço de Verificador de Ponto
- **wuauserv** = Serviço de Windows Update
- **WSearch** = Serviço de Pesquisa do Windows

Remove os arquivos de atualizações não realizada
``` bash
%WinDir%\SoftwareDistribution\Download
``` 




## Limpar Google Update

Remove serviços e processos relacionados ao Google Update, evitando consumo excessivo de recursos por atualizações automáticas do Google Chrome

``` bash
%ProgramFiles(x86)%\Google\GoogleUpdater
%ProgramFiles(x86)%\Google\Update
```

**Serviços**
- **edgeupdate** = Serviço do google
- **edgeupdatem** = Serviço do google
- **gupdatem** = Serviço do google
- **gupdate** = Serviço do google
- **GoogleChromeElevationService** = Serviço do google
- **gusvc** = Serviço do google




## Backup Registro
  
Faz uma cópia de segurança do Registro do *Usuário** atual e tendo a opção de escolha de **Todos Usuário** garantindo a possibilidade de restauração em caso de problemas.

``` bash
Computador\HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run
Computador\HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Run
Computador\HKEY_LOCAL_MACHINE\Software\WOW6432Node\Microsoft\Windows\CurrentVersion\Run 
``` 



## Otimizar Memória Virtual

Otimiza o arquivo de paginação do Windows (Pagefile.sys), ajustando seu tamanho ou desativando-o conforme a necessidade do usuário.




## Backup de Drivers 

Cria uma cópia de segurança dos drivers instalados no sistema, permitindo restaurá-los em caso de falha ou reinstalação do Windows.

Execute o comando no **CMD** como Administrador para restaura os **Driver** do windows, contendo a pasta no diretorio C:\DriversBackup\

``` bash
 pnputil /add-driver "C:\DriversBackup\*.inf" /subdirs /install
```



## Limpar Registros 

Remove chaves de registros do desnecessárias ou obsoletas do Registro Windows no **Usuário** atual e tendo a opção de escolha de **Todos Usuário** para melhorar a estabilidade e o desempenho. 

``` bash
Computador\HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run
Computador\HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Run
Computador\HKEY_LOCAL_MACHINE\Software\WOW6432Node\Microsoft\Windows\CurrentVersion\Run
```

Remove inicialiação de Serviço de armazenamento em Nuvem. Mantendo somente os Serviço que o Usuario esta logado
- OneDrive
- GoogleDrive

#### Lista de Registro que não ira **apaga** 
Módulo de consulta de Notas Fiscais eletrônicas (NF-e) junto à SEFAZ do estado do Rio Grande do Sul.
- ConsultaNF-e_SEFAZ_RS

Serviço de comunicação com portal federal da Receita para validação e transmissão de documentos fiscais.
- WebServicePortalFederal

Aplicativo impressão do Documento Auxiliar da Nota Fiscal Eletrônica (DANFE).
- DANFEViewUniNFe
- DANFEViewMon
- DANFEViewWatch

Ferramenta de captura de tela simples e rápida
- Lightshot

Aplicativo de telefonia via internet
- Wave

Programa de acesso remoto
- AnyDesk

Plugins de integração com sistemas de gestão empresarial (ERP)
- GestaoPlugin
- GestaoPluginx64

Aplicativo de agenda e gerenciamento de compromissos Tecnobyte
- Tecnobyte Agenda

Ferramenta de criptografia utilizada para garantir a segurança de certificados digitais
- CriptoCNS

Serviço responsável pela validação e autenticação de certificados e transações digitais dentro do sistema.
- Valid Agent Server
- AgenteExecucaoAssistente

Conjunto de drivers e utilitários gráficos responsáveis pelo funcionamento da placa de vídeo
- NVIDIA Corporation

Software e drivers desenvolvidos pela Leucotron, utilizados para integração com sistemas de telefonia corporativa (PABX)
- Leucotron Telecom

Aplicativo de assinatura digital  (como NF-e, CT-e e MDF-e) com certificados digitais A1 ou A3
- GO-Signer

Drivers e utilitários de áudio ou rede desenvolvidos pela Realtek Semiconductor
- Realtek

Drivers do sistema operacional Windows
- DriverStore





## Usuário "Suporte"

Cria uma conta Local com privilégio administrador para facilitar a manutenção e resolução de problemas no sistema.
 
``` bash
Nome: Suporte
Senha: r46W6h8#
```




## Limpar Prefetch
 
Remover Arquivos de Inicialização Lenta no (Prefetch) que podem estar desatualizados e impactar negativamente o desempenho do sistema.

``` bash
%WinDir%\Prefetch
```



## Backup do BootBCD 

Faz uma cópia de segurança do arquivo **BCD_Backup.zip** "Boot Configuration Data (BCD)", configurações de inicialização possam ser restauradas caso ocorram problemas.

Quando restaura
- O Windows não inicia por erro no BCD (“Boot Configuration Data missing/corrupt”);
- Após falhas em dual boot ou remoção de outro sistema operacional;
- Depois de reinstalar o Windows e precisar recuperar entradas antigas de inicialização.

Segue os passos para restauração:

Remova a proteção do arquivo BCD atual 
``` bash
attrib C:\boot\bcd -r -s -h
```

Renomeie o BCD atual para manter uma cópia de segurança
``` bash
ren C:\boot\bcd bcd.old
```

Importe o backup do BCD
``` bash
bcdedit /import C:\bcdbackup
```

Reative os atributos de proteção
``` bash
attrib C:\boot\bcd +r +s +h
```
Verifique se o BCD foi restaurado corretamente
``` bash
bcdedit /enum all
```




## Ponto de Restauração 
 
Cria um Ponto de Restauração do Sistema para reverter o estado do seu sistema operacional para um momento anterior, sem afetar seus arquivos pessoais,

Finalidade:
- **Corrigir falhas** = Se o seu PC apresentar lentidão, travamentos ou erros após a instalação de um novo programa, driver ou atualização do Windows
- **Desfazer alterações do sistema** = Ele desfaz modificações feitas em arquivos do sistema, configurações e no registro do Windows que possam ter causado instabilidade
- **Recuperar de problemas** = É uma maneira rápida de solucionar problemas sem precisar reinstalar todo o sistema operacional




## Acesso Remoto RDP 
 
Ativa\Desativa O Acesso Remoto RDP (Remote Desktop Protocol)

- **Suporte técnico** = Equipes de suporte podem acessar o computador do usuário para diagnosticar e resolver problemas.
- **Trabalho remoto** = Usuario conseguem se conectar ao computador do escritório para acessar arquivos e programas para trabalhar remotamente




## Limpar Bloatware pré instalados

Remove os **Bloatware** pré-instalados no sistema que 90% não são úteis para o usuário final, como alguns jogos ou versões de teste de programas pagos

- 3DBuilder  = 3D Builder  
- AdobeSystemsIncorporated.AdobeExpress  = Adobe Express  
- AgeofEmpiresCastleSiege  = Age of Empires Castle Siege  
- WindowsAlarms  = Alarmes  
- AmazonAppstore  = Amazon Appstore  
- GAMELOFTSA.Asphalt8Airborne  = Asphalt 8  
- QuickAssist  = Assistência Rápida  
- Astro  = Astro  
- king.com.BubbleWitch3Saga  = Bubble Witch 3  
- Sagaking.com.BubbleWitch3Saga  = Bubble Witch 3 Saga  
- king.com.CandyCrushFriends  = Candy Crush Friends Saga  
- king.com.CandyCrushSaga  = Candy Crush Saga  
- ScreenSketch  = Captura e Esboço  
- Clipchamp  = Clipchamp  
- BingWeather  = Clima  
- Copilot  = Copilot  
- Cortana  = Cortana  
- Microsoft.Getstarted  = Dicas  
- BingFinance  = Dinheiro  
- Disney.37853FC22B2CE  = Disney Magic Kingdoms  
- Samsung.Earbuds  = Earbuds  
- windowscommunicationsapps  = Email e Calendário  
- BingSports  = Esportes  
- Facebook.Facebook  = Facebook  
- WindowsFeedbackHub  = Feedback Hub  
- ZuneVideo  = Filmes & TV  
- Windows.Photos  = Fotos  
- CommsPhone  = Gerenciador de Telefone  
- WindowsSoundRecorder  = Gravador de voz  
- G5Entertainment.HiddenCityMysteryofShadows  = Hidden City Hidden Object Adventure  
- Facebook.InstagramBeta  = Instagram  
- LinkedIn.LinkedIn  = LinkedIn  
- WindowsMaps  = Mapas  
- Gameloft.SE.MarchofEmpires  = March of Empires  
- McAfee.McAfee  = McAfee  
- Messaging  = Mensagens  
- MicrosoftOfficeHub  = Microsoft 365 (Hub)  
- Microsoft.Todos  = Microsoft To Do  
- ZuneMusic  = Música (Groove)  
- NarratorQuickStart  = Narrador  
- BingNews  = News (Notícias)  
- BingNews  = Notícia  
- MicrosoftStickyNotes  = Notas autoadesivas  
- Office.GetOffice  = Obter o Office  
- SkypeApp  = Obter o Skype  
- Office.Sway  = Office Sway  
- OneConnect  = OneConnect  
- OneDrive  = OneDrive  
- Office.OneNote  = OneNote  
- People  = Pessoas  
- PhoneCompanion  = Phone Companion  
- PowerAutomateDesktop  = Power Automate Desktop  
- Amazon.com.AmazonVideo  = Prime Video  
- Print3D  = Print 3D  
- MixedReality.Portal  = Realidade Misturada Portal  
- ROBLOXCORPORATION.ROBLOX  = Roblox  
- MicrosoftSolitaireCollection  = Solitário  
- NetworkSpeedTest  = Speed Test  
- SpotifyAB.SpotifyMusic  = Spotify  
- MicrosoftTeams  = Teams  
- BytedancePte.Ltd.TikTok  = TikTok  
- Twitter.Twitter  = Twitter  
- MixedReality.Viewer  = Visualizador 3D  
- Whiteboard  = Whiteboard  
- WindowsMediaPlayer  = Windows Media Player  
- XboxApp  = Xbox  
- XboxGamingOverlay  = Xbox Game Bar  
- XboxSpeechToTextOverlay  = Xbox Game Speech Window  
- XboxIdentityProvider  = Xbox Identity Provider




## Backup Relatorio de Erros do Windows  
 
Cria um arquivo compactado no formato .Zip de todos os Relatório Erros do Sistema e dos Aplicativos

Descompacte os arquivos nos diretórios abaixo
``` bash
C:\ProgramData\Microsoft\Windows\WER\ReportQueue\
C:\ProgramData\Microsoft\Windows\WER\ReportArchive\
```
Para visualizar os Relatorios basta ir no Painel de controle do windows
Painel de Controle\Sistema e Segurança\Segurança e Manutenção\Relatórios de Problemas



## Limpar Relatorio de Erros do Windows  
 
Apagar todos os arquivo de Relatório Erros do Sistema e dos Aplicativos.
ideal para manter um controle de erros recorrentes na maquina



## Perfil Graphic 
 
Permite altera o perfil de acordo com sua preferência.

- Desempenho:
   - Sistema rápido e leve
- Aparência:
   - Interface bonita e fluida 




## Perfil de Energia 
 
### Permite altera o **Plano** de energia de acordo com sua preferência.
#### ⚡ Plano de Desempenho
- Foco: 
	- máximo desempenho do sistema.
- Características:
	- Mantém o processador funcionando em frequências mais altas.
	- Reduz o tempo que o sistema espera antes de desligar componentes (como tela e disco).
	- O ventilador trabalha mais, e o notebook pode esquentar mais.
- Vantagens: 
	- ideal para tarefas pesadas como jogos, renderização, edição de vídeo, e softwares de engenharia.

#### ⚙️ Plano Equilibrado
- Foco: 
	- equilíbrio entre desempenho e economia de energia.
- Características:
	- Ajusta dinamicamente a velocidade do processador conforme a carga de trabalho.
	- Economiza energia quando o sistema está ocioso.
- Vantagens: 
	- bom desempenho na maioria das tarefas do dia a dia, sem gastar energia à toa.

#### 🔋 Plano de Economia de Bateria
- Foco: 
	- prolongar a duração da bateria.
- Características:
	- Reduz o brilho da tela.
	- Limita a frequência do processador.
	- Desativa tarefas em segundo plano e notificações não essenciais.
- Vantagens:
	- ótimo para quando você precisa usar o notebook por mais tempo longe da tomada.



## Salva Log dos processos executados 
 
Após a finalização do Software o mesmo ira criar uma pasta com nomenclatura "**Preventiva Dia-Mês-Ano**" no mesmo diretório da execução do Software, com os os Logs de todo o processo realizado, para fim de auditoria.



