using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Archivos
{
    public class Texto:IArchivo<string>
    {
        StreamReader sr;
        StreamWriter sw;

        public bool Guardar(string archivo, string datos)
        {
            if (archivo == "" || archivo == null || datos == null)
            {
                return false;
            }
            else
            {
                using (sw = new StreamWriter(archivo, false, Encoding.Default))
                {
                    sw.Write(datos);
                }

                return true;
            }
        }

        public bool Leer(string archivo, out string datos)
        {
            datos = null;
            if (archivo == "" || archivo == null || datos == null)
            {
                return false;
            }
            else
            {
                using (sr = new StreamReader(archivo, Encoding.Default))
                {
                    datos = (string)sr.ReadToEnd();
                }
                return true;
            }
        }
    }
}
