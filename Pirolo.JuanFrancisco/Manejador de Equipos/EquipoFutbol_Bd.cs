using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manejador_de_Equipos
{
    public class EquipoFutbol_Bd
    {
        public int id;
        public string equipo;
        public string apodo;
        public int hinchas;
        public DateTime peorPartido;
        public int puntos;

        public override string ToString()
        {
            return $" {equipo} || {apodo} || Hinchas: {hinchas} ||Peor partido: {peorPartido.ToString("dd/MM/yyyy")} || PUNTOS: {puntos} ";
        }

    }
}
