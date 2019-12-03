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
            bool escrituraOk = true;

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
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Leer(string archivo, out string datos)
        {
            bool lecturaOk = true;

            try
            {
                using (sr = new StreamReader(archivo))
                {
                    datos = sr.ReadToEnd();
                }
            }
            catch (Exception)
            {
                lecturaOk = false;
                datos = null;
            }

            return lecturaOk;
        }
    }
}
