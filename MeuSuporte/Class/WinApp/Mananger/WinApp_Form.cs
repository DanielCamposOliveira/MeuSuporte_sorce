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
        private CheckBox checkBox_ExportInventory;
        private CheckBox checkBox_OptimizeBar;
        private CheckBox checkBoxAll; // CheckBox única

        private RadioButton radioButtonUserUAC_Ativar;
        private RadioButton radioButtonCleanPageFile_Ativar;
        private RadioButton radioButtonConnectionRDP_Ativar;
        private RadioButton radioButtonUserUAC_Desativar;
        private RadioButton radioButtonCleanPageFile_Desativar;
        private RadioButton radioButtonConnectionRDP_Desativar;
        private RadioButton radioButtonOptimizeBar_Atual;
        private RadioButton radioButtonOptimizeBar_Todos;
        private RadioButton radioButtonDeleteRegistry_Atual;
        private RadioButton radioButtonDeleteRegistry_todos;
        private RadioButton radioButtonCleanTemp_Atual;
        private RadioButton radioButtonCleanTemp_Todos;
        private RadioButton radioButtonBackupRegistrysRun_Atual;
        private RadioButton radioButtonBackupRegistrysRun_Todos;

        private PictureBox pictureBox_UserUAC;
        private PictureBox pictureBox_CleanTask;
        private PictureBox pictureBox_CleanTrash;
        private PictureBox pictureBox_CleanProcess;
        private PictureBox pictureBox_CleanTemp;
        private PictureBox pictureBox_CleanWindowsUpdate;
        private PictureBox pictureBox_CleanGoogle;
        private PictureBox pictureBox_BackupRegistrysRun;
        private PictureBox pictureBox_CleanPageFile;
        private PictureBox pictureBox_DriversBackup;
        private PictureBox pictureBox_DeleteRegistry;
        private PictureBox pictureBox_Usuario;
        private PictureBox pictureBox_CleanPrefetch;
        private PictureBox pictureBox_BackupBCD;
        private PictureBox pictureBox_RestorePoint;
        private PictureBox pictureBox_ConnectionRDP;
        private PictureBox pictureBox_Bloatware;
        private PictureBox pictureBox_BackupReportError;
        private PictureBox pictureBox_CleanReportError;
        private PictureBox pictureBoxInfoDescricao;
        private PictureBox pictureBox_ExportInventory;
        private PictureBox pictureBox_OptimizeBar;

        private Panel panelBoton;
        private Panel panelDivisoria;
        private Panel panel_UserUAC;
        private Panel panelLog;
        private Panel panel_ConnectionRDP;
        private Panel panel_CleanPageFile;
        private Panel panel1;
        private Panel panel_CleanTemp;
        private Panel panel_BackupRegistrysRun;
        private Panel panel_DeleteRegistry;
        private Panel panel_OptimizeBar;

        private Label label1;
        private Label labelInfoDescricao;
        private Label labelInfoTitulo;
        private Label Label_NameMachine;

        private Button Btn_Canselar;
        private Button btn_IniciarProcesso;

        private ProgressBar progressBar1;

        private Form Formulario;

        private TextBox txt_Log;

        #endregion

        #region Initialize

        public static void Initialize(
         // 1. CheckBoxes
        CheckBox _checkBox_UserUAC, CheckBox _checkBox_CleanTask, CheckBox _checkBox_CleanTrash, CheckBox _checkBox_CleanProcess,
        CheckBox _checkBox_CleanTemp, CheckBox _checkBox_CleanWindowsUpdate, CheckBox _checkBox_CleanGoogle, CheckBox _checkBox_BackupRegistrysRun,
        CheckBox _checkBox_CleanPageFile, CheckBox _checkBox_DriversBackup, CheckBox _checkBox_DeleteRegistry, CheckBox _checkBox_Usuario,
        CheckBox _checkBox_CleanPrefetch, CheckBox _checkBox_BackupBCD, CheckBox _checkBox_RestorePoint, CheckBox _checkBox_ConnectionRDP,
        CheckBox _checkBox_Bloatware, CheckBox _checkBox_BackupReportError, CheckBox _checkBox_CleanReportError, CheckBox _checkBox_ExportInventory,
        CheckBox _checkBox_OptimizeBar, CheckBox _checkBoxAll,

        // 2. RadioButtons - Ativar/Desativar
        RadioButton _radioButtonUserUAC_Ativar, RadioButton _radioButtonCleanPageFile_Ativar, RadioButton _radioButtonConnectionRDP_Ativar,
        RadioButton _radioButtonUserUAC_Desativar, RadioButton _radioButtonCleanPageFile_Desativar, RadioButton _radioButtonConnectionRDP_Desativar,

        // 3. RadioButtons - Otimização/Limpeza (Atual/Todos)
        RadioButton _radioButtonOptimizeBar_Atual, RadioButton _radioButtonOptimizeBar_Todos,
        RadioButton _radioButtonDeleteRegistry_Atual, RadioButton _radioButtonDeleteRegistry_todos,
        RadioButton _radioButtonCleanTemp_Atual, RadioButton _radioButtonCleanTemp_Todos,
        RadioButton _radioButtonBackupRegistrysRun_Atual, RadioButton _radioButtonBackupRegistrysRun_Todos,

        // 4. PictureBoxes
        PictureBox _pictureBox_UserUAC, PictureBox _pictureBox_CleanTask, PictureBox _pictureBox_CleanTrash, PictureBox _pictureBox_CleanProcess,
        PictureBox _pictureBox_CleanTemp, PictureBox _pictureBox_CleanWindowsUpdate, PictureBox _pictureBox_CleanGoogle, PictureBox _pictureBox_BackupRegistrysRun,
        PictureBox _pictureBox_CleanPageFile, PictureBox _pictureBox_DriversBackup, PictureBox _pictureBox_DeleteRegistry, PictureBox _pictureBox_Usuario,
        PictureBox _pictureBox_CleanPrefetch, PictureBox _pictureBox_BackupBCD, PictureBox _pictureBox_RestorePoint, PictureBox _pictureBox_ConnectionRDP,
        PictureBox _pictureBox_Bloatware, PictureBox _pictureBox_BackupReportError, PictureBox _pictureBox_CleanReportError, PictureBox _pictureBoxInfoDescricao,
        PictureBox _pictureBox_ExportInventory, PictureBox _pictureBox_OptimizeBar,

        // 5. Panels
        Panel _panelBoton, Panel _panelDivisoria, Panel _panel_UserUAC, Panel _panelLog, Panel _panel_ConnectionRDP, Panel _panel_CleanPageFile,
        Panel _panel1, Panel _panel_CleanTemp, Panel _panel_BackupRegistrysRun, Panel _panel_DeleteRegistry, Panel _panel_OptimizeBar,

        // 6. Labels
        Label _label1, Label _labelInfoDescricao, Label _labelInfoTitulo, Label _Label_NameMachine,

        // 7. Buttons
        Button _Btn_Canselar, Button _btn_IniciarProcesso,

        // 8. Controles Únicos / Form
        ProgressBar _ProgressBar, TextBox _txt_Log, Form _Formulario
        )  
        {
            if (_instance == null)
            {
                _instance = new WinApp_Form
                {
                    // 1. CheckBoxes
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
                    checkBox_ExportInventory = _checkBox_ExportInventory,
                    checkBox_OptimizeBar = _checkBox_OptimizeBar,
                    checkBoxAll = _checkBoxAll,

                    // 2. RadioButtons - Ativar/Desativar
                    radioButtonUserUAC_Ativar = _radioButtonUserUAC_Ativar,
                    radioButtonCleanPageFile_Ativar = _radioButtonCleanPageFile_Ativar,
                    radioButtonConnectionRDP_Ativar = _radioButtonConnectionRDP_Ativar,
                    radioButtonUserUAC_Desativar = _radioButtonUserUAC_Desativar,
                    radioButtonCleanPageFile_Desativar = _radioButtonCleanPageFile_Desativar,
                    radioButtonConnectionRDP_Desativar = _radioButtonConnectionRDP_Desativar,

                    // 3. RadioButtons - Otimização/Limpeza (Atual/Todos)
                    radioButtonOptimizeBar_Atual = _radioButtonOptimizeBar_Atual,
                    radioButtonOptimizeBar_Todos = _radioButtonOptimizeBar_Todos,
                    radioButtonDeleteRegistry_Atual = _radioButtonDeleteRegistry_Atual,
                    radioButtonDeleteRegistry_todos = _radioButtonDeleteRegistry_todos,
                    radioButtonCleanTemp_Atual = _radioButtonCleanTemp_Atual,
                    radioButtonCleanTemp_Todos = _radioButtonCleanTemp_Todos,
                    radioButtonBackupRegistrysRun_Atual = _radioButtonBackupRegistrysRun_Atual,
                    radioButtonBackupRegistrysRun_Todos = _radioButtonBackupRegistrysRun_Todos,

                    // 4. PictureBoxes
                    pictureBox_UserUAC = _pictureBox_UserUAC,
                    pictureBox_CleanTask = _pictureBox_CleanTask,
                    pictureBox_CleanTrash = _pictureBox_CleanTrash,
                    pictureBox_CleanProcess = _pictureBox_CleanProcess,
                    pictureBox_CleanTemp = _pictureBox_CleanTemp,
                    pictureBox_CleanWindowsUpdate = _pictureBox_CleanWindowsUpdate,
                    pictureBox_CleanGoogle = _pictureBox_CleanGoogle,
                    pictureBox_BackupRegistrysRun = _pictureBox_BackupRegistrysRun,
                    pictureBox_CleanPageFile = _pictureBox_CleanPageFile,
                    pictureBox_DriversBackup = _pictureBox_DriversBackup,
                    pictureBox_DeleteRegistry = _pictureBox_DeleteRegistry,
                    pictureBox_Usuario = _pictureBox_Usuario,
                    pictureBox_CleanPrefetch = _pictureBox_CleanPrefetch,
                    pictureBox_BackupBCD = _pictureBox_BackupBCD,
                    pictureBox_RestorePoint = _pictureBox_RestorePoint,
                    pictureBox_ConnectionRDP = _pictureBox_ConnectionRDP,
                    pictureBox_Bloatware = _pictureBox_Bloatware,
                    pictureBox_BackupReportError = _pictureBox_BackupReportError,
                    pictureBox_CleanReportError = _pictureBox_CleanReportError,
                    pictureBoxInfoDescricao = _pictureBoxInfoDescricao,
                    pictureBox_ExportInventory = _pictureBox_ExportInventory,
                    pictureBox_OptimizeBar = _pictureBox_OptimizeBar,

                    // 5. Panels
                    panelBoton = _panelBoton,
                    panelDivisoria = _panelDivisoria,
                    panel_UserUAC = _panel_UserUAC,
                    panelLog = _panelLog,
                    panel_ConnectionRDP = _panel_ConnectionRDP,
                    panel_CleanPageFile = _panel_CleanPageFile,
                    panel1 = _panel1,
                    panel_CleanTemp = _panel_CleanTemp,
                    panel_BackupRegistrysRun = _panel_BackupRegistrysRun,
                    panel_DeleteRegistry = _panel_DeleteRegistry,
                    panel_OptimizeBar = _panel_OptimizeBar,

                    // 6. Labels
                    label1 = _label1,
                    labelInfoDescricao = _labelInfoDescricao,
                    labelInfoTitulo = _labelInfoTitulo,
                    Label_NameMachine = _Label_NameMachine,

                    // 7. Buttons
                    Btn_Canselar = _Btn_Canselar,
                    btn_IniciarProcesso = _btn_IniciarProcesso,

                    // 8. Controles Únicos / Form
                    progressBar1 = _ProgressBar,
                    txt_Log = _txt_Log,
                    Formulario = _Formulario,
                };
            }
        }

        #endregion

        #region Screen Resolution

        public void ScreenResolution1920x1080()
        {

            // MainForm
            // 
            Formulario.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            Formulario.ClientSize = new System.Drawing.Size(966, 685);


            // txt_Log
            txt_Log.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txt_Log.Size = new System.Drawing.Size(651, 496);
            // progressBar1
            progressBar1.Location = new System.Drawing.Point(316, 65);
            progressBar1.Size = new System.Drawing.Size(488, 11);
            // checkBox_UserUAC
            checkBox_UserUAC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_UserUAC.Location = new System.Drawing.Point(40, 36);
            checkBox_UserUAC.Size = new System.Drawing.Size(226, 24);

            // checkBox_CleanTask
            checkBox_CleanTask.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_CleanTask.Location = new System.Drawing.Point(40, 66);
            checkBox_CleanTask.Size = new System.Drawing.Size(220, 24);
            // checkBox_CleanTrash
            checkBox_CleanTrash.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_CleanTrash.Location = new System.Drawing.Point(40, 96);
            checkBox_CleanTrash.Size = new System.Drawing.Size(125, 24);
            // checkBox_CleanProcess
            checkBox_CleanProcess.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_CleanProcess.Location = new System.Drawing.Point(40, 126);
            checkBox_CleanProcess.Size = new System.Drawing.Size(173, 24);
            // checkBox_CleanTemp
            checkBox_CleanTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_CleanTemp.Location = new System.Drawing.Point(40, 156); ;
            checkBox_CleanTemp.Size = new System.Drawing.Size(193, 24);
            // checkBox_CleanWindowsUpdate
            checkBox_CleanWindowsUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_CleanWindowsUpdate.Location = new System.Drawing.Point(40, 186);
            checkBox_CleanWindowsUpdate.Size = new System.Drawing.Size(233, 24);
            // checkBox_CleanGoogle
            checkBox_CleanGoogle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_CleanGoogle.Location = new System.Drawing.Point(40, 216);
            checkBox_CleanGoogle.Size = new System.Drawing.Size(189, 24);
            // checkBox_DeleteRegistry
            checkBox_DeleteRegistry.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_DeleteRegistry.Location = new System.Drawing.Point(40, 336);
            checkBox_DeleteRegistry.Size = new System.Drawing.Size(140, 24);
            // checkBox_CleanPageFile
            checkBox_CleanPageFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_CleanPageFile.Location = new System.Drawing.Point(40, 276);
            checkBox_CleanPageFile.Size = new System.Drawing.Size(112, 24);
            // checkBox_BackupRegistrysRun
            checkBox_BackupRegistrysRun.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_BackupRegistrysRun.Location = new System.Drawing.Point(40, 246);
            checkBox_BackupRegistrysRun.Size = new System.Drawing.Size(146, 24);
            // checkBox_Usuario
            checkBox_Usuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_Usuario.Location = new System.Drawing.Point(40, 366);
            checkBox_Usuario.Size = new System.Drawing.Size(121, 24);
            // checkBox_CleanPrefetch
            checkBox_CleanPrefetch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_CleanPrefetch.Location = new System.Drawing.Point(40, 396);
            checkBox_CleanPrefetch.Size = new System.Drawing.Size(140, 24);
            // checkBox_BackupBCD
            checkBox_BackupBCD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_BackupBCD.Location = new System.Drawing.Point(40, 426);
            checkBox_BackupBCD.Size = new System.Drawing.Size(158, 24);
            // checkBox_DriversBackup
            checkBox_DriversBackup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_DriversBackup.Location = new System.Drawing.Point(40, 306);
            checkBox_DriversBackup.Size = new System.Drawing.Size(131, 24);
            // checkBoxAll
            checkBoxAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBoxAll.Location = new System.Drawing.Point(12, 9);
            checkBoxAll.Size = new System.Drawing.Size(77, 24);
            // checkBox_RestorePoint
            checkBox_RestorePoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_RestorePoint.Location = new System.Drawing.Point(40, 456);
            checkBox_RestorePoint.Size = new System.Drawing.Size(218, 24);
            // checkBox_ConnectionRDP
            checkBox_ConnectionRDP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_ConnectionRDP.Location = new System.Drawing.Point(40, 486);
            checkBox_ConnectionRDP.Size = new System.Drawing.Size(180, 24);
            // checkBox_Bloatware
            checkBox_Bloatware.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_Bloatware.Location = new System.Drawing.Point(40, 516);
            checkBox_Bloatware.Size = new System.Drawing.Size(167, 24);
            // checkBox_BackupReportError
            checkBox_BackupReportError.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_BackupReportError.Location = new System.Drawing.Point(40, 546);
            checkBox_BackupReportError.Size = new System.Drawing.Size(214, 24);
            // checkBox_CleanReportError
            checkBox_CleanReportError.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_CleanReportError.Location = new System.Drawing.Point(40, 576);
            checkBox_CleanReportError.Size = new System.Drawing.Size(208, 24);
            // checkBox_ExportInventory
            checkBox_ExportInventory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_ExportInventory.Location = new System.Drawing.Point(40, 606);
            checkBox_ExportInventory.Size = new System.Drawing.Size(160, 24);
            // checkBox_OptimizeBar
            checkBox_OptimizeBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_OptimizeBar.Location = new System.Drawing.Point(40, 5);
            checkBox_OptimizeBar.Size = new System.Drawing.Size(213, 24);
            // panel_UserUAC
            panel_UserUAC.Location = new System.Drawing.Point(996, 295);
            panel_UserUAC.Size = new System.Drawing.Size(147, 27);
            // panel_CleanPageFile
            panel_CleanPageFile.Location = new System.Drawing.Point(996, 265);
            panel_CleanPageFile.Size = new System.Drawing.Size(147, 24);
            // panel_ConnectionRDP
            panel_ConnectionRDP.Location = new System.Drawing.Point(996, 235);
            panel_ConnectionRDP.Size = new System.Drawing.Size(147, 24);
            // panelBoton
            panelBoton.Location = new System.Drawing.Point(0, 648);
            panelBoton.Size = new System.Drawing.Size(966, 37);
            // panelDivisoria
            panelDivisoria.Location = new System.Drawing.Point(301, 55);
            panelDivisoria.Size = new System.Drawing.Size(1, 570);
            // panelLog
            panelLog.Location = new System.Drawing.Point(308, 87);
            panelLog.Size = new System.Drawing.Size(653, 498);
            // panel1
            panel1.Location = new System.Drawing.Point(0, 60);
            panel1.Size = new System.Drawing.Size(296, 563);
            // panel_CleanTemp
            panel_CleanTemp.Location = new System.Drawing.Point(996, 328);
            panel_CleanTemp.Size = new System.Drawing.Size(147, 27);
            // panel_BackupRegistrysRun
            panel_BackupRegistrysRun.Location = new System.Drawing.Point(996, 362); ;
            panel_BackupRegistrysRun.Size = new System.Drawing.Size(147, 27);
            // panel_DeleteRegistry
            panel_DeleteRegistry.Location = new System.Drawing.Point(996, 395);
            panel_DeleteRegistry.Size = new System.Drawing.Size(147, 27);

            

            // panel_OptimizeBar
            panel_OptimizeBar.Location = new System.Drawing.Point(996, 428);
            panel_OptimizeBar.Size = new System.Drawing.Size(147, 27);
            // Btn_Canselar;
            Btn_Canselar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Btn_Canselar.Location = new System.Drawing.Point(672, 2);
            Btn_Canselar.Size = new System.Drawing.Size(138, 31);
            // btn_IniciarProcesso
            btn_IniciarProcesso.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btn_IniciarProcesso.Location = new System.Drawing.Point(816, 2);
            btn_IniciarProcesso.Size = new System.Drawing.Size(138, 31);
            // label1
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(8, 24);
            label1.Size = new System.Drawing.Size(87, 26);
            // labelInfoDescricao
            labelInfoDescricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labelInfoDescricao.Location = new System.Drawing.Point(346, 590);
            labelInfoDescricao.Size = new System.Drawing.Size(610, 52);
            // labelInfoTitulo
            labelInfoTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labelInfoTitulo.Location = new System.Drawing.Point(312, 37);
            labelInfoTitulo.Size = new System.Drawing.Size(81, 20); ;
            // Label_NameMachine
            Label_NameMachine.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Label_NameMachine.Location = new System.Drawing.Point(680, 9);
            Label_NameMachine.Size = new System.Drawing.Size(281, 48);
            // pictureBoxInfoDescricao
            pictureBoxInfoDescricao.Location = new System.Drawing.Point(306, 590);
            pictureBoxInfoDescricao.Size = new System.Drawing.Size(38, 35);
            // pictureBox_DriversBackup
            pictureBox_DriversBackup.Location = new System.Drawing.Point(7, 306);
            pictureBox_DriversBackup.Size = new System.Drawing.Size(24, 24);
            // pictureBox_BackupBCD
            pictureBox_BackupBCD.Location = new System.Drawing.Point(7, 426);
            pictureBox_BackupBCD.Size = new System.Drawing.Size(24, 24);         
            // pictureBox_CleanPrefetch
            pictureBox_CleanPrefetch.Location = new System.Drawing.Point(7, 396);
            pictureBox_CleanPrefetch.Size = new System.Drawing.Size(24, 24);
            // pictureBox_Usuario
            pictureBox_Usuario.Location = new System.Drawing.Point(7, 366);
            pictureBox_Usuario.Size = new System.Drawing.Size(24, 24);
            // pictureBox_BackupRegistrysRun
            pictureBox_BackupRegistrysRun.Location = new System.Drawing.Point(7, 246);
            pictureBox_BackupRegistrysRun.Size = new System.Drawing.Size(24, 24);
            // pictureBox_CleanPageFile
            pictureBox_CleanPageFile.Location = new System.Drawing.Point(7, 276);
            pictureBox_CleanPageFile.Size = new System.Drawing.Size(24, 24);
            // pictureBox_DeleteRegistry
            pictureBox_DeleteRegistry.Location = new System.Drawing.Point(7, 336);
            pictureBox_DeleteRegistry.Size = new System.Drawing.Size(24, 24);
            // pictureBox_CleanGoogle
            pictureBox_CleanGoogle.Location = new System.Drawing.Point(7, 216);
            pictureBox_CleanGoogle.Size = new System.Drawing.Size(24, 24);
            // pictureBox_CleanWindowsUpdate
            pictureBox_CleanWindowsUpdate.Location = new System.Drawing.Point(7, 186);
            pictureBox_CleanWindowsUpdate.Size = new System.Drawing.Size(24, 24);
            // pictureBox_CleanTemp
            pictureBox_CleanTemp.Location = new System.Drawing.Point(7, 156);
            pictureBox_CleanTemp.Size = new System.Drawing.Size(24, 24);
            // pictureBox_CleanProcess
            pictureBox_CleanProcess.Location = new System.Drawing.Point(7, 126);
            pictureBox_CleanProcess.Size = new System.Drawing.Size(24, 24);
            // pictureBox_CleanTrash
            pictureBox_CleanTrash.Location = new System.Drawing.Point(7, 96);
            pictureBox_CleanTrash.Size = new System.Drawing.Size(24, 24);
            // pictureBox_UserUAC
            pictureBox_UserUAC.Location = new System.Drawing.Point(7, 36);
            pictureBox_UserUAC.Size = new System.Drawing.Size(24, 24);
            // pictureBox_CleanTask
            pictureBox_CleanTask.Location = new System.Drawing.Point(7, 66);
            pictureBox_CleanTask.Size = new System.Drawing.Size(24, 24);
            // pictureBox_RestorePoint
            pictureBox_RestorePoint.Location = new System.Drawing.Point(7, 456);
            pictureBox_RestorePoint.Size = new System.Drawing.Size(24, 24);
            // pictureBox_ConnectionRDP
            pictureBox_ConnectionRDP.Location = new System.Drawing.Point(7, 486);
            pictureBox_ConnectionRDP.Size = new System.Drawing.Size(24, 24);
            // pictureBox_Bloatware
            pictureBox_Bloatware.Location = new System.Drawing.Point(7, 516);
            pictureBox_Bloatware.Size = new System.Drawing.Size(24, 24);
            // pictureBox_BackupReportError
            pictureBox_BackupReportError.Location = new System.Drawing.Point(7, 546);
            pictureBox_BackupReportError.Size = new System.Drawing.Size(24, 24);
            // pictureBox_CleanReportError
            pictureBox_CleanReportError.Location = new System.Drawing.Point(7, 576);
            pictureBox_CleanReportError.Size = new System.Drawing.Size(24, 24);
            // pictureBox_ExportInventory
            pictureBox_ExportInventory.Location = new System.Drawing.Point(7, 606);
            pictureBox_ExportInventory.Size = new System.Drawing.Size(24, 24);
            // pictureBox_OptimizeBar
            pictureBox_OptimizeBar.Location = new System.Drawing.Point(7, 5);
            pictureBox_OptimizeBar.Size = new System.Drawing.Size(24, 24);
            // radioButtonUserUAC_Desativar
            radioButtonUserUAC_Desativar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radioButtonUserUAC_Desativar.Location = new System.Drawing.Point(62, 3);
            radioButtonUserUAC_Desativar.Size = new System.Drawing.Size(76, 19);
            // radioButtonUserUAC_Ativar
            radioButtonUserUAC_Ativar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radioButtonUserUAC_Ativar.Location = new System.Drawing.Point(3, 3); ;
            radioButtonUserUAC_Ativar.Size = new System.Drawing.Size(54, 19);
            // radioButtonCleanPageFile_Ativar
            radioButtonCleanPageFile_Ativar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radioButtonCleanPageFile_Ativar.Location = new System.Drawing.Point(3, 5);
            radioButtonCleanPageFile_Ativar.Size = new System.Drawing.Size(54, 19);
            // radioButtonCleanPageFile_Desativar
            radioButtonCleanPageFile_Desativar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radioButtonCleanPageFile_Desativar.Location = new System.Drawing.Point(62, 5);
            radioButtonCleanPageFile_Desativar.Size = new System.Drawing.Size(76, 19);
            // radioButtonradioButtonConnectionRDP_Ativar
            radioButtonConnectionRDP_Ativar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radioButtonConnectionRDP_Ativar.Location = new System.Drawing.Point(3, 4);
            radioButtonConnectionRDP_Ativar.Size = new System.Drawing.Size(54, 19);
            // radioButtonConnectionRDP_Desativar
            radioButtonConnectionRDP_Desativar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radioButtonConnectionRDP_Desativar.Location = new System.Drawing.Point(62, 4);
            radioButtonConnectionRDP_Desativar.Size = new System.Drawing.Size(76, 19);
            // radioButtonOptimizeBar_Atual
            radioButtonOptimizeBar_Atual.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radioButtonOptimizeBar_Atual.Location = new System.Drawing.Point(3, 3);
            radioButtonOptimizeBar_Atual.Size = new System.Drawing.Size(52, 19);
            // radioButtonOptimizeBar_Todos
            radioButtonOptimizeBar_Todos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radioButtonOptimizeBar_Todos.Location = new System.Drawing.Point(62, 3);
            radioButtonOptimizeBar_Todos.Size = new System.Drawing.Size(59, 19);
            // radioButtonDeleteRegistry_Atual
            radioButtonDeleteRegistry_Atual.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radioButtonDeleteRegistry_Atual.Location = new System.Drawing.Point(3, 3);
            radioButtonDeleteRegistry_Atual.Size = new System.Drawing.Size(52, 19);
            // radioButtonDeleteRegistry_todos
            radioButtonDeleteRegistry_todos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radioButtonDeleteRegistry_todos.Location = new System.Drawing.Point(62, 3);
            radioButtonDeleteRegistry_todos.Size = new System.Drawing.Size(59, 19);
            // radioButtonCleanTemp_Atual
            radioButtonCleanTemp_Atual.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radioButtonCleanTemp_Atual.Location = new System.Drawing.Point(3, 3);
            radioButtonCleanTemp_Atual.Size = new System.Drawing.Size(52, 19);
            // radioButtonCleanTemp_Todos
            radioButtonCleanTemp_Todos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radioButtonCleanTemp_Todos.Location = new System.Drawing.Point(62, 3);
            radioButtonCleanTemp_Todos.Size = new System.Drawing.Size(59, 19);
            // radioButtonBackupRegistrysRun_Atual
            radioButtonBackupRegistrysRun_Atual.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radioButtonBackupRegistrysRun_Atual.Location = new System.Drawing.Point(3, 3);
            radioButtonBackupRegistrysRun_Atual.Size = new System.Drawing.Size(52, 19);
            // radioButtonBackupRegistrysRun_Todos
            radioButtonBackupRegistrysRun_Todos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radioButtonBackupRegistrysRun_Todos.Location = new System.Drawing.Point(62, 3);
            radioButtonBackupRegistrysRun_Todos.Size = new System.Drawing.Size(59, 19);

        }

        public void ScreenResolution1024x800()
        {

            // Reset de componentes - Apenas Font, Location e Size (e Location/Size para PictureBox)

            // MainForm
            Formulario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Formulario.Size = new System.Drawing.Size(886, 537);

            // txt_Log
            txt_Log.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txt_Log.Location = new System.Drawing.Point(1, 1);
            txt_Log.Size = new System.Drawing.Size(559, 365);

            // progressBar1
            progressBar1.Location = new System.Drawing.Point(309, 32);
            progressBar1.Size = new System.Drawing.Size(488, 11);

            // checkBox_UserUAC
            checkBox_UserUAC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_UserUAC.Location = new System.Drawing.Point(40, 30);
            checkBox_UserUAC.Size = new System.Drawing.Size(177, 19);

            // checkBox_CleanTask
            checkBox_CleanTask.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_CleanTask.Location = new System.Drawing.Point(40, 55);
            checkBox_CleanTask.Size = new System.Drawing.Size(174, 19);

            // checkBox_CleanTrash
            checkBox_CleanTrash.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_CleanTrash.Location = new System.Drawing.Point(40, 80);
            checkBox_CleanTrash.Size = new System.Drawing.Size(105, 19);

            // checkBox_CleanProcess
            checkBox_CleanProcess.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_CleanProcess.Location = new System.Drawing.Point(40, 105);
            checkBox_CleanProcess.Size = new System.Drawing.Size(137, 19);

            // checkBox_CleanTemp
            checkBox_CleanTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_CleanTemp.Location = new System.Drawing.Point(40, 130);
            checkBox_CleanTemp.Size = new System.Drawing.Size(156, 19);

            // checkBox_CleanWindowsUpdate
            checkBox_CleanWindowsUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_CleanWindowsUpdate.Location = new System.Drawing.Point(40, 155);
            checkBox_CleanWindowsUpdate.Size = new System.Drawing.Size(183, 19);

            // checkBox_CleanGoogle
            checkBox_CleanGoogle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_CleanGoogle.Location = new System.Drawing.Point(40, 180);
            checkBox_CleanGoogle.Size = new System.Drawing.Size(151, 19);

            // checkBox_DeleteRegistry
            checkBox_DeleteRegistry.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_DeleteRegistry.Location = new System.Drawing.Point(40, 280);
            checkBox_DeleteRegistry.Size = new System.Drawing.Size(114, 19);

            // checkBox_CleanPageFile
            checkBox_CleanPageFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_CleanPageFile.Location = new System.Drawing.Point(40, 230);
            checkBox_CleanPageFile.Size = new System.Drawing.Size(91, 19);

            // checkBox_BackupRegistrysRun
            checkBox_BackupRegistrysRun.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_BackupRegistrysRun.Location = new System.Drawing.Point(40, 205);
            checkBox_BackupRegistrysRun.Size = new System.Drawing.Size(116, 19);

            // checkBox_Usuario
            checkBox_Usuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_Usuario.Location = new System.Drawing.Point(40, 303);
            checkBox_Usuario.Size = new System.Drawing.Size(98, 19);

            // checkBox_CleanPrefetch
            checkBox_CleanPrefetch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_CleanPrefetch.Location = new System.Drawing.Point(40, 328);
            checkBox_CleanPrefetch.Size = new System.Drawing.Size(113, 19);

            // checkBox_BackupBCD
            checkBox_BackupBCD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_BackupBCD.Location = new System.Drawing.Point(40, 353);
            checkBox_BackupBCD.Size = new System.Drawing.Size(123, 19);

            // Btn_Canselar
            Btn_Canselar.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Btn_Canselar.Location = new System.Drawing.Point(661, 4);
            Btn_Canselar.Size = new System.Drawing.Size(100, 25);

            // checkBox_DriversBackup
            checkBox_DriversBackup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_DriversBackup.Location = new System.Drawing.Point(40, 255);
            checkBox_DriversBackup.Size = new System.Drawing.Size(105, 19);

            // panelBoton
            panelBoton.Location = new System.Drawing.Point(0, 466);
            panelBoton.Size = new System.Drawing.Size(870, 32);

            // btn_IniciarProcesso
            btn_IniciarProcesso.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btn_IniciarProcesso.Location = new System.Drawing.Point(767, 4);
            btn_IniciarProcesso.Size = new System.Drawing.Size(100, 25);

            // checkBoxAll
            checkBoxAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBoxAll.Location = new System.Drawing.Point(12, 9);
            checkBoxAll.Size = new System.Drawing.Size(65, 19);

            // panelDivisoria
            panelDivisoria.Location = new System.Drawing.Point(301, 55);
            panelDivisoria.Size = new System.Drawing.Size(1, 570);

            // label1
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(8, 10);
            label1.Size = new System.Drawing.Size(64, 20);

            // labelInfoDescricao
            labelInfoDescricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labelInfoDescricao.Location = new System.Drawing.Point(351, 420);
            labelInfoDescricao.Size = new System.Drawing.Size(511, 39);

            // labelInfoTitulo
            labelInfoTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labelInfoTitulo.Location = new System.Drawing.Point(306, 9);
            labelInfoTitulo.Size = new System.Drawing.Size(74, 17);

            // panelLog
            panelLog.Location = new System.Drawing.Point(307, 50);
            panelLog.Size = new System.Drawing.Size(561, 367);

            // Label_NameMachine
            Label_NameMachine.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Label_NameMachine.Location = new System.Drawing.Point(587, 3);
            Label_NameMachine.Size = new System.Drawing.Size(281, 26);

            // pictureBoxInfoDescricao
            pictureBoxInfoDescricao.Location = new System.Drawing.Point(307, 420);
            pictureBoxInfoDescricao.Size = new System.Drawing.Size(38, 35);

            // pictureBox_DriversBackup
            pictureBox_DriversBackup.Location = new System.Drawing.Point(7, 255);
            pictureBox_DriversBackup.Size = new System.Drawing.Size(20, 18);

            // pictureBox_BackupBCD
            pictureBox_BackupBCD.Location = new System.Drawing.Point(7, 353);
            pictureBox_BackupBCD.Size = new System.Drawing.Size(20, 18);

            // pictureBox_CleanPrefetch
            pictureBox_CleanPrefetch.Location = new System.Drawing.Point(7, 328);
            pictureBox_CleanPrefetch.Size = new System.Drawing.Size(20, 18);

            // pictureBox_Usuario
            pictureBox_Usuario.Location = new System.Drawing.Point(7, 303);
            pictureBox_Usuario.Size = new System.Drawing.Size(20, 18);

            // pictureBox_BackupRegistrysRun
            pictureBox_BackupRegistrysRun.Location = new System.Drawing.Point(7, 205);
            pictureBox_BackupRegistrysRun.Size = new System.Drawing.Size(20, 18);

            // pictureBox_CleanPageFile
            pictureBox_CleanPageFile.Location = new System.Drawing.Point(7, 230);
            pictureBox_CleanPageFile.Size = new System.Drawing.Size(20, 18);

            // pictureBox_DeleteRegistry
            pictureBox_DeleteRegistry.Location = new System.Drawing.Point(7, 280);
            pictureBox_DeleteRegistry.Size = new System.Drawing.Size(20, 18);

            // pictureBox_CleanGoogle
            pictureBox_CleanGoogle.Location = new System.Drawing.Point(7, 180);
            pictureBox_CleanGoogle.Size = new System.Drawing.Size(20, 18);

            // pictureBox_CleanWindowsUpdate
            pictureBox_CleanWindowsUpdate.Location = new System.Drawing.Point(7, 155);
            pictureBox_CleanWindowsUpdate.Size = new System.Drawing.Size(20, 18);

            // pictureBox_CleanTemp
            pictureBox_CleanTemp.Location = new System.Drawing.Point(7, 130);
            pictureBox_CleanTemp.Size = new System.Drawing.Size(20, 18);

            // pictureBox_CleanProcess
            pictureBox_CleanProcess.Location = new System.Drawing.Point(7, 105);
            pictureBox_CleanProcess.Size = new System.Drawing.Size(20, 18);

            // pictureBox_CleanTrash
            pictureBox_CleanTrash.Location = new System.Drawing.Point(7, 80);
            pictureBox_CleanTrash.Size = new System.Drawing.Size(20, 18);

            // pictureBox_UserUAC
            pictureBox_UserUAC.Location = new System.Drawing.Point(7, 31);
            pictureBox_UserUAC.Size = new System.Drawing.Size(20, 18);

            // pictureBox_CleanTask
            pictureBox_CleanTask.Location = new System.Drawing.Point(7, 55);
            pictureBox_CleanTask.Size = new System.Drawing.Size(20, 18);

            // radioButtonUserUAC_Desativar
            radioButtonUserUAC_Desativar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radioButtonUserUAC_Desativar.Location = new System.Drawing.Point(62, 0);
            radioButtonUserUAC_Desativar.Size = new System.Drawing.Size(76, 19);

            // radioButtonUserUAC_Ativar
            radioButtonUserUAC_Ativar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radioButtonUserUAC_Ativar.Location = new System.Drawing.Point(3, 0);
            radioButtonUserUAC_Ativar.Size = new System.Drawing.Size(54, 19);

            // radioButtonCleanPageFile_Ativar
            radioButtonCleanPageFile_Ativar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radioButtonCleanPageFile_Ativar.Location = new System.Drawing.Point(3, 0);
            radioButtonCleanPageFile_Ativar.Size = new System.Drawing.Size(54, 19);

            // radioButtonCleanPageFile_Desativar
            radioButtonCleanPageFile_Desativar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radioButtonCleanPageFile_Desativar.Location = new System.Drawing.Point(62, 0);
            radioButtonCleanPageFile_Desativar.Size = new System.Drawing.Size(76, 19);

            // panel_UserUAC
            panel_UserUAC.Location = new System.Drawing.Point(884, 125);
            panel_UserUAC.Size = new System.Drawing.Size(147, 17);

            // panel_CleanPageFile
            panel_CleanPageFile.Location = new System.Drawing.Point(884, 100);
            panel_CleanPageFile.Size = new System.Drawing.Size(147, 17);

            // checkBox_RestorePoint
            checkBox_RestorePoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_RestorePoint.Location = new System.Drawing.Point(40, 378);
            checkBox_RestorePoint.Size = new System.Drawing.Size(172, 19);

            // checkBox_ConnectionRDP
            checkBox_ConnectionRDP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_ConnectionRDP.Location = new System.Drawing.Point(40, 403);
            checkBox_ConnectionRDP.Size = new System.Drawing.Size(141, 19);

            // panel_ConnectionRDP
            panel_ConnectionRDP.Location = new System.Drawing.Point(881, 71);
            panel_ConnectionRDP.Size = new System.Drawing.Size(147, 17);

            // radioButtonConnectionRDP_Ativar
            radioButtonConnectionRDP_Ativar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radioButtonConnectionRDP_Ativar.Location = new System.Drawing.Point(3, -1);
            radioButtonConnectionRDP_Ativar.Size = new System.Drawing.Size(54, 19);

            // radioButtonConnectionRDP_Desativar
            radioButtonConnectionRDP_Desativar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radioButtonConnectionRDP_Desativar.Location = new System.Drawing.Point(62, -1);
            radioButtonConnectionRDP_Desativar.Size = new System.Drawing.Size(76, 19);

            // pictureBox_RestorePoint
            pictureBox_RestorePoint.Location = new System.Drawing.Point(7, 378);
            pictureBox_RestorePoint.Size = new System.Drawing.Size(20, 18);

            // pictureBox_ConnectionRDP
            pictureBox_ConnectionRDP.Location = new System.Drawing.Point(7, 403);
            pictureBox_ConnectionRDP.Size = new System.Drawing.Size(20, 18);

            // checkBox_Bloatware
            checkBox_Bloatware.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_Bloatware.Location = new System.Drawing.Point(40, 428);
            checkBox_Bloatware.Size = new System.Drawing.Size(134, 19);

            // checkBox_BackupReportError
            checkBox_BackupReportError.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_BackupReportError.Location = new System.Drawing.Point(40, 453);
            checkBox_BackupReportError.Size = new System.Drawing.Size(169, 19);

            // checkBox_CleanReportError
            checkBox_CleanReportError.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_CleanReportError.Location = new System.Drawing.Point(40, 478);
            checkBox_CleanReportError.Size = new System.Drawing.Size(167, 19);

            // pictureBox_Bloatware
            pictureBox_Bloatware.Location = new System.Drawing.Point(7, 428);
            pictureBox_Bloatware.Size = new System.Drawing.Size(20, 18);

            // pictureBox_BackupReportError
            pictureBox_BackupReportError.Location = new System.Drawing.Point(7, 453);
            pictureBox_BackupReportError.Size = new System.Drawing.Size(20, 18);

            // pictureBox_CleanReportError
            pictureBox_CleanReportError.Location = new System.Drawing.Point(7, 478);
            pictureBox_CleanReportError.Size = new System.Drawing.Size(20, 18);

            // panel1
            panel1.Location = new System.Drawing.Point(1, 50);
            panel1.Size = new System.Drawing.Size(296, 410);

            panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            panel1.AutoScrollMargin = new System.Drawing.Size(0, 3);
            panel1.AutoScrollMinSize = new System.Drawing.Size(0, 5);

            // pictureBox_ExportInventory
            pictureBox_ExportInventory.Location = new System.Drawing.Point(7, 503);
            pictureBox_ExportInventory.Size = new System.Drawing.Size(20, 18);

            // checkBox_ExportInventory
            checkBox_ExportInventory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_ExportInventory.Location = new System.Drawing.Point(40, 503);
            checkBox_ExportInventory.Size = new System.Drawing.Size(128, 19);

            // checkBox_OptimizeBar
            checkBox_OptimizeBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_OptimizeBar.Location = new System.Drawing.Point(40, 5);
            checkBox_OptimizeBar.Size = new System.Drawing.Size(169, 19);

            // pictureBox_OptimizeBar
            pictureBox_OptimizeBar.Location = new System.Drawing.Point(7, 5);
            pictureBox_OptimizeBar.Size = new System.Drawing.Size(20, 18);

            // panel_CleanTemp
            panel_CleanTemp.Location = new System.Drawing.Point(884, 153);
            panel_CleanTemp.Size = new System.Drawing.Size(147, 17);

            // radioButtonCleanTemp_Atual
            radioButtonCleanTemp_Atual.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radioButtonCleanTemp_Atual.Location = new System.Drawing.Point(3, 0);
            radioButtonCleanTemp_Atual.Size = new System.Drawing.Size(52, 19);

            // radioButtonCleanTemp_Todos
            radioButtonCleanTemp_Todos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radioButtonCleanTemp_Todos.Location = new System.Drawing.Point(62, 0);
            radioButtonCleanTemp_Todos.Size = new System.Drawing.Size(59, 19);

            // panel_BackupRegistrysRun
            panel_BackupRegistrysRun.Location = new System.Drawing.Point(884, 181);
            panel_BackupRegistrysRun.Size = new System.Drawing.Size(147, 17);

            // radioButtonBackupRegistrysRun_Atual
            radioButtonBackupRegistrysRun_Atual.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radioButtonBackupRegistrysRun_Atual.Location = new System.Drawing.Point(3, -1);
            radioButtonBackupRegistrysRun_Atual.Size = new System.Drawing.Size(52, 19);

            // radioButtonBackupRegistrysRun_Todos
            radioButtonBackupRegistrysRun_Todos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radioButtonBackupRegistrysRun_Todos.Location = new System.Drawing.Point(62, -1);
            radioButtonBackupRegistrysRun_Todos.Size = new System.Drawing.Size(59, 19);

            // panel_DeleteRegistry
            panel_DeleteRegistry.Location = new System.Drawing.Point(884, 215);
            panel_DeleteRegistry.Size = new System.Drawing.Size(147, 17);

            // radioButtonDeleteRegistry_Atual
            radioButtonDeleteRegistry_Atual.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radioButtonDeleteRegistry_Atual.Location = new System.Drawing.Point(3, 0);
            radioButtonDeleteRegistry_Atual.Size = new System.Drawing.Size(52, 19);

            // radioButtonDeleteRegistry_todos
            radioButtonDeleteRegistry_todos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radioButtonDeleteRegistry_todos.Location = new System.Drawing.Point(62, 0);
            radioButtonDeleteRegistry_todos.Size = new System.Drawing.Size(59, 19);

            // panel_OptimizeBar
            panel_OptimizeBar.Location = new System.Drawing.Point(884, 238);
            panel_OptimizeBar.Size = new System.Drawing.Size(147, 17);

            // radioButtonOptimizeBar_Atual
            radioButtonOptimizeBar_Atual.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radioButtonOptimizeBar_Atual.Location = new System.Drawing.Point(3, 0);
            radioButtonOptimizeBar_Atual.Size = new System.Drawing.Size(52, 19);

            // radioButtonOptimizeBar_Todos
            radioButtonOptimizeBar_Todos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radioButtonOptimizeBar_Todos.Location = new System.Drawing.Point(62, 0);
            radioButtonOptimizeBar_Todos.Size = new System.Drawing.Size(59, 19);


        }

        #endregion
    }
}
