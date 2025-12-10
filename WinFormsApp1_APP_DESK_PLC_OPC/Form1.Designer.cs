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
            SuspendLayout();
            // 
            // btnConectarPLC
            // 
            btnConectarPLC.Location = new Point(46, 53);
            btnConectarPLC.Name = "btnConectarPLC";
            btnConectarPLC.Size = new Size(89, 56);
            btnConectarPLC.TabIndex = 0;
            btnConectarPLC.Text = "Conectar";
            btnConectarPLC.UseVisualStyleBackColor = true;
            btnConectarPLC.Click += button1_Click;
            // 
            // btnLeervalor
            // 
            btnLeervalor.Location = new Point(46, 136);
            btnLeervalor.Name = "btnLeervalor";
            btnLeervalor.Size = new Size(89, 55);
            btnLeervalor.TabIndex = 1;
            btnLeervalor.Text = "Leer";
            btnLeervalor.UseVisualStyleBackColor = true;
            btnLeervalor.Click += button2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnLeervalor);
            Controls.Add(btnConectarPLC);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button btnConectarPLC;
        private Button btnLeervalor;
    }
}
