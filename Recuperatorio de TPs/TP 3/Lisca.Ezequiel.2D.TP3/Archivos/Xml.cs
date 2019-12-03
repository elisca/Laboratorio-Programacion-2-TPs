using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Archivos
{
    public class Xml<T>
    {
        XmlTextWriter xmlWriter; //Instancia para escribir archivos XML
        XmlTextReader xmlReader; //Instancia para leer archivos XML
        XmlSerializer xmlSer; //Instancia para serializar/deserializar archivos XML

        /// <summary>
        /// Escribe los datos de tipo genérico T en un archivo XML
        /// </summary>
        /// <param name="archivo">Ruta completa del archivo</param>
        /// <param name="datos">Datos a ser serializados a XML</param>
        /// <returns>True- Escritura correcta, False- Sin escritura, error</returns>
        public bool Guardar(string archivo, T datos)
        {
            bool escrituraOK = false; //Bandera de estado de proceso de escritura
            xmlSer = new XmlSerializer(typeof(T)); //Instancia para serializar configurada a tipo genérico T
            xmlWriter = new XmlTextWriter(archivo, Encoding.ASCII); //Instancia de escritura preparada con ruta y codificación ASCII

            try //Intenta serializar los datos recibidos a un archivo y marca la bandera
            {
                xmlSer.Serialize(xmlWriter, datos);
                escrituraOK = true;
            }
            catch (Exception) //En caso de error no realiza acciones, solo captura la excepcion ya que la bandera era false
            {
            }
            finally //Cierra la instancia de escritura de archivos para liberarla
            {
                xmlWriter.Close();
            }
            return escrituraOK; //Devuelve el estado final del proceso
        }

        /// <summary>
        /// Lee datos de un archivo XML
        /// </summary>
        /// <param name="archivo">Ruta completa del archivo</param>
        /// <param name="datos">Salida de datos leídos del archivo</param>
        /// <returns>True- Lectura correcta, False- Sin lectura, error</returns>
        public bool Leer(string archivo, out T datos)
        {
            xmlSer = new XmlSerializer(typeof(T)); //Instancia para desearializar configurada
            xmlReader = new XmlTextReader(archivo); //Instancia para lectura de archivos XML
            bool lecturaOK = false; //Bandera de estado de proceso

            try //Intenta leer un archivo XML y realizar la salida de datos del método por medio del argumento
            {
                datos = (T)xmlSer.Deserialize(xmlReader);
            }
            catch (Exception) //En caso de error, captura la excepción y los datos de salida son los predeterminados del tipo genérico T
            {
                datos = default(T);
            }
            finally //Cierra la instancia para leer archivos con el fin de liberarla
            {
                xmlReader.Close();
            }

            return lecturaOK; //Devuelve el estado del proceso
        }
    }
}
