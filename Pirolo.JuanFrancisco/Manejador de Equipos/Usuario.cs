using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO; // Necesitas importar la clase File de System.IO

namespace Manejador_de_Equipos
{
    public class Usuario
    {

        static string apellido { get; set; }
        public string nombre { get; set; } 
        static int legajo { get; set; }
        public string correo { get; set; }
        public string clave { get; set; }
        static string perfil { get; set; }


        /// <summary>
        /// Autentica a un usuario en el sistema mediante correo y clave.
        /// </summary>
        /// <param name="correo">Correo electrónico del usuario.</param>
        /// <param name="clave">Clave de acceso del usuario.</param>
        /// <returns>El usuario autenticado o null si la autenticación falla.</returns>
        public Usuario AutenticarUsuario(string correo, string clave)
        {

            List<Usuario> usuarios;

            try
            {
                string json = File.ReadAllText(@"../../../../Manejador de Equipos\Usuarios.json");
                usuarios = JsonSerializer.Deserialize<List<Usuario>>(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al leer el archivo JSON: " + ex.Message);
                return null;
            }


            foreach (var usuario in usuarios)
            {
                if (usuario.correo == correo && usuario.clave == clave)
                {
                    return usuario;
                }
            }

            return null;
        }

        /// <summary>
        /// Registra el acceso de un usuario en el archivo de registro de usuarios.
        /// </summary>
        /// <param name="nombreUsuario">Nombre del usuario que ha accedido.</param>
        public void RegistrarAcceso(string nombreUsuario)
        {

            string fechaHoraActual = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");


            string entradaLog = $"{fechaHoraActual} - Usuario: {nombreUsuario} ha accedido a la aplicación.";


            File.AppendAllText("usuarios.log", entradaLog + Environment.NewLine);
        }

    }
}
