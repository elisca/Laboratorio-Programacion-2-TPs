using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public DniInvalidoException()
        { }

        /// <summary>
        /// Sobrecarga de la excepción, permite inner exception y un mensaje fijo
        /// </summary>
        /// <param name="e">Excepción original</param>
        public DniInvalidoException(Exception e) : base("DNI ingresado se comprueba incorrecto.", e)
        { }

        /// <summary>
        /// Sobrecarga de la excepción, permite escribir un mensaje
        /// </summary>
        /// <param name="message">Mensaje a mostrar</param>
        public DniInvalidoException(string message) : base(message)
        { }

        /// <summary>
        /// Sobrecarga de la excepción, permite escribir un mensaje y guardar el error original
        /// </summary>
        /// <param name="message">Mensaje</param>
        /// <param name="e">Error original</param>
        public DniInvalidoException(string message, Exception e) : base(message, e)
        { }
    }
}
