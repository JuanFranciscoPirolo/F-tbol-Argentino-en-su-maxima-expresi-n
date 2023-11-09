namespace Manejador_de_Equipos
{
    partial class InformacionUsuarioscs
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtLog = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // txtLog
            // 
            txtLog.Location = new Point(84, 60);
            txtLog.Multiline = true;
            txtLog.Name = "txtLog";
            txtLog.ReadOnly = true;
            txtLog.Size = new Size(590, 368);
            txtLog.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(243, 21);
            label1.Name = "label1";
            label1.Size = new Size(267, 20);
            label1.TabIndex = 3;
            label1.Text = "Informacion de los usuarios ingresados";
            // 
            // InformacionUsuarioscs
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(768, 450);
            Controls.Add(label1);
            Controls.Add(txtLog);
            Name = "InformacionUsuarioscs";
            Text = "Historial de usuarios.";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtLog;
        private Label label1;
    }
}