using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace Archivos
{
    public class Xml<T>:IArchivo<T>
    {
        XmlSerializer xmlSer = new XmlSerializer(typeof(T));
        XmlTextReader xmlReader;
        XmlTextWriter xmlWriter;

        public bool Guardar(string archivo, T datos)
        {
            if (archivo == "" || archivo == null)
            {
                return false;
            }
            else
            {
                xmlWriter = new XmlTextWriter(archivo, Encoding.Default);
                xmlSer.Serialize(xmlWriter, datos);
                xmlWriter.Close();

                return true;
            }
        }

        public bool Leer(string archivo, out T datos)
        {
            datos = default(T);

            if (archivo == null || archivo == "" || !File.Exists(archivo))
            {
                return false;
            }
            else
            {
                xmlReader = new XmlTextReader(archivo);
                datos = (T)xmlSer.Deserialize(xmlReader);
                xmlReader.Close();

                return true;
            }
        }
    }
}
