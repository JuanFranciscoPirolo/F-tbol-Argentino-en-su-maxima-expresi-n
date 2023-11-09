using FutbolArgentino;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Pirolo.JuanFrancisco
{
    /// <summary>
    /// Representa un equipo de fútbol genérico.
    /// </summary>
    [XmlInclude(typeof(NuevoEquipoFutbol))]
    [XmlRoot("EquipoFutbol")]
    public abstract class EquipoFutbol
    {
        protected string apodo;
        protected DateTime fechaCreacion;
        protected DateTime mejorPartido;
        protected DateTime peorPartido;
        protected int cantidadHinchas;
        protected int cantidadPuntos;
        protected string nombreEquipo;

        //Constructores:
        public EquipoFutbol(string nombreEquipo, string apodo, int cantidadHinchas, DateTime peorPartido, int cantidadPuntos)
        {
            this.nombreEquipo = nombreEquipo;
            this.cantidadHinchas = cantidadHinchas;
            this.peorPartido = peorPartido;
            this.cantidadPuntos = cantidadPuntos;
            this.apodo = apodo;
        }
        public EquipoFutbol()
        {

        }
        public EquipoFutbol(int cantidadHinchas)
        {
            this.cantidadHinchas = cantidadHinchas;

        }
        public EquipoFutbol(int cantidadHinchas, int cantidadPuntos) : this(cantidadHinchas)
        {
            this.cantidadPuntos = cantidadPuntos;
        }
        public EquipoFutbol(int cantidadHinchas, int cantidadPuntos, DateTime peorPartido) : this(cantidadHinchas, cantidadPuntos)
        {
            this.peorPartido = peorPartido;
        }
        public EquipoFutbol(int cantidadHinchas, int cantidadPuntos, DateTime peorPartido, DateTime mejorPartido) : this(cantidadHinchas, cantidadPuntos, peorPartido)
        {
            this.mejorPartido = mejorPartido;
        }
        public EquipoFutbol(int cantidadHinchas, int cantidadPuntos, DateTime peorPartido, DateTime mejorPartido, DateTime fechaCreacion) : this(cantidadHinchas, cantidadPuntos, peorPartido, mejorPartido)
        {
            this.fechaCreacion = fechaCreacion;
        }



        public int CantidadHinchas
        {
            get { return this.cantidadHinchas; }
        }
        public string Apodo
        {
            get { return this.apodo; }
        }
        public string NombreEquipo
        {
            get { return this.nombreEquipo; }
        }
        public DateTime MejorPartido
        {
            get { return this.mejorPartido; }
        }

        public DateTime PeorPartido
        {
            get { return this.peorPartido; }
        }
        public DateTime FechaCreacion
        {
            get { return this.fechaCreacion; }
        }
        public int CantidadPuntos
        {
            get { return this.cantidadPuntos; }
        }


        public virtual string ObtenerApodo()
        {
            return "Equipo de Fútbol Genérico";
        }

        /// <summary>
        /// Calcula los puntos del equipo de fútbol. Debe ser implementado por las clases derivadas.
        /// </summary>
        /// <returns>La cantidad de puntos del equipo.</returns>
        public abstract int CalcularPuntos(int partidosGanados, int partidosEmpatados);


        /// <summary>
        /// Compara si el objeto actual es igual a otro objeto.
        /// </summary>
        /// <param name="obj">El objeto a comparar.</param>
        /// <returns><see langword="true"/> si son iguales, <see langword="false"/> en caso contrario.</returns>
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            EquipoFutbol other = (EquipoFutbol)obj;


            return this.CantidadHinchas == other.CantidadHinchas &&
                   this.cantidadPuntos == other.cantidadPuntos;

        }

        /// <summary>
        /// Obtiene el código hash del objeto actual.
        /// </summary>
        /// <returns>El código hash del objeto.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Sobrecarga del operador de igualdad (==) para comparar dos objetos de tipo EquipoFutbol.
        /// </summary>

    }
}
