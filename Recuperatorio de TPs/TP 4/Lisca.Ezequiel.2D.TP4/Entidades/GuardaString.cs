using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    /// <summary>
    /// Escribe un archivo de texto con los datos de los paquetes en procesos de envio
    /// </summary>
    public static class GuardaString
    {
        /// <summary>
        /// Guarda un archivo de texto con la informacion de los paquetes (si existe agrega informacion, sino lo crea)
        /// </summary>
        /// <param name="texto">Datos a escribir</param>
        /// <param name="archivo">Ruta completa del archivo</param>
        /// <returns>True-Escritura exitosa, En caso de error lanza excepcion</returns>
        public static bool Guardar(this string texto, string archivo)
        {
            bool estadoArchivo = false;
            StreamWriter swArchivo = null;

            try //Intenta escribir el archivo, en caso de existir agrega informacion, caso contrario lo crea
            {
                swArchivo = new StreamWriter(archivo, true);
                swArchivo.WriteLine(texto);

                estadoArchivo = true;
            }
            catch (Exception e) //En caso de error (ruta inexistente, error en datos, etc) relanza la excepcion
            {
                throw e;
            }
            finally //Se asegura de cerrar la instancia que manipula el archivo abierto
            {
                swArchivo.Close();  
            }

            return estadoArchivo; //Retorna si el proceso de escritura pudo realizarse
        }
    }
}
