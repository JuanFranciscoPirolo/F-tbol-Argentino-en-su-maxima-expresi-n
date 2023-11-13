using FutbolArgentino;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manejador_de_Equipos
{
    public partial class frmLogin : Form
    {
        public bool InicioSesionExitoso { get; private set; }

        public frmLogin()
        {
            InitializeComponent();
            this.MaximizeBox = false;
        }

        /// <summary>
        /// Método para iniciar sesión, verifica las credenciales y muestra el formulario de equipos si la autenticación es exitosa.
        /// </summary>
        private void IniciarSesion()
        {
            string correo = txtCorreo.Text;
            string clave = txtClave.Text;

            Usuario usuario = new Usuario();
            DateTime fechaInicioSesion = DateTime.Now;
            Usuario usuarioAutenticado = usuario.AutenticarUsuario(correo, clave);

            if (usuarioAutenticado != null)
            {
                usuario.nombre = "";
                usuario.RegistrarAcceso(usuarioAutenticado.nombre);
                frmEquipos equipos = new frmEquipos(fechaInicioSesion, usuarioAutenticado.nombre, usuarioAutenticado.perfil);
                this.Hide();
                equipos.Show();
                InicioSesionExitoso = true;
                this.DialogResult = DialogResult.OK;

            }
            else
            {
                MessageBox.Show("Inicio de sesión fallido. Verifica tus credenciales.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Maneja el evento de clic en el botón para iniciar sesión.
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            IniciarSesion();
        }

        /// <summary>
        /// Maneja el evento de presionar una tecla en el campo de contraseña.
        /// Realiza la acción de inicio de sesión si se presiona la tecla "Enter".
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void txtClave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                IniciarSesion();
                e.Handled = true;
            }
        }
    }
}