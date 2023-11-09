namespace Manejador_de_Equipos
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            groupBox1 = new GroupBox();
            button1 = new Button();
            label1 = new Label();
            label2 = new Label();
            txtCorreo = new TextBox();
            txtClave = new TextBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtCorreo);
            groupBox1.Controls.Add(txtClave);
            groupBox1.ForeColor = Color.Black;
            groupBox1.Location = new Point(67, 47);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(273, 367);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Iniciar sesión";
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ButtonHighlight;
            button1.BackgroundImageLayout = ImageLayout.Center;
            button1.Cursor = Cursors.Hand;
            button1.ForeColor = SystemColors.Highlight;
            button1.Location = new Point(71, 311);
            button1.Name = "button1";
            button1.Size = new Size(119, 38);
            button1.TabIndex = 4;
            button1.Text = "Aceptar";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.Highlight;
            label1.Location = new Point(42, 78);
            label1.Name = "label1";
            label1.Size = new Size(169, 25);
            label1.TabIndex = 1;
            label1.Text = "Correo eléctronico";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.Highlight;
            label2.Location = new Point(42, 191);
            label2.Name = "label2";
            label2.Size = new Size(108, 25);
            label2.TabIndex = 3;
            label2.Text = "Contraseña";
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(22, 129);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.PlaceholderText = "Usuario";
            txtCorreo.Size = new Size(217, 27);
            txtCorreo.TabIndex = 0;
            // 
            // txtClave
            // 
            txtClave.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            txtClave.BackColor = SystemColors.HighlightText;
            txtClave.Location = new Point(22, 246);
            txtClave.Name = "txtClave";
            txtClave.PasswordChar = '*';
            txtClave.PlaceholderText = "***************";
            txtClave.Size = new Size(217, 27);
            txtClave.TabIndex = 2;
            txtClave.KeyPress += txtClave_KeyPress;
            // 
            // frmLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(395, 450);
            Controls.Add(groupBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Formulario de ingreso";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button button1;
        private Label label1;
        private Label label2;
        private TextBox txtUsuario;
        private TextBox textBox1;
        private TextBox txtCorreo;
        private TextBox txtClave;
    }
}