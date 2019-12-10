using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException : Exception
    {
        /// <summary>
        /// Error de lectura o escritura de archivos de texto o XML
        /// </summary>
        /// <param name="innerException">Excepción original</param>
        public ArchivosException(Exception innerException) : base(innerException.Message, innerException)
        { }
    }
}
