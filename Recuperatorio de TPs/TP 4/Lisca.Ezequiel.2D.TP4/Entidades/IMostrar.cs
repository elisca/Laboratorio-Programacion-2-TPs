using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    interface IMostrar<T> where T: Paquete
    {
        string MostrarDatos(IMostrar<T> elemento);
    }
}
