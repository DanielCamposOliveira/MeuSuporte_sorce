using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeuSuporte
{
    internal class WinBloatware_MessageErroList
    {
        public async Task MessageError(string outputError, string AppTitulo, string AppComando)
        {
            // Dicionário de erros conhecidos com suas mensagens explicativas
            Dictionary<string, string> errosConhecidos = new Dictionary<string, string>
            {
                {
                    "0x80073CFA",
                    "Este aplicativo faz parte do Windows e não pode ser desinstalado no nível do usuário.\n" +
                    "Um administrador pode tentar remover o aplicativo do computador usando a opção \"Ativar e desativar recursos do Windows\".\n" +
                    "No entanto, talvez não seja possível desinstalar o aplicativo.\n"
                },
                {
                    "0x80073D01",
                    "O aplicativo está em uso e não pode ser removido ou atualizado neste momento.\n" +
                    "Tente fechar o app ou reiniciar o computador.\n"
                },
                {
                    "0x80073D02",
                    "O aplicativo possui arquivos que estão em uso por outro processo.\n" +
                    "Reinicie o sistema ou feche o aplicativo relacionado.\n"
                },
                {
                    "0x80070032",
                    "A função solicitada não está implementada.\n" +
                    "Pode ocorrer quando se tenta uma operação inválida para o estado do app.\n"
                },
                {
                    "0x80073CF0",
                    "O pacote está danificado ou ausente.\n" +
                    "Geralmente causado por arquivos corrompidos.\n"
                },
                {
                    "0x80073CF3",
                    "Conflito de dependências.\n" +
                    "Pode haver pacotes requeridos que não estão presentes ou não são compatíveis.\n"
                },
                {
                    "0x80073CF6",
                    "Falha geral durante a instalação ou remoção.\n" +
                    "Muitas vezes associada a problemas no manifest ou nas permissões do sistema.\n"
                },
                {
                    "0x80073CFF",
                    "Você está tentando operar sobre um pacote que não existe ou foi removido parcialmente\n"
                },
                {
                    "0x80070005",
                    "Acesso Negado! Você provavelmente não tem permissão.\n" +
                    "Tente executar como administrador pode resolver.\n"
                },
                {
                    "0x80070002",
                    "Arquivo não encontrado.\n" +
                    "Geralmente ocorre quando o caminho de instalação está corrompido ou faltando.\n"
                }
            };

            foreach (var erro in errosConhecidos)
            {
                if (outputError.Contains(erro.Key))
                {
                    await WinGlobal_UIService.Instance.AddMessage($"{AppTitulo} {{{AppComando}}} - uninstall failed \nCodigo Erro: {erro.Key} \nMensagem: {erro.Value}  ");
                    break;
                }
            }
        }
    }
}
