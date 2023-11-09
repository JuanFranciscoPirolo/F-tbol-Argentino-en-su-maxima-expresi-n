using Pirolo.JuanFrancisco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutbolArgentino
{
    /// <summary>
    /// Representa una colección genérica con capacidades extendidas.
    /// </summary>
    /// <typeparam name="T">El tipo de elementos en la colección.</typeparam>
    /// 
    [Serializable]


    public class MiColeccion<T>
    {
        public List<T> elementos = new List<T>();

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="MiColeccion{T}"/> con una lista de elementos.
        /// </summary>
        /// <param name="elementos">La lista de elementos iniciales.</param>
        public MiColeccion(List<T> elementos)
        {
            this.elementos = elementos;
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="MiColeccion{T}"/>.
        /// </summary>
        public MiColeccion()
        {
        }

        /// <summary>
        /// Sobrecarga del operador de adición (+) para agregar un elemento a la colección si no existe.
        /// </summary>
        /// <param name="coleccion">La colección a la que se agregará el elemento.</param>
        /// <param name="elemento">El elemento que se agregará.</param>
        /// <returns>La colección actualizada.</returns>
        public static MiColeccion<T> operator +(MiColeccion<T> coleccion, T elemento)
        {
            if(!coleccion.elementos.Contains(elemento))
            {
                coleccion.elementos.Add(elemento);
            }
            return coleccion;
        }

        /// <summary>
        /// Sobrecarga del operador de sustracción (-) para eliminar un elemento de la colección.
        /// </summary>
        /// <param name="coleccion">La colección de la que se eliminará el elemento.</param>
        /// <param name="elemento">El elemento que se eliminará.</param>
        /// <returns>La colección actualizada.</returns>
        public static MiColeccion<T> operator -(MiColeccion<T> coleccion, T elemento)
        {
            coleccion.elementos.Remove(elemento);
            return coleccion;
        }

        /// <summary>
        /// Comprueba si la colección contiene un elemento especificado.
        /// </summary>
        /// <param name="elemento">El elemento que se buscará en la colección.</param>
        /// <returns><see langword="true" /> si el elemento se encuentra en la colección, de lo contrario, <see langword="false" />.</returns>
        public bool Contiene(T elemento)
        {
            return this.elementos.Contains(elemento);
        }

        /// <summary>
        /// Sobrecarga del operador de igualdad (==) para comparar una colección y un elemento.
        /// </summary>
        /// <param name="coleccion">La colección a comparar.</param>
        /// <param name="elemento">El elemento a comparar.</param>
        /// <returns><see langword="true" /> si el elemento se encuentra en la colección, de lo contrario, <see langword="false" />.</returns>
        public static bool operator ==(MiColeccion<T> coleccion, T elemento)
        {
            if (coleccion is null)
            {
                return false;
            }
            return coleccion.Contiene(elemento);
        }

        /// <summary>
        /// Sobrecarga del operador de desigualdad (!=) para comparar una colección y un elemento.
        /// </summary>
        /// <param name="coleccion">La colección a comparar.</param>
        /// <param name="elemento">El elemento a comparar.</param>
        /// <returns><see langword="true" /> si el elemento no se encuentra en la colección, de lo contrario, <see langword="false" />.</returns>
        public static bool operator !=(MiColeccion<T> coleccion, T elemento)
        {
            if (coleccion is null)
            {
                return true; // Si la colección es nula, los elementos no son iguales.
            }
            return !coleccion.Contiene(elemento);
        }

        /// <summary>
        /// Ordena los elementos de la colección en orden ascendente.
        /// </summary>
        /// <returns>Una nueva lista con los elementos ordenados en orden ascendente.</returns>
        public List<T> OrdenarAscendentemente()
        {
            List<T> listaOrdenada = new List<T>(elementos);
            return listaOrdenada;
        }


        /// <summary>
        /// Ordena los elementos de la colección en orden descendente.
        /// </summary>
        /// <returns>Una nueva lista con los elementos ordenados en orden descendente.</returns>

        public List<T> OrdenarDescendentemente()
        {
            List<T> listaOrdenada = new List<T>(elementos);
            listaOrdenada.Sort((a, b) => Comparer<T>.Default.Compare(b, a));
            return listaOrdenada;
        }

    }
}
