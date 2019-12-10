using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Excepcion personalizada, se lanza cuando se intenta agregar un paquete con un tracking ID ya registrado
    /// </summary>
    public class TrackingIdRepetidoException : Exception
    {
        /// <summary>
        /// Excepcion con mensaje personalizado, sin excepcion previa
        /// </summary>
        /// <param name="mensaje">Mensaje a mostrar</param>
        public TrackingIdRepetidoException(string mensaje) : base(mensaje)
        { }

        /// <summary>
        /// Excepcion con mensaje personalizado, con excepcion previa
        /// </summary>
        /// <param name="mensaje">Mensaje a mostrar</param>
        /// <param name="inner">Excepcion previa</param>
        public TrackingIdRepetidoException(string mensaje, Exception inner) : base(mensaje, inner)
        { }
    }
}
