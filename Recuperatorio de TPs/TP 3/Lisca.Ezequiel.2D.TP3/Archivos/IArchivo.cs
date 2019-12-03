using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    /// <summary>
    /// Firma de los métodos de lectura y escritura para clases "Texto" y "Xml"
    /// </summary>
    /// <typeparam name="T"></typeparam>
    interface IArchivo<T>
    {
        /// <summary>
        /// Firma para método que guarda archivos con tipo de datos genérico T
        /// </summary>
        /// <param name="archivo">Ruta completa del archivo a escribir</param>
        /// <param name="datos">Datos a escribir en el archivo</param>
        /// <returns>True-Escritura con éxito, False-Sin escritura, error</returns>
        bool Guardar(string archivo, T datos);

        /// <summary>
        /// Firma para método que lee archivos con tipo de datos genérico T
        /// </summary>
        /// <param name="archivo">Ruta completa del archivo a leer</param>
        /// <param name="datos">Datos leídos en el archivo</param>
        /// <returns>True-Lectura correcta, False-Sin lectura, error</returns>
        bool Leer(string archivo, out T datos);
    }
}
