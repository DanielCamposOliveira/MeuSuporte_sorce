using System;
using System.DirectoryServices;
using System.Threading.Tasks;

namespace MeuSuporte
{
    internal class WinUser_AccountCreate
    {

        private readonly WinUser_GroupAdministrators WinUser_GroupAdministrators;
        private readonly WinUser_GroupRemote WinUser_GroupRemote;
       
        public WinUser_AccountCreate()
        {
            WinUser_GroupAdministrators = new WinUser_GroupAdministrators();
            WinUser_GroupRemote = new WinUser_GroupRemote();
        }

        public async Task Create(int ValueUniProgressBar, string NameUser, string PasswordUser )
        {
            try
            {
                WinGlobal_UIService.Instance.ProgressBarADD(ValueUniProgressBar / 2);
                WinGlobal_UIService.Instance.token.ThrowIfCancellationRequested(); // Checa se o cancelamento foi solicitado antes de começar

                // cria usuario
                DirectoryEntry EntradaDiretorioGrupos = new DirectoryEntry("WinNT://" + Environment.MachineName + ",computer");
                DirectoryEntry EntradaDiretorioUsuarios = EntradaDiretorioGrupos.Children.Add(NameUser, "user");
                EntradaDiretorioUsuarios.Invoke("SetPassword", new object[] { PasswordUser });
                EntradaDiretorioUsuarios.CommitChanges();

                // atribui os grupos para o usuario
                await WinUser_GroupRemote.Add(EntradaDiretorioUsuarios);
                await WinUser_GroupAdministrators.Add(EntradaDiretorioUsuarios);

                WinGlobal_UIService.Instance.ProgressBarADD(ValueUniProgressBar / 2);
                WinGlobal_UIService.Instance.Sucesso++;
                await WinGlobal_UIService.Instance.Log_MensagemAsync($"Manutenção de usuario: Conta Criada com Sucesso", true);
                await WinGlobal_UIService.Instance.Log_MensagemAsync($"Usuario: {NameUser}", true);
                await WinGlobal_UIService.Instance.Log_MensagemAsync($"Senha: {PasswordUser}", true);
            }
            catch (Exception ex)
            {
                WinGlobal_UIService.Instance.Erro++;
                await WinGlobal_UIService.Instance.Log_MensagemAsync($"Manutenção de usuario: Ocorreu um Erro ao tentar Criar Usuario {NameUser}", true);
            }
        }
    }
}
