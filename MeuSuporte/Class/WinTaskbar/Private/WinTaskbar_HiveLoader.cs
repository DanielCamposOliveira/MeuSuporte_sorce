using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Threading;

namespace MeuSuporte
{
    internal class WinTaskbar_HiveLoader
    {
        private static readonly IntPtr HKEY_USERS = new IntPtr(unchecked((int)0x80000003));

        #region P/Invoke Declarations (A CORREÇÃO ESTÁ AQUI!)

        [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern int RegLoadKey(IntPtr hKey, string lpSubKey, string lpFile);

        [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern int RegUnLoadKey(IntPtr hKey, string lpSubKey);

        #endregion

        //monta o arquivo NTUSER.DAT (o registro do usuário) em uma subchave
        //temporária (hiveName) dentro de HKEY_USERS, permitindo que o código acesse
        //as configurações de um usuário que não está logado ou que não é o usuário atual
        public void LoadHive(string hiveName, string ntUserDatPath)
        {
            // A chamada usa o método estático da DllImport nativa 'RegLoadKey' da API do Windows
            int result = RegLoadKey(HKEY_USERS, hiveName, ntUserDatPath);

            if (result != 0)
            {
                throw new Win32Exception(result, $"Falha ao carregar o hive '{hiveName}'. Código de erro: {result}");
            }
        }


        //Esta função remove o ninho de registro temporário (hiveName) montado anteriormente
        // de HKEY_USERS, liberando o arquivo NTUSER.DAT para que o sistema operacional
        public void UnloadHive(string hiveName)
        {
            const int MaxRetries = 3;
            const int DelayMs = 100; // 100 milissegundos

            for (int attempt = 1; attempt <= MaxRetries; attempt++)
            {
                int result = RegUnLoadKey(HKEY_USERS, hiveName);

                if (result == 0)
                {
                    // Sucesso no descarregamento
                    return;
                }

                // Falha ao descarregar o hiveName entao aguarda um tempo para espera a liberacao
                if (attempt < MaxRetries)
                {
                    // Pausa breve antes de tentar novamente
                    Thread.Sleep(DelayMs);
                }
            }
        }
    }
}
