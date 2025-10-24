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
        private CheckBox checkBox_ProfileGraphic;
        private CheckBox checkBox_ProfileEnergy;



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
        private RadioButton radioButtonProfileGraphic_Performace;
        private RadioButton radioButtonProfileGraphic_Appearance;
        private RadioButton radioButtonProfileEnergy_Desenpenho;
        private RadioButton radioButtonProfileEnergy_Equilibrado;
        private RadioButton radioButtonProfileEnergy_Economia;

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
        private PictureBox pictureBox_ProfileGraphic;
        private PictureBox pictureBox_ProfileEnergy;

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
        private Panel panel_ProfileGraphic;
        private Panel panel_ProfileEnergy;

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
             CheckBox _checkBox_UserUAC, CheckBox _checkBox_CleanTask, 
             CheckBox _checkBox_CleanTrash, CheckBox _checkBox_CleanProcess, 
             CheckBox _checkBox_CleanTemp, CheckBox _checkBox_CleanWindowsUpdate, 
             CheckBox _checkBox_CleanGoogle, CheckBox _checkBox_BackupRegistrysRun, 
             CheckBox _checkBox_CleanPageFile, CheckBox _checkBox_DriversBackup, 
             CheckBox _checkBox_DeleteRegistry, CheckBox _checkBox_Usuario,
             CheckBox _checkBox_CleanPrefetch, CheckBox _checkBox_BackupBCD, 
             CheckBox _checkBox_RestorePoint, CheckBox _checkBox_ConnectionRDP, 
             CheckBox _checkBox_Bloatware, CheckBox _checkBox_BackupReportError, 
             CheckBox _checkBox_CleanReportError, CheckBox _checkBox_ExportInventory,
             CheckBox _checkBox_OptimizeBar, CheckBox _checkBoxAll,
             CheckBox _checkBox_ProfileGraphic, CheckBox _checkBox_ProfileEnergy,

             // 2. RadioButtons - Ativar/Desativar
             RadioButton _radioButtonUserUAC_Ativar, RadioButton _radioButtonCleanPageFile_Ativar, 
             RadioButton _radioButtonConnectionRDP_Ativar, RadioButton _radioButtonUserUAC_Desativar, 
             RadioButton _radioButtonCleanPageFile_Desativar, RadioButton _radioButtonConnectionRDP_Desativar,
             RadioButton _radioButtonOptimizeBar_Atual, RadioButton _radioButtonOptimizeBar_Todos,
             RadioButton _radioButtonDeleteRegistry_Atual, RadioButton _radioButtonDeleteRegistry_todos,
             RadioButton _radioButtonCleanTemp_Atual, RadioButton _radioButtonCleanTemp_Todos,
             RadioButton _radioButtonBackupRegistrysRun_Atual, RadioButton _radioButtonBackupRegistrysRun_Todos,
             RadioButton _radioButtonProfileGraphic_Performace, RadioButton _radioButtonProfileGraphic_Appearance,
             RadioButton _radioButtonProfileEnergy_Desenpenho, RadioButton _radioButtonProfileEnergy_Equilibrado,
             RadioButton _radioButtonProfileEnergy_Economia,

             // 3. PictureBoxes
             PictureBox _pictureBox_UserUAC, PictureBox _pictureBox_CleanTask, 
             PictureBox _pictureBox_CleanTrash, PictureBox _pictureBox_CleanProcess,
             PictureBox _pictureBox_CleanTemp, PictureBox _pictureBox_CleanWindowsUpdate, 
             PictureBox _pictureBox_CleanGoogle, PictureBox _pictureBox_BackupRegistrysRun,
             PictureBox _pictureBox_CleanPageFile, PictureBox _pictureBox_DriversBackup, 
             PictureBox _pictureBox_DeleteRegistry, PictureBox _pictureBox_Usuario,
             PictureBox _pictureBox_CleanPrefetch, PictureBox _pictureBox_BackupBCD, 
             PictureBox _pictureBox_RestorePoint, PictureBox _pictureBox_ConnectionRDP,
             PictureBox _pictureBox_Bloatware, PictureBox _pictureBox_BackupReportError,
             PictureBox _pictureBox_CleanReportError, PictureBox _pictureBoxInfoDescricao,
             PictureBox _pictureBox_ExportInventory, PictureBox _pictureBox_OptimizeBar,
             PictureBox _pictureBox_ProfileGraphic, PictureBox _pictureBox_ProfileEnergy,

             // 4. Panels
             Panel _panelBoton, Panel _panelDivisoria, 
             Panel _panel_UserUAC, Panel _panelLog, 
             Panel _panel_ConnectionRDP, Panel _panel_CleanPageFile,
             Panel _panel1, Panel _panel_CleanTemp, 
             Panel _panel_BackupRegistrysRun, Panel _panel_DeleteRegistry, 
             Panel _panel_OptimizeBar, Panel _panel_ProfileGraphic,
             Panel _panel_ProfileEnergy,

             // 5. Labels
             Label _label1, Label _labelInfoDescricao, 
             Label _labelInfoTitulo, Label _Label_NameMachine,

             // 6. Buttons
             Button _Btn_Canselar, Button _btn_IniciarProcesso,

             // 7. Controles Únicos / Form
             ProgressBar _ProgressBar, TextBox _txt_Log, 
             Form _Formulario
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
                    checkBox_ProfileGraphic = _checkBox_ProfileGraphic,
                    checkBox_ProfileEnergy = _checkBox_ProfileEnergy,

                    // 2. RadioButtons - Ativar/Desativar
                    radioButtonUserUAC_Ativar = _radioButtonUserUAC_Ativar,
                    radioButtonCleanPageFile_Ativar = _radioButtonCleanPageFile_Ativar,
                    radioButtonConnectionRDP_Ativar = _radioButtonConnectionRDP_Ativar,
                    radioButtonUserUAC_Desativar = _radioButtonUserUAC_Desativar,
                    radioButtonCleanPageFile_Desativar = _radioButtonCleanPageFile_Desativar,
                    radioButtonConnectionRDP_Desativar = _radioButtonConnectionRDP_Desativar,
                    radioButtonOptimizeBar_Atual = _radioButtonOptimizeBar_Atual,
                    radioButtonOptimizeBar_Todos = _radioButtonOptimizeBar_Todos,
                    radioButtonDeleteRegistry_Atual = _radioButtonDeleteRegistry_Atual,
                    radioButtonDeleteRegistry_todos = _radioButtonDeleteRegistry_todos,
                    radioButtonCleanTemp_Atual = _radioButtonCleanTemp_Atual,
                    radioButtonCleanTemp_Todos = _radioButtonCleanTemp_Todos,
                    radioButtonBackupRegistrysRun_Atual = _radioButtonBackupRegistrysRun_Atual,
                    radioButtonBackupRegistrysRun_Todos = _radioButtonBackupRegistrysRun_Todos,
                    radioButtonProfileGraphic_Performace = _radioButtonProfileGraphic_Performace,
                    radioButtonProfileGraphic_Appearance = _radioButtonProfileGraphic_Appearance,
                    radioButtonProfileEnergy_Desenpenho = _radioButtonProfileEnergy_Desenpenho,
                    radioButtonProfileEnergy_Equilibrado = _radioButtonProfileEnergy_Equilibrado,
                    radioButtonProfileEnergy_Economia = _radioButtonProfileEnergy_Economia,

                    // 3. PictureBoxes
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
                    pictureBox_ProfileGraphic = _pictureBox_ProfileGraphic,
                    pictureBox_ProfileEnergy = _pictureBox_ProfileEnergy,

                    // 4. Panels
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
                    panel_ProfileGraphic = _panel_ProfileGraphic,
                    panel_ProfileEnergy = _panel_ProfileEnergy,

                    // 5. Labels
                    label1 = _label1,
                    labelInfoDescricao = _labelInfoDescricao,
                    labelInfoTitulo = _labelInfoTitulo,
                    Label_NameMachine = _Label_NameMachine,

                    // 6. Buttons
                    Btn_Canselar = _Btn_Canselar,
                    btn_IniciarProcesso = _btn_IniciarProcesso,

                    // 7. Controles Únicos / Form
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




            // -----------------------------------------------------------------------
            // CHECKBOX ALINHADA EM X=40 E COM ESPAÇAMENTO DE Y=30
            // -----------------------------------------------------------------------
            // checkBox_OptimizeBar (Y=6)
            checkBox_OptimizeBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_OptimizeBar.Location = new System.Drawing.Point(40, 6);
            // checkBox_UserUAC (Y=36)
            checkBox_UserUAC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_UserUAC.Location = new System.Drawing.Point(40, 36);
            // checkBox_CleanTask (Y=66)
            checkBox_CleanTask.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_CleanTask.Location = new System.Drawing.Point(40, 66);
            // checkBox_CleanTrash (Y=96)
            checkBox_CleanTrash.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_CleanTrash.Location = new System.Drawing.Point(40, 96);
            // checkBox_CleanProcess (Y=126)
            checkBox_CleanProcess.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_CleanProcess.Location = new System.Drawing.Point(40, 126);
            // checkBox_CleanTemp (Y=156)
            checkBox_CleanTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_CleanTemp.Location = new System.Drawing.Point(40, 156);
            // checkBox_CleanWindowsUpdate (Y=186)
            checkBox_CleanWindowsUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_CleanWindowsUpdate.Location = new System.Drawing.Point(40, 186);
            // checkBox_CleanGoogle (Y=216)
            checkBox_CleanGoogle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_CleanGoogle.Location = new System.Drawing.Point(40, 216);
            // checkBox_BackupRegistrysRun (Y=246)
            checkBox_BackupRegistrysRun.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_BackupRegistrysRun.Location = new System.Drawing.Point(40, 246);
            // checkBox_CleanPageFile (Y=276)
            checkBox_CleanPageFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_CleanPageFile.Location = new System.Drawing.Point(40, 276);
            // checkBox_DriversBackup (Y=306)
            checkBox_DriversBackup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_DriversBackup.Location = new System.Drawing.Point(40, 306);
            // checkBox_DeleteRegistry (Y=336)
            checkBox_DeleteRegistry.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_DeleteRegistry.Location = new System.Drawing.Point(40, 336);
            // checkBox_Usuario (Y=366)
            checkBox_Usuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_Usuario.Location = new System.Drawing.Point(40, 366);
            // checkBox_CleanPrefetch (Y=396)
            checkBox_CleanPrefetch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_CleanPrefetch.Location = new System.Drawing.Point(40, 396);
            // checkBox_BackupBCD (Y=426)
            checkBox_BackupBCD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_BackupBCD.Location = new System.Drawing.Point(40, 426);
            // checkBox_RestorePoint (Y=456)
            checkBox_RestorePoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_RestorePoint.Location = new System.Drawing.Point(40, 456);
            // checkBox_ConnectionRDP (Y=486)
            checkBox_ConnectionRDP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_ConnectionRDP.Location = new System.Drawing.Point(40, 486);
            // checkBox_Bloatware (Y=516)
            checkBox_Bloatware.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_Bloatware.Location = new System.Drawing.Point(40, 516);
            // checkBox_BackupReportError (Y=546)
            checkBox_BackupReportError.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_BackupReportError.Location = new System.Drawing.Point(40, 546);
            // checkBox_CleanReportError (Y=576)
            checkBox_CleanReportError.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_CleanReportError.Location = new System.Drawing.Point(40, 576);
            // checkBox_ExportInventory (Y=606)
            checkBox_ExportInventory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_ExportInventory.Location = new System.Drawing.Point(40, 606);
            // checkBox_ProfileGraphic (Y=636)
            checkBox_ProfileGraphic.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_ProfileGraphic.Location = new System.Drawing.Point(40, 636);
            // checkBox_ProfileEnergy (Y=666)
            checkBox_ProfileEnergy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_ProfileEnergy.Location = new System.Drawing.Point(40, 666);


            // checkBoxAll
            checkBoxAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBoxAll.Location = new System.Drawing.Point(12, 9);




            // -----------------------------------------------------------------------
            // PICTUREBOX ALINHADA EM X=7 E COM ESPAÇAMENTO DE Y=30 (TAMANHO 24x24)
            // -----------------------------------------------------------------------
            // pictureBox_OptimizeBar (Y=5)
            pictureBox_OptimizeBar.Location = new System.Drawing.Point(7, 5);
            pictureBox_OptimizeBar.Size = new System.Drawing.Size(24, 24);
            // pictureBox_UserUAC (Y=36)
            pictureBox_UserUAC.Location = new System.Drawing.Point(7, 36);
            pictureBox_UserUAC.Size = new System.Drawing.Size(24, 24);
            // pictureBox_CleanTask (Y=66)
            pictureBox_CleanTask.Location = new System.Drawing.Point(7, 66);
            pictureBox_CleanTask.Size = new System.Drawing.Size(24, 24);
            // pictureBox_CleanTrash (Y=96)
            pictureBox_CleanTrash.Location = new System.Drawing.Point(7, 96);
            pictureBox_CleanTrash.Size = new System.Drawing.Size(24, 24);
            // pictureBox_CleanProcess (Y=126)
            pictureBox_CleanProcess.Location = new System.Drawing.Point(7, 126);
            pictureBox_CleanProcess.Size = new System.Drawing.Size(24, 24);
            // pictureBox_CleanTemp (Y=156)
            pictureBox_CleanTemp.Location = new System.Drawing.Point(7, 156);
            pictureBox_CleanTemp.Size = new System.Drawing.Size(24, 24);
            // pictureBox_CleanWindowsUpdate (Y=186)
            pictureBox_CleanWindowsUpdate.Location = new System.Drawing.Point(7, 186);
            pictureBox_CleanWindowsUpdate.Size = new System.Drawing.Size(24, 24);
            // pictureBox_CleanGoogle (Y=216)
            pictureBox_CleanGoogle.Location = new System.Drawing.Point(7, 216);
            pictureBox_CleanGoogle.Size = new System.Drawing.Size(24, 24);
            // pictureBox_BackupRegistrysRun (Y=246)
            pictureBox_BackupRegistrysRun.Location = new System.Drawing.Point(7, 246);
            pictureBox_BackupRegistrysRun.Size = new System.Drawing.Size(24, 24);
            // pictureBox_CleanPageFile (Y=276)
            pictureBox_CleanPageFile.Location = new System.Drawing.Point(7, 276);
            pictureBox_CleanPageFile.Size = new System.Drawing.Size(24, 24);
            // pictureBox_DriversBackup (Y=306)
            pictureBox_DriversBackup.Location = new System.Drawing.Point(7, 306);
            pictureBox_DriversBackup.Size = new System.Drawing.Size(24, 24);
            // pictureBox_DeleteRegistry (Y=336)
            pictureBox_DeleteRegistry.Location = new System.Drawing.Point(7, 336);
            pictureBox_DeleteRegistry.Size = new System.Drawing.Size(24, 24);
            // pictureBox_Usuario (Y=366)
            pictureBox_Usuario.Location = new System.Drawing.Point(7, 366);
            pictureBox_Usuario.Size = new System.Drawing.Size(24, 24);
            // pictureBox_CleanPrefetch (Y=396)
            pictureBox_CleanPrefetch.Location = new System.Drawing.Point(7, 396);
            pictureBox_CleanPrefetch.Size = new System.Drawing.Size(24, 24);
            // pictureBox_BackupBCD (Y=426)
            pictureBox_BackupBCD.Location = new System.Drawing.Point(7, 426);
            pictureBox_BackupBCD.Size = new System.Drawing.Size(24, 24);
            // pictureBox_RestorePoint (Y=456)
            pictureBox_RestorePoint.Location = new System.Drawing.Point(7, 456);
            pictureBox_RestorePoint.Size = new System.Drawing.Size(24, 24);
            // pictureBox_ConnectionRDP (Y=486)
            pictureBox_ConnectionRDP.Location = new System.Drawing.Point(7, 486);
            pictureBox_ConnectionRDP.Size = new System.Drawing.Size(24, 24);
            // pictureBox_Bloatware (Y=516)
            pictureBox_Bloatware.Location = new System.Drawing.Point(7, 516);
            pictureBox_Bloatware.Size = new System.Drawing.Size(24, 24);
            // pictureBox_BackupReportError (Y=546)
            pictureBox_BackupReportError.Location = new System.Drawing.Point(7, 546);
            pictureBox_BackupReportError.Size = new System.Drawing.Size(24, 24);
            // pictureBox_CleanReportError (Y=576)
            pictureBox_CleanReportError.Location = new System.Drawing.Point(7, 576);
            pictureBox_CleanReportError.Size = new System.Drawing.Size(24, 24);
            // pictureBox_ExportInventory (Y=606)
            pictureBox_ExportInventory.Location = new System.Drawing.Point(7, 606);
            pictureBox_ExportInventory.Size = new System.Drawing.Size(24, 24);
            // pictureBox_ProfileGraphic (Y=636)
            pictureBox_ProfileGraphic.Location = new System.Drawing.Point(7, 636);
            pictureBox_ProfileGraphic.Size = new System.Drawing.Size(24, 24);
            // pictureBox_ProfileEnergy (Y=666)
            pictureBox_ProfileEnergy.Location = new System.Drawing.Point(7, 666);
            pictureBox_ProfileEnergy.Size = new System.Drawing.Size(24, 24);

            // -----------------------------------------------------------------------
            // PICTURE BOX FORA DA SEQUÊNCIA (X e Tamanho diferentes)
            // -----------------------------------------------------------------------
            // panel_OptimizeBar
            panel_OptimizeBar.Location = new System.Drawing.Point(996, 428);
            panel_OptimizeBar.Size = new System.Drawing.Size(147, 27);
            // panel_UserUAC
            panel_UserUAC.Location = new System.Drawing.Point(996, 295);
            panel_UserUAC.Size = new System.Drawing.Size(147, 27);
            // panel_CleanTemp
            panel_CleanTemp.Location = new System.Drawing.Point(996, 328);
            panel_CleanTemp.Size = new System.Drawing.Size(147, 27);
            // panel_BackupRegistrysRun
            panel_BackupRegistrysRun.Location = new System.Drawing.Point(996, 362); ;
            panel_BackupRegistrysRun.Size = new System.Drawing.Size(147, 27);
            // panel_CleanPageFile
            panel_CleanPageFile.Location = new System.Drawing.Point(996, 265);
            panel_CleanPageFile.Size = new System.Drawing.Size(147, 24);
            // panel_DeleteRegistry
            panel_DeleteRegistry.Location = new System.Drawing.Point(996, 395);
            panel_DeleteRegistry.Size = new System.Drawing.Size(147, 27);
            // panel_ConnectionRDP
            panel_ConnectionRDP.Location = new System.Drawing.Point(996, 235);
            panel_ConnectionRDP.Size = new System.Drawing.Size(147, 24);
            // panel_ProfileGraphic
            panel_ProfileGraphic.Location = new System.Drawing.Point(996, 461);
            panel_ProfileGraphic.Size = new System.Drawing.Size(189, 24);
            // panel_ProfileEnergy
            panel_ProfileEnergy.Location = new System.Drawing.Point(996, 494);
            panel_ProfileEnergy.Size = new System.Drawing.Size(158, 69);  

            // pictureBoxInfoDescricao (Y=590)
            pictureBoxInfoDescricao.Location = new System.Drawing.Point(306, 590);
            pictureBoxInfoDescricao.Size = new System.Drawing.Size(38, 35);


            // -----------------------------------------------------------------------
            // PANEL
            // -----------------------------------------------------------------------
            // panel1
            panel1.Location = new System.Drawing.Point(0, 60);
            panel1.Size = new System.Drawing.Size(296, 563);
            // panelLog
            panelLog.Location = new System.Drawing.Point(308, 87);
            panelLog.Size = new System.Drawing.Size(653, 498);
            // panelDivisoria
            panelDivisoria.Location = new System.Drawing.Point(301, 55);
            panelDivisoria.Size = new System.Drawing.Size(1, 570);
            // panelBoton
            panelBoton.Location = new System.Drawing.Point(0, 648);
            panelBoton.Size = new System.Drawing.Size(966, 37);





            // -----------------------------------------------------------------------
            // BOTTON
            // -----------------------------------------------------------------------
            // Btn_Canselar;
            Btn_Canselar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Btn_Canselar.Location = new System.Drawing.Point(672, 2);
            Btn_Canselar.Size = new System.Drawing.Size(138, 31);
            // btn_IniciarProcesso
            btn_IniciarProcesso.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btn_IniciarProcesso.Location = new System.Drawing.Point(816, 2);
            btn_IniciarProcesso.Size = new System.Drawing.Size(138, 31);

            // -----------------------------------------------------------------------
            // LABEL
            // -----------------------------------------------------------------------
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


            // -----------------------------------------------------------------------
            // RADIOBUTTON
            // -----------------------------------------------------------------------
            // radioButtonUserUAC_Desativar
            radioButtonUserUAC_Desativar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radioButtonUserUAC_Desativar.Location = new System.Drawing.Point(62, 3);
            // radioButtonUserUAC_Ativar
            radioButtonUserUAC_Ativar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radioButtonUserUAC_Ativar.Location = new System.Drawing.Point(3, 3); 
            // radioButtonCleanPageFile_Ativar
            radioButtonCleanPageFile_Ativar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radioButtonCleanPageFile_Ativar.Location = new System.Drawing.Point(3, 5);
            // radioButtonCleanPageFile_Desativar
            radioButtonCleanPageFile_Desativar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radioButtonCleanPageFile_Desativar.Location = new System.Drawing.Point(62, 5);
            // radioButtonradioButtonConnectionRDP_Ativar
            radioButtonConnectionRDP_Ativar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radioButtonConnectionRDP_Ativar.Location = new System.Drawing.Point(3, 4);
            // radioButtonConnectionRDP_Desativar
            radioButtonConnectionRDP_Desativar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radioButtonConnectionRDP_Desativar.Location = new System.Drawing.Point(62, 4);
            // radioButtonOptimizeBar_Atual
            radioButtonOptimizeBar_Atual.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radioButtonOptimizeBar_Atual.Location = new System.Drawing.Point(3, 3);
            // radioButtonOptimizeBar_Todos
            radioButtonOptimizeBar_Todos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radioButtonOptimizeBar_Todos.Location = new System.Drawing.Point(62, 3);
            // radioButtonDeleteRegistry_Atual
            radioButtonDeleteRegistry_Atual.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radioButtonDeleteRegistry_Atual.Location = new System.Drawing.Point(3, 3);
            // radioButtonDeleteRegistry_todos
            radioButtonDeleteRegistry_todos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radioButtonDeleteRegistry_todos.Location = new System.Drawing.Point(62, 3);
            // radioButtonCleanTemp_Atual
            radioButtonCleanTemp_Atual.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radioButtonCleanTemp_Atual.Location = new System.Drawing.Point(3, 3);
            // radioButtonCleanTemp_Todos
            radioButtonCleanTemp_Todos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radioButtonCleanTemp_Todos.Location = new System.Drawing.Point(62, 3);
            // radioButtonBackupRegistrysRun_Atual
            radioButtonBackupRegistrysRun_Atual.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radioButtonBackupRegistrysRun_Atual.Location = new System.Drawing.Point(3, 3);
            // radioButtonBackupRegistrysRun_Todos
            radioButtonBackupRegistrysRun_Todos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radioButtonBackupRegistrysRun_Todos.Location = new System.Drawing.Point(62, 3);
            // radioButtonProfileGraphic_Performace
            radioButtonProfileGraphic_Performace.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radioButtonProfileGraphic_Performace.Location = new System.Drawing.Point(3, 3);
            // radioButtonProfileGraphic_Appearance
            radioButtonProfileGraphic_Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radioButtonProfileGraphic_Appearance.Location = new System.Drawing.Point(107, 3);
            // radioButtonProfileEnergy_Desenpenho
            radioButtonProfileEnergy_Desenpenho.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radioButtonProfileEnergy_Desenpenho.Location = new System.Drawing.Point(3, 3);
            // radioButtonProfileEnergy_Equilibrado
            radioButtonProfileEnergy_Equilibrado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radioButtonProfileEnergy_Equilibrado.Location = new System.Drawing.Point(3,24);
            // radioButtonProfileEnergy_Economia
            radioButtonProfileEnergy_Economia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radioButtonProfileEnergy_Economia.Location = new System.Drawing.Point(3,45);


        }

        public void ScreenResolution1024x801()
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
            Btn_Canselar.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Btn_Canselar.Location = new System.Drawing.Point(660, 8);
            Btn_Canselar.Size = new System.Drawing.Size(100, 25);

            // btn_IniciarProcesso
            btn_IniciarProcesso.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btn_IniciarProcesso.Location = new System.Drawing.Point(760, 8);
            btn_IniciarProcesso.Size = new System.Drawing.Size(100, 25);

            // checkBox_DriversBackup
            checkBox_DriversBackup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_DriversBackup.Location = new System.Drawing.Point(40, 255);
            checkBox_DriversBackup.Size = new System.Drawing.Size(105, 19);

            // panelBoton
            panelBoton.Location = new System.Drawing.Point(0, 466);
            panelBoton.Size = new System.Drawing.Size(870, 32);

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

        public void ScreenResolution1024x800()
        {

            // MainForm
            //
            Formulario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Formulario.Size = new System.Drawing.Size(886, 537);

            // txt_Log
            txt_Log.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txt_Log.Location = new System.Drawing.Point(1, 1);
            txt_Log.Size = new System.Drawing.Size(559, 365);

            // progressBar1
            progressBar1.Location = new System.Drawing.Point(309, 32);
            progressBar1.Size = new System.Drawing.Size(488, 11);

            // -----------------------------------------------------------------------
            // CHECKBOX ALINHADA EM X=40 E COM ESPAÇAMENTO DE Y=25 (Aproximadamente)
            // -----------------------------------------------------------------------
            // checkBox_OptimizeBar (Y=5)
            checkBox_OptimizeBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_OptimizeBar.Location = new System.Drawing.Point(40, 5);
            // checkBox_UserUAC (Y=30)
            checkBox_UserUAC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_UserUAC.Location = new System.Drawing.Point(40, 30);
            // checkBox_CleanTask (Y=55)
            checkBox_CleanTask.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_CleanTask.Location = new System.Drawing.Point(40, 55);
            // checkBox_CleanTrash (Y=80)
            checkBox_CleanTrash.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_CleanTrash.Location = new System.Drawing.Point(40, 80);
            // checkBox_CleanProcess (Y=105)
            checkBox_CleanProcess.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_CleanProcess.Location = new System.Drawing.Point(40, 105);
            // checkBox_CleanTemp (Y=130)
            checkBox_CleanTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_CleanTemp.Location = new System.Drawing.Point(40, 130);
            // checkBox_CleanWindowsUpdate (Y=155)
            checkBox_CleanWindowsUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_CleanWindowsUpdate.Location = new System.Drawing.Point(40, 155);
            // checkBox_CleanGoogle (Y=180)
            checkBox_CleanGoogle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_CleanGoogle.Location = new System.Drawing.Point(40, 180);
            // checkBox_BackupRegistrysRun (Y=205)
            checkBox_BackupRegistrysRun.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_BackupRegistrysRun.Location = new System.Drawing.Point(40, 205);
            // checkBox_CleanPageFile (Y=230)
            checkBox_CleanPageFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_CleanPageFile.Location = new System.Drawing.Point(40, 230);
            // checkBox_DriversBackup (Y=255)
            checkBox_DriversBackup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_DriversBackup.Location = new System.Drawing.Point(40, 255);
            // checkBox_DeleteRegistry (Y=280)
            checkBox_DeleteRegistry.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_DeleteRegistry.Location = new System.Drawing.Point(40, 280);
            // checkBox_Usuario (Y=303)
            checkBox_Usuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_Usuario.Location = new System.Drawing.Point(40, 303);
            // checkBox_CleanPrefetch (Y=328)
            checkBox_CleanPrefetch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_CleanPrefetch.Location = new System.Drawing.Point(40, 328);
            // checkBox_BackupBCD (Y=353)
            checkBox_BackupBCD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_BackupBCD.Location = new System.Drawing.Point(40, 353);
            // checkBox_RestorePoint (Y=378)
            checkBox_RestorePoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_RestorePoint.Location = new System.Drawing.Point(40, 378);
            // checkBox_ConnectionRDP (Y=403)
            checkBox_ConnectionRDP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_ConnectionRDP.Location = new System.Drawing.Point(40, 403);
            // checkBox_Bloatware (Y=428)
            checkBox_Bloatware.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_Bloatware.Location = new System.Drawing.Point(40, 428);
            // checkBox_BackupReportError (Y=453)
            checkBox_BackupReportError.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_BackupReportError.Location = new System.Drawing.Point(40, 453);
            // checkBox_CleanReportError (Y=478)
            checkBox_CleanReportError.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_CleanReportError.Location = new System.Drawing.Point(40, 478);
            // checkBox_ExportInventory (Y=503)
            checkBox_ExportInventory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_ExportInventory.Location = new System.Drawing.Point(40, 503);
            // checkBox_ProfileGraphic (Y=528)
            checkBox_ProfileGraphic.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_ProfileGraphic.Location = new System.Drawing.Point(40, 528);
            // checkBox_ProfileEnergy (Y=553)
            checkBox_ProfileEnergy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBox_ProfileEnergy.Location = new System.Drawing.Point(40, 553);

            // checkBoxAll
            checkBoxAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            checkBoxAll.Location = new System.Drawing.Point(12, 9);
            checkBoxAll.Size = new System.Drawing.Size(65, 19); // Mantido por ser um item de destaque.

            // -----------------------------------------------------------------------
            // PICTUREBOX ALINHADA EM X=7 E COM ESPAÇAMENTO DE Y=25 (TAMANHO 20x18)
            // -----------------------------------------------------------------------
            // As PictureBoxes estão alinhadas com as CheckBoxes
            // pictureBox_OptimizeBar (Y=5)
            pictureBox_OptimizeBar.Location = new System.Drawing.Point(7, 5);
            pictureBox_OptimizeBar.Size = new System.Drawing.Size(20, 18);
            // pictureBox_UserUAC (Y=31 - Diferença de 1px em relação ao CheckBox)
            pictureBox_UserUAC.Location = new System.Drawing.Point(7, 31);
            pictureBox_UserUAC.Size = new System.Drawing.Size(20, 18);
            // pictureBox_CleanTask (Y=55)
            pictureBox_CleanTask.Location = new System.Drawing.Point(7, 55);
            pictureBox_CleanTask.Size = new System.Drawing.Size(20, 18);
            // pictureBox_CleanTrash (Y=80)
            pictureBox_CleanTrash.Location = new System.Drawing.Point(7, 80);
            pictureBox_CleanTrash.Size = new System.Drawing.Size(20, 18);
            // pictureBox_CleanProcess (Y=105)
            pictureBox_CleanProcess.Location = new System.Drawing.Point(7, 105);
            pictureBox_CleanProcess.Size = new System.Drawing.Size(20, 18);
            // pictureBox_CleanTemp (Y=130)
            pictureBox_CleanTemp.Location = new System.Drawing.Point(7, 130);
            pictureBox_CleanTemp.Size = new System.Drawing.Size(20, 18);
            // pictureBox_CleanWindowsUpdate (Y=155)
            pictureBox_CleanWindowsUpdate.Location = new System.Drawing.Point(7, 155);
            pictureBox_CleanWindowsUpdate.Size = new System.Drawing.Size(20, 18);
            // pictureBox_CleanGoogle (Y=180)
            pictureBox_CleanGoogle.Location = new System.Drawing.Point(7, 180);
            pictureBox_CleanGoogle.Size = new System.Drawing.Size(20, 18);
            // pictureBox_BackupRegistrysRun (Y=205)
            pictureBox_BackupRegistrysRun.Location = new System.Drawing.Point(7, 205);
            pictureBox_BackupRegistrysRun.Size = new System.Drawing.Size(20, 18);
            // pictureBox_CleanPageFile (Y=230)
            pictureBox_CleanPageFile.Location = new System.Drawing.Point(7, 230);
            pictureBox_CleanPageFile.Size = new System.Drawing.Size(20, 18);
            // pictureBox_DriversBackup (Y=255)
            pictureBox_DriversBackup.Location = new System.Drawing.Point(7, 255);
            pictureBox_DriversBackup.Size = new System.Drawing.Size(20, 18);
            // pictureBox_DeleteRegistry (Y=280)
            pictureBox_DeleteRegistry.Location = new System.Drawing.Point(7, 280);
            pictureBox_DeleteRegistry.Size = new System.Drawing.Size(20, 18);
            // pictureBox_Usuario (Y=303)
            pictureBox_Usuario.Location = new System.Drawing.Point(7, 303);
            pictureBox_Usuario.Size = new System.Drawing.Size(20, 18);
            // pictureBox_CleanPrefetch (Y=328)
            pictureBox_CleanPrefetch.Location = new System.Drawing.Point(7, 328);
            pictureBox_CleanPrefetch.Size = new System.Drawing.Size(20, 18);
            // pictureBox_BackupBCD (Y=353)
            pictureBox_BackupBCD.Location = new System.Drawing.Point(7, 353);
            pictureBox_BackupBCD.Size = new System.Drawing.Size(20, 18);
            // pictureBox_RestorePoint (Y=378)
            pictureBox_RestorePoint.Location = new System.Drawing.Point(7, 378);
            pictureBox_RestorePoint.Size = new System.Drawing.Size(20, 18);
            // pictureBox_ConnectionRDP (Y=403)
            pictureBox_ConnectionRDP.Location = new System.Drawing.Point(7, 403);
            pictureBox_ConnectionRDP.Size = new System.Drawing.Size(20, 18);
            // pictureBox_Bloatware (Y=428)
            pictureBox_Bloatware.Location = new System.Drawing.Point(7, 428);
            pictureBox_Bloatware.Size = new System.Drawing.Size(20, 18);
            // pictureBox_BackupReportError (Y=453)
            pictureBox_BackupReportError.Location = new System.Drawing.Point(7, 453);
            pictureBox_BackupReportError.Size = new System.Drawing.Size(20, 18);
            // pictureBox_CleanReportError (Y=478)
            pictureBox_CleanReportError.Location = new System.Drawing.Point(7, 478);
            pictureBox_CleanReportError.Size = new System.Drawing.Size(20, 18);
            // pictureBox_ExportInventory (Y=503)
            pictureBox_ExportInventory.Location = new System.Drawing.Point(7, 503);
            pictureBox_ExportInventory.Size = new System.Drawing.Size(20, 18);
            // pictureBox_ProfileGraphic (Y=528)
            pictureBox_ProfileGraphic.Location = new System.Drawing.Point(7, 528);
            pictureBox_ProfileGraphic.Size = new System.Drawing.Size(20, 18);
            // pictureBox_ProfileEnergy (Y=553)
            pictureBox_ProfileEnergy.Location = new System.Drawing.Point(7, 553);
            pictureBox_ProfileEnergy.Size = new System.Drawing.Size(20, 18);


            // pictureBoxInfoDescricao (Y=420)
            pictureBoxInfoDescricao.Location = new System.Drawing.Point(307, 420);
            pictureBoxInfoDescricao.Size = new System.Drawing.Size(38, 35);


            // -----------------------------------------------------------------------
            // PANEL - CONTROLES DE OPÇÃO (RadioButton Panels)
            // -----------------------------------------------------------------------
            // panel_OptimizeBar
            panel_OptimizeBar.Location = new System.Drawing.Point(884, 238);
            panel_OptimizeBar.Size = new System.Drawing.Size(147, 17);
            // panel_ConnectionRDP
            panel_ConnectionRDP.Location = new System.Drawing.Point(881, 71);
            panel_ConnectionRDP.Size = new System.Drawing.Size(147, 17);
            // panel_CleanPageFile
            panel_CleanPageFile.Location = new System.Drawing.Point(884, 100);
            panel_CleanPageFile.Size = new System.Drawing.Size(147, 17);
            // panel_UserUAC
            panel_UserUAC.Location = new System.Drawing.Point(884, 125);
            panel_UserUAC.Size = new System.Drawing.Size(147, 17);
            // panel_CleanTemp
            panel_CleanTemp.Location = new System.Drawing.Point(884, 153);
            panel_CleanTemp.Size = new System.Drawing.Size(147, 17);
            // panel_BackupRegistrysRun
            panel_BackupRegistrysRun.Location = new System.Drawing.Point(884, 181);
            panel_BackupRegistrysRun.Size = new System.Drawing.Size(147, 20);
            // panel_DeleteRegistry
            panel_DeleteRegistry.Location = new System.Drawing.Point(884, 215);
            panel_DeleteRegistry.Size = new System.Drawing.Size(147, 20);
            // panel_ProfileGraphic
            panel_ProfileGraphic.Location = new System.Drawing.Point(884, 300); 
            panel_ProfileGraphic.Size = new System.Drawing.Size(189, 20);
            // panel_ProfileEnergy
            panel_ProfileEnergy.Location = new System.Drawing.Point(884, 345); 
            panel_ProfileEnergy.Size = new System.Drawing.Size(158, 69);


            // -----------------------------------------------------------------------
            // PANEL - PAINÉIS PRINCIPAIS
            // -----------------------------------------------------------------------
            // panel1 (Painel dos CheckBoxes)
            panel1.Location = new System.Drawing.Point(1, 50);
            panel1.Size = new System.Drawing.Size(296, 410);
            panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            panel1.AutoScrollMargin = new System.Drawing.Size(0, 3);
            panel1.AutoScrollMinSize = new System.Drawing.Size(0, 5);
            // panelLog
            panelLog.Location = new System.Drawing.Point(307, 50);
            panelLog.Size = new System.Drawing.Size(561, 367);
            // panelDivisoria
            panelDivisoria.Location = new System.Drawing.Point(301, 55);
            panelDivisoria.Size = new System.Drawing.Size(1, 570);
            // panelBoton
            panelBoton.Location = new System.Drawing.Point(0, 466);
            panelBoton.Size = new System.Drawing.Size(870, 32);

            // -----------------------------------------------------------------------
            // BOTTON
            // -----------------------------------------------------------------------
            // Btn_Canselar
            Btn_Canselar.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Btn_Canselar.Location = new System.Drawing.Point(660, 8);
            Btn_Canselar.Size = new System.Drawing.Size(100, 25);
            // btn_IniciarProcesso
            btn_IniciarProcesso.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btn_IniciarProcesso.Location = new System.Drawing.Point(760, 8);
            btn_IniciarProcesso.Size = new System.Drawing.Size(100, 25);

            // -----------------------------------------------------------------------
            // LABEL
            // -----------------------------------------------------------------------
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
            // Label_NameMachine
            Label_NameMachine.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Label_NameMachine.Location = new System.Drawing.Point(587, 3);
            Label_NameMachine.Size = new System.Drawing.Size(281, 26);

            // -----------------------------------------------------------------------
            // RADIOBUTTON (Removido o .Size desnecessário)
            // -----------------------------------------------------------------------
            // radioButtonOptimizeBar_Atual
            radioButtonOptimizeBar_Atual.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radioButtonOptimizeBar_Atual.Location = new System.Drawing.Point(3, 0);
            // radioButtonUserUAC_Ativar
            radioButtonUserUAC_Ativar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radioButtonUserUAC_Ativar.Location = new System.Drawing.Point(3, 0);
            // radioButtonUserUAC_Desativar
            radioButtonUserUAC_Desativar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radioButtonUserUAC_Desativar.Location = new System.Drawing.Point(62, 0);

            // radioButtonCleanPageFile_Ativar
            radioButtonCleanPageFile_Ativar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radioButtonCleanPageFile_Ativar.Location = new System.Drawing.Point(3, 0);
            // radioButtonCleanPageFile_Desativar
            radioButtonCleanPageFile_Desativar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radioButtonCleanPageFile_Desativar.Location = new System.Drawing.Point(62, 0);

            // radioButtonConnectionRDP_Ativar
            radioButtonConnectionRDP_Ativar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radioButtonConnectionRDP_Ativar.Location = new System.Drawing.Point(3, 0);
            // radioButtonConnectionRDP_Desativar
            radioButtonConnectionRDP_Desativar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radioButtonConnectionRDP_Desativar.Location = new System.Drawing.Point(62, 0);

            // radioButtonCleanTemp_Atual
            radioButtonCleanTemp_Atual.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radioButtonCleanTemp_Atual.Location = new System.Drawing.Point(3, 0);
            // radioButtonCleanTemp_Todos
            radioButtonCleanTemp_Todos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radioButtonCleanTemp_Todos.Location = new System.Drawing.Point(62, 0);

            // radioButtonBackupRegistrysRun_Atual
            radioButtonBackupRegistrysRun_Atual.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radioButtonBackupRegistrysRun_Atual.Location = new System.Drawing.Point(3, 0);
            // radioButtonBackupRegistrysRun_Todos
            radioButtonBackupRegistrysRun_Todos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radioButtonBackupRegistrysRun_Todos.Location = new System.Drawing.Point(62, 0);

            // radioButtonDeleteRegistry_Atual
            radioButtonDeleteRegistry_Atual.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radioButtonDeleteRegistry_Atual.Location = new System.Drawing.Point(3, 0);
            // radioButtonDeleteRegistry_todos
            radioButtonDeleteRegistry_todos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radioButtonDeleteRegistry_todos.Location = new System.Drawing.Point(62, 0);

            // radioButtonProfileGraphic_Performace
            radioButtonProfileGraphic_Performace.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radioButtonProfileGraphic_Performace.Location = new System.Drawing.Point(3, 0);

            // radioButtonProfileGraphic_Appearance
            radioButtonProfileGraphic_Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radioButtonProfileGraphic_Appearance.Location = new System.Drawing.Point(107, 0); //107; 4

            // radioButtonProfileEnergy_Desenpenho
            radioButtonProfileEnergy_Desenpenho.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radioButtonProfileEnergy_Desenpenho.Location = new System.Drawing.Point(3, 0);

            // radioButtonProfileEnergy_Equilibrado
            radioButtonProfileEnergy_Equilibrado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radioButtonProfileEnergy_Equilibrado.Location = new System.Drawing.Point(3, 20);

            // radioButtonProfileEnergy_Economia
            radioButtonProfileEnergy_Economia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radioButtonProfileEnergy_Economia.Location = new System.Drawing.Point(3, 40);
            // radioButtonOptimizeBar_Todos
            radioButtonOptimizeBar_Todos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radioButtonOptimizeBar_Todos.Location = new System.Drawing.Point(62, 0);
        }


        #endregion
    }
}
