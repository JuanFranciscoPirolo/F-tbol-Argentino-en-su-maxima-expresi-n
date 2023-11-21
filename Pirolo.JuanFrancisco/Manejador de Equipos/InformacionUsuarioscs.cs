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
                string[] lineas = File.ReadAllLines("usuarios.log");

                // Usa Join para unir las líneas con saltos de línea
                string contenido = string.Join(Environment.NewLine, lineas);

                // Asigna el contenido con saltos de línea al cuadro de texto
                txtLog.Text = contenido;
            }
            else
            {
                txtLog.Text = "El archivo de registro no existe o está vacío.";
            }
        }

    }
}
