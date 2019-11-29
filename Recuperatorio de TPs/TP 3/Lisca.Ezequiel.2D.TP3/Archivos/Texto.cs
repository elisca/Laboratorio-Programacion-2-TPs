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
        StreamReader sr;
        StreamWriter sw;

        public bool Guardar(string archivo, string datos)
        {
            bool escrituraOk = true;

            try
            {
                using (sw = new StreamWriter(archivo, false))
                {
                    sw.Write(datos);
                }
            }
            catch (Exception)
            {
                escrituraOk = false;
            }

            return escrituraOk;
        }

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
