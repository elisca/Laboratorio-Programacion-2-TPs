using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class SinProfesorException : Exception
    {
        /// <summary>
        /// Cuando no hay profesor que dicte una clase, se lanza esta excepción
        /// </summary>
        public SinProfesorException() : base("No hay profesor para la clase.")
        {}
    }
}
