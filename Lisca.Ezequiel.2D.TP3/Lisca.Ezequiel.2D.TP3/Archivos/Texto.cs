using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using ClasesAbstractas;
using ClasesInstanciables;
using Excepciones;


namespace Archivos
{
    public class Texto:IArchivo<string>
    {
        public bool Guardar(string archivo, string datos)
        {
            return false;
        }

        public bool Leer(string archivo, out string datos)
        {
            datos = null;
            return false;
        }
    }
}
