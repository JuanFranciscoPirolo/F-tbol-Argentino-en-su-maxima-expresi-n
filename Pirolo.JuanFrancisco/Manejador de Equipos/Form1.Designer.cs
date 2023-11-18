namespace Manejador_de_Equipos
{
    partial class frmEquipos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEquipos));
            pictureBox1 = new PictureBox();
            btnEliminar = new Button();
            btnOrdenar = new Button();
            btnAgregar = new Button();
            lstEquipos = new ListBox();
            lblInformacion = new Label();
            label1 = new Label();
            btnInformacion = new Button();
            rdAscendente = new RadioButton();
            rdDescendente = new RadioButton();
            btnDeseleccionar = new Button();
            button1 = new Button();
            button2 = new Button();
            lblHoraActual = new Label();
            pictureBoxDescanso = new PictureBox();
            button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxDescanso).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.LightGray;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1197, 708);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.LightGray;
            btnEliminar.ForeColor = SystemColors.HotTrack;
            btnEliminar.ImageKey = "(ninguna)";
            btnEliminar.Location = new Point(1010, 566);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(124, 51);
            btnEliminar.TabIndex = 12;
            btnEliminar.Text = "Eliminar equipo";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnOrdenar
            // 
            btnOrdenar.BackColor = Color.LightGray;
            btnOrdenar.FlatStyle = FlatStyle.Flat;
            btnOrdenar.ForeColor = SystemColors.HotTrack;
            btnOrdenar.ImageKey = "(ninguna)";
            btnOrdenar.Location = new Point(902, 335);
            btnOrdenar.Name = "btnOrdenar";
            btnOrdenar.Size = new Size(193, 53);
            btnOrdenar.TabIndex = 11;
            btnOrdenar.Text = "Ordenar por puntos";
            btnOrdenar.UseVisualStyleBackColor = false;
            btnOrdenar.Click += btnOrdenar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.LightGray;
            btnAgregar.ForeColor = SystemColors.HotTrack;
            btnAgregar.ImageKey = "(ninguna)";
            btnAgregar.Location = new Point(823, 566);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(163, 51);
            btnAgregar.TabIndex = 10;
            btnAgregar.Text = "Agregar equipo  o Modificar";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click_1;
            // 
            // lstEquipos
            // 
            lstEquipos.BackColor = Color.Black;
            lstEquipos.ForeColor = SystemColors.Menu;
            lstEquipos.FormattingEnabled = true;
            lstEquipos.ItemHeight = 20;
            lstEquipos.Location = new Point(12, 61);
            lstEquipos.Name = "lstEquipos";
            lstEquipos.Size = new Size(784, 604);
            lstEquipos.TabIndex = 7;
            // 
            // lblInformacion
            // 
            lblInformacion.AutoSize = true;
            lblInformacion.BackColor = SystemColors.ButtonHighlight;
            lblInformacion.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            lblInformacion.ForeColor = SystemColors.HotTrack;
            lblInformacion.Location = new Point(1010, 672);
            lblInformacion.Name = "lblInformacion";
            lblInformacion.Size = new Size(55, 23);
            lblInformacion.TabIndex = 13;
            lblInformacion.Text = "label1";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.MintCream;
            label1.Font = new Font("Microsoft Sans Serif", 12.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ActiveCaptionText;
            label1.Location = new Point(81, 19);
            label1.Name = "label1";
            label1.Size = new Size(621, 25);
            label1.TabIndex = 14;
            label1.Text = "TABLA DE PUNTUACION Y DATOS DEL FUTBOL ARGENTINO";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // btnInformacion
            // 
            btnInformacion.BackColor = Color.Black;
            btnInformacion.FlatStyle = FlatStyle.Flat;
            btnInformacion.ForeColor = SystemColors.ControlLightLight;
            btnInformacion.ImageKey = "(ninguna)";
            btnInformacion.Location = new Point(857, 61);
            btnInformacion.Name = "btnInformacion";
            btnInformacion.Size = new Size(293, 74);
            btnInformacion.TabIndex = 15;
            btnInformacion.Text = "Informacion de los tres grandes";
            btnInformacion.UseVisualStyleBackColor = false;
            btnInformacion.Click += btnInformacion_Click;
            // 
            // rdAscendente
            // 
            rdAscendente.AutoSize = true;
            rdAscendente.BackColor = Color.LightGray;
            rdAscendente.ForeColor = SystemColors.Highlight;
            rdAscendente.Location = new Point(922, 282);
            rdAscendente.Name = "rdAscendente";
            rdAscendente.Size = new Size(149, 24);
            rdAscendente.TabIndex = 17;
            rdAscendente.TabStop = true;
            rdAscendente.Text = "Ascendentemente";
            rdAscendente.UseVisualStyleBackColor = false;
            // 
            // rdDescendente
            // 
            rdDescendente.AutoSize = true;
            rdDescendente.BackColor = Color.LightGray;
            rdDescendente.ForeColor = SystemColors.Highlight;
            rdDescendente.Location = new Point(922, 236);
            rdDescendente.Name = "rdDescendente";
            rdDescendente.Size = new Size(158, 24);
            rdDescendente.TabIndex = 18;
            rdDescendente.TabStop = true;
            rdDescendente.Text = "Descendentemente";
            rdDescendente.UseVisualStyleBackColor = false;
            // 
            // btnDeseleccionar
            // 
            btnDeseleccionar.BackColor = Color.Red;
            btnDeseleccionar.ForeColor = SystemColors.Control;
            btnDeseleccionar.ImageKey = "(ninguna)";
            btnDeseleccionar.Location = new Point(635, 666);
            btnDeseleccionar.Name = "btnDeseleccionar";
            btnDeseleccionar.Size = new Size(161, 37);
            btnDeseleccionar.TabIndex = 19;
            btnDeseleccionar.Text = "Deseleccionar opcion";
            btnDeseleccionar.UseVisualStyleBackColor = false;
            btnDeseleccionar.Click += btnDeseleccionar_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.LightGray;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = SystemColors.HotTrack;
            button1.ImageKey = "(ninguna)";
            button1.Location = new Point(902, 165);
            button1.Name = "button1";
            button1.Size = new Size(193, 53);
            button1.TabIndex = 20;
            button1.Text = "Ordenar por hinchas";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.Red;
            button2.ForeColor = SystemColors.Control;
            button2.ImageKey = "(ninguna)";
            button2.Location = new Point(12, 666);
            button2.Name = "button2";
            button2.Size = new Size(193, 37);
            button2.TabIndex = 21;
            button2.Text = "Informacion de usuarios";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // lblHoraActual
            // 
            lblHoraActual.AutoSize = true;
            lblHoraActual.BackColor = SystemColors.ButtonHighlight;
            lblHoraActual.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            lblHoraActual.ForeColor = SystemColors.HotTrack;
            lblHoraActual.Location = new Point(1064, 9);
            lblHoraActual.Name = "lblHoraActual";
            lblHoraActual.Size = new Size(55, 23);
            lblHoraActual.TabIndex = 22;
            lblHoraActual.Text = "label1";
            // 
            // pictureBoxDescanso
            // 
            pictureBoxDescanso.BackColor = Color.LightGray;
            pictureBoxDescanso.Image = (Image)resources.GetObject("pictureBoxDescanso.Image");
            pictureBoxDescanso.Location = new Point(0, 1);
            pictureBoxDescanso.Name = "pictureBoxDescanso";
            pictureBoxDescanso.Size = new Size(1197, 747);
            pictureBoxDescanso.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxDescanso.TabIndex = 23;
            pictureBoxDescanso.TabStop = false;
            // 
            // button3
            // 
            button3.BackColor = Color.Firebrick;
            button3.ForeColor = SystemColors.Control;
            button3.ImageKey = "(ninguna)";
            button3.Location = new Point(337, 666);
            button3.Name = "button3";
            button3.Size = new Size(161, 37);
            button3.TabIndex = 24;
            button3.Text = "Me voy al descanso...";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // frmEquipos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Highlight;
            ClientSize = new Size(1186, 704);
            Controls.Add(button3);
            Controls.Add(pictureBoxDescanso);
            Controls.Add(lblHoraActual);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(btnDeseleccionar);
            Controls.Add(rdDescendente);
            Controls.Add(rdAscendente);
            Controls.Add(btnInformacion);
            Controls.Add(label1);
            Controls.Add(lblInformacion);
            Controls.Add(btnEliminar);
            Controls.Add(btnOrdenar);
            Controls.Add(btnAgregar);
            Controls.Add(lstEquipos);
            Controls.Add(pictureBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmEquipos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Futbol argentino en su maxima expresión";
            FormClosing += frmEquipos_FormClosing;
            Load += frmEquipos_Load_1;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxDescanso).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnAgregarEquipo;
        private EventHandler frmEquipos_Load;
        private PictureBox pictureBox1;
        private Button btnEliminar;
        private Button btnOrdenar;
        private Button btnAgregar;
        private CheckBox checkAscendente;
        private CheckBox checkDescendente;
        private Label lblInformacion;
        private Label label1;
        private Button btnInformacion;
        public ListBox lstEquipos;
        private RadioButton rdAscendente;
        private RadioButton rdDescendente;
        private Button btnDeseleccionar;
        private Button button1;
        private Button button2;
        private Label lblHoraActual;
        private PictureBox pictureBoxDescanso;
        private Button button3;
    }
}