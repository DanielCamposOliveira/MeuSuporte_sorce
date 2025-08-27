using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeuSuporte
{
    internal class WinBloatware_Mananger
    {
        private  WinBloatware_CheckInstallation CheckInstallation;

        public async Task Mananger()
        {
            CheckInstallation = new WinBloatware_CheckInstallation();

            var Bloatware_List = new WinBloatware_List();
            List<WinBloatware_Format> Bloatware_Format = Bloatware_List.List(); // carrega a lista para struct
            int loop = 0;

            foreach (var bloat in Bloatware_Format)
            {
                WinGlobal_UIService.Instance.token.ThrowIfCancellationRequested();  // Checa se o cancelamento foi solicitado antes de começar
                                
                await CheckInstallation.Check(bloat); // Executa o a função Async em uma nova thread
                loop++;
                await Task.Delay(300);
                await WinGlobal_UIService.Instance.Log_MensagemAsyncSobrescrever($"Removendo Bloatware {loop} / {Bloatware_Format.Count} ");
            } 
        }

        
        //#removido com sucesso
        //Notícia {BingNews} - uninstall success

        //#falha na desinstalação
        //Notícia {BingNews} - uninstall failed

        //#não encontrado
        //Notícia {BingNews} - not found
    }
}
