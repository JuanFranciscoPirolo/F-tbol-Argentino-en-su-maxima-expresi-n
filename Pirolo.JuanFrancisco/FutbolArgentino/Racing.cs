using Pirolo.JuanFrancisco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pirolo.JuanFrancisco;
using System;
using System.Collections.Generic;

namespace FutbolArgentino
{
    /// <summary>
    /// Representa el Racing Club de Avellaneda.
    /// </summary>
    public class Racing : EquipoFutbol // Racing hereda de EquipoFutbol
    {
        private Presidentes presidente;
        protected int capacidadCancha;
        private int partidosGanados;
        private int partidosEmpatados;


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
        public int CapacidadCancha
        {
            get { return capacidadCancha; }
            set { capacidadCancha = value; }
        }

        // Constructores
        /// <summary>
        /// Inicializa una nueva instancia de la clase Racing con datos específicos.
        /// </summary>
        /// <param name="cantidadHinchas">La cantidad de hinchas de Racing.</param>
        /// <param name="capacidadCancha">La capacidad de la cancha de Racing.</param>
        /// <param name="mejorPartido">La fecha del mejor partido de Racing.</param>
        /// <param name="fechaCreacion">La fecha de creación de Racing.</param>
        /// <param name="presidente">El presidente de Racing.</param>
        /// <param name="cantidadPuntos">La cantidad de puntos de Racing.</param>
        public Racing(int cantidadHinchas, int capacidadCancha, DateTime mejorPartido, DateTime fechaCreacion, Presidentes presidente, int cantidadPuntos)
            : base(cantidadHinchas, cantidadPuntos)
        {
            this.capacidadCancha = capacidadCancha;
            this.mejorPartido = mejorPartido;
            this.fechaCreacion = fechaCreacion;
            this.presidente = presidente;
        }

        // Constructor adicional para el caso en que no se pase la cantidad de puntos
        /// <summary>
        /// Inicializa una nueva instancia de la clase Racing con datos específicos.
        /// </summary>
        /// <param name="cantidadHinchas">La cantidad de hinchas de Racing.</param>
        /// <param name="capacidadCancha">La capacidad de la cancha de Racing.</param>
        /// <param name="mejorPartido">La fecha del mejor partido de Racing.</param>
        /// <param name="fechaCreacion">La fecha de creación de Racing.</param>
        /// <param name="presidente">El presidente de Racing.</param>

        public Racing(string nombreEquipo, int cantidadHinchas, DateTime peorPartido, int cantidadPuntos)
    : base(cantidadHinchas, cantidadPuntos, peorPartido)
        {
            this.peorPartido = peorPartido;
            this.nombreEquipo = nombreEquipo;
        }

        // Métodos
        /// <summary>
        /// Calcula los puntos del Racing Club de Avellaneda.
        /// </summary>
        /// <returns>La puntuación calculada.</returns>
        public override int CalcularPuntos(int partidosGanados, int partidosEmpatados)
        {
            int puntos = (partidosGanados * 3) + partidosEmpatados;
            return puntos;
        }

        /// <summary>
        /// Obtiene una representación en formato de cadena del Racing Club de Avellaneda.
        /// </summary>
        /// <returns>Una cadena que representa a Racing Club de Avellaneda.</returns>

        public override string ToString()
        {
            return $"{this.nombreEquipo} || {ObtenerApodo()} || Hinchas: {this.cantidadHinchas} ||Peor partido: {this.peorPartido.ToString("dd/MM/yyyy")} || PUNTOS: {this.cantidadPuntos} ";
        }

        /// <summary>
        /// Obtiene el apodo del Racing Club de Avellaneda.
        /// </summary>
        /// <returns>El apodo del club.</returns>

        public override string ObtenerApodo()
        {
            return "La academia";
        }



    }
}
