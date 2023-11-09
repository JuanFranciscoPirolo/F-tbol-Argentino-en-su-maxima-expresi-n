using FutbolArgentino;
using Microsoft.VisualBasic.ApplicationServices;
using System.Drawing.Text;
using Manejador_de_Equipos;
using System.Xml.Serialization;
using Pirolo.JuanFrancisco;

namespace Manejador_de_Equipos
{
    public partial class frmEquipos : Form
    {
        private bool intentarNuevamente = false;
        private bool guardadoExitoso = false;
        private bool saveDialogOpened = false;
        private List<NuevoEquipoFutbol> equiposColeccion;

        private DateTime fechaInicioSesion;
        private string nombre;
        private SaveFileDialog saveDialog;


        /// <summary>
        /// Constructor del formulario frmEquipos. Inicializa el formulario, deshabilita la capacidad de maximizar,
        /// establece la fecha de inicio de sesión y el nombre del usuario, inicializa una colección de equipos y agrega equipos por defecto.
        /// </summary>
        /// <param name="fechaInicioSesion">La fecha de inicio de sesión del usuario.</param>
        /// <param name="nombre">El nombre del usuario.</param>
        public frmEquipos(DateTime fechaInicioSesion, string nombre)
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.fechaInicioSesion = fechaInicioSesion;
            this.nombre = nombre;
            equiposColeccion = new List<NuevoEquipoFutbol>();
            saveDialog = new SaveFileDialog();
            saveDialog.Filter = "XML Files (.xml)|*.xml";
        }


        /// <summary>
        /// Maneja el evento de cierre del formulario, mostrando un mensaje de confirmación antes de cerrar la aplicación.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>

        private void frmEquipos_FormClosing(object sender, FormClosingEventArgs e)
        {

            CerrarForm(e);

        }

        private bool segundaConfirmacionMostrada = false;

        private void CerrarForm(FormClosingEventArgs e)
        {
            if (intentarNuevamente)
            {
                // Si intentarNuevamente es verdadero, cierra la aplicación sin mostrar ningún mensaje.
                Application.Exit();
            }
            else
            {
                if (guardadoExitoso)
                {
                    // El guardado fue exitoso, se puede cerrar la aplicación.
                    Application.Exit();
                }
                else
                {
                    if (segundaConfirmacionMostrada)
                    {
                        // La segunda confirmación ya se mostró, se debe salir de la aplicación
                        Application.Exit();
                    }
                    else
                    {
                        // Muestra un mensaje de confirmación para guardar los datos.
                        DialogResult resultado0 = MessageBox.Show("¿Deseas guardar los datos?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (resultado0 == DialogResult.Yes)
                        {
                            // El usuario desea guardar los datos.
                            SerializarColeccion();
                            if (guardadoExitoso)
                            {
                                // El guardado fue exitoso, se puede cerrar la aplicación.
                                Application.Exit();
                            }
                            else
                            {
                                segundaConfirmacionMostrada = true;
                                e.Cancel = true;
                            }
                        }
                        else
                        {
                            // El usuario no desea guardar los datos, pero quiere cerrar la aplicación.
                            intentarNuevamente = true;
                            // Establecer guardadoExitoso en true para permitir el cierre sin guardar.
                            guardadoExitoso = true;
                            Application.Exit();
                        }
                    }
                }
            }
        }



        public void ActualizarEquipos()
        {
            // Actualiza tu lista de equipos en lstEquipos
            lstEquipos.Items.Clear();
            foreach (var equipo in equiposColeccion)
            {
                lstEquipos.Items.Add(equipo);
            }
        }


        /// <summary>
        /// Abre un formulario para agregar un equipo y permite la actualización si se selecciona un elemento en la lista de equipos.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void btnAgregar_Click_1(object sender, EventArgs e)
        {

            frmAgregarEquipo NuevoEquipo = new frmAgregarEquipo(equiposColeccion, this); // Pasa una referencia de frmEquipos
            if (lstEquipos.SelectedItem != null)
            {
                int indiceSeleccionado = lstEquipos.SelectedIndex;
                NuevoEquipo.IndiceSeleccionado = indiceSeleccionado;
                NuevoEquipo.modoActualizacion = true;
            }
            NuevoEquipo.FormClosed += (s, args) =>
            {
                if (!NuevoEquipo.formularioIniciado)
                {
                    this.Show();
                }
            };

            NuevoEquipo.Show();
            this.Hide();
        }
        //error en guardado y modificar

        /// <summary>
        /// Se ejecuta al cargar el formulario, muestra información del usuario y deserializa la colección de equipos.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void frmEquipos_Load_1(object sender, EventArgs e)
        {
            lblInformacion.Text = $"{nombre} - {fechaInicioSesion:yy/MM/yyyy}";
            DeserializarColeccion();

            /*
            foreach (EquipoFutbol equipo in coleccionEquipos.OrdenarAscendentemente())
            {
                // Verificar si el equipo no está en lstEquipos
                //if (!nombresEquiposEnLista.Any(item => item.Contains(equipo)))
                //{
                lstEquipos.Items.Add(equipo);
            //}
            }
            */

        }

        /// <summary>
        /// Abre un formulario de información de equipos y gestiona su cierre.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void btnInformacion_Click(object sender, EventArgs e)
        {
            frmInfoEquipos infoEquipo = new frmInfoEquipos();
            infoEquipo.FormClosed += (s, args) =>
            {
                if (!infoEquipo.formularioInformacion)
                {
                    this.Show();
                }
            };

            infoEquipo.Show();
            this.Hide();
        }


        /// <summary>
        /// Elimina un elemento seleccionado de la lista de equipos.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (lstEquipos.SelectedItem != null)
            {
                string elementoSeleccionado = lstEquipos.SelectedItem.ToString();

                // Mostrar un cuadro de diálogo para confirmar la eliminación
                DialogResult resultado = MessageBox.Show("¿Estás seguro que deseas eliminar este equipo?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    lstEquipos.Items.Remove(lstEquipos.SelectedItem);
                }
            }
            else
            {
                MessageBox.Show("Ningún elemento seleccionado.");
            }
        }


        /// <summary>
        /// Deselecciona todos los elementos seleccionados en la lista de equipos.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void btnDeseleccionar_Click(object sender, EventArgs e)
        {
            lstEquipos.ClearSelected();

        }

        /// <summary>
        /// Ordena la lista de equipos por un tópico seleccionado y una dirección (ascendente o descendente).
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void btnOrdenar_Click(object sender, EventArgs e)
        {
            if (!(rdAscendente.Checked) && !(rdDescendente.Checked))
            {
                MessageBox.Show("Debes marcar al menos una de las dos opciones", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string topico = "PUNTOS";
            string ascendenteODescendente = rdAscendente.Checked ? "ascendente" : "descendente";
            int resultado = OrdenarPorTopico(ascendenteODescendente, topico);

        }

        /// <summary>
        /// Ordena la lista de equipos por un tópico seleccionado y una dirección (ascendente o descendente).
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (!(rdAscendente.Checked) && !(rdDescendente.Checked))
            {
                MessageBox.Show("Debes marcar al menos una de las dos opciones", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string topico = "Hinchas";
            string ascendenteODescendente = rdAscendente.Checked ? "ascendente" : "descendente";
            int resultado = OrdenarPorTopico(ascendenteODescendente, topico);
        }

        /// <summary>
        /// Realiza la ordenación de la lista de equipos según el tópico y la dirección especificados.
        /// </summary>
        /// <param name="ascendenteODescendente">La dirección de la ordenación (ascendente o descendente).</param>
        /// <param name="topico">El tópico por el que se ordenarán los equipos.</param>
        /// <returns>0 en caso de éxito.</returns>
        private int OrdenarPorTopico(string ascendenteODescendente, string topico)
        {
            List<string> equiposEnLista = new List<string>();
            foreach (var item in lstEquipos.Items)
            {
                equiposEnLista.Add(item.ToString());
            }

            if (ascendenteODescendente == "ascendente")
            {
                var equiposOrdenados = equiposEnLista.OrderBy(equipo =>
                {
                    int ordeno = 0;
                    var partes = equipo.Split(new string[] { "||" }, StringSplitOptions.None);
                    foreach (var parte in partes)
                    {
                        if (parte.Contains($"{topico}:"))
                        {
                            var topicoStr = parte.Replace($"{topico}:", "").Trim();
                            if (int.TryParse(topicoStr, out ordeno))
                            {
                                break;
                            }
                        }
                    }
                    return ordeno;
                });

                lstEquipos.Items.Clear();
                lstEquipos.Items.AddRange(equiposOrdenados.ToArray());
            }
            else if (ascendenteODescendente == "descendente")
            {
                var equiposOrdenados = equiposEnLista.OrderByDescending(equipo =>
                {
                    int puntos = 0;
                    var partes = equipo.Split(new string[] { "||" }, StringSplitOptions.None);
                    foreach (var parte in partes)
                    {
                        if (parte.Contains($"{topico}:"))
                        {
                            var puntosStr = parte.Replace($"{topico}:", "").Trim();
                            if (int.TryParse(puntosStr, out puntos))
                            {
                                break;
                            }
                        }
                    }
                    return puntos;
                });
                lstEquipos.Items.Clear();
                lstEquipos.Items.AddRange(equiposOrdenados.ToArray());
            }

            return 0;
        }


        /// <summary>
        /// Serializa la colección de equipos y la guarda en un archivo XML, gestionando errores y excepcione
        /// </summary>
        private void SerializarColeccion()
        {
            try
            {
                if (!saveDialogOpened)
                {
                    saveDialog.Filter = "XML Files (.xml)|*.xml";
                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        saveDialogOpened = true;

                        string fileName = saveDialog.FileName;


                        List<string> equiposParaSerializar = new List<string>();

                        foreach (var item in lstEquipos.Items)
                        {
                            equiposParaSerializar.Add(item.ToString());
                        }


                        XmlSerializer serializer = new XmlSerializer(typeof(List<string>));

                        using (FileStream stream = new FileStream(fileName, FileMode.Create))
                        {
                            serializer.Serialize(stream, equiposParaSerializar);
                        }

                        guardadoExitoso = true;
                    }
                    else
                    {
                        saveDialogOpened = true;
                    }
                }
            }
            catch (Exception ex)
            {
                File.AppendAllText("errores.log", $"Error: {ex.Message}\nStackTrace: {ex.StackTrace}\n\n");
            }
        }


        /// <summary>
        /// Deserializa una colección de equipos desde un archivo XML previamente guardado y la muestra en la lista de equipos.
        /// </summary>
        private void DeserializarColeccion()
        {
            try
            {
                OpenFileDialog openDialog = new OpenFileDialog();
                openDialog.Filter = "XML Files (.xml)|*.xml";

                if (openDialog.ShowDialog() == DialogResult.OK)
                {
                    string archivoSerializacion = openDialog.FileName;
                    XmlSerializer serializer = new XmlSerializer(typeof(List<string>));

                    using (FileStream stream = new FileStream(archivoSerializacion, FileMode.Open))
                    {
                        List<string> equiposDeserializados = (List<string>)serializer.Deserialize(stream);

                        foreach (string equipo in equiposDeserializados)
                        {
                            lstEquipos.Items.Add(equipo);
                        }
                    }
                }
                else
                {

                }

            }
            catch (Exception ex)
            {

                File.AppendAllText("errores.log", $"Error: {ex.Message}\nStackTrace: {ex.StackTrace}\n\n");
            }

        }
        /// <summary>
        /// Abre un formulario para ver la información de usuarios.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void button2_Click(object sender, EventArgs e)
        {
            InformacionUsuarioscs visualizador = new InformacionUsuarioscs();
            visualizador.Show();
        }
        private List<NuevoEquipoFutbol> ObtenerEquipos()
        {
            List<NuevoEquipoFutbol> equiposTipoNuevo = new List<NuevoEquipoFutbol>();

            foreach (var item in lstEquipos.Items)
            {
                if (item is NuevoEquipoFutbol nuevoEquipo)
                {
                    equiposTipoNuevo.Add(nuevoEquipo);
                }
            }

            return equiposTipoNuevo;
        }
    }

}
