using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MeuSuporte.Properties;
using Microsoft.VisualBasic.Devices;
using Control = System.Windows.Forms.Control;
using Font = System.Drawing.Font;
using Point = System.Drawing.Point;


namespace MeuSuporte
{
    public partial class MainForm : System.Windows.Forms.Form
    {
        public int ValueUniProgressBar = 100;
        public int Sucesso = 0;
        public int Erro = 0;
        private bool Aborted = false;
        private CancellationTokenSource cts;
        CancellationToken token;

        private Dictionary<CheckBox, Panel> checkBoxPanelMap;
        private Dictionary<CheckBox, PictureBox> checkBoxIconMap;

        public MainForm()
        {
            InitializeComponent();

            #region WinApp_Form Initialize

            WinApp_Form.Initialize(
                // 1. CheckBoxes
                checkBox_UserUAC, checkBox_CleanTask, 
                checkBox_CleanTrash, checkBox_CleanProcess, 
                checkBox_CleanTemp, checkBox_CleanWindowsUpdate, 
                checkBox_CleanGoogle, checkBox_BackupRegistrysRun,
                checkBox_CleanPageFile, checkBox_DriversBackup, 
                checkBox_DeleteRegistry, checkBox_Usuario,
                checkBox_CleanPrefetch, checkBox_BackupBCD, 
                checkBox_RestorePoint, checkBox_ConnectionRDP,
                checkBox_Bloatware, checkBox_BackupReportError, 
                checkBox_CleanReportError, checkBox_ExportInventory,
                checkBox_Taskbar, checkBoxAll, 
                checkBox_ProfileGraphic, checkBox_ProfileEnergy,

                // 2. RadioButtons - Ativar/Desativar
                radioButtonUserUAC_Ativar, radioButtonCleanPageFile_Ativar, 
                radioButtonConnectionRDP_Ativar, radioButtonUserUAC_Desativar, 
                radioButtonCleanPageFile_Desativar, radioButtonConnectionRDP_Desativar,
                radioButtonTaskbar_Ativar, radioButtonTaskbar_Desativar,
                radioButtonDeleteRegistry_Single, radioButtonDeleteRegistry_All,
                radioButtonCleanTemp_Single, radioButtonCleanTemp_All,
                radioButtonBackupRegistrysRun_Atual, radioButtonBackupRegistrysRun_All,
                radioButtonProfileGraphic_Performace, radioButtonProfileGraphic_Appearance,
                radioButtonProfileEnergy_Desenpenho, radioButtonProfileEnergy_Equilibrado,
                radioButtonProfileEnergy_Economia,

                // 4. PictureBoxes
                pictureBox_UserUAC, pictureBox_CleanTask,
                pictureBox_CleanTrash, pictureBox_CleanProcess,
                pictureBox_CleanTemp, pictureBox_CleanWindowsUpdate, 
                pictureBox_CleanGoogle, pictureBox_BackupRegistrysRun,
                pictureBox_CleanPageFile, pictureBox_DriversBackup, 
                pictureBox_DeleteRegistry, pictureBox_Usuario,
                pictureBox_CleanPrefetch, pictureBox_BackupBCD, 
                pictureBox_RestorePoint, pictureBox_ConnectionRDP,
                pictureBox_Bloatware, pictureBox_BackupReportError, 
                pictureBox_CleanReportError, pictureBoxInfoDescricao,
                pictureBox_ExportInventory, pictureBox_Taskbar,
                pictureBox_ProfileGraphic, pictureBox_ProfileEnergy,

                // 5. Panels
                panelBoton, panelDivisoria, 
                panel_UserUAC, panelLog, 
                panel_ConnectionRDP, panel_CleanPageFile,
                panel1, panel_CleanTemp, 
                panel_BackupRegistrysRun, panel_DeleteRegistry, 
                panel_OptimizeBar, panel_ProfileGraphic, 
                panel_ProfileEnergy,

                // 6. Labels
                label1, labelInfoDescricao, labelInfoTitulo, Label_NameMachine,

                // 7. Buttons
                Btn_Canselar, btn_IniciarProcesso,

                // 8. Controles Únicos / Form
                progressBar1, txt_Log, this  // 'this' é usado para representar o próprio Form (MainForm)
            );
            #endregion

            ScreenResolucao(); // Aplaca a resolução do App de acordo com tamanho da Tela

            CheckForIllegalCrossThreadCalls = false;

            #region WinGlobal_UIService Initialize

            // envia os componete para interface
            WinGlobal_UIService.Initialize(
                this, txt_Log, progressBar1, labelInfoTitulo, checkBox_UserUAC, labelInfoDescricao, pictureBoxInfoDescricao, token
                );

            #endregion

            #region  WinApp_Mananger Initialize

            WinApp_Mananger.Initialize(
                // 1. CheckBoxes
                checkBox_Taskbar, checkBox_UserUAC, checkBox_CleanTask, 
                checkBox_CleanTrash, checkBox_CleanProcess, checkBox_CleanTemp, 
                checkBox_CleanWindowsUpdate, checkBox_CleanGoogle, checkBox_BackupRegistrysRun, 
                checkBox_CleanPageFile, checkBox_DriversBackup, checkBox_DeleteRegistry,
                checkBox_Usuario, checkBox_CleanPrefetch, checkBox_BackupBCD, 
                checkBox_RestorePoint, checkBox_ConnectionRDP, checkBox_Bloatware, 
                checkBox_BackupReportError, checkBox_CleanReportError, checkBox_ProfileGraphic,
                checkBox_ProfileEnergy,

                // 2. RadioButtons
                radioButtonUserUAC_Ativar, radioButtonCleanPageFile_Ativar, radioButtonConnectionRDP_Ativar, 
                radioButtonCleanTemp_All, radioButtonDeleteRegistry_All, radioButtonBackupRegistrysRun_All, 
                radioButtonTaskbar_Ativar, radioButtonProfileGraphic_Performace, radioButtonProfileEnergy_Desenpenho,
                radioButtonProfileEnergy_Equilibrado, radioButtonProfileEnergy_Economia
                );

            #endregion

            #region  CheckBoxPanelMap

            // Mapeia cada checkbox ao seu painel correspondente
            checkBoxPanelMap = new Dictionary<CheckBox, Panel>
             {
                {checkBox_UserUAC, panel_UserUAC },
                {checkBox_CleanPageFile, panel_CleanPageFile },
                {checkBox_ConnectionRDP, panel_ConnectionRDP },
                {checkBox_CleanTemp, panel_CleanTemp},
                {checkBox_BackupRegistrysRun, panel_BackupRegistrysRun },
                {checkBox_DeleteRegistry, panel_DeleteRegistry },
                {checkBox_Taskbar, panel_OptimizeBar },
                {checkBox_ProfileGraphic, panel_ProfileGraphic },
                {checkBox_ProfileEnergy, panel_ProfileEnergy },
            };

            #endregion

            #region CheckBoxIconMap

            // NOVO: Mapeia cada checkbox ao seu PictureBox (ícone) correspondente
            checkBoxIconMap = new Dictionary<CheckBox, PictureBox>
            {
                {checkBox_Taskbar, pictureBox_Taskbar},
                {checkBox_UserUAC, pictureBox_UserUAC },
                {checkBox_CleanTask, pictureBox_CleanTask },
                {checkBox_CleanTrash, pictureBox_CleanTrash },
                {checkBox_CleanProcess, pictureBox_CleanProcess },
                {checkBox_CleanTemp, pictureBox_CleanTemp },
                {checkBox_CleanWindowsUpdate, pictureBox_CleanWindowsUpdate },
                {checkBox_CleanGoogle, pictureBox_CleanGoogle },
                {checkBox_BackupRegistrysRun, pictureBox_BackupRegistrysRun },
                {checkBox_CleanPageFile, pictureBox_CleanPageFile },
                {checkBox_DriversBackup, pictureBox_DriversBackup },
                {checkBox_DeleteRegistry, pictureBox_DeleteRegistry },
                {checkBox_Usuario, pictureBox_Usuario },
                {checkBox_CleanPrefetch, pictureBox_CleanPrefetch },
                {checkBox_BackupBCD, pictureBox_BackupBCD },
                {checkBox_RestorePoint, pictureBox_RestorePoint },
                {checkBox_ConnectionRDP, pictureBox_ConnectionRDP },
                {checkBox_Bloatware, pictureBox_Bloatware },
                {checkBox_BackupReportError, pictureBox_BackupReportError },
                {checkBox_CleanReportError, pictureBox_CleanReportError },
                {checkBox_ExportInventory, pictureBox_ExportInventory },
                {checkBox_ProfileGraphic, pictureBox_ProfileGraphic },
                {checkBox_ProfileEnergy, pictureBox_ProfileEnergy },
            };

            #endregion

        }

        #region Funçoes de UI

        // Painel de informações, mostra a descrição do processo
        public void PainelInfoDescricao(Image foto, string texto, Color Cor)
        {
            pictureBoxInfoDescricao.Image = foto;
            labelInfoDescricao.Text = texto;
            labelInfoDescricao.ForeColor = Cor;
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

        // Aplaca a resolução do App de acordo com tamanho da Tela
        private void ScreenResolucao()
        {
            if (Screen.PrimaryScreen.Bounds.Height >= 900)
            {
                //WinApp_Form.Instance.ScreenResolution1920x1080();
                WinApp_Form.Instance.ScreenResolution1920x1080();
            }
            else
            {
                WinApp_Form.Instance.ScreenResolution1024x800();
            }
        }

        #endregion
       
        

        private void AtualizarLayoutDinamico()
        {
            // AVISA O PAINEL PARA PARAR DE ATUALIZAR O LAYOUT
            panel1.SuspendLayout();

            try
            {
                // Pega a lista ordenada de CheckBoxes pela sua posição vertical (Top)
                var checkBoxesOrdenados = panel1.Controls.OfType<CheckBox>()
                                                          .OrderBy(cb => cb.Top);

                // Verifica se existe algum checkbox para evitar erros
                if (!checkBoxesOrdenados.Any()) return;

                // Pega a posição inicial do primeiro CheckBox
                int posicaoYAtual = checkBoxesOrdenados.First().Location.Y;
                const int espacoVertical = 3; // Espaço extra entre os controles

                foreach (CheckBox checkbox in checkBoxesOrdenados)
                {
                    // --- INÍCIO DA MUDANÇA ---

                    // 1. Reposiciona o ÍCONE associado
                    if (checkBoxIconMap.ContainsKey(checkbox))
                    {
                        PictureBox iconeAssociado = checkBoxIconMap[checkbox];
                        // Alinha o Y do ícone com o Y do checkbox que será posicionado
                        // (O cálculo no meio serve para centralizar verticalmente caso as alturas sejam diferentes)
                        int iconeY = posicaoYAtual + (checkbox.Height - iconeAssociado.Height) / 2;
                        iconeAssociado.Location = new Point(iconeAssociado.Location.X, iconeY);
                    }

                    // 2. Reposiciona o CHECKBOX atual (como antes)
                    checkbox.Location = new Point(checkbox.Location.X, posicaoYAtual);

                 

                    // 3. Incrementa a posição Y para o próximo controle
                    posicaoYAtual += checkbox.Height + espacoVertical;

                    // 4. Verifica se este checkbox tem um painel associado
                    if (checkBoxPanelMap.ContainsKey(checkbox))
                    {
                        Panel painelAssociado = checkBoxPanelMap[checkbox];

                        // 5. Se o checkbox estiver MARCADO, mostra e posiciona o painel
                        if (checkbox.Checked)
                        {
                            painelAssociado.Visible = true;
                            painelAssociado.Location = new Point(checkbox.Location.X + 20, posicaoYAtual);

                            // Garante que o painel está dentro do panel1 (boa prática)
                            if (!panel1.Controls.Contains(painelAssociado))
                            {
                                panel1.Controls.Add(painelAssociado);
                            }

                            // 6. Adiciona a altura do painel à posição Y para o próximo controle
                            posicaoYAtual += painelAssociado.Height + espacoVertical;
                        }
                        else
                        {
                            // Se não estiver marcado, apenas garante que o painel está invisível
                            painelAssociado.Visible = false;
                        }
                    }
                }
            }
            finally
            {
                // REATIVA AS ATUALIZAÇÕES DE LAYOUT, MOSTRANDO TODAS AS MUDANÇAS DE UMA VEZ
                panel1.ResumeLayout(true);
            }
        }





        #region Funçoes dos Botões UI

        //CheckBox Marca todos
        private void checkBoxAll_Click(object sender, EventArgs e)
        {
            bool estadoDesejado = checkBoxAll.Checked;

            // Itera sobre os controles DENTRO do panel1, que é o container correto.
            foreach (Control control in panel1.Controls)
            {
                // Se o controle for um CheckBox...
                if (control is CheckBox checkBox)
                {
                    // ...e não for o próprio "Marcar Todos", atualiza o seu estado.
                    if (checkBox != checkBoxAll)
                    {
                        checkBox.Checked = estadoDesejado;
                    }
                }
            }

            AtualizarLayoutDinamico();
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
                Btn_Canselar.Enabled = false;
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

        private void checkBox_CleanTemp_Click(object sender, EventArgs e)
        {
            AtualizarLayoutDinamico();
        }
        private void checkBox_BackupRegistrysRun_Click(object sender, EventArgs e)
        {
            AtualizarLayoutDinamico();
        }
        private void checkBox_DeleteRegistry_Click(object sender, EventArgs e)
        {
            AtualizarLayoutDinamico();
        }
        private void checkBox_Taskbar_Click(object sender, EventArgs e)
        {
            AtualizarLayoutDinamico();
        }     
        private void checkBox_ConnectionRDP_Click(object sender, EventArgs e)
        {
            AtualizarLayoutDinamico();
        }
        private void checkBox_CleanPageFile_Click(object sender, EventArgs e)
        {
            AtualizarLayoutDinamico();
        }
        private void checkBox_UserUAC_Click(object sender, EventArgs e)
        {
            AtualizarLayoutDinamico();
        }
        private void checkBox_ProfileGraphic_Click(object sender, EventArgs e)
        {
            AtualizarLayoutDinamico();
        }
        private void checkBox_ProfileEnergy_Click(object sender, EventArgs e)
        {
            AtualizarLayoutDinamico();
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
            WinUser_CurrentUser CurrentUser = new WinUser_CurrentUser();
            
            WinGlobal_UIService.Instance.UserName = CurrentUser.User;
            checkBox_Usuario.Text = "Usuario " + CurrentUser.User;
        }

        #endregion

        #region Funcao de Encerramento do Programa

        private async void Form1_FormClosing(object sender, FormClosingEventArgs e) // evento antes de fechar o Programa
        {      
            if (e.CloseReason == CloseReason.UserClosing)
            {
                var result = MessageBox.Show(this, "Você tem certeza que deseja sair?", "Confirmação", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    cts?.Cancel(); // cansela as trarefas 
                    WinGlobal_UIService.Instance.token = token;

                    await GravaLog();

                    Application.Exit();
                }
                else
                {
                    e.Cancel = true; // Cancela o fechamento
                }
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            DeletaApp();
        }

        // Grava Log em um arquivo de Texto
        private async Task GravaLog()
        {    
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
                {checkBox_RestorePoint, WinApp_Mananger.Instance.CreateSystemPoint},
                { checkBox_Taskbar,WinApp_Mananger.Instance.Taskbar},
                {checkBox_UserUAC, WinApp_Mananger.Instance.UserUAC},
                {checkBox_CleanTask, WinApp_Mananger.Instance.CleanTask},
                {checkBox_CleanTrash, WinApp_Mananger.Instance.CleanTrash},
                {checkBox_CleanProcess, WinApp_Mananger.Instance.CleanProcess},
                {checkBox_CleanTemp, WinApp_Mananger.Instance.CleanTemp},
                {checkBox_CleanWindowsUpdate, WinApp_Mananger.Instance.CleanWindowsUpdate},
                {checkBox_CleanGoogle, WinApp_Mananger.Instance.CleanGoogle},
                {checkBox_BackupRegistrysRun, WinApp_Mananger.Instance.BackupRegistrysRun},
                {checkBox_CleanPageFile, WinApp_Mananger.Instance.CleanPageFile},
                {checkBox_DriversBackup, WinApp_Mananger.Instance.DriversBackup},
                {checkBox_DeleteRegistry, WinApp_Mananger.Instance.DeleteRegistry},
                {checkBox_Usuario, WinApp_Mananger.Instance.UsuarioSuporte},
                {checkBox_CleanPrefetch, WinApp_Mananger.Instance.CleanPrefetch},
                {checkBox_BackupBCD, WinApp_Mananger.Instance.BackupBCD},
                {checkBox_ConnectionRDP, WinApp_Mananger.Instance.RemoteRDP},
                {checkBox_Bloatware, WinApp_Mananger.Instance.RenoveBloatware },
                {checkBox_BackupReportError, WinApp_Mananger.Instance.BackupReportError },
                {checkBox_CleanReportError, WinApp_Mananger.Instance.CleanReportError },
                {checkBox_ProfileGraphic, WinApp_Mananger.Instance.ProfileGraphic},
                {checkBox_ProfileEnergy, WinApp_Mananger.Instance.ProfileEnergy},
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
            return panel1.Controls
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

 
    }
}
