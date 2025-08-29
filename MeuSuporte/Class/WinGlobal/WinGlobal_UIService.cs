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
                    token = _token

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

        public void ProgressBarADD(int valor)
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

        public async Task Log_MensagemAsync(string mensagem, bool pularLinha)
        {
            if (_logTextBox.InvokeRequired)
            {
                await Task.Run(() =>
                {
                    _logTextBox.Invoke(new Action(() =>
                    {
                        _logTextBox.AppendText(mensagem);
                        if (pularLinha)
                            _logTextBox.AppendText(Environment.NewLine);
                    }));
                });
            }
            else
            {
                _logTextBox.AppendText(mensagem);
                if (pularLinha)
                    _logTextBox.AppendText(Environment.NewLine);
            }
        }

        public async Task Log_MensagemAsyncSobrescrever(string mensagem)
        {
            if (_logTextBox.InvokeRequired)
            {
                await Task.Run(() =>
                {
                    _logTextBox.Invoke(new Action(() =>
                    {
                        string[] linhas = _logTextBox.Text.Split('\n');
                        _logTextBox.Text = string.Join("\n", linhas.Take(linhas.Length - 1).Concat(new[] { mensagem }));
                    }));
                });
            }
            else
            {
                string[] linhas = _logTextBox.Text.Split('\n');
                _logTextBox.Text = string.Join("\n", linhas.Take(linhas.Length - 1).Concat(new[] { mensagem }));
            }
        }

        public async Task UpdateIfonUI(string _Log, CheckBox _CheckBox, Image _icon, string _description)
        {
            await Log_MensagemAsync("\r\n", true);
            await Log_MensagemAsync($"======= {_Log} =======", true);
            await Log_MensagemAsync(" ", false);
           labelInfoTitulo.Text = _CheckBox.Text;
            
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
                    await Log_MensagemAsync($" • {_Porecesso}   {{executed}}", true);

                    if (_Porecesso == CurrentProcess)
                    {
                        await Log_MensagemAsync($" • {_Porecesso}   {{aborted}}", true);
                        executed = false;
                    }
                }
                else
                {
                    await Log_MensagemAsync($" • {_Porecesso}   {{canceled}}", true);
                }
            }
        }












    }
}
