using System;
using System.Windows.Forms;

namespace Manejador_de_Equipos
{
    public partial class InformacionUsuarioscs : Form
    {
        /// <summary>
        /// Constructor de la clase InformacionUsuarioscs. Inicializa una nueva instancia del formulario y carga el registro de usuarios.
        /// </summary>
        public InformacionUsuarioscs()
        {
            InitializeComponent();
            CargarRegistro();
        }

        /// <summary>
        /// Carga el contenido del archivo de registro de usuarios en el cuadro de texto.
        /// </summary>
        private void CargarRegistro()
        {
            if (File.Exists("usuarios.log"))
            {
                string contenido = File.ReadAllText("usuarios.log");
                txtLog.Text = contenido;
            }
            else
            {
                txtLog.Text = "El archivo de registro no existe o está vacío.";
            }
        }

    }
}
