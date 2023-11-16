using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using System.Linq.Expressions;
using FutbolArgentino;

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
        public List<NuevoEquipoFutbol> ObtenerListaDatos()
        {
            List<NuevoEquipoFutbol> lista = new List<NuevoEquipoFutbol>();
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

                    NuevoEquipoFutbol equipo = new NuevoEquipoFutbol();
                    equipo.id = (int)this.lector["id"];
                    equipo.NombreEquipo = (string)this.lector["equipo"];
                    equipo.Apodo = (string)this.lector["apodo"];
                    equipo.CantidadHinchas = (int)this.lector["hinchas"];
                    equipo.PeorPartido = (DateTime)this.lector["peorPartido"];
                    equipo.CantidadPuntos = (int)this.lector["puntos"];
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

        public bool AgregarDato(NuevoEquipoFutbol e)
        {
            bool retorno = false;
            try
            {
                this.comando = new SqlCommand();
                this.comando.CommandType = System.Data.CommandType.Text;

                // Utilizando parámetros SQL para prevenir inyección y problemas de formato de fecha
                this.comando.CommandText = "INSERT INTO tabla_equipos (equipo, apodo, hinchas, peorPartido, puntos) " +
                                           "VALUES(@equipo, @apodo, @hinchas, @peorPartido, @puntos)";

                this.comando.Parameters.AddWithValue("@equipo", e.NombreEquipo);
                this.comando.Parameters.AddWithValue("@apodo", e.Apodo);
                this.comando.Parameters.AddWithValue("@hinchas", e.CantidadHinchas);
                this.comando.Parameters.AddWithValue("@peorPartido", e.PeorPartido.ToString("yyyy-MM-dd")); // Formatear la fecha correctamente
                this.comando.Parameters.AddWithValue("@puntos", e.CantidadPuntos);

                this.comando.Connection = this.conexion;

                this.conexion.Open();

                int filasAfectadas = this.comando.ExecuteNonQuery();

                if (filasAfectadas == 1)
                {
                    retorno = true;
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción (puedes agregar código para registrarla o manejarla de alguna manera específica)
            }
            finally
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }
            return retorno;
        }

        public bool ModificarDato(NuevoEquipoFutbol e)
        {
            bool retorno = false;
            try
            {
                this.comando = new SqlCommand();
                this.comando.CommandType = System.Data.CommandType.Text;
                this.comando.Parameters.AddWithValue("@equipo", e.NombreEquipo);
                this.comando.Parameters.AddWithValue("@apodo", e.Apodo);
                this.comando.Parameters.AddWithValue("@hinchas", e.CantidadHinchas);
                this.comando.Parameters.AddWithValue("@peorPartido", e.PeorPartido.ToString("yyyy-MM-dd")); // Formatear la fecha correctamente
                this.comando.Parameters.AddWithValue("@puntos", e.CantidadPuntos);
                this.comando.CommandType = System.Data.CommandType.Text;
                //ATENTO AL WHERE
                this.comando.CommandText = $"UPDATE tabla_equipos SET equipo = @equipo, apodo = @apodo, hinchas = @hinchas, peorPartido = @peorPartido, puntos = @puntos WHERE equipo = @equipo";
                this.comando.Connection = this.conexion;

                this.conexion.Open();

                int filasAfectadas = this.comando.ExecuteNonQuery();

                if (filasAfectadas == 1)
                {
                    retorno = true;
                }
            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }
            return retorno;
        }

        public bool EliminarDato(NuevoEquipoFutbol e)
        {
            bool retorno = false;
            try
            {
                this.comando = new SqlCommand();
                this.comando.CommandType = System.Data.CommandType.Text;
                this.comando.Parameters.AddWithValue("@equipo", e.NombreEquipo);
                this.comando.CommandType = System.Data.CommandType.Text;
                //ATENTO AL WHERE
                this.comando.CommandText = "DELETE FROM tabla_equipos WHERE equipo = @equipo";
                this.comando.Connection = this.conexion;

                this.conexion.Open();

                int filasAfectadas = this.comando.ExecuteNonQuery();

                if (filasAfectadas == 1)
                {
                    retorno = true;
                }
            }
            catch (Exception ex)
            {
                
            }
            finally 
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }
            return retorno;
        }

    }

}
