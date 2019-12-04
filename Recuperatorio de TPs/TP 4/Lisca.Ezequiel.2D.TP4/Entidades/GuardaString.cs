using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public static class GuardaString
    {
        public static bool Guardar(this string texto, string archivo)
        {
            string rutaEscritorio = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            StringBuilder rutaArchivo = new StringBuilder();
            rutaArchivo.AppendFormat(@"{0}\{1}", rutaEscritorio, archivo);
            bool escrituraOK;

            try
            {
                using (StreamWriter swArchivo = new StreamWriter(rutaArchivo.ToString(), true))
                {
                    swArchivo.Write(texto);
                }

                escrituraOK = true;
            }
            catch (Exception)
            {
                escrituraOK = false;
            }

            return escrituraOK;
        }
    }
}
