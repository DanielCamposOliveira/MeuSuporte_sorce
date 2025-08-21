using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MeuSuporte.Properties;
using Control = System.Windows.Forms.Control;
using Font = System.Drawing.Font;
using Point = System.Drawing.Point;



namespace MeuSuporte
{
    public partial class MainForm : System.Windows.Forms.Form
    {
      //  private bool SaveLog = false;
        public int ValueUniProgressBar = 100;
        public int Sucesso = 0;
        public int Erro = 0;
        private bool Aborted = false;
        private string UserName;
        private CancellationTokenSource cts;
        CancellationToken token;

        public MainForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;            
            WinGlobal_UIService.Initialize(this, txt_Log, progressBar1, labelInfoTitulo, checkBox_UserUAC, labelInfoDescricao, pictureBoxInfoDescricao, token); // envia os componete para interface
            //WinApp_Temp.Initialize(checkBox_CleanTemp, radioButtonUserUAC_Ativar);
           
            WinApp_Mananger.Initialize(checkBox_UserUAC, checkBox_CleanTask, checkBox_CleanTrash, 
                checkBox_CleanProcess, checkBox_CleanTemp, checkBox_CleanWindowsUpdate, checkBox_CleanGoogle, 
                checkBox_BackupRegistrysRun, checkBox_CleanPageFile, checkBox_DriversBackup, checkBox_DeleteRegistry, 
                checkBox_Usuario, checkBox_CleanPrefetch, checkBox_BackupBCD, checkBox_RestorePoint, checkBox_ConnectionRDP, checkBox_Bloatware, checkBox_BackupReportError, checkBox_CleanReportError,
                radioButtonUserUAC_Ativar, radioButtonCleanPageFile_Ativar, radioButtonradioButtonConnectionRDP_Ativar
                );
        }

        #region Funçoes de UI

        // Painel de informações, mostra a descrição do processo
        public void PainelInfoDescricao(Image foto, string texto)
        {
            pictureBoxInfoDescricao.Image = foto;
            labelInfoDescricao.Text = texto;
        }

        // informa a conclusao no painel de informações
        void InfoDescricaoConclusao(int _erro, int _Sucesso)
        {
            if (Aborted == false)
            {
                string mensage = "Todas as etapas foram concluído. \r\n " + _Sucesso + " sucesso " + _erro + " falhas";
                labelInfoDescricao.Text = mensage;
                labelInfoTitulo.Text = "Finalizado !";

                if (_erro > 0)
                {
                    pictureBoxInfoDescricao.Image = Resources.Alert_Black;
                }
                else
                {
                    pictureBoxInfoDescricao.Image = Resources.closed_Black;
                }
            }
            else
            {
                string mensage = "Processo abortado sem conclusão. \r\n " + _Sucesso + " sucesso " + _erro + " falhas";
                labelInfoDescricao.Text = mensage;
                labelInfoTitulo.Text = "Abortado !";

                pictureBoxInfoDescricao.Image = Resources.abort_Black;
            }
            progressBar1.Value = 100;
        }

        //Adiciona valor ao ProgressBar
        public void ProgressBarADD(int valor)
        {
            if (progressBar1.InvokeRequired)
            {
                progressBar1.Invoke(new Action(() => ProgressBarADD(valor)));             
                return;
            }

            int _max = progressBar1.Value + valor;

            if (_max < 100)
            {
                progressBar1.Value += valor;
            }
            else
            {
                progressBar1.Value = 100;
            }
        }

        //Evento Load do Formulario
        private void FormPreventiva_Load(object sender, EventArgs e)
        {           
            Label_NameMachine.Text = Environment.MachineName;
            ExecutionPath(); // verifica o local da execução do programa
            CheckBuild();   // verifica a versão do programa
            UserNameCheckBox();
        }

        //Evento Closing do Formulario
        private bool SaveLog = false;

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) // evento antes de fechar o Programa
        {      
            SaveLog = MessageBox.Show("Deseja Salvar Log?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
            GravaLog();           
        }

        
        // Ajusta Layout das CheckBox 
        private Dictionary<Control, Point> posicoesOriginais = new Dictionary<Control, Point>();
        private bool posicoesSalvas = false;
        private int panelPosition = 18;
        private void AjustarLayout()
        {
            // Salvar posições apenas uma vez
            if (!posicoesSalvas)
            {
                //foreach (Control ctrl in this.Controls)
                foreach (Control ctrl in this.Controls)
                {
                    if (ctrl is CheckBox || ctrl is Panel || ctrl is PictureBox)
                        posicoesOriginais[ctrl] = ctrl.Location;
                }
                posicoesSalvas = true;

            }

            // Começa reposicionando tudo de acordo com a posição original
            foreach (var item in posicoesOriginais)
            {
                item.Key.Location = item.Value;
            }

            // Adiciona espaço para os painéis abertos
            int offset = 18; // altura dos painéis
            int acumuladorY = 0;

            // CheckBoxes e PictureBoxes em ordem
            CheckBox[] checkBoxes = new CheckBox[] {
             checkBox_UserUAC, checkBox_CleanTask,  checkBox_CleanTrash,
             checkBox_CleanProcess,  checkBox_CleanTemp, checkBox_CleanWindowsUpdate,
             checkBox_CleanGoogle,  checkBox_BackupRegistrysRun, checkBox_CleanPageFile,
             checkBox_DriversBackup,  checkBox_DeleteRegistry,  checkBox_Usuario,
             checkBox_CleanPrefetch,  checkBox_BackupBCD,  checkBox_RestorePoint,  checkBox_ConnectionRDP, checkBox_Bloatware, checkBox_BackupReportError, checkBox_CleanReportError
            };

            PictureBox[] pictureBoxes = new PictureBox[] {
              pictureBox0, pictureBox1, pictureBox2, pictureBox3, pictureBox4,
              pictureBox5, pictureBox6, pictureBox7, pictureBox8, pictureBox9,
              pictureBox10, pictureBox11, pictureBox12, pictureBox13, pictureBox14, pictureBox15, pictureBox16, pictureBox17, pictureBox18
            };

            for (int i = 0; i < checkBoxes.Length; i++)
            {
                CheckBox atual = checkBoxes[i];
                PictureBox imagem = pictureBoxes[i];

                // Ajusta posição do checkbox
                Point posCheck = posicoesOriginais[atual];
                atual.Location = new Point(posCheck.X, posCheck.Y + acumuladorY);

                // Ajusta posição da imagem associada
                Point posImg = posicoesOriginais[imagem];
                imagem.Location = new Point(posImg.X, posImg.Y + acumuladorY);

                // Verifica se o checkbox exige painel e se está marcado
                if (atual == checkBox_UserUAC && atual.Checked)
                {
                    panel_UserUAC.Location = new Point(atual.Location.X + 20, atual.Location.Y + panelPosition);
                    panel_UserUAC.Visible = true;
                    acumuladorY += offset;
                }
                else if (atual == checkBox_CleanPageFile && atual.Checked)
                {
                    panel_CleanPageFile.Location = new Point(atual.Location.X + 20, atual.Location.Y + panelPosition);
                    panel_CleanPageFile.Visible = true;
                    acumuladorY += offset;
                }
                else if (atual == checkBox_ConnectionRDP && atual.Checked)
                {
                    panel_ConnectionRDP.Location = new Point(atual.Location.X + 20, atual.Location.Y + panelPosition);
                    panel_ConnectionRDP.Visible = true;
                    acumuladorY += offset;
                }
            }

            // Esconde os painéis que não foram ativados
            if (!checkBox_UserUAC.Checked) panel_UserUAC.Visible = false;
            if (!checkBox_CleanPageFile.Checked) panel_CleanPageFile.Visible = false;
            if (!checkBox_ConnectionRDP.Checked) panel_ConnectionRDP.Visible = false;
        }

        #endregion

        #region Funçoes dos Botões UI

        //CheckBox Marca todos
        private void checkBoxAll_Click(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                if (control is CheckBox checkBox && checkBox != checkBoxAll)
                {
                    checkBox.Checked = checkBoxAll.Checked;
                }
            }
            AjustarLayout();
        }

        //CheckBox Notificação UAC
        private void checkBox_UserUAC_Click(object sender, EventArgs e)
        {
            AjustarLayout();
        }

        //CheckBox Acesso Remoto RDP
        private void checkBox_ConnectionRDP_Click(object sender, EventArgs e)
        {
            AjustarLayout();
        }

        //CheckBox PageFile
        private void checkBox_CleanPageFile_Click(object sender, EventArgs e)
        {
            AjustarLayout();
        }

        //Botão de Iniciar
        private async void btn_IniciarProcesso_Click(object sender, EventArgs e)
        {
            if (IsAnyCheckBoxChecked()) // verifica se tem algum CheckBox selecionado
            {
                progressBar1.Value = 0;
                txt_Log.Text = "";
                Btn_Canselar.Enabled = true;
                btn_IniciarProcesso.Enabled = false;
                await ExecuteProcesses();
                //InfoDescricaoConclusao(UIService.Erro, UIService.Sucesso);
                InfoDescricaoConclusao(WinGlobal_UIService.Instance.Erro, WinGlobal_UIService.Instance.Sucesso);
                btn_IniciarProcesso.Enabled = true;
            }
            else
            {
                MessageBox.Show("Selecione algum Objetos para iniciar a execução");
            }
        }

        //Botão de Canselar
        private async void Btn_Canselar_Click(object sender, EventArgs e)
        {
            cts?.Cancel(); // cansela as trarefas 
            WinGlobal_UIService.Instance.token = token;
            Btn_Canselar.Enabled = false;
            btn_IniciarProcesso.Enabled = true;
        }


        #endregion
         
        #region Politica de Seguraça do Software

        //Verifica Versão do GitHub
        async Task CheckBuild()
        {
            CheckBuild_Mananger _Class_BuildView = new CheckBuild_Mananger();
            _Class_BuildView.Build();
        }

        // função que desativa os checkbox chamado atraves da Class_BuildView
        public void checkBoxAllState(bool state)
        {
            panel_UserUAC.Enabled = state;
            panel_CleanPageFile.Enabled = state;
            panel_ConnectionRDP.Enabled = state;
            btn_IniciarProcesso.Enabled = state;

            foreach (Control control in this.Controls)
            {
                if (control is CheckBox checkBox)
                {
                    checkBox.Enabled = state;
                }
            }
        }

        //Verifica se o programa esta execuntando localmente ou em rede
        private void ExecutionPath()
        {
            WinApp_ExecutionPath _Class_ExecutionPath = new WinApp_ExecutionPath();
            if (_Class_ExecutionPath.getDiscoverNetwork())
            {
                MessageBox.Show("O programa não pode ser executado em um diretório de rede. Por favor, execute-o localmente em sua maquina.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0); // Força o fechamento imediato
                return;
            }
        }

        // adiciona o nome do usuario na checkBox_Usuario        
        async Task UserNameCheckBox()
        {
            Credential_Private Credential = new Credential_Private();
            //Credential_Public Credential = new Credential_Public();

            UserName = Credential.User;
            WinGlobal_UIService.Instance.UserName = Credential.User;
            checkBox_Usuario.Text = "Usuario " + UserName;
        }

        #endregion

        #region Funcao de Encerramento do Programa

        // Grava Log em um arquivo de Texto
        private async Task GravaLog()
        {
            if(SaveLog == false)         
                return;        

            WinApp_Log class_Log = new WinApp_Log();
            await Task.Run(async () =>
            {
                if (txt_Log.Text != "")
                {
                    await class_Log.GravaAsync(txt_Log.Text);
                }
            });
        }

        //Deleta o Aplicativo
        void DeletaApp()
        {
            string arquivoExe = Application.ExecutablePath;  // Caminho completo do EXE

            try
            {
                // Adiciona aspas ao redor do caminho do EXE para lidar com espaços no diretório
                string comandoDeletar = $"/C choice /C Y /N /D Y /T 3 & Del /F /Q \"{arquivoExe}\"";

                ProcessStartInfo info = new ProcessStartInfo
                {
                    FileName = "cmd.exe",  // Executa o comando via cmd
                    Arguments = comandoDeletar,  // Comando para deletar o EXE com delay de 3 segundos
                    WindowStyle = ProcessWindowStyle.Hidden,  // Executa em segundo plano
                    CreateNoWindow = true  // Não cria uma janela do cmd
                };

                Process.Start(info); // Inicia o processo de exclusão
               // Application.Exit(); // Fecha o aplicativo
            }
            catch (Exception ex)
            {
               // Application.Exit();
            }
        }

        #endregion

        #region Executa todas as tarefas dos CheckBox selecionado

        //Processa opções marcadas pelo usuário
        private async Task ExecuteProcesses()
        {
            // Dicionário associando CheckBox com métodos
            Dictionary<CheckBox, Func<Task>> checkBoxActions = new Dictionary<CheckBox, Func<Task>>
                {
                  {checkBox_UserUAC, WinApp_Mananger.Instance.UserUAC}, {checkBox_CleanTask, WinApp_Mananger.Instance.CleanTask},  {checkBox_CleanTrash, WinApp_Mananger.Instance.CleanTrash},  {checkBox_CleanProcess, WinApp_Mananger.Instance.CleanProcess},  {checkBox_CleanTemp, WinApp_Mananger.Instance.CleanTemp},
                  {checkBox_CleanWindowsUpdate, WinApp_Mananger.Instance.CleanWindowsUpdate},  {checkBox_CleanGoogle, WinApp_Mananger.Instance.CleanGoogle}, {checkBox_BackupRegistrysRun, WinApp_Mananger.Instance.BackupRegistrysRun}, {checkBox_CleanPageFile, WinApp_Mananger.Instance.CleanPageFile},
                  {checkBox_DriversBackup, WinApp_Mananger.Instance.DriversBackup}, {checkBox_DeleteRegistry, WinApp_Mananger.Instance.DeleteRegistry}, {checkBox_Usuario, WinApp_Mananger.Instance.UsuarioSuporte},{checkBox_CleanPrefetch, WinApp_Mananger.Instance.CleanPrefetch},  {checkBox_BackupBCD, WinApp_Mananger.Instance.BackupBCD},
                  {checkBox_RestorePoint, WinApp_Mananger.Instance.CreateSystemPointNew}, {checkBox_ConnectionRDP, WinApp_Mananger.Instance.RemoteRDP}, {checkBox_Bloatware, WinApp_Mananger.Instance.RenoveBloatware }, {checkBox_BackupReportError, WinApp_Mananger.Instance.BackupReportError }, {checkBox_CleanReportError, WinApp_Mananger.Instance.CleanReportError }
                };

            try
            {
                cts = new CancellationTokenSource();
                token = cts.Token;

                // Desativa todos os CheckBox
                await EnableDisableCheckBox(checkBoxActions, false);

                // Fraciona o valor em 100
               // ValueUniProgressBar = 100 / checkBoxActions.Keys.Count(cb => cb.Checked);
                WinGlobal_UIService.Instance.ValueUniProgressBar = 100 / checkBoxActions.Keys.Count(cb => cb.Checked);

                // cria um ponto de restauração antes de todas as alterações caso essa opção esteja marcada 
                if (checkBox_RestorePoint.Checked == true)
                {
                    await WinApp_Mananger.Instance.CreateSystemPointOld();
                }

                //Lista uma Variavel com todo os processo que sera executado
                foreach (var item in checkBoxActions)
                {
                    if (item.Key.Checked == true) 
                    {
                        WinGlobal_UIService.Instance.ProcessoSelecionados.Add(item.Key.Text); // adiciona na lista somente os que estiver marcado pelo usuario
                    }
                }

                // executa todos os processo que estiver selecionados
                foreach (var item in checkBoxActions)
                {                   
                    // Interrompe o loop imediatamente, caso alguma função não tenha passado CancellationToken em sua função então encerra por aqui
                    if (token.IsCancellationRequested)
                    {
                        token.ThrowIfCancellationRequested();
                    }
                    
                    //Execulta a função do CheckBox marcado
                    if (item.Key.Checked)
                    {
                        WinGlobal_UIService.Instance.CurrentProcess = item.Key.Text; // adiciona na variavel o processa que ira ser executado 
                        await item.Value();                                                
                    }
                }

                // Habilita todos os CheckBox
                await EnableDisableCheckBox(checkBoxActions, true);
            }
            catch (OperationCanceledException ex)
            {      
                MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);// Mensagem informativa de canselamento

                await WinGlobal_UIService.Instance.Log_MensagemAsync("\r\n", true);
                await WinGlobal_UIService.Instance.Log_MensagemAsync($"======= PROCESSO CANCELADO PELO USUÁRIO ! =======", false);
                await WinGlobal_UIService.Instance.Log_MensagemAsync(" ", true);
                await WinGlobal_UIService.Instance.MensagemAbortedAsync(); // Exibe um log com todos os Processos que foram executadoes e os que foram canselado
                await Task.Delay(300);

                await EnableDisableCheckBox(checkBoxActions, true); // Habilita todos os CheckBox
                await Task.Delay(300);
                Aborted = true;
            }
        }


        // Verifica se algum CheckBox está marcado  com exeção do checkBoxAll
        private bool IsAnyCheckBoxChecked()
        {
            return this.Controls
                .OfType<CheckBox>()
                .Where(cb => cb != checkBoxAll) // Se necessário, exclui o checkBoxAll da verificação
                .Any(cb => cb.Checked);
        }

        // Alterar a propriedade do CheckBox
        static async Task EnableDisableCheckBox(Dictionary<CheckBox, Func<Task>> checkBoxs, bool status)
        {
            await Task.Run(() =>
            {
                foreach (var item in checkBoxs)
                {
                    item.Key.Invoke((MethodInvoker)delegate
                    {
                        item.Key.Enabled = status;
                        if (status)
                        {
                            item.Key.Font = new Font(item.Key.Font.FontFamily, item.Key.Font.Size, FontStyle.Regular);
                        }
                    });
                }
            });
        }

        #endregion

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            DeletaApp();
        }
    }
}
