using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manejador_de_Equipos
{
    /// <summary>
    /// Excepción personalizada lanzada al producirse un error durante la lectura de JSON.
    /// </summary>
    public class JsonLecturaException : Exception
    {
        /// <summary>
        /// Obtiene detalles adicionales sobre el error de lectura de JSON.
        /// </summary>
        public string DetallesErrorJson { get; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="JsonLecturaException"/>.
        /// </summary>
        /// <param name="mensaje">Mensaje de error.</param>
        /// <param name="detallesErrorJson">Detalles adicionales sobre el error de lectura de JSON.</param>
        public JsonLecturaException(string mensaje, string detallesErrorJson) : base(mensaje)
        {
            DetallesErrorJson = detallesErrorJson;
        }   
    }
}
