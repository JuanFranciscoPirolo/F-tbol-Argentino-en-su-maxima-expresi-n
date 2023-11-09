using Pirolo.JuanFrancisco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutbolArgentino
{
    /// <summary>
    /// Representa el Club Atlético River Plate.
    /// </summary>
    public class River : EquipoFutbol
    {
        protected int puntuacionHistorial;
        protected string nombreHinchada;

        private int partidosGanados;
        private int partidosEmpatados;

        // Propiedades
        public int PuntuacionHistorial
        {
            get { return puntuacionHistorial; }
            set { puntuacionHistorial = value; }
        }
        public int PartidosGanados
        {
            get { return partidosGanados; }
            set { partidosGanados = value; }
        }
        public int PartidosEmpatados
        {
            get { return partidosEmpatados; }
            set { partidosEmpatados = value; }
        }
        // Constructor
        /// <summary>
        /// Inicializa una nueva instancia de la clase River con datos específicos.
        /// </summary>
        /// <param name="nombreHinchada">El nombre de la hinchada de River.</param>
        /// <param name="cantidadHinchas">La cantidad de hinchas de River.</param>
        /// <param name="peorPartido">La fecha del peor partido de River.</param>
        /// <param name="fechaCreacion">La fecha de creación de River.</param>
        /// <param name="puntuacionHistorial">La puntuación histórica de River.</param>
        /// <param name="cantidadPuntos">La cantidad de puntos de River.</param>
        public River(string nombreHinchada, int cantidadHinchas, DateTime peorPartido, DateTime fechaCreacion, int puntuacionHistorial, int cantidadPuntos)
    : base(cantidadPuntos)
        {
            this.nombreHinchada = nombreHinchada;
            this.cantidadHinchas = cantidadHinchas;
            this.peorPartido = peorPartido;
            this.fechaCreacion = fechaCreacion;
            this.puntuacionHistorial = puntuacionHistorial;
        }

        public River(int cantidadHinchas, int cantidadPuntos, DateTime peorPartido)
            : base(cantidadHinchas, cantidadPuntos, peorPartido)
        {
            this.peorPartido = peorPartido;
        }
        public River(string nombreEquipo, int cantidadHinchas, DateTime peorPartido, int cantidadPuntos)
    : base(cantidadHinchas, cantidadPuntos, peorPartido)
        {
            this.peorPartido = peorPartido;
            this.nombreEquipo = nombreEquipo;
        }


        // Métodos
        /// <summary>
        /// Calcula los puntos del Club Atlético River Plate.
        /// </summary>
        /// <returns>La puntuación calculada.</returns>
        public override int CalcularPuntos(int partidosGanados, int partidosEmpatados)
        {
            int puntos = (partidosGanados * 3) + partidosEmpatados;
            return puntos;
        }

        /// <summary>
        /// Obtiene una representación en formato de cadena del Club Atlético River Plate.
        /// </summary>
        /// <returns>Una cadena que representa a River Plate.</returns>
        public override string ToString()
        {
            return $"{this.nombreEquipo} || {ObtenerApodo()} || Hinchas: {this.cantidadHinchas} || Peor partido: {this.peorPartido.ToString("dd/MM/yyyy")} || PUNTOS: {this.cantidadPuntos} ";

        }

        /// <summary>
        /// Obtiene el apodo del Club Atlético River Plate.
        /// </summary>
        /// <returns>El apodo del club.</returns>
        public override string ObtenerApodo()
        {
            return "El millonario";
        }
    }
}
