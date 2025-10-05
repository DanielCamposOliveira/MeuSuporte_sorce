using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MeuSuporte
{
    internal class WinBackupBCD_ProcessController
    {
        private readonly  WinGlobal_DirectoryMananger DirectoryManange;
        private readonly  WinBackupBCD_ProcessInfo BCD_ProcessInfo;

        public WinBackupBCD_ProcessController()
        {
            DirectoryManange = new WinGlobal_DirectoryMananger();
            BCD_ProcessInfo = new WinBackupBCD_ProcessInfo();
        }

        public async Task Create(int ValueUniProgressBar)
        {
            string NameFolder = "BCD_Backup";

            try
            {
                WinGlobal_UIService.Instance.token.ThrowIfCancellationRequested(); // Checa se o cancelamento foi solicitado antes de começar

                // Cria o diretorio
                if (DirectoryManange.Create(NameFolder) == false)
                {
                    await WinGlobal_UIService.Instance.Log_MensagemAsync($"Backup BCD: Ocorreu um erro ao tentar criar Pasta {NameFolder}", true);
                    return;
                }

                WinGlobal_UIService.Instance.ProgressBarADD(ValueUniProgressBar / 2);

                //Cria um processo para executar
                var processStartInfo = BCD_ProcessInfo.Create(DirectoryManange.GetDirectory(NameFolder));

                using (var process = new Process { StartInfo = await processStartInfo.ConfigureAwait(false) })
                {
                    process.Start();
                    await WaitForExitAsync(process);
                    await Task.Delay(500);                    
                    await WinGlobal_UIService.Instance.Log_MensagemAsync("Backup BCD: Criado com Sucesso", true);
                }

                WinGlobal_UIService.Instance.Sucesso++;
                await WinGlobal_UIService.Instance.ProgressBarADD(ValueUniProgressBar / 2);
            }
            catch (Exception ex)
            {
                WinGlobal_UIService.Instance.Erro++;
                await WinGlobal_UIService.Instance.Log_MensagemAsync("Backup BCD: Erro - " + ex.Message, true);
                await Task.Delay(500);
            }
        }

        // Executa a tarefa async em uma nova thread
        private async Task WaitForExitAsync(Process process)
        {
            await Task.Run(() => process.WaitForExit());
        }



        //Abra as Opções avançadas de inicialização
        //Execute o comando Bootrec /ScanOS para verificar os sistemas instalados
        //Reinicie o computador
        //Se o problema persistir, execute os seguintes comandos:
        //bcdedit /export c:\bcdbackup
        //attrib c:\boot\bcd -r -s -h
        //ren c:\boot\bcd bcd.old
        //bootrec /rebuildbcd
        //Reinicie o sistema
        //Se a ferramenta do Bootrec.exe não conseguir localizar uma instalação do Windows, pode ser necessário remover e recriar o BCD store. 
        //O BCDBoot é uma ferramenta de linha de comando que configura os arquivos de inicialização para executar o sistema operacional Windows. O arquivo de registro BCD está localizado no diretório //\Boot\Bcd da partição ativa. 

    }
}
