using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {
        public enum EEstado
        { 
            Ingresado,
            EnViaje,
            Entregado
        }

        public delegate void DelegadoEstado(); //La firma del delegado hay que chequearla.
        string direccionEntrega;
        EEstado estado;
        string trackingID;

        public string DireccionEntrega
        {
            get;
            set;
        }

        public EEstado Estado
        {
            get;
            set;
        }

        public string TrackingID
        {
            get;
            set;
        }

        public void MockCicloDeVida()
        {
            Thread.Sleep(4000);
        }

        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            return null;
        }

        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }

        public static bool operator ==(Paquete p1, Paquete p2)
        {
            return p1.TrackingID == p2.TrackingID;
        }

        public Paquete(string direccionEntrega, string trackingID)
        { }

        public override string ToString()
        {
            return null;
        }
    }
}
