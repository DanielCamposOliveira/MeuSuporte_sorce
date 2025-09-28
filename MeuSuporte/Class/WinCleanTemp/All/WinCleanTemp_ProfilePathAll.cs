using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace MeuSuporte
{
    internal class WinCleanTemp_ProfilePathAll
    {
        private WinGlobal_DirectoryMananger DirectoryManange;

        // Usuarios Ignorados
        private static readonly HashSet<string> IgnoredUserProfiles = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
        "All Users",
        "Default",
        "Default User",
        "Public",
        "Todos os Usuários",
        "Usuário Padrão"
        };

        //public List<string> GetUserProfilePaths()
        public async Task<List<string>> GetUserProfilePathsAsync()
        {
            var PathListProfile = new List<string>();
            DirectoryManange = new WinGlobal_DirectoryMananger();

            // Pega o caminho da pasta "Users", normalmente "C:\Users"
            string usersFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile); // C:\Users\Usuario
            string baseUsersPath = Path.GetDirectoryName(usersFolderPath); // C:\Users

            if (string.IsNullOrEmpty(baseUsersPath))
            {
                //Não foi possível encontrar a pasta de usuários
                return PathListProfile;
            }

            // Pega todos os diretórios dentro da pasta "C:\Users"
            string[] userDirectories = Directory.GetDirectories(baseUsersPath);

            foreach (string userDir in userDirectories)
            {
                WinGlobal_UIService.Instance.token.ThrowIfCancellationRequested(); // Checa se o cancelamento foi solicitado antes de começar

                // Pega o nome do usuário a partir do caminho (ex: "Nome do Usuario")
                string userName = new DirectoryInfo(userDir).Name;

                // verifica se o Usuario esta na lista IgnoredUserProfiles
                if (IgnoredUserProfiles.Contains(userName))
                {
                    continue;
                }

                // Monta o caminho para a pasta Temp do usuário específico
                string tempPath = Path.Combine(userDir, "AppData", "Local", "Temp");

                // verifica se diretorio existe
                if (!DirectoryManange.Check(tempPath))
                {
                    WinGlobal_UIService.Instance.Erro++;
                    //  await WinGlobal_UIService.Instance.Log_MensagemAsync($"{applicant}: Ocorreu um erro ao tentar acessa o diretório {_NameFolder}", true);
                    continue;
                }

                // adiciona o caminho na lista
                PathListProfile.Add(tempPath);
            }            
            return PathListProfile;
        }
    }
}
