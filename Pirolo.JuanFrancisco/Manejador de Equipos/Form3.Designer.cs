namespace Manejador_de_Equipos
{
    partial class frmAgregarEquipo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAgregarEquipo));
            pictureBox1 = new PictureBox();
            btnAceptarActualizar = new Button();
            txtPuntosClub = new TextBox();
            label1 = new Label();
            txtApodoClub = new TextBox();
            label2 = new Label();
            label3 = new Label();
            txtNombreClub = new TextBox();
            label4 = new Label();
            txtHinchas = new TextBox();
            LBL = new Label();
            txtPeorPartido = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.cancha;
            pictureBox1.Location = new Point(-76, -95);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(594, 438);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // btnAceptarActualizar
            // 
            btnAceptarActualizar.BackColor = SystemColors.ActiveCaption;
            btnAceptarActualizar.FlatStyle = FlatStyle.Popup;
            btnAceptarActualizar.Font = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnAceptarActualizar.ForeColor = SystemColors.InfoText;
            btnAceptarActualizar.Location = new Point(161, 239);
            btnAceptarActualizar.Name = "btnAceptarActualizar";
            btnAceptarActualizar.Size = new Size(153, 48);
            btnAceptarActualizar.TabIndex = 1;
            btnAceptarActualizar.Text = "Aceptar";
            btnAceptarActualizar.UseVisualStyleBackColor = false;
            btnAceptarActualizar.Click += btnAceptarActualizar_Click;
            // 
            // txtPuntosClub
            // 
            txtPuntosClub.BackColor = SystemColors.ScrollBar;
            txtPuntosClub.Location = new Point(30, 160);
            txtPuntosClub.Name = "txtPuntosClub";
            txtPuntosClub.Size = new Size(129, 27);
            txtPuntosClub.TabIndex = 2;
            txtPuntosClub.TextChanged += txtPuntosClub_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Impact", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 113);
            label1.Name = "label1";
            label1.Size = new Size(160, 22);
            label1.TabIndex = 3;
            label1.Text = "CANTIDAD DE PUNTOS";
            // 
            // txtApodoClub
            // 
            txtApodoClub.BackColor = SystemColors.ScrollBar;
            txtApodoClub.Location = new Point(331, 160);
            txtApodoClub.Name = "txtApodoClub";
            txtApodoClub.Size = new Size(125, 27);
            txtApodoClub.TabIndex = 4;
            txtApodoClub.TextChanged += txtApodoClub_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Impact", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(331, 113);
            label2.Name = "label2";
            label2.Size = new Size(125, 22);
            label2.TabIndex = 5;
            label2.Text = "APODO DEL CLUB";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Impact", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(177, 28);
            label3.Name = "label3";
            label3.Size = new Size(137, 22);
            label3.TabIndex = 6;
            label3.Text = "NOMBRE DEL CLUB";
            // 
            // txtNombreClub
            // 
            txtNombreClub.BackColor = SystemColors.ScrollBar;
            txtNombreClub.Location = new Point(161, 67);
            txtNombreClub.Name = "txtNombreClub";
            txtNombreClub.Size = new Size(160, 27);
            txtNombreClub.TabIndex = 7;
            txtNombreClub.TextChanged += txtNombreClub_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Impact", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(399, 28);
            label4.Name = "label4";
            label4.Size = new Size(73, 22);
            label4.TabIndex = 8;
            label4.Text = "HINCHAS";
            // 
            // txtHinchas
            // 
            txtHinchas.BackColor = SystemColors.ScrollBar;
            txtHinchas.Location = new Point(392, 67);
            txtHinchas.Name = "txtHinchas";
            txtHinchas.Size = new Size(92, 27);
            txtHinchas.TabIndex = 9;
            txtHinchas.TextChanged += txtHinchas_TextChanged;
            // 
            // LBL
            // 
            LBL.AutoSize = true;
            LBL.Font = new Font("Impact", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            LBL.Location = new Point(30, 28);
            LBL.Name = "LBL";
            LBL.Size = new Size(110, 22);
            LBL.TabIndex = 10;
            LBL.Text = "PEOR PARTIDO";
            // 
            // txtPeorPartido
            // 
            txtPeorPartido.BackColor = SystemColors.ScrollBar;
            txtPeorPartido.Location = new Point(30, 67);
            txtPeorPartido.Name = "txtPeorPartido";
            txtPeorPartido.Size = new Size(92, 27);
            txtPeorPartido.TabIndex = 11;
            // 
            // frmAgregarEquipo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(496, 310);
            Controls.Add(txtPeorPartido);
            Controls.Add(LBL);
            Controls.Add(txtHinchas);
            Controls.Add(label4);
            Controls.Add(txtNombreClub);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtApodoClub);
            Controls.Add(label1);
            Controls.Add(txtPuntosClub);
            Controls.Add(btnAceptarActualizar);
            Controls.Add(pictureBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmAgregarEquipo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Agregar club";
            FormClosing += frmAgregarEquipo_FormClosing;
            Load += frmAgregarEquipo_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Button btnAceptarActualizar;
        private TextBox txtPuntosClub;
        private Label label1;
        private TextBox txtApodoClub;
        private Label label2;
        private Label label3;
        private TextBox txtNombreClub;
        private Label label4;
        private TextBox txtHinchas;
        private Label LBL;
        private TextBox txtPeorPartido;
    }
}