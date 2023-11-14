using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO; // Necesitas importar la clase File de System.IO

namespace Manejador_de_Equipos
{
    public class Usuario
    {
        public string nombre { get; set; } 
        public string correo { get; set; }
        public string clave { get; set; }
        public string perfil { get; set; }

        public Usuario() 
        {
            
        }


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
            catch (JsonException ex)
            {

                throw new JsonLecturaException("Error al leer el archivo JSON", ex.Message);
                
            }
            catch (IOException ex)
            {
                // Captura la excepción de E/S
                Console.WriteLine($"Error de E/S al leer el archivo JSON: {ex.Message}");
                throw new JsonLecturaException("Error de E/S al leer el archivo JSON", ex.Message);
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
