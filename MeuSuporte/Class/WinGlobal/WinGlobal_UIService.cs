using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MeuSuporte
{
    internal class WinGlobal_UIService
    {
        public MainForm InterfaceGUI;
        private TextBox _logTextBox;
        private static WinGlobal_UIService _instance;
               
        private ProgressBar _progressBar;
        
        public int ValueUniProgressBar;
        public int Sucesso;
        public int Erro;
        public string UserName;

        public CancellationToken token;

        private PictureBox pictureBoxInfoDescricao;
        private Label labelInfoTitulo;
        private Label labelInfoDescricao;
        private CheckBox checkBox_UserUAC;

        private WinApp_Log _WinApp_Log;

        // Inicialização (chame no MainForm no início)
        public static void Initialize(MainForm form, TextBox logTextBox, ProgressBar progressBar, Label _labelInfoTitulo, CheckBox _checkBox_UserUAC, Label _labelInfoDescricao, PictureBox _pictureBoxInfoDescricao, CancellationToken _token)
        {
            if (_instance == null)
            {
                _instance = new WinGlobal_UIService
                {
                    InterfaceGUI = form,
                    _logTextBox = logTextBox,
                    _progressBar = progressBar,
                    labelInfoTitulo = _labelInfoTitulo,
                    checkBox_UserUAC = _checkBox_UserUAC,
                    labelInfoDescricao = _labelInfoDescricao,
                    pictureBoxInfoDescricao = _pictureBoxInfoDescricao,
                    token = _token,
                    _WinApp_Log = new WinApp_Log()

                };
            }
        }

        // Acesso à instância
        public static WinGlobal_UIService Instance
        {
            get
            {
                if (_instance == null)
                    throw new Exception("WinGlobal_UIService não foi inicializado. Chame Initialize() antes de usar.");

                return _instance;
            }
        }

        public async Task ProgressBarADD(int valor)
        {
            if (_progressBar.InvokeRequired)
            {
                _progressBar.Invoke(new Action(() => ProgressBarADD(valor)));
                return;
            }

            int _max = _progressBar.Value + valor;

            if (_max < 100)
            {
                _progressBar.Value += valor;
            }
            else
            {
                _progressBar.Value = 100;
            }
        }

        // Adiciona uma linha com texto
        public async Task AddMessage(string mensagem)
        {
            // grava dados para variavel
            _WinApp_Log.AdicionarLinha(mensagem);

            _logTextBox.Text = string.Join(
                Environment.NewLine,
                _WinApp_Log.linhasRelatorio
            );  
        }

        // atualiza a ultima linha
        public async Task AddUpdatedMessage(string mensagem)
        {
            _WinApp_Log.AtualizarUltimaLinha(mensagem);

            _logTextBox.Text = string.Join(
                    Environment.NewLine,
                    _WinApp_Log.linhasRelatorio
                );
        }

        // limpa todo o texto
        public async Task ClearMessage()
        {
            _WinApp_Log.Limpar();

            _logTextBox.Text = string.Join(
                Environment.NewLine,
                _WinApp_Log.linhasRelatorio
            );
        }

        public async Task SalvarPDF()
        {
            _WinApp_Log.SalvarPDF();
        }

        public async Task UpdateInfoUI(string _Log, CheckBox _CheckBox, Image _icon, string _description)
        {
            await _WinApp_Log.AdicionarLinha("----- " + _Log + " -----");

           labelInfoTitulo.Text = _CheckBox.Text;

            // usar o negrito do checkBox_UserUAC para manter o padrão visual
            _CheckBox.Font = new Font(checkBox_UserUAC.Font.FontFamily, checkBox_UserUAC.Font.Size, FontStyle.Bold);    
            pictureBoxInfoDescricao.Image = _icon;
            labelInfoDescricao.Text = _description;
        }



        //Adiciona informaçoes do progresso Abortado na interface
        public string CurrentProcess; // Processo atual em execução
        public List<string> ProcessoSelecionados = new List<string>(); // lista de processo para ser executado
        //Exibe um log com todos os Processos que foram executadoes e os que foram canselado
        public async Task MensagemAbortedAsync()
        {
            bool executed = true;

            foreach (string _Porecesso in ProcessoSelecionados)
            {
                if (executed == true)
                {
                    await AddMessage($" • {_Porecesso}   {{executed}}");

                    if (_Porecesso == CurrentProcess)
                    {
                        await AddMessage($" • {_Porecesso}   {{aborted}}");
                        executed = false;
                    }
                }
                else
                {
                    await AddMessage($" • {_Porecesso}   {{canceled}}");
                }
            }
        }
    }
}
