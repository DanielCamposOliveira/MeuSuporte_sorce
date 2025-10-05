using System.Threading.Tasks;

namespace MeuSuporte
{
    internal class WinRestorePoint_Mananger
    {
        private readonly WinRestorePoint_IsSystemRestoreEnabled _IsSystemRestoreEnabled;
        
        public WinRestorePoint_Mananger()
        {
            _IsSystemRestoreEnabled = new WinRestorePoint_IsSystemRestoreEnabled();
        }

        public async Task Mananger()
        {
            await CreateSystemPoint();
        }

        private async Task CreateSystemPoint()
        {
            //1° verifica se a configuração esta ativa
            if (!await _IsSystemRestoreEnabled.IsSystemRestoreEnabledAsync())
            {
                // ativa a configuração
                WinRestorePoint_EnableProtection _Class_EnableProtection = new WinRestorePoint_EnableProtection();
                if (!await _Class_EnableProtection.EnableProtection(WinGlobal_UIService.Instance.ValueUniProgressBar / 3))
                    return;                
            }

            // Gera uma Descrição para o Ponto de Restauração
            WinRestorePoint_PointName _PointName = new WinRestorePoint_PointName();
            string NamePoint = _PointName.GetName();
            await Task.Delay(500);


            //2° Cria Ponto de Restauração
            WinRestorePoint_Create _PointCreate = new WinRestorePoint_Create();
            if (!await _PointCreate.CreatePoint(NamePoint, WinGlobal_UIService.Instance.ValueUniProgressBar / 3))
                return;


            await Task.Delay(2000);

            //3° Procura pelo Ponto de Restauração recém-criado
            WinRestorePoint_PointSearch _PointSearch = new WinRestorePoint_PointSearch();
            if (!await _PointSearch.PointSearch(NamePoint, WinGlobal_UIService.Instance.ValueUniProgressBar / 3))
                return;

         //   await _PointSearch.PointSearch(NamePoint, WinGlobal_UIService.Instance.ValueUniProgressBar / 3); // Executa a tarefa async em uma nova thread                 
        }
    }
}
