using FutbolArgentino;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manejador_de_Equipos
{
    public partial class frmInfoEquipos : Form
    {
        public bool formularioInformacion { get; private set; }
        public frmInfoEquipos()
        {
            InitializeComponent();
            this.MaximizeBox = false;
        }


        /// <summary>
        /// Maneja el evento Load del formulario. Este método se ejecuta cuando el formulario se carga por primera vez. 
        /// En este evento, se realiza la inicialización de los elementos gráficos y se muestra información detallada de equipos de fútbol, como el Club Atlético Boca Juniors, River Plate y Racing Club de Avellaneda.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento, en este caso, el formulario en sí.</param>
        /// <param name="e">Argumentos del evento que pueden contener información adicional sobre el evento.</param>

        private void frmInfoEquipos_Load(object sender, EventArgs e)
        {
            Racing ra = new Racing(80000, 50000, new DateTime(1967, 11, 4), new DateTime(1904, 2, 7), Presidentes.VictorBlanco, 100);
            formularioInformacion = true;
            lblCapacidadRacing.Text = ra.CapacidadCancha.ToString();
            lblHinchasRacing.Text = ra.CantidadHinchas.ToString();

            string fechaMejorPartidoFormateada = ra.MejorPartido.ToString("dd/MM/yyyy");
            string fechaCreacion = ra.FechaCreacion.ToString("dd/MM/yyyy");
            lblFechaCreacion.Text = fechaCreacion;
            lblMejorPartidoRacing.Text = fechaMejorPartidoFormateada;
            lblPresidenteRacing.Text = Presidentes.VictorBlanco.ToString();
            lblApodoRacing.Text = ra.ObtenerApodo().ToString();
            lblPuntosTorneoPasadoRacing.Text = ra.CalcularPuntos(14,8).ToString();
            River ri = new River("Los borrachos del Tablón", 120000, new DateTime(2023, 5, 3), new DateTime(1901, 5, 25), 5584, 100);

            string fechaMejorPartidoRiver = ri.PeorPartido.ToString("dd/MM/yyyy");
            string fechaCreacionRiver = ri.FechaCreacion.ToString("dd/MM/yyyy");
            lblPuntosHistoricos.Text = ri.PuntuacionHistorial.ToString();
            lblMejorPartidoRiver.Text = fechaMejorPartidoRiver;
            lblPuntosTorneoPasadoRiver.Text = ri.CalcularPuntos(14, 5).ToString();
            lblPresidenteRiver.Text = Presidentes.JorgeBrito.ToString();
            lblApodoRiverr.Text = ri.ObtenerApodo();
            lblFechaCreacionRiver.Text = fechaCreacionRiver;


            Boca bo = new Boca("Maradona", "Bianchi", 100, new DateTime(2018, 12, 9), new DateTime(2003, 12, 14));

            //FECHAS:
            string fechaMejorPartidoBoca = bo.MejorPartido.ToString("dd/MM/yyyy");
            string fechaPeorPartidoBoca = bo.PeorPartido.ToString("dd/MM/yyyy");
            string fechaCreacionBoca = new DateTime(1905, 04, 3).ToString("dd/MM/yyyy");
            lblPuntosPasadosBoca.Text = bo.CalcularPuntos(16,4).ToString();
            lblApodoBoca.Text = bo.ObtenerApodo().ToString();
            lblDiasPeorPartidoBoca.Text = bo.ObtenerDias().ToString();
            lblMejorPartidoBoca.Text = fechaMejorPartidoBoca.ToString();
            lblFechaCreacionBoca.Text = fechaCreacionBoca.ToString();
            lblPeorPartidoBoca.Text = fechaPeorPartidoBoca.ToString();
            lblIdoloBocaJugador.Text = bo.IdoloJugador.ToString();
            lblIdoloBocaDt.Text = bo.IdoloTecnico.ToString();


        }

        /// <summary>
        /// Maneja el evento FormClosing del formulario.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void frmInfoEquipos_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro que desea volver al formulario inicial?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                formularioInformacion = false;
            }
        }
    }
}
