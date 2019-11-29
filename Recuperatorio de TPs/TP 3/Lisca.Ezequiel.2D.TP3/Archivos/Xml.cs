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
        XmlTextWriter xmlWriter;
        XmlTextReader xmlReader;
        XmlSerializer xmlSer;

        public bool Guardar(string archivo, T datos)
        {
            bool escrituraOK = false;
            xmlSer = new XmlSerializer(typeof(T));
            xmlWriter = new XmlTextWriter(archivo, Encoding.ASCII);

            try
            {
                xmlSer.Serialize(xmlWriter, datos);
                escrituraOK = true;
            }
            catch (Exception)
            {
            }
            finally
            {
                xmlWriter.Close();
            }
            return escrituraOK;
        }

        public bool Leer(string archivo, out T datos)
        {
            xmlSer = new XmlSerializer(typeof(T));
            xmlReader = new XmlTextReader(archivo);
            bool lecturaOK = false;

            try
            {
                datos = (T)xmlSer.Deserialize(xmlReader);
            }
            catch (Exception)
            {
                datos = default(T);
            }
            finally
            {
                xmlReader.Close();
            }

            return lecturaOK;
        }
    }
}
