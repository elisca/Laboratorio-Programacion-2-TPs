using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public class Correo
    {
        List<Thread> mockPaquetes;
        List<Paquete> paquetes;

        public List<Paquete> Paquetes
        {
            get;
            set;
        }

        public Correo()
        {
        }
        
        public void FinEntregas()
        { }

        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            return null;
        }

        public static Correo operator +(Correo c, Paquete p)
        {
            return c;
        }
    }
}
