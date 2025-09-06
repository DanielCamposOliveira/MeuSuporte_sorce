using System;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using MeuSuporte.Properties;

namespace MeuSuporte
{
    internal class WinApp_Form
    {
        private static WinApp_Form _instance;

        public static WinApp_Form Instance
        {
            get
            {
                if (_instance == null)
                    throw new Exception("WinApp_Form não foi inicializado. Chame Initialize() antes de usar.");

                return _instance;
            }
        }

        #region Componentes do Formulario

        private CheckBox checkBox_UserUAC;
        private CheckBox checkBox_CleanTask;
        private CheckBox checkBox_CleanTrash;
        private CheckBox checkBox_CleanProcess;
        private CheckBox checkBox_CleanTemp;
        private CheckBox checkBox_CleanWindowsUpdate;
        private CheckBox checkBox_CleanGoogle;
        private CheckBox checkBox_BackupRegistrysRun;
        private CheckBox checkBox_CleanPageFile;
        private CheckBox checkBox_DriversBackup;
        private CheckBox checkBox_DeleteRegistry;
        private CheckBox checkBox_Usuario;
        private CheckBox checkBox_CleanPrefetch;
        private CheckBox checkBox_BackupBCD;
        private CheckBox checkBox_RestorePoint;
        private CheckBox checkBox_ConnectionRDP;
        private CheckBox checkBox_Bloatware;
        private CheckBox checkBox_BackupReportError;
        private CheckBox checkBox_CleanReportError;

        private RadioButton radioButtonUserUAC_Ativar;
        private RadioButton radioButtonCleanPageFile_Ativar;
        private RadioButton radioButtonradioButtonConnectionRDP_Ativar;

        private PictureBox pictureBox0;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private PictureBox pictureBox5;
        private PictureBox pictureBox6;
        private PictureBox pictureBox7;
        private PictureBox pictureBox8;
        private PictureBox pictureBox9;
        private PictureBox pictureBox10;
        private PictureBox pictureBox11;
        private PictureBox pictureBox12;
        private PictureBox pictureBox13;
        private PictureBox pictureBox14;
        private PictureBox pictureBox15;
        private PictureBox pictureBox16;
        private PictureBox pictureBox17;
        private PictureBox pictureBox18;
        private PictureBox pictureBoxInfoDescricao;

        private Panel panelBoton;
        private Panel panelDivisoria;
        private Panel panel_UserUAC;
        private Panel panelLog;
        private Panel panel_ConnectionRDP;
        private Panel panel_CleanPageFile;

        private Label label1;
        private Label labelInfoDescricao;
        private Label labelInfoTitulo;
        private Label Label_NameMachine;

        private RadioButton radioButtonUserUAC_Desativar;
        private RadioButton radioButtonCleanPageFile_Desativar;
        private RadioButton radioButtonConnectionRDP_Desativar;

        private Button Btn_Canselar;
        private Button btn_IniciarProcesso;

        private CheckBox checkBoxAll;

        private ProgressBar progressBar1;

        private Form Formulario;

        private TextBox txt_Log;

        #endregion

        #region Initialize

        public static void Initialize(ProgressBar _ProgressBar, CheckBox _checkBox_UserUAC, CheckBox _checkBox_CleanTask, CheckBox _checkBox_CleanTrash,
            CheckBox _checkBox_CleanProcess, CheckBox _checkBox_CleanTemp, CheckBox _checkBox_CleanWindowsUpdate, CheckBox _checkBox_CleanGoogle,
            CheckBox _checkBox_BackupRegistrysRun, CheckBox _checkBox_CleanPageFile, CheckBox _checkBox_DriversBackup, CheckBox _checkBox_DeleteRegistry,
            CheckBox _checkBox_Usuario, CheckBox _checkBox_CleanPrefetch, CheckBox _checkBox_BackupBCD, CheckBox _checkBox_RestorePoint,
            CheckBox _checkBox_ConnectionRDP, CheckBox _checkBox_Bloatware, CheckBox _checkBox_BackupReportError, CheckBox _checkBox_CleanReportError,
            RadioButton _radioButtonUserUAC_Ativar, RadioButton _radioButtonCleanPageFile_Ativar,
            RadioButton _radioButtonradioButtonConnectionRDP_Ativar, PictureBox _pictureBox0, PictureBox _pictureBox1, PictureBox _pictureBox2,
            PictureBox _pictureBox3, PictureBox _pictureBox4, PictureBox _pictureBox5, PictureBox _pictureBox6, PictureBox _pictureBox7,
            PictureBox _pictureBox8, PictureBox _pictureBox9, PictureBox _pictureBox10, PictureBox _pictureBox11, PictureBox _pictureBox12,
            PictureBox _pictureBox13, PictureBox _pictureBox14, PictureBox _pictureBox15, PictureBox _pictureBox16, PictureBox _pictureBox17, PictureBox _pictureBox18,
            TextBox _txt_Log, Button _Btn_Canselar, Panel _panelBoton, Button _btn_IniciarProcesso, Panel _panelDivisoria, Panel _panel_UserUAC, Panel _panelLog,
            PictureBox _pictureBoxInfoDescricao, Panel _panel_ConnectionRDP, Panel _panel_CleanPageFile, CheckBox _checkBoxAll, Label _label1,
            Label _labelInfoDescricao, Label _labelInfoTitulo, Label _Label_NameMachine,
            RadioButton _radioButtonUserUAC_Desativar, RadioButton _radioButtonCleanPageFile_Desativar, RadioButton _radioButtonConnectionRDP_Desativar, Form _Formulario
            )
        {
            if (_instance == null)
            {
                _instance = new WinApp_Form
                {
                    checkBox_UserUAC = _checkBox_UserUAC,
                    checkBox_CleanTask = _checkBox_CleanTask,
                    checkBox_CleanTrash = _checkBox_CleanTrash,
                    checkBox_CleanProcess = _checkBox_CleanProcess,
                    checkBox_CleanTemp = _checkBox_CleanTemp,
                    checkBox_CleanWindowsUpdate = _checkBox_CleanWindowsUpdate,
                    checkBox_CleanGoogle = _checkBox_CleanGoogle,
                    checkBox_BackupRegistrysRun = _checkBox_BackupRegistrysRun,
                    checkBox_CleanPageFile = _checkBox_CleanPageFile,
                    checkBox_DriversBackup = _checkBox_DriversBackup,
                    checkBox_DeleteRegistry = _checkBox_DeleteRegistry,
                    checkBox_Usuario = _checkBox_Usuario,
                    checkBox_CleanPrefetch = _checkBox_CleanPrefetch,
                    checkBox_BackupBCD = _checkBox_BackupBCD,
                    checkBox_RestorePoint = _checkBox_RestorePoint,
                    checkBox_ConnectionRDP = _checkBox_ConnectionRDP,
                    checkBox_Bloatware = _checkBox_Bloatware,
                    checkBox_BackupReportError = _checkBox_BackupReportError,
                    checkBox_CleanReportError = _checkBox_CleanReportError,
                    checkBoxAll = _checkBoxAll,

                    pictureBox0 = _pictureBox0,
                    pictureBox1 = _pictureBox1,
                    pictureBox2 = _pictureBox2,
                    pictureBox3 = _pictureBox3,
                    pictureBox4 = _pictureBox4,
                    pictureBox5 = _pictureBox5,
                    pictureBox6 = _pictureBox6,
                    pictureBox7 = _pictureBox7,
                    pictureBox8 = _pictureBox8,
                    pictureBox9 = _pictureBox9,
                    pictureBox10 = _pictureBox10,
                    pictureBox11 = _pictureBox11,
                    pictureBox12 = _pictureBox12,
                    pictureBox13 = _pictureBox13,
                    pictureBox14 = _pictureBox14,
                    pictureBox15 = _pictureBox15,
                    pictureBox16 = _pictureBox16,
                    pictureBox17 = _pictureBox17,
                    pictureBox18 = _pictureBox18,
                    pictureBoxInfoDescricao = _pictureBoxInfoDescricao,

                    radioButtonUserUAC_Ativar = _radioButtonUserUAC_Ativar,
                    radioButtonCleanPageFile_Ativar = _radioButtonCleanPageFile_Ativar,
                    radioButtonradioButtonConnectionRDP_Ativar = _radioButtonradioButtonConnectionRDP_Ativar,
                    radioButtonUserUAC_Desativar = _radioButtonUserUAC_Desativar,
                    radioButtonCleanPageFile_Desativar = _radioButtonCleanPageFile_Desativar,
                    radioButtonConnectionRDP_Desativar = _radioButtonConnectionRDP_Desativar,

                    panelBoton = _panelBoton,
                    panelDivisoria = _panelDivisoria,
                    panel_UserUAC = _panel_UserUAC,
                    panelLog = _panelLog,
                    panel_ConnectionRDP = _panel_ConnectionRDP,
                    panel_CleanPageFile = _panel_CleanPageFile,

                    label1 = _label1,
                    labelInfoDescricao = _labelInfoDescricao,
                    labelInfoTitulo = _labelInfoTitulo,
                    Label_NameMachine = _Label_NameMachine,

                    Btn_Canselar = _Btn_Canselar,
                    btn_IniciarProcesso = _btn_IniciarProcesso,

                    Formulario = _Formulario,

                    progressBar1 = _ProgressBar,

                    txt_Log = _txt_Log,
                };
            }
        }

        #endregion

        #region Screen Resolution

        public void ScreenResolution1920x1080()
        {
            // MainForm
            Formulario.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            Formulario.ClientSize = new System.Drawing.Size(966, 715);


            // txt_Log
            txt_Log.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txt_Log.Size = new System.Drawing.Size(651, 496);

            // progressBar1
            progressBar1.Location = new System.Drawing.Point(316, 65);
            progressBar1.Size = new System.Drawing.Size(488, 11);

            // checkBox_UserUAC
            checkBox_UserUAC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_UserUAC.Location = new System.Drawing.Point(43, 55);
            checkBox_UserUAC.Size = new System.Drawing.Size(226, 24);

            // checkBox_CleanTask
            checkBox_CleanTask.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_CleanTask.Location = new System.Drawing.Point(43, 85);
            checkBox_CleanTask.Size = new System.Drawing.Size(220, 24);

            // checkBox_CleanTrash
            checkBox_CleanTrash.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_CleanTrash.Location = new System.Drawing.Point(43, 115);
            checkBox_CleanTrash.Size = new System.Drawing.Size(125, 24);

            // checkBox_CleanProcess
            checkBox_CleanProcess.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_CleanProcess.Location = new System.Drawing.Point(43, 145);
            checkBox_CleanProcess.Size = new System.Drawing.Size(173, 24);

            // checkBox_CleanTemp
            checkBox_CleanTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_CleanTemp.Location = new System.Drawing.Point(43, 175);
            checkBox_CleanTemp.Size = new System.Drawing.Size(193, 24);

            // checkBox_CleanWindowsUpdate
            checkBox_CleanWindowsUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_CleanWindowsUpdate.Location = new System.Drawing.Point(43, 205);
            checkBox_CleanWindowsUpdate.Size = new System.Drawing.Size(233, 24);

            // checkBox_CleanGoogle
            checkBox_CleanGoogle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_CleanGoogle.Location = new System.Drawing.Point(43, 235);
            checkBox_CleanGoogle.Size = new System.Drawing.Size(189, 24);

            // checkBox_DeleteRegistry
            checkBox_DeleteRegistry.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_DeleteRegistry.Location = new System.Drawing.Point(43, 355);
            checkBox_DeleteRegistry.Size = new System.Drawing.Size(140, 24);

            // checkBox_CleanPageFile
            checkBox_CleanPageFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_CleanPageFile.Location = new System.Drawing.Point(43, 295);
            checkBox_CleanPageFile.Size = new System.Drawing.Size(112, 24);

            // checkBox_BackupRegistrysRun
            checkBox_BackupRegistrysRun.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_BackupRegistrysRun.Location = new System.Drawing.Point(43, 265);
            checkBox_BackupRegistrysRun.Size = new System.Drawing.Size(146, 24);

            // checkBox_Usuario
            checkBox_Usuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_Usuario.Location = new System.Drawing.Point(43, 385);
            checkBox_Usuario.Size = new System.Drawing.Size(121, 24);

            // checkBox_CleanPrefetch
            checkBox_CleanPrefetch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_CleanPrefetch.Location = new System.Drawing.Point(43, 415);
            checkBox_CleanPrefetch.Size = new System.Drawing.Size(140, 24);

            // checkBox_BackupBCD
            checkBox_BackupBCD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_BackupBCD.Location = new System.Drawing.Point(43, 445);
            checkBox_BackupBCD.Size = new System.Drawing.Size(158, 24);

            // Btn_Canselar
            Btn_Canselar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Btn_Canselar.Location = new System.Drawing.Point(672, 2);
            Btn_Canselar.Size = new System.Drawing.Size(138, 31);

            // checkBox_DriversBackup
            checkBox_DriversBackup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_DriversBackup.Location = new System.Drawing.Point(43, 325);
            checkBox_DriversBackup.Size = new System.Drawing.Size(131, 24);

            // panelBoton
            panelBoton.Location = new System.Drawing.Point(0, 678);
            panelBoton.Size = new System.Drawing.Size(966, 37);

            // btn_IniciarProcesso
            btn_IniciarProcesso.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btn_IniciarProcesso.Location = new System.Drawing.Point(816, 2);
            btn_IniciarProcesso.Size = new System.Drawing.Size(138, 31);

            // checkBoxAll
            checkBoxAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBoxAll.Location = new System.Drawing.Point(12, 9);
            checkBoxAll.Size = new System.Drawing.Size(77, 24);

            // panelDivisoria
            panelDivisoria.Location = new System.Drawing.Point(301, 55);
            panelDivisoria.Size = new System.Drawing.Size(1, 570);

            // label1
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(6, 21);
            label1.Size = new System.Drawing.Size(87, 26);

            // labelInfoDescricao
            labelInfoDescricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labelInfoDescricao.Location = new System.Drawing.Point(346, 590);
            labelInfoDescricao.Size = new System.Drawing.Size(610, 52);

            // labelInfoTitulo
            labelInfoTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labelInfoTitulo.Location = new System.Drawing.Point(312, 37);
            labelInfoTitulo.Size = new System.Drawing.Size(81, 20);

            // panelLog
            panelLog.Location = new System.Drawing.Point(308, 87);
            panelLog.Size = new System.Drawing.Size(653, 498);

            // Label_NameMachine
            Label_NameMachine.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Label_NameMachine.Location = new System.Drawing.Point(680, 9);
            Label_NameMachine.Size = new System.Drawing.Size(281, 48);

            // pictureBoxInfoDescricao
            pictureBoxInfoDescricao.Location = new System.Drawing.Point(306, 590);
            pictureBoxInfoDescricao.Size = new System.Drawing.Size(38, 35);

            // pictureBox0
            pictureBox0.Location = new System.Drawing.Point(10, 55);
            pictureBox0.Size = new System.Drawing.Size(24, 24);

            // pictureBox1
            pictureBox1.Location = new System.Drawing.Point(10, 85);
            pictureBox1.Size = new System.Drawing.Size(24, 24);

            // pictureBox2
            pictureBox2.Location = new System.Drawing.Point(10, 115);
            pictureBox2.Size = new System.Drawing.Size(24, 24);

            // pictureBox3
            pictureBox3.Location = new System.Drawing.Point(10, 145);
            pictureBox3.Size = new System.Drawing.Size(24, 24);

            // pictureBox4
            pictureBox4.Location = new System.Drawing.Point(10, 175);
            pictureBox4.Size = new System.Drawing.Size(24, 24);

            // pictureBox5
            pictureBox5.Location = new System.Drawing.Point(10, 205);
            pictureBox5.Size = new System.Drawing.Size(24, 24);

            // pictureBox6
            pictureBox6.Location = new System.Drawing.Point(10, 235);
            pictureBox6.Size = new System.Drawing.Size(24, 24);

            // pictureBox7
            pictureBox7.Location = new System.Drawing.Point(10, 265);
            pictureBox7.Size = new System.Drawing.Size(24, 24);

            // pictureBox8
            pictureBox8.Location = new System.Drawing.Point(10, 295);
            pictureBox8.Size = new System.Drawing.Size(24, 24);

            // pictureBox9
            pictureBox9.Location = new System.Drawing.Point(10, 325);
            pictureBox9.Size = new System.Drawing.Size(24, 24);

            // pictureBox10
            pictureBox10.Location = new System.Drawing.Point(10, 355);
            pictureBox10.Size = new System.Drawing.Size(24, 24);

            // pictureBox11
            pictureBox11.Location = new System.Drawing.Point(10, 385);
            pictureBox11.Size = new System.Drawing.Size(24, 24);

            // pictureBox12
            pictureBox12.Location = new System.Drawing.Point(10, 415);
            pictureBox12.Size = new System.Drawing.Size(24, 24);

            // pictureBox13
            pictureBox13.Location = new System.Drawing.Point(10, 445);
            pictureBox13.Size = new System.Drawing.Size(24, 24);

            // pictureBox14
            pictureBox14.Location = new System.Drawing.Point(10, 475);
            pictureBox14.Size = new System.Drawing.Size(24, 24);

            // pictureBox15
            pictureBox15.Location = new System.Drawing.Point(10, 505);
            pictureBox15.Size = new System.Drawing.Size(24, 24);

            // pictureBox16
            pictureBox16.Location = new System.Drawing.Point(10, 535);
            pictureBox16.Size = new System.Drawing.Size(24, 24);

            // pictureBox17
            pictureBox17.Location = new System.Drawing.Point(10, 565);
            pictureBox17.Size = new System.Drawing.Size(24, 24);

            // pictureBox18
            pictureBox18.Location = new System.Drawing.Point(10, 595);
            pictureBox18.Size = new System.Drawing.Size(24, 24);

            // radioButtonUserUAC_Desativar
            radioButtonUserUAC_Desativar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radioButtonUserUAC_Desativar.Location = new System.Drawing.Point(62, 3);
            radioButtonUserUAC_Desativar.Size = new System.Drawing.Size(76, 19);

            // radioButtonUserUAC_Ativar
            radioButtonUserUAC_Ativar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radioButtonUserUAC_Ativar.Location = new System.Drawing.Point(3, 3);
            radioButtonUserUAC_Ativar.Size = new System.Drawing.Size(54, 19);

            // radioButtonCleanPageFile_Ativar
            radioButtonCleanPageFile_Ativar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radioButtonCleanPageFile_Ativar.Location = new System.Drawing.Point(3, 5);
            radioButtonCleanPageFile_Ativar.Size = new System.Drawing.Size(54, 19);

            // radioButtonCleanPageFile_Desativar
            radioButtonCleanPageFile_Desativar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radioButtonCleanPageFile_Desativar.Location = new System.Drawing.Point(62, 5);
            radioButtonCleanPageFile_Desativar.Size = new System.Drawing.Size(76, 19);

            // panel_UserUAC
            panel_UserUAC.Location = new System.Drawing.Point(996, 295);
            panel_UserUAC.Size = new System.Drawing.Size(147, 27);

            // panel_CleanPageFile
            panel_CleanPageFile.Location = new System.Drawing.Point(996, 265);
            panel_CleanPageFile.Size = new System.Drawing.Size(147, 24);

            // checkBox_RestorePoint
            checkBox_RestorePoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_RestorePoint.Location = new System.Drawing.Point(43, 475);
            checkBox_RestorePoint.Size = new System.Drawing.Size(218, 24);

            // checkBox_ConnectionRDP
            checkBox_ConnectionRDP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_ConnectionRDP.Location = new System.Drawing.Point(43, 505);
            checkBox_ConnectionRDP.Size = new System.Drawing.Size(180, 24);

            // panel_ConnectionRDP
            panel_ConnectionRDP.Location = new System.Drawing.Point(996, 235);
            panel_ConnectionRDP.Size = new System.Drawing.Size(147, 24);

            // radioButtonradioButtonConnectionRDP_Ativar
            radioButtonradioButtonConnectionRDP_Ativar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radioButtonradioButtonConnectionRDP_Ativar.Location = new System.Drawing.Point(3, 4);
            radioButtonradioButtonConnectionRDP_Ativar.Size = new System.Drawing.Size(54, 19);

            // radioButtonConnectionRDP_Desativar
            radioButtonConnectionRDP_Desativar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radioButtonConnectionRDP_Desativar.Location = new System.Drawing.Point(62, 4);
            radioButtonConnectionRDP_Desativar.Size = new System.Drawing.Size(76, 19);


            // checkBox_Bloatware
            checkBox_Bloatware.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_Bloatware.Location = new System.Drawing.Point(43, 535);
            checkBox_Bloatware.Size = new System.Drawing.Size(167, 24);

            // checkBox_BackupReportError
            checkBox_BackupReportError.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_BackupReportError.Location = new System.Drawing.Point(43, 565);
            checkBox_BackupReportError.Size = new System.Drawing.Size(214, 24);

            // checkBox_CleanReportError
            checkBox_CleanReportError.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_CleanReportError.Location = new System.Drawing.Point(43, 595);
            checkBox_CleanReportError.Size = new System.Drawing.Size(208, 24);


        }

        public void ScreenResolution1024x800()
        {
            // MainForm
            Formulario.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            Formulario.ClientSize = new System.Drawing.Size(768, 605);

            // txt_Log
            txt_Log.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txt_Log.Size = new System.Drawing.Size(527, 448);

            // progressBar1
            progressBar1.Location = new System.Drawing.Point(240, 40);
            progressBar1.Size = new System.Drawing.Size(284, 11);

            // checkBox_UserUAC
            checkBox_UserUAC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_UserUAC.Location = new System.Drawing.Point(33, 38);
            checkBox_UserUAC.Size = new System.Drawing.Size(177, 19);

            // checkBox_CleanTask
            checkBox_CleanTask.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_CleanTask.Location = new System.Drawing.Point(33, 63);
            checkBox_CleanTask.Size = new System.Drawing.Size(174, 19);

            // checkBox_CleanTrash
            checkBox_CleanTrash.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_CleanTrash.Location = new System.Drawing.Point(33, 88);
            checkBox_CleanTrash.Size = new System.Drawing.Size(105, 19);

            // checkBox_CleanProcess
            checkBox_CleanProcess.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_CleanProcess.Location = new System.Drawing.Point(33, 113);
            checkBox_CleanProcess.Size = new System.Drawing.Size(137, 19);

            // checkBox_CleanTemp
            checkBox_CleanTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_CleanTemp.Location = new System.Drawing.Point(33, 138);
            checkBox_CleanTemp.Size = new System.Drawing.Size(156, 19);

            // checkBox_CleanWindowsUpdate
            checkBox_CleanWindowsUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_CleanWindowsUpdate.Location = new System.Drawing.Point(33, 163);
            checkBox_CleanWindowsUpdate.Size = new System.Drawing.Size(183, 19);

            // checkBox_CleanGoogle
            checkBox_CleanGoogle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_CleanGoogle.Location = new System.Drawing.Point(33, 188);
            checkBox_CleanGoogle.Size = new System.Drawing.Size(151, 19);

            // checkBox_DeleteRegistry
            checkBox_DeleteRegistry.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_DeleteRegistry.Location = new System.Drawing.Point(33, 293);
            checkBox_DeleteRegistry.Size = new System.Drawing.Size(114, 19);

            // checkBox_CleanPageFile
            checkBox_CleanPageFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_CleanPageFile.Location = new System.Drawing.Point(33, 238);
            checkBox_CleanPageFile.Size = new System.Drawing.Size(112, 24);

            // checkBox_BackupRegistrysRun
            checkBox_BackupRegistrysRun.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_BackupRegistrysRun.Location = new System.Drawing.Point(33, 213);
            checkBox_BackupRegistrysRun.Size = new System.Drawing.Size(116, 19);

            // checkBox_Usuario
            checkBox_Usuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_Usuario.Location = new System.Drawing.Point(33, 318);
            checkBox_Usuario.Size = new System.Drawing.Size(98, 19);

            // checkBox_CleanPrefetch
            checkBox_CleanPrefetch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_CleanPrefetch.Location = new System.Drawing.Point(33, 343);
            checkBox_CleanPrefetch.Size = new System.Drawing.Size(113, 19);

            // checkBox_BackupBCD
            checkBox_BackupBCD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_BackupBCD.Location = new System.Drawing.Point(33, 368);
            checkBox_BackupBCD.Size = new System.Drawing.Size(123, 19);

            // Btn_Canselar
            Btn_Canselar.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Btn_Canselar.Location = new System.Drawing.Point(550, 8);
            Btn_Canselar.Size = new System.Drawing.Size(100, 25);

            // checkBox_DriversBackup
            checkBox_DriversBackup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_DriversBackup.Location = new System.Drawing.Point(33, 268);
            checkBox_DriversBackup.Size = new System.Drawing.Size(105, 19);

            // panelBoton
            panelBoton.Location = new System.Drawing.Point(0, 568);
            panelBoton.Size = new System.Drawing.Size(768, 37);

            // btn_IniciarProcesso
            btn_IniciarProcesso.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btn_IniciarProcesso.Location = new System.Drawing.Point(656, 8);
            btn_IniciarProcesso.Size = new System.Drawing.Size(100, 25);

            // checkBoxAll
            checkBoxAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBoxAll.Location = new System.Drawing.Point(12, 9);
            checkBoxAll.Size = new System.Drawing.Size(65, 19);

            // panelDivisoria
            panelDivisoria.Location = new System.Drawing.Point(225, 38);
            panelDivisoria.Size = new System.Drawing.Size(1, 540);

            // label1
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(9, 6);
            label1.Size = new System.Drawing.Size(64, 20);

            // labelInfoDescricao
            labelInfoDescricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labelInfoDescricao.Location = new System.Drawing.Point(273, 515);
            labelInfoDescricao.Size = new System.Drawing.Size(610, 52);

            // labelInfoTitulo
            labelInfoTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labelInfoTitulo.Location = new System.Drawing.Point(236, 12);
            labelInfoTitulo.Size = new System.Drawing.Size(74, 17);

            // panelLog
            panelLog.Location = new System.Drawing.Point(233, 62);
            panelLog.Size = new System.Drawing.Size(529, 450);

            // Label_NameMachine
            Label_NameMachine.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Label_NameMachine.Location = new System.Drawing.Point(480, 3);
            Label_NameMachine.Size = new System.Drawing.Size(281, 33);

            // pictureBoxInfoDescricao
            pictureBoxInfoDescricao.Location = new System.Drawing.Point(233, 515);
            pictureBoxInfoDescricao.Size = new System.Drawing.Size(38, 35);

            // pictureBox0
            pictureBox0.Location = new System.Drawing.Point(9, 39);
            pictureBox0.Size = new System.Drawing.Size(20, 18);

            // pictureBox1
            pictureBox1.Location = new System.Drawing.Point(9, 64);
            pictureBox1.Size = new System.Drawing.Size(20, 18);

            // pictureBox2
            pictureBox2.Location = new System.Drawing.Point(9, 89);
            pictureBox2.Size = new System.Drawing.Size(20, 18);

            // pictureBox3
            pictureBox3.Location = new System.Drawing.Point(9, 115);
            pictureBox3.Size = new System.Drawing.Size(20, 18);

            // pictureBox4
            pictureBox4.Location = new System.Drawing.Point(9, 139);
            pictureBox4.Size = new System.Drawing.Size(20, 18);

            // pictureBox5
            pictureBox5.Location = new System.Drawing.Point(9, 164);
            pictureBox5.Size = new System.Drawing.Size(20, 18);

            // pictureBox6
            pictureBox6.Location = new System.Drawing.Point(9, 188);
            pictureBox6.Size = new System.Drawing.Size(20, 18);

            // pictureBox7
            pictureBox7.Location = new System.Drawing.Point(9, 214);
            pictureBox7.Size = new System.Drawing.Size(20, 18);

            // pictureBox8
            pictureBox8.Location = new System.Drawing.Point(9, 244);
            pictureBox8.Size = new System.Drawing.Size(20, 18);

            // pictureBox9
            pictureBox9.Location = new System.Drawing.Point(9, 269);
            pictureBox9.Size = new System.Drawing.Size(20, 18);

            // pictureBox10
            pictureBox10.Location = new System.Drawing.Point(9, 294);
            pictureBox10.Size = new System.Drawing.Size(20, 18);

            // pictureBox11
            pictureBox11.Location = new System.Drawing.Point(9, 319);
            pictureBox11.Size = new System.Drawing.Size(20, 18);

            // pictureBox12
            pictureBox12.Location = new System.Drawing.Point(9, 344);
            pictureBox12.Size = new System.Drawing.Size(20, 18);

            // pictureBox13
            pictureBox13.Location = new System.Drawing.Point(9, 369);
            pictureBox13.Size = new System.Drawing.Size(20, 18);

            // pictureBox14
            pictureBox14.Location = new System.Drawing.Point(9, 394);
            pictureBox14.Size = new System.Drawing.Size(20, 18);

            // pictureBox15
            pictureBox15.Location = new System.Drawing.Point(9, 419);
            pictureBox15.Size = new System.Drawing.Size(20, 18);

            // pictureBox16
            pictureBox16.Location = new System.Drawing.Point(9, 444);
            pictureBox16.Size = new System.Drawing.Size(20, 18);

            // pictureBox17
            pictureBox17.Location = new System.Drawing.Point(9, 469);
            pictureBox17.Size = new System.Drawing.Size(20, 18);

            // pictureBox18
            pictureBox18.Location = new System.Drawing.Point(9, 494);
            pictureBox18.Size = new System.Drawing.Size(20, 18);

            // radioButtonUserUAC_Desativar
            radioButtonUserUAC_Desativar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radioButtonUserUAC_Desativar.Location = new System.Drawing.Point(62, 3);
            radioButtonUserUAC_Desativar.Size = new System.Drawing.Size(76, 19);

            // radioButtonUserUAC_Ativar
            radioButtonUserUAC_Ativar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radioButtonUserUAC_Ativar.Location = new System.Drawing.Point(3, 3);
            radioButtonUserUAC_Ativar.Size = new System.Drawing.Size(54, 19);

            // radioButtonCleanPageFile_Ativar
            radioButtonCleanPageFile_Ativar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radioButtonCleanPageFile_Ativar.Location = new System.Drawing.Point(3, 5);
            radioButtonCleanPageFile_Ativar.Size = new System.Drawing.Size(54, 19);

            // radioButtonCleanPageFile_Desativar
            radioButtonCleanPageFile_Desativar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radioButtonCleanPageFile_Desativar.Location = new System.Drawing.Point(62, 5);
            radioButtonCleanPageFile_Desativar.Size = new System.Drawing.Size(76, 19);

            // panel_UserUAC
            panel_UserUAC.Location = new System.Drawing.Point(996, 295);
            panel_UserUAC.Size = new System.Drawing.Size(147, 27);

            // panel_CleanPageFile
            panel_CleanPageFile.Location = new System.Drawing.Point(996, 265);
            panel_CleanPageFile.Size = new System.Drawing.Size(147, 24);

            // checkBox_RestorePoint
            checkBox_RestorePoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_RestorePoint.Location = new System.Drawing.Point(33, 393);
            checkBox_RestorePoint.Size = new System.Drawing.Size(172, 19);

            // checkBox_ConnectionRDP
            checkBox_ConnectionRDP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_ConnectionRDP.Location = new System.Drawing.Point(33, 418);
            checkBox_ConnectionRDP.Size = new System.Drawing.Size(141, 19);

            // panel_ConnectionRDP
            panel_ConnectionRDP.Location = new System.Drawing.Point(996, 235);
            panel_ConnectionRDP.Size = new System.Drawing.Size(147, 24);

            // radioButtonradioButtonConnectionRDP_Ativar
            radioButtonradioButtonConnectionRDP_Ativar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radioButtonradioButtonConnectionRDP_Ativar.Location = new System.Drawing.Point(3, 4);
            radioButtonradioButtonConnectionRDP_Ativar.Size = new System.Drawing.Size(54, 19);

            // radioButtonConnectionRDP_Desativar
            radioButtonConnectionRDP_Desativar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radioButtonConnectionRDP_Desativar.Location = new System.Drawing.Point(62, 4);
            radioButtonConnectionRDP_Desativar.Size = new System.Drawing.Size(76, 19);

            // checkBox_Bloatware
            checkBox_Bloatware.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_Bloatware.Location = new System.Drawing.Point(33, 443);
            checkBox_Bloatware.Size = new System.Drawing.Size(134, 19);

            // checkBox_BackupReportError
            checkBox_BackupReportError.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_BackupReportError.Location = new System.Drawing.Point(33, 468);
            checkBox_BackupReportError.Size = new System.Drawing.Size(169, 19);

            // checkBox_CleanReportError
            checkBox_CleanReportError.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_CleanReportError.Location = new System.Drawing.Point(33, 493);
            checkBox_CleanReportError.Size = new System.Drawing.Size(167, 19);

        }

        #endregion
    }
}
