using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace MeuSuporte
{
    internal class CheckBuild_CheckNetwork
    {
        // Verifica se a internet está disponível
        public async Task<bool> IsInternetAvailable()
        {
            try
            {
                using (var ping = new Ping())
                {
                    var reply = ping.Send("google.com", 3000); // Realiza um ping por 3 segundos para Servidor externo para verificar se tem conexao 
                    return reply.Status == IPStatus.Success;
                }
            }
            catch
            {
                return false; // Em caso de erro, não há conexão com a internet
            }
        }
    }
}
