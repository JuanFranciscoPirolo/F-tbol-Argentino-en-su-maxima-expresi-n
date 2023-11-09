using Pirolo.JuanFrancisco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutbolArgentino
{
    public class Boca : EquipoFutbol
    {
        
        private string idoloJugador;
        private string idoloTecnico;

       

        public string IdoloJugador
        {
            get { return idoloJugador; }
            set { idoloJugador = value; }
        }
        public string IdoloTecnico
        {
            get { return idoloTecnico; }
            set { idoloTecnico = value; }
        }

        public Boca(string idoloJugador, string idoloTecnico, int cantidadHinchas, DateTime peorPartido, DateTime mejorPartido)
: base(cantidadHinchas, 0, peorPartido)
        {
            this.idoloJugador = idoloJugador;
            this.idoloTecnico = idoloTecnico;
            this.peorPartido = peorPartido;
            this.mejorPartido = mejorPartido;
        }
        public Boca(string nombreEquipo, int cantidadHinchas, DateTime peorPartido, int cantidadPuntos)
            : base(cantidadHinchas, cantidadPuntos, peorPartido)
        {
            this.nombreEquipo = nombreEquipo;
        }

        public Boca(string nombreEquipo, string idoloJugador, string idoloTecnico, int cantidadHinchas, DateTime peorPartido, int cantidadPuntos)
            : base(cantidadHinchas, cantidadPuntos, peorPartido)
        {
            this.nombreEquipo = nombreEquipo;
            this.idoloJugador = idoloJugador;
            this.idoloTecnico = idoloTecnico;
        }

        public Boca(string idoloJugador, string idoloTecnico, int cantidadHinchas, DateTime peorPartido, int cantidadPuntos)
            : base(cantidadHinchas, cantidadPuntos, peorPartido)
        {
            this.idoloJugador = idoloJugador;
            this.idoloTecnico = idoloTecnico;
        }

        public Boca(string idoloJugador, string idoloTecnico, int cantidadHinchas, DateTime peorPartido, int cantidadPuntos, DateTime fechaCreacion)
            : base(cantidadHinchas, cantidadPuntos, peorPartido, fechaCreacion)
        {
            this.fechaCreacion = fechaCreacion;
            this.idoloJugador = idoloJugador;
            this.idoloTecnico = idoloTecnico;
            this.peorPartido = peorPartido;
        }



        /// <summary>
        /// Calcula los puntos del equipo de Boca Juniors.
        /// </summary>
        public override int CalcularPuntos(int partidosGanados, int partidosEmpatados)
        {
            int puntos = (partidosGanados * 3) + partidosEmpatados;
            return puntos;
        }
        /// <summary>
        /// Devuelve una representación en formato de cadena del equipo de Boca Juniors.
        /// </summary>
        /// <returns>Una cadena que representa el equipo de Boca Juniors.</returns>
        // no tiene referencia porque lo utilizo indirectamente en el lstbox
        public override string ToString()
        {
            return $"{this.nombreEquipo} || {ObtenerApodo()} || Hinchas: {this.cantidadHinchas} ||Peor partido: {this.peorPartido.ToString("dd/MM/yyyy")} || PUNTOS: {this.cantidadPuntos} ";
        }
        /// <summary>
        /// Obtiene el apodo del equipo de Boca Juniors.
        /// </summary>
        /// <returns>El apodo del equipo de Boca Juniors.</returns>
        public override string ObtenerApodo()
        {
            return "El Xeneixe";
        }

        /// <summary>
        /// Obtiene la cantidad de días que han pasado desde el peor partido hasta la fecha actual.
        /// </summary>
        /// <returns>La cantidad de días transcurridos.</returns>
        public int ObtenerDias()
        {
            DateTime fechaActual = DateTime.Now;
            TimeSpan tiempoDelPeorDia = fechaActual - this.peorPartido;
            int diasPasados = tiempoDelPeorDia.Days;
            return diasPasados;
        }

    }
}
