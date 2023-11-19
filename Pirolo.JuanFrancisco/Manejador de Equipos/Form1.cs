using FutbolArgentino;
using Microsoft.VisualBasic.ApplicationServices;
using System.Drawing.Text;
using Manejador_de_Equipos;
using System.Xml.Serialization;
using Pirolo.JuanFrancisco;
using System.Security.Cryptography.X509Certificates;
using System.Globalization;
using System.Text;

namespace Manejador_de_Equipos
{
    public partial class frmEquipos : Form, IAcciones
    {
        private GestorDescanso gestorDescanso;
        private AccesoDatos ado;
        private bool usuarioPuedeCrear = false;
        private bool usuarioPuedeLeer = false;
        private bool usuarioPuedeActualizar = false;
        private bool usuarioPuedeEliminar = false;
        private bool saveDialogOpened = false;
        private MiColeccion<NuevoEquipoFutbol> equiposDeColeccionGenerica;
        private DateTime fechaInicioSesion;
        private string perfil;
        private string nombre;
        private SaveFileDialog saveDialog;
        private bool fotoVisible = false; // Variable de control para la visibilidad de la foto

        /// <summary>
        /// Constructor del formulario frmEquipos. Inicializa el formulario, deshabilita la capacidad de maximizar,
        /// establece la fecha de inicio de sesión y el nombre del usuario, inicializa una colección de equipos y agrega equipos por defecto.
        /// </summary>
        /// <param name="fechaInicioSesion">La fecha de inicio de sesión del usuario.</param>
        /// <param name="nombre">El nombre del usuario.</param>

        public frmEquipos(DateTime fechaInicioSesion, string nombre, string perfil)
        {
            InitializeComponent();
            this.ado = new AccesoDatos();
            this.MaximizeBox = false;
            this.fechaInicioSesion = fechaInicioSesion;
            this.nombre = nombre;
            this.perfil = perfil;
            equiposDeColeccionGenerica = new MiColeccion<NuevoEquipoFutbol>();
            saveDialog = new SaveFileDialog();
            saveDialog.Filter = "XML Files (.xml)|*.xml";
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            gestorDescanso = new GestorDescanso();
            gestorDescanso.ImagenCambiada += CambiarImagenDescanso;
            pictureBoxDescanso.Visible = false;

        }

        /// <summary>
        /// Maneja el evento de cierre del formulario, mostrando un mensaje de confirmación antes de cerrar la aplicación.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>

        private void frmEquipos_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult resultado = MessageBox.Show("¿Está seguro que desea cerrar el formulario?", "Confirmar cierre", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.No)
                {
                    e.Cancel = true;  // Cancelar el cierre del formulario
                }
                else
                {
                    Application.Exit();
                }
            }




        }

        public void ActualizarEquipos(MiColeccion<NuevoEquipoFutbol> miColeccion)
        {
            foreach (NuevoEquipoFutbol equipo in miColeccion.elementos)
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
            if (usuarioPuedeCrear || usuarioPuedeActualizar) //administrador o supervisor
            {

                frmAgregarEquipo NuevoEquipo = new frmAgregarEquipo(); // Pasa una referencia de frmEquipos
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
            else
            {
                MessageBox.Show("No tienes permisos para crear un equipo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        //error en guardado y modificar

        /// <summary>
        /// Se ejecuta al cargar el formulario, muestra información del usuario y deserializa la colección de equipos.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void frmEquipos_Load_1(object sender, EventArgs e)
        {
            if (perfil == "administrador")
            {
                usuarioPuedeCrear = true;
                usuarioPuedeLeer = true;
                usuarioPuedeActualizar = true;
                usuarioPuedeEliminar = true;
            }
            else if (perfil == "supervisor")
            {
                usuarioPuedeEliminar = false;
                usuarioPuedeCrear = true;
                usuarioPuedeLeer = true;
                usuarioPuedeActualizar = true;
            }
            else if (perfil == "vendedor")
            {
                usuarioPuedeEliminar = false;
                usuarioPuedeCrear = false;
                usuarioPuedeLeer = true;
                usuarioPuedeActualizar = false;
            }
            lblInformacion.Text = $"{nombre} - {fechaInicioSesion:yy/MM/yyyy}";
            ActualizarEquiposDatos(ado.ObtenerListaDatos());
            //DeserializarColeccion();

        }
        public void ActualizarEquiposDatos(List<NuevoEquipoFutbol> nuevaLista)
        {
            // Actualizar la lista de equipos en el formulario
            lstEquipos.Items.Clear();
            lstEquipos.Items.AddRange(nuevaLista.ToArray());
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
            if (usuarioPuedeEliminar)
            {
                if (lstEquipos.SelectedItem != null)
                {
                    // Mostrar un cuadro de diálogo para confirmar la eliminación
                    DialogResult resultado = MessageBox.Show("¿Estás seguro que deseas eliminar este equipo?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (resultado == DialogResult.Yes)
                    {
                        // Obtén el equipo seleccionado
                        NuevoEquipoFutbol equipoSeleccionado = (NuevoEquipoFutbol)lstEquipos.SelectedItem;
                        lstEquipos.Items.Remove(lstEquipos.SelectedItem);
                        // Elimina el equipo de la colección genérica

                        equiposDeColeccionGenerica -= equipoSeleccionado;

                        //NuevoEquipoFutbol otroEquipo = new NuevoEquipoFutbol(equipoSeleccionado.NombreEquipo,"",0, new DateTime(2023, 11, 15),2);

                        NuevoEquipoFutbol nuevoEquipo = new NuevoEquipoFutbol();
                        nuevoEquipo.NombreEquipo = equipoSeleccionado.NombreEquipo;

                        try
                        {
                            if (ado.EliminarDato(nuevoEquipo))
                            {
                                MessageBox.Show("Equipo eliminado correctamente", "Eliminación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error al intentar eliminar el equipo: {ex.Message}", "Error de Eliminación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }




                    }
                }
                else
                {
                    MessageBox.Show("Ningún elemento seleccionado.");
                }
            }
            else
            {
                MessageBox.Show("No tienes permisos para crear un equipo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            IAcciones acciones = this;
            int resultado = acciones.OrdenarPorTopico(ascendenteODescendente, topico);

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
            IAcciones acciones = this; // se crea usando la referencia del formulario, lo llama a traves de la interfaz
            int resultado = acciones.OrdenarPorTopico(ascendenteODescendente, topico);
        }

        /// <summary>
        /// Realiza el ordenamiento de la lista de equipos según el tópico y la dirección especificados.
        /// </summary>
        /// <param name="ascendenteODescendente">La dirección de la ordenación (ascendente o descendente).</param>
        /// <param name="topico">El tópico por el que se ordenarán los equipos.</param>
        /// <returns>0 en caso de éxito.</returns>
        int IAcciones.OrdenarPorTopico(string ascendenteODescendente, string topico)
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

        MiColeccion<NuevoEquipoFutbol> IAcciones.ObtenerEquipos()
        {
            MiColeccion<NuevoEquipoFutbol> equiposTipoNuevo = new MiColeccion<NuevoEquipoFutbol>();

            foreach (var item in lstEquipos.Items)
            {
                if (item is NuevoEquipoFutbol nuevoEquipo)
                {
                    equiposTipoNuevo += nuevoEquipo;
                }
            }

            return equiposTipoNuevo;
        }
        string IAcciones.QuitarTildesYConvertirAMinusculas(string input)
        {
            return new string(
                input.Normalize(NormalizationForm.FormD)
                     .Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                     .ToArray()
            ).ToLower();
        }
        private void CambiarImagenDescanso(string rutaImagen)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(CambiarImagenDescanso), rutaImagen);
                return;
            }

            
            // Actualiza la imagen en el PictureBox
            pictureBoxDescanso.ImageLocation = rutaImagen;


        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Invierte el valor de la variable de control
            fotoVisible = !fotoVisible;

            if (fotoVisible)
            {
                // Muestra la foto
                pictureBoxDescanso.Visible = true;
                button3.Text = "Descansando...";


            }
            else
            {
                // Oculta la foto
                pictureBoxDescanso.Visible = false;
                button3.Text = "Me voy al descanso...";
            }
        }
    }


}
