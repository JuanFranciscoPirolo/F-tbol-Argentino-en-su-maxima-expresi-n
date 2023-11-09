using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manejador_de_Equipos
{
    public class NuevoEquipoAgregarLista
    {
        private string nombreEquipo;
        private string apodoEquipo;
        private int hinchas;
        private DateTime peorPartido;
        private int puntosEquipo;

        public string NombreEquipo
        {
            get { return nombreEquipo; }
            set { nombreEquipo = value; }
        }
        public string ApodoEquipo
        {
            get { return apodoEquipo; }
            set { apodoEquipo = value; }
        }
        public int Hinchas
        {
            get { return hinchas; }
            set { hinchas = value; }
        }
        public DateTime PeorPartido
        {
            get { return peorPartido; }
            set { peorPartido = value; }
        }
        public int PuntosEquipo
        {
            get { return puntosEquipo; }
            set { puntosEquipo = value; }
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase NuevoEquipoAgregarLista con los datos especificados.
        /// </summary>
        /// <param name="nombreEquipo">El nombre del equipo.</param>
        /// <param name="apodoEquipo">El apodo del equipo.</param>
        /// <param name="hinchas">La cantidad de hinchas del equipo.</param>
        /// <param name="peorPartido">La fecha del peor partido del equipo.</param>
        /// <param name="puntosEquipo">La cantidad de puntos del equipo.</param>
        public NuevoEquipoAgregarLista(string nombreEquipo, string apodoEquipo, int hinchas, DateTime peorPartido, int puntosEquipo)
        {
            this.nombreEquipo = nombreEquipo;
            this.apodoEquipo = apodoEquipo;
            this.hinchas = hinchas;
            this.peorPartido = peorPartido;
            this.puntosEquipo = puntosEquipo;
        }
    }
}
