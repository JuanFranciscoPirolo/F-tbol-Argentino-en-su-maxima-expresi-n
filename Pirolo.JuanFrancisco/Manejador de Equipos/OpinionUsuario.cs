using System;
using System.Threading;
using System.Windows.Forms;

namespace Manejador_de_Equipos
{
    public class OpinionUsuario
    {
        private Thread temporizadorThread;
        public event Action<string> ClasificarAplicacion;
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

            // Aquí puedes procesar el valor ingresado después de que se ha validado correctamente
            ClasificarAplicacion?.Invoke($"Clasificación: {valorIngresado}");
        }

    }
}
