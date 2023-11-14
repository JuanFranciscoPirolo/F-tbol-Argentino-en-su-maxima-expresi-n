using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manejador_de_Equipos
{
    public class JsonLecturaException : Exception
    {
        public string DetallesErrorJson { get; }

        public JsonLecturaException(string mensaje, string detallesErrorJson) : base(mensaje)
        {
            DetallesErrorJson = detallesErrorJson;
        }   
    }
}
