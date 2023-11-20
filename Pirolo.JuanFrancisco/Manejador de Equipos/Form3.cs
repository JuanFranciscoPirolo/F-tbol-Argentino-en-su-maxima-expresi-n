using FutbolArgentino;
using Pirolo.JuanFrancisco;
using Manejador_de_Equipos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Globalization;
using Microsoft.VisualBasic;

namespace Manejador_de_Equipos
{
    
    public partial class frmAgregarEquipo : Form, IAcciones
    {
        private delegate bool ValidarFechaDelegate(string fecha);
        private ValidarFechaDelegate validarFechaDelegate;
        private bool cerrarFormularioAgregar = true;
        private bool estasSeguro = true;
        private bool equipoActualizado = false;
        private AccesoDatos ado;
        
        private MiColeccion<NuevoEquipoFutbol> miColeccion = new MiColeccion<NuevoEquipoFutbol>();

        public NuevoEquipoFutbol equipo;
        public bool formularioIniciado { get; private set; }
        public bool modoActualizacion { get; set; }
        public int IndiceSeleccionado { get; set; }


        public frmAgregarEquipo()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.ado = new AccesoDatos();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            validarFechaDelegate = new ValidarFechaDelegate(EsFechaPasada);
        }



        /// <summary>
        /// Maneja el evento Load del formulario y configura el modo de actualización si es necesario.
        /// </summary>
        private void frmAgregarEquipo_Load(object sender, EventArgs e)
        {

            formularioIniciado = true;
            if (modoActualizacion)
            {
                txtNombreClub.ReadOnly = true;
                txtNombreClub.Enabled = false;
                txtNombreClub.BackColor = SystemColors.Control;  // Cambia el color de fondo para indicar que está deshabilitado
                this.Text = "Modificar equipo";
                btnAceptarActualizar.Text = "Modificar";
                frmEquipos frmEquiposForm = Application.OpenForms["frmEquipos"] as frmEquipos;
                if (frmEquiposForm != null)
                {
                    if (frmEquiposForm.lstEquipos.SelectedItem != null)
                    {
                        if (frmEquiposForm.lstEquipos.SelectedItem is NuevoEquipoFutbol)
                        {
                            NuevoEquipoFutbol equipoSeleccionado = (NuevoEquipoFutbol)frmEquiposForm.lstEquipos.SelectedItem;
                            // Configura los cuadros de texto con los valores del equipo seleccionado
                            txtNombreClub.Text = equipoSeleccionado.NombreEquipo;
                            txtApodoClub.Text = equipoSeleccionado.Apodo;
                            txtHinchas.Text = equipoSeleccionado.CantidadHinchas.ToString();
                            txtPeorPartido.Text = equipoSeleccionado.PeorPartido.ToString("dd/MM/yyyy");
                            txtPuntosClub.Text = equipoSeleccionado.CantidadPuntos.ToString();
                        }
                    }
                }

            }

        }

        /// <summary>
        /// Maneja el evento FormClosing del formulario para mostrar una confirmación antes de cerrar.
        /// </summary>
        private void frmAgregarEquipo_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (equipoActualizado)
            {
                DialogResult result = MessageBox.Show("¿Está seguro que desea modificar este equipo?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                    estasSeguro = false;
                }
                else
                {
                    estasSeguro = true;
                    formularioIniciado = false;
                }
            }
            else
            {
                formularioIniciado = false;
            }
            

        }


        /// <summary>
        /// Maneja el evento Click del botón para agregar o actualizar un equipo.
        /// </summary>
        public void btnAceptarActualizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreClub.Text) || string.IsNullOrWhiteSpace(txtApodoClub.Text) || string.IsNullOrWhiteSpace(txtHinchas.Text) || string.IsNullOrWhiteSpace(txtPeorPartido.Text) || string.IsNullOrWhiteSpace(txtPuntosClub.Text))
            {
                MessageBox.Show("Complete todos los espacios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!EsFormatoFechaValido(txtPeorPartido.Text))
            {
                MessageBox.Show("Formato de fecha incorrecto. Debe ser dd/MM/yyyy", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!(EsFechaPasada(txtPeorPartido.Text)))
            {
                MessageBox.Show("Fecha incorrecta, no se puede ingresar una fecha futura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                frmEquipos frmEquiposForm = Application.OpenForms["frmEquipos"] as frmEquipos;
                if (frmEquiposForm != null)
                {
                    IAcciones acciones = this;
                    string nombreClub = acciones.QuitarTildesYConvertirAMinusculas(txtNombreClub.Text);


                    if (frmEquiposForm.lstEquipos.SelectedItem != null)
                    {
                        
                        if (frmEquiposForm.lstEquipos.SelectedItem is NuevoEquipoFutbol)
                        {
                            NuevoEquipoFutbol nuevoEquipo = new NuevoEquipoFutbol(txtNombreClub.Text, txtApodoClub.Text, int.Parse(txtHinchas.Text), DateTime.Parse(txtPeorPartido.Text), int.Parse(txtPuntosClub.Text));
                            int indiceSeleccionado = frmEquiposForm.lstEquipos.SelectedIndex;
                            frmEquiposForm.lstEquipos.Items[indiceSeleccionado] = nuevoEquipo;
                            
                            try
                            {
                                equipoActualizado = true;
                                this.Close();
                                if (estasSeguro)
                                {
                                    ado.ModificarDato(nuevoEquipo);
                                }

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Error al intentar modificar el equipo en la base de datos: {ex.Message}");
                            }
                        }
                        
                        equipoActualizado = true;
                        this.Close();
                    }
                    else
                    {
                        NuevoEquipoFutbol nuevoEquipo = new NuevoEquipoFutbol(txtNombreClub.Text, txtApodoClub.Text, int.Parse(txtHinchas.Text), DateTime.Parse(txtPeorPartido.Text), int.Parse(txtPuntosClub.Text));
                        miColeccion += nuevoEquipo;
                        frmEquiposForm.ActualizarEquipos(miColeccion);
                        nuevoEquipo.NombreEquipo = nuevoEquipo.NombreEquipo;
                        nuevoEquipo.Apodo = nuevoEquipo.Apodo;
                        nuevoEquipo.CantidadHinchas = nuevoEquipo.CantidadHinchas;
                        nuevoEquipo.PeorPartido = nuevoEquipo.PeorPartido;
                        nuevoEquipo.CantidadPuntos = nuevoEquipo.CantidadPuntos;

                        try
                        {
                            ado.AgregarDato(nuevoEquipo);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error al intentar agregar el equipo: {ex.Message}");
                        }

                        // Actualiza la lista en frmEquipos después de agregar el equipo
                        frmEquiposForm.ActualizarEquiposDatos(ado.ObtenerListaDatos());

                        // Realiza la operación de UI en el hilo principal utilizando Invoke
                        this.Invoke((MethodInvoker)delegate
                        {
                            cerrarFormularioAgregar = true;
                            this.Close(); // Cierra el formulario actual
                            
                        });
                    }
                }
            }
        }


        /// <summary>
        /// Verifica y maneja el cambio en el campo de nombre del club.
        /// </summary>
        private void txtNombreClub_TextChanged(object sender, EventArgs e)
        {
            ValidarString(txtNombreClub, "Ingrese un nombre correcto");
        }

        /// <summary>
        /// Verifica y maneja el cambio en el campo de cantidad de hinchas.
        /// </summary>
        private void txtHinchas_TextChanged(object sender, EventArgs e)
        {
            ValidarEnteros(txtHinchas, "La cantidad de hinchas debe ser un número entero válido.");
        }

        /// <summary>
        /// Verifica y maneja el cambio en el campo de puntos del club.
        /// </summary>
        private void txtPuntosClub_TextChanged(object sender, EventArgs e)
        {
            ValidarEnteros(txtPuntosClub, "La cantidad de puntos debe ser un número entero válido.");

        }

        /// <summary>
        /// Verifica y maneja el cambio en el campo de apodo del club.
        /// </summary>
        private void txtApodoClub_TextChanged(object sender, EventArgs e)
        {
            ValidarString(txtApodoClub, "Ingrese un apodo correcto");
        }
        private void ValidarEnteros(System.Windows.Forms.TextBox textBox, string errorMessage)
        {
            if (!string.IsNullOrWhiteSpace(textBox.Text) && !int.TryParse(textBox.Text, out _))
            {
                MessageBox.Show(errorMessage, "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox.Clear();
            }
        }
        /// <summary>
        /// Valida que lo que se ingrese no sea otro tipo de dato que un string
        /// </summary>
        private void ValidarString(System.Windows.Forms.TextBox textBox, string errorMessage)
        {
            if (textBox.Text.Any(char.IsDigit))
            {
                MessageBox.Show(errorMessage, "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox.Clear();
            }
        }

        private bool EsFormatoFechaValido(string fecha)
        {

            string formatoFecha = "dd/MM/yyyy";


            if (DateTime.TryParseExact(fecha, formatoFecha, null, System.Globalization.DateTimeStyles.None, out _))
            {
                return validarFechaDelegate(fecha);
            }
            else
            {
                return false;
            }
        }
        private bool EsFechaPasada(string fecha)
        {
            if (EsFormatoFechaValido(fecha))
            {
                DateTime fechaIngresada = DateTime.ParseExact(fecha, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime fechaActual = DateTime.Now;

                // Verificar si la fecha ingresada es anterior a la fecha actual
                if (fechaIngresada <= fechaActual)
                {
                    return true; // La fecha es pasada o igual a la fecha actual
                }
            }

            return false; // La fecha no es válida o es futura
        }

        /// <summary>
        /// Quita tildes y convierte una cadena a minúsculas.
        /// </summary>
        /// <param name="input">La cadena de entrada.</param>
        /// <returns>La cadena sin tildes y en minúsculas.</returns>
        string IAcciones.QuitarTildesYConvertirAMinusculas(string input)
        {
            return new string(
                input.Normalize(NormalizationForm.FormD)
                     .Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                     .ToArray()
            ).ToLower();
        }
        MiColeccion<NuevoEquipoFutbol> IAcciones.ObtenerEquipos()
        {
            MiColeccion<NuevoEquipoFutbol> equiposTipoNuevo = new MiColeccion<NuevoEquipoFutbol>();
            return equiposTipoNuevo;
        }

        
        public void ActualizarEquipos(MiColeccion<NuevoEquipoFutbol> miColeccion)
        {
            throw new NotImplementedException();
        }
        
        public int OrdenarPorTopico(string ascendenteODescendente, string topico)
        {
            throw new NotImplementedException();
        }
    }
}