using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Archivos
{
    public class Texto
    {
        StreamReader sr; //Instancia para leer archivos de texto
        StreamWriter sw; //Instancia para escribir archivos de texto

        /// <summary>
        /// Guarda archivos de texto
        /// </summary>
        /// <param name="archivo">Ruta completa del archivo</param>
        /// <param name="datos">Datos de texto que a guardar</param>
        /// <returns>True- Escritura satisfactoria, False- Sin escritura, error</returns>
        public bool Guardar(string archivo, string datos)
        {
            bool escrituraOk = true; //Bandera del proceso de escritura

            try //Se intenta escribir el archivo
            {
                using (sw = new StreamWriter(archivo, false))
                {
                    sw.Write(datos);
                }
            }
            catch (Exception) //En caso de error, se indica en la bandera que ocurrió un error
            {
                escrituraOk = false;
            }

            return escrituraOk; //Se retorna si el proceso pudo ser concretado o no
        }

        /// <summary>
        /// Lee archivos de texto
        /// </summary>
        /// <param name="archivo">Ruta completa del archivo</param>
        /// <param name="datos">Datos leídos del archivo</param>
        /// <returns>True- Lectura correcta, False- Sin lectura, error</returns>
        public bool Leer(string archivo, out string datos)
        {
            bool lecturaOk = true; //Bandera del proceso de lectura

            try //Intenta leer los datos del archivo de texto
            {
                using (sr = new StreamReader(archivo))
                {
                    datos = sr.ReadToEnd();
                }
            }
            catch (Exception) //En caso de error, marca la bandera y los datos devueltos son "null"
            {
                lecturaOk = false;
                datos = null;
            }

            return lecturaOk; //Devuelve el estado del proceso de lectura
        }
    }
}
