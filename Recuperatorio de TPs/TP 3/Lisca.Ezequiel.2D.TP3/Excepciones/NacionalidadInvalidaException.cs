using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NacionalidadInvalidaException : Exception
    {
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public NacionalidadInvalidaException()
        { }

        /// <summary>
        /// Sobrecarga de constructor, se lanza cuando el DNI no coincide con la nacionalidad del alumno
        /// </summary>
        /// <param name="message">Mensaje</param>
        public NacionalidadInvalidaException(string message) : base(message)
        { }
    }
}
