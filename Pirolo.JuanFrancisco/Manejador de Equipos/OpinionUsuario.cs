using System;
using System.Threading;
using System.Windows.Forms;

namespace Manejador_de_Equipos
{
    /// <summary>
    /// Clase que gestiona la opinión del usuario sobre la aplicación y muestra un diálogo de clasificación después de un tiempo determinado.
    /// </summary>
    public class OpinionUsuario
    {
        private Thread temporizadorThread;
        /// <summary>
        /// Evento que se dispara al clasificar la aplicación.
        /// </summary>
        public event Action<string> ClasificarAplicacion;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="OpinionUsuario"/>.
        /// </summary>
        public OpinionUsuario()
        {
            InicializarTemporizador();
        }

        private void InicializarTemporizador()
        {
            temporizadorThread = new Thread(EsperarYMostrarDialogo);
            temporizadorThread.IsBackground = true;
            temporizadorThread.Start();
        }

        private void EsperarYMostrarDialogo()
        {
            // Espera 2 minutos (120,000 milisegundos)
            Thread.Sleep(120000);

            // Muestra el diálogo de clasificación
            MostrarDialogoClasificacion();
        }


        /// <summary>
        /// Muestra un diálogo para que el usuario clasifique la aplicación.
        /// </summary>

        public void MostrarDialogoClasificacion()
        {
            bool entradaValida = false;
            string valorIngresado = "";

            while (!entradaValida)
            {
                valorIngresado = Microsoft.VisualBasic.Interaction.InputBox("¿Cuántas estrellas le das a esta aplicación?", "Clasificación", "");

                if (int.TryParse(valorIngresado, out int clasificacion) && clasificacion >= 1 && clasificacion <= 5)
                {
                    entradaValida = true;

                }
                else
                {
                    MessageBox.Show("Dato incorrecto. Por favor, ingrese un número entero del 1 al 5.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            ClasificarAplicacion?.Invoke($"Clasificación: {valorIngresado}");
        }

    }
}
