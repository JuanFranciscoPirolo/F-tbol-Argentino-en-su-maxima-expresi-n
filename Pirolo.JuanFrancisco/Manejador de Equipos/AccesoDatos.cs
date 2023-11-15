using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

namespace Manejador_de_Equipos
{
    public class AccesoDatos
    {
        private SqlConnection conexion; // objeto que permite conectarse a la base de datos.
        private static string cadena_conexion; //
        private SqlCommand comando; //una vez conectada la base de datos, me permite ejecutar comandos.
        private SqlDataReader lector; //contiene lo que te devuelve la consulta de sql

        //Con el constructor estatico inicializo a partir de un recurso mi cadena_conexion
        static AccesoDatos()
        {
            AccesoDatos.cadena_conexion = Properties.Resources.miConexion; //para ahorrar codigo
        }

        public AccesoDatos()
        {
            this.conexion = new SqlConnection(AccesoDatos.cadena_conexion);
        }

        public bool PruebaConexion()
        {
            bool retorno = false;

            try
            {
                this.conexion.Open();
                retorno = true;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                // si esta abierto lo cierra sino no.

                if(this.conexion.State == System.Data.ConnectionState.Open)
                {
                    this.conexion.Close();
                }
                
            }
            return retorno;
        }
        public List<EquipoFutbol_Bd> ObtenerListaDatos()
        {
            List<EquipoFutbol_Bd> lista = new List<EquipoFutbol_Bd>();
            try
            {
                this.comando = new SqlCommand();
                this.comando.CommandType = System.Data.CommandType.Text; //enumerado, consultas tipo base de datos.
                this.comando.CommandText = "select id,equipo,apodo,hinchas,peorPartido,puntos from tabla_equipos"; //consulta de la base de datos
                this.comando.Connection = this.conexion;
                this.conexion.Open();
                this.lector = this.comando.ExecuteReader(); //consulta de tipo select (reader), devuelve objeto SqlReader

                while (this.lector.Read()) // devuelve true cuando hay algo para leer, cuando se queda sin nada devuelve false y corta el bucle
                {
                    //cada iteracion del while representa una fila de la tabla

                    EquipoFutbol_Bd equipo = new EquipoFutbol_Bd();
                    equipo.id = (int)this.lector["id"];
                    equipo.equipo = (string)this.lector["equipo"];
                    equipo.apodo = (string)this.lector["apodo"];
                    equipo.hinchas = (int)this.lector["hinchas"];
                    equipo.peorPartido = (DateTime)this.lector["peorPartido"];
                    equipo.puntos = (int)this.lector["puntos"];
                    lista.Add(equipo);
                }
                this.lector.Close();

            }
            catch(Exception ex) 
            {

            }
            finally
            {
                if(this.conexion.State == System.Data.ConnectionState.Open)
                {
                    this.conexion.Close(); 
                }
                
            }

            return lista;


        }
    }

}
