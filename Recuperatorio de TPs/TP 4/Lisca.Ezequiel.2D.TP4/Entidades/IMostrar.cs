using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Interface para metodo que muestra datos tanto de una lista de paquetes como un paquete individual
    /// </summary>
    /// <typeparam name="T">Recomendado Paquete o List<Paquetes></typeparam>
    public interface IMostrar<T>
    {
        string MostrarDatos(IMostrar<T> elemento);
    }
}
