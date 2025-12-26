namespace WinFormsApp1_APP_DESK_PLC_OPC
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnConectarPLC = new Button();
            btnLeervalor = new Button();
            lbLeertag1 = new Label();
            btnEscribir = new Button();
            txtBox_Escribirtag1 = new TextBox();
            lbBloqAutoHora = new Label();
            lbRunRem = new Label();
            txtBox_BloqAutoHora = new TextBox();
            txtBox_RunRem = new TextBox();
            btnBloqAutoHora = new Button();
            btnRunRem = new Button();
            checkB_RunRem = new CheckBox();
            checkBox_BloqAutHr = new CheckBox();
            dateTimePicker_On = new DateTimePicker();
            lb_HoraOn = new Label();
            label1 = new Label();
            dateTimePicker_Off = new DateTimePicker();
            bt_EnviarHr = new Button();
            lbSerieEquipo = new Label();
            lbModelEquipo = new Label();
            lbVersionTiaP = new Label();
            SuspendLayout();
            // 
            // btnConectarPLC
            // 
            btnConectarPLC.Location = new Point(12, 12);
            btnConectarPLC.Name = "btnConectarPLC";
            btnConectarPLC.Size = new Size(89, 31);
            btnConectarPLC.TabIndex = 0;
            btnConectarPLC.Text = "Conectar";
            btnConectarPLC.UseVisualStyleBackColor = true;
            btnConectarPLC.Click += button1_Click;
            // 
            // btnLeervalor
            // 
            btnLeervalor.Location = new Point(484, 19);
            btnLeervalor.Name = "btnLeervalor";
            btnLeervalor.Size = new Size(89, 31);
            btnLeervalor.TabIndex = 1;
            btnLeervalor.Text = "Leer";
            btnLeervalor.UseVisualStyleBackColor = true;
            btnLeervalor.Click += button2_Click;
            // 
            // lbLeertag1
            // 
            lbLeertag1.AutoSize = true;
            lbLeertag1.Location = new Point(595, 27);
            lbLeertag1.Name = "lbLeertag1";
            lbLeertag1.Size = new Size(22, 15);
            lbLeertag1.TabIndex = 3;
            lbLeertag1.Text = "---";
            // 
            // btnEscribir
            // 
            btnEscribir.Location = new Point(484, 62);
            btnEscribir.Name = "btnEscribir";
            btnEscribir.Size = new Size(89, 27);
            btnEscribir.TabIndex = 4;
            btnEscribir.Text = "Escribir";
            btnEscribir.UseVisualStyleBackColor = true;
            btnEscribir.Click += btnEscribir_Click;
            // 
            // txtBox_Escribirtag1
            // 
            txtBox_Escribirtag1.Location = new Point(585, 67);
            txtBox_Escribirtag1.Name = "txtBox_Escribirtag1";
            txtBox_Escribirtag1.Size = new Size(100, 23);
            txtBox_Escribirtag1.TabIndex = 5;
            // 
            // lbBloqAutoHora
            // 
            lbBloqAutoHora.AutoSize = true;
            lbBloqAutoHora.Location = new Point(15, 133);
            lbBloqAutoHora.Name = "lbBloqAutoHora";
            lbBloqAutoHora.Size = new Size(86, 15);
            lbBloqAutoHora.TabIndex = 6;
            lbBloqAutoHora.Text = "BloqAutoHora:";
            // 
            // lbRunRem
            // 
            lbRunRem.AutoSize = true;
            lbRunRem.Location = new Point(15, 102);
            lbRunRem.Name = "lbRunRem";
            lbRunRem.Size = new Size(55, 15);
            lbRunRem.TabIndex = 7;
            lbRunRem.Text = "RunRem:";
            // 
            // txtBox_BloqAutoHora
            // 
            txtBox_BloqAutoHora.Location = new Point(107, 128);
            txtBox_BloqAutoHora.Name = "txtBox_BloqAutoHora";
            txtBox_BloqAutoHora.Size = new Size(100, 23);
            txtBox_BloqAutoHora.TabIndex = 8;
            // 
            // txtBox_RunRem
            // 
            txtBox_RunRem.Location = new Point(107, 99);
            txtBox_RunRem.Name = "txtBox_RunRem";
            txtBox_RunRem.Size = new Size(100, 23);
            txtBox_RunRem.TabIndex = 9;
            // 
            // btnBloqAutoHora
            // 
            btnBloqAutoHora.Location = new Point(252, 128);
            btnBloqAutoHora.Name = "btnBloqAutoHora";
            btnBloqAutoHora.Size = new Size(100, 23);
            btnBloqAutoHora.TabIndex = 10;
            btnBloqAutoHora.Text = "Enviar";
            btnBloqAutoHora.UseVisualStyleBackColor = true;
            btnBloqAutoHora.Click += btnBloqAutoHora_Click;
            // 
            // btnRunRem
            // 
            btnRunRem.Location = new Point(252, 99);
            btnRunRem.Name = "btnRunRem";
            btnRunRem.Size = new Size(100, 23);
            btnRunRem.TabIndex = 11;
            btnRunRem.Text = "Enviar";
            btnRunRem.UseVisualStyleBackColor = true;
            btnRunRem.Click += btnRunRem_Click;
            // 
            // checkB_RunRem
            // 
            checkB_RunRem.AutoSize = true;
            checkB_RunRem.Location = new Point(218, 103);
            checkB_RunRem.Name = "checkB_RunRem";
            checkB_RunRem.Size = new Size(15, 14);
            checkB_RunRem.TabIndex = 12;
            checkB_RunRem.UseVisualStyleBackColor = true;
            checkB_RunRem.CheckedChanged += checkB_RunRem_CheckedChanged;
            // 
            // checkBox_BloqAutHr
            // 
            checkBox_BloqAutHr.AutoSize = true;
            checkBox_BloqAutHr.Location = new Point(218, 132);
            checkBox_BloqAutHr.Name = "checkBox_BloqAutHr";
            checkBox_BloqAutHr.Size = new Size(15, 14);
            checkBox_BloqAutHr.TabIndex = 13;
            checkBox_BloqAutHr.UseVisualStyleBackColor = true;
            checkBox_BloqAutHr.CheckedChanged += checkBox_BloqAutHr_CheckedChanged;
            // 
            // dateTimePicker_On
            // 
            dateTimePicker_On.Location = new Point(107, 157);
            dateTimePicker_On.Name = "dateTimePicker_On";
            dateTimePicker_On.Size = new Size(126, 23);
            dateTimePicker_On.TabIndex = 14;
            // 
            // lb_HoraOn
            // 
            lb_HoraOn.AutoSize = true;
            lb_HoraOn.Location = new Point(15, 163);
            lb_HoraOn.Name = "lb_HoraOn";
            lb_HoraOn.Size = new Size(55, 15);
            lb_HoraOn.TabIndex = 15;
            lb_HoraOn.Text = "Hora On:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 192);
            label1.Name = "label1";
            label1.Size = new Size(56, 15);
            label1.TabIndex = 16;
            label1.Text = "Hora Off:";
            // 
            // dateTimePicker_Off
            // 
            dateTimePicker_Off.Location = new Point(107, 186);
            dateTimePicker_Off.Name = "dateTimePicker_Off";
            dateTimePicker_Off.Size = new Size(126, 23);
            dateTimePicker_Off.TabIndex = 17;
            // 
            // bt_EnviarHr
            // 
            bt_EnviarHr.Location = new Point(252, 174);
            bt_EnviarHr.Name = "bt_EnviarHr";
            bt_EnviarHr.Size = new Size(100, 23);
            bt_EnviarHr.TabIndex = 18;
            bt_EnviarHr.Text = "Enviar Hora";
            bt_EnviarHr.UseVisualStyleBackColor = true;
            bt_EnviarHr.Click += bt_EnviarHr_Click;
            // 
            // lbSerieEquipo
            // 
            lbSerieEquipo.AutoSize = true;
            lbSerieEquipo.Location = new Point(167, 19);
            lbSerieEquipo.Name = "lbSerieEquipo";
            lbSerieEquipo.Size = new Size(32, 15);
            lbSerieEquipo.TabIndex = 19;
            lbSerieEquipo.Text = "-----";
            // 
            // lbModelEquipo
            // 
            lbModelEquipo.AutoSize = true;
            lbModelEquipo.Location = new Point(264, 19);
            lbModelEquipo.Name = "lbModelEquipo";
            lbModelEquipo.Size = new Size(32, 15);
            lbModelEquipo.TabIndex = 20;
            lbModelEquipo.Text = "-----";
            // 
            // lbVersionTiaP
            // 
            lbVersionTiaP.AutoSize = true;
            lbVersionTiaP.Location = new Point(119, 19);
            lbVersionTiaP.Name = "lbVersionTiaP";
            lbVersionTiaP.Size = new Size(32, 15);
            lbVersionTiaP.TabIndex = 21;
            lbVersionTiaP.Text = "-----";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lbVersionTiaP);
            Controls.Add(lbModelEquipo);
            Controls.Add(lbSerieEquipo);
            Controls.Add(bt_EnviarHr);
            Controls.Add(dateTimePicker_Off);
            Controls.Add(label1);
            Controls.Add(lb_HoraOn);
            Controls.Add(dateTimePicker_On);
            Controls.Add(checkBox_BloqAutHr);
            Controls.Add(checkB_RunRem);
            Controls.Add(btnRunRem);
            Controls.Add(btnBloqAutoHora);
            Controls.Add(txtBox_RunRem);
            Controls.Add(txtBox_BloqAutoHora);
            Controls.Add(lbRunRem);
            Controls.Add(lbBloqAutoHora);
            Controls.Add(txtBox_Escribirtag1);
            Controls.Add(btnEscribir);
            Controls.Add(lbLeertag1);
            Controls.Add(btnLeervalor);
            Controls.Add(btnConectarPLC);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnConectarPLC;
        private Button btnLeervalor;
        private Label lbLeertag1;
        private Button btnEscribir;
        private TextBox txtBox_Escribirtag1;
        private Label lbBloqAutoHora;
        private Label lbRunRem;
        private TextBox txtBox_BloqAutoHora;
        private TextBox txtBox_RunRem;
        private Button btnBloqAutoHora;
        private Button btnRunRem;
        private CheckBox checkB_RunRem;
        private CheckBox checkBox_BloqAutHr;
        private DateTimePicker dateTimePicker_On;
        private Label lb_HoraOn;
        private Label label1;
        private DateTimePicker dateTimePicker_Off;
        private Button bt_EnviarHr;
        private Label lbSerieEquipo;
        private Label lbModelEquipo;
        private Label lbVersionTiaP;
    }
}
