using Pirolo.JuanFrancisco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FutbolArgentino
{
    [XmlRoot("EquipoFutbol")]
    public class NuevoEquipoFutbol : EquipoFutbol
    {
        public NuevoEquipoFutbol()
        {

        }
        public NuevoEquipoFutbol(string nombreEquipo, string apodo, int cantidadHinchas, DateTime peorPartido, int cantidadPuntos)
            : base(nombreEquipo, apodo, cantidadHinchas, peorPartido, cantidadPuntos)
        {

        }

        public override string ToString()
        {
            return $"Nombre: {this.nombreEquipo} || Apodo: {this.apodo} || Hinchas: {this.cantidadHinchas} || Peor partido: {this.peorPartido.ToString("dd/MM/yyyy")} || PUNTOS: {this.CantidadPuntos} ";
        }

        public override int CalcularPuntos(int partidosGanados, int partidosEmpatados)
        {
            throw new NotImplementedException();
        }

    }
}
