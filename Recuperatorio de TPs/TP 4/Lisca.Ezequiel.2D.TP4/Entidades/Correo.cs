using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        List<Thread> mockPaquetes;
        List<Paquete> paquetes;

        public List<Paquete> Paquetes
        {
            get
            {
                return this.paquetes;
            }
            set
            {
                this.paquetes = value;
            }
        }

        public Correo()
        {
        }
        
        public void FinEntregas()
        {
            foreach (Thread auxThread in this.mockPaquetes)
            {
                auxThread.Abort();
            }
        }

        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            return null;
        }

        public static Correo operator +(Correo c, Paquete p)
        {
            if (c.Paquetes.Contains(p))
            {
                throw new TrackingIdRepetidoException("El paquete que se intenta agregar ya existe.");
            }
            else
            {
                c.Paquetes.Add(p);
            }

            Thread hiloPaquete = new Thread(p.MockCicloDeVida);
            c.mockPaquetes.Add(hiloPaquete);
            hiloPaquete.Start();

            return c;
        }
    }
}
