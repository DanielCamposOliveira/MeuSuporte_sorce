using System;
using System.DirectoryServices;
using System.Linq;
using System.Threading.Tasks;

namespace MeuSuporte
{
    internal class WinUser_AccountUpdate
    {

        private readonly WinUser_GroupAdministrators WinUser_GroupAdministrators;
        private readonly WinUser_GroupRemote WinUser_GroupRemote;
        private readonly WinUser_State WinUser_State;

        public WinUser_AccountUpdate()
        {
            WinUser_GroupAdministrators = new WinUser_GroupAdministrators();
            WinUser_GroupRemote = new WinUser_GroupRemote();
            WinUser_State = new WinUser_State();
        }

        public async Task Update(int ValueUniProgressBar, string NameUser, string PasswordUser) // altera a senha do usuario selecionado
        {
            try
            {
                WinGlobal_UIService.Instance.ProgressBarADD(ValueUniProgressBar / 2);
                WinGlobal_UIService.Instance.token.ThrowIfCancellationRequested(); // Checa se o cancelamento foi solicitado antes de começar

                DirectoryEntry EntradaUsuario = new DirectoryEntry("WinNT://" + Environment.MachineName + ",Computer");

                if (EntradaUsuario.Children != null)
                {
                    var results = EntradaUsuario.Children.Cast<DirectoryEntry>().Where(r => r.SchemaClassName == "User").OrderBy(r => r.Name);

                    foreach (DirectoryEntry child in results)
                    {
                        if (child.Name == NameUser) // seleciona o Usuario
                        {
                            await WinUser_GroupAdministrators.Add(child);  // adiciona no grupo
                            await WinUser_GroupRemote.Add(child);  // adiciona no grupo

                            await WinUser_State.State(child, false); // abilita usuario
                            child.Invoke("SetPassword", new Object[] { PasswordUser });   // altera a senha do usuario

                            WinGlobal_UIService.Instance.ProgressBarADD(ValueUniProgressBar / 2);
                            await WinGlobal_UIService.Instance.Log_MensagemAsync($"Manutenção de usuario: Conta Atualizado com Sucesso", true);
                            await WinGlobal_UIService.Instance.Log_MensagemAsync($"Usuario: {NameUser}", true);
                            await WinGlobal_UIService.Instance.Log_MensagemAsync($"Senha: {PasswordUser}", true);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                WinGlobal_UIService.Instance.Erro++;
                await WinGlobal_UIService.Instance.Log_MensagemAsync($"Manutenção de usuario: Ocorreu um Erro ao tentar Atualizar a senha do Usuario {NameUser}", true);
            }
        }

    }
}
