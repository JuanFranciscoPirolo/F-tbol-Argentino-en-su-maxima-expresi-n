using FutbolArgentino;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manejador_de_Equipos
{
    /// <summary>
    /// Interfaz que define operaciones comunes para la gestión de equipos.
    /// </summary>
    public interface IAcciones
    {
        /// <summary>
        /// Actualiza la colección de equipos con una nueva colección proporcionada.
        /// </summary>
        /// <param name="miColeccion">Nueva colección de equipos.</param>
        void ActualizarEquipos(MiColeccion<NuevoEquipoFutbol> miColeccion);

        /// <summary>
        /// Ordena la colección de equipos por un tópico específico, en orden ascendente o descendente.
        /// </summary>
        /// <param name="ascendenteODescendente">Indica si la ordenación es ascendente ("asc") o descendente ("desc").</param>
        /// <param name="topico">Tópico por el cual se va a ordenar la colección.</param>
        /// <returns>Entero que indica el resultado de la operación de ordenación.</returns>
        int OrdenarPorTopico(string ascendenteODescendente, string topico);

        /// <summary>
        /// Quita tildes y convierte una cadena a minúsculas.
        /// </summary>
        /// <param name="input">La cadena de entrada.</param>
        /// <returns>La cadena sin tildes y en minúsculas.</returns>
        string QuitarTildesYConvertirAMinusculas(string input);

        /// <summary>
        /// Obtiene la colección actual de equipos.
        /// </summary>
        /// <returns>Colección de equipos.</returns>
        MiColeccion<NuevoEquipoFutbol> ObtenerEquipos();

    }
}
