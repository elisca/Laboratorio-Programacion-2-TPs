using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Archivos;
using ClasesAbstractas;
using ClasesInstanciables;
using Excepciones;


namespace Archivos
{
    public class Xml<T> where T:class
    {
        public bool Guardar(string archivo, T datos)
        {
            if (archivo != null && datos != null)
            {
                XmlTextWriter xmlWriter = new XmlTextWriter(archivo, Encoding.Default);
                XmlSerializer xmlSer = new XmlSerializer(typeof(T));

                xmlSer.Serialize(xmlWriter, datos);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Leer(string archivo, out T datos)
        {
            datos = null;
            if (archivo != null)
            {
                XmlTextReader xmlReader = new XmlTextReader(archivo);
                XmlSerializer xmlSer = new XmlSerializer(typeof(T));

                datos = (T)xmlSer.Deserialize(xmlReader);

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
