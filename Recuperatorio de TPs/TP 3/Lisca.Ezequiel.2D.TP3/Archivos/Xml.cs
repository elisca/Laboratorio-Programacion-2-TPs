using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;

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

            try //Intenta serializar los datos recibidos a un archivo y marca la bandera
            {
                xmlWriter = new XmlTextWriter(archivo, Encoding.ASCII); //Instancia de escritura preparada con ruta y codificación ASCII
                xmlSer.Serialize(xmlWriter, datos);
                escrituraOK = true;
            }
            catch (Exception e) //En caso de error, captura la excepcion y crea ArchivosException incluyendo la previa
            {
                throw new ArchivosException(e);
            }
            finally //Cierra la instancia de escritura de archivos para liberarla si no es null
            {
                if (xmlWriter != null)
                {
                    xmlWriter.Close();
                }
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
            bool lecturaOK = false; //Bandera de estado de proceso

            try //Intenta leer un archivo XML y realizar la salida de datos del método por medio del argumento
            {
                xmlReader = new XmlTextReader(archivo); //Instancia para lectura de archivos XML
                datos = (T)xmlSer.Deserialize(xmlReader);
            }
            catch (Exception e) //En caso de error, captura la excepcion y crea ArchivosException incluyendo la previa
            {
                datos = default(T);
                throw new ArchivosException(e);
            }
            finally //Cierra la instancia para leer archivos con el fin de liberarla si no es null
            {
                if (xmlReader != null)
                {
                    xmlReader.Close();
                }
            }

            return lecturaOK; //Devuelve el estado del proceso
        }
    }
}
