using System;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace Manejador_de_Equipos
{
    /// <summary>
    /// Clase que gestiona el descanso y la rotación de imágenes.
    /// </summary>
    public class GestorDescanso
    {
        private Thread hiloImagenes;
        private System.Timers.Timer temporizadorInactividad;
        private string[] imagenes = { @"../../../../Manejador de Equipos\Resources\boca_cancha.jpg",
            @"../../../../Manejador de Equipos\Resources\cancha_racing.jpg",
            @"../../../../Manejador de Equipos\Resources\messi.jpg",
            @"../../../../Manejador de Equipos\Resources\cancha_river.jpg" };
        private int indiceImagenActual = 0;

        /// <summary>
        /// Evento que se dispara cuando la imagen cambia.
        /// </summary>
        public event Action<string> ImagenCambiada;

        /// <summary>
        /// Constructor de la clase <see cref="GestorDescanso"/>.
        /// </summary>
        public GestorDescanso()
        {
            // Inicia el hilo para cambiar imágenes
            hiloImagenes = new Thread(CambiarImagenes);
            hiloImagenes.IsBackground = true;
            hiloImagenes.Start();
            temporizadorInactividad = new System.Timers.Timer();
            temporizadorInactividad.Interval = 10000; // 10 segundos
            temporizadorInactividad.AutoReset = false; // Solo se activa una vez, después de cada intervalo
            temporizadorInactividad.Start();
        }

        /// <summary>
        /// Método que cambia las imágenes de manera continua.
        /// </summary>
        private void CambiarImagenes()
        {

            try
            {
                while (true)
                {
                    // Cambia la imagen actual
                    MostrarSiguienteImagen();

                    // Duerme el hilo durante un tiempo determinado (por ejemplo, 5 segundos)
                    Thread.Sleep(5000);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Error al mostrar las imagenes{ex}");
            }
        }

        /// <summary>
        /// Método que muestra la siguiente imagen en la secuencia.
        /// </summary>
        private void MostrarSiguienteImagen()
        {
            // Actualiza la imagen actual
            if (indiceImagenActual < imagenes.Length)
            {
                ImagenCambiada?.Invoke(imagenes[indiceImagenActual]);
                indiceImagenActual++;
            }
            else
            {
                indiceImagenActual = 0; // Reinicia el índice si llega al final del arreglo
            }
        }

    }
}