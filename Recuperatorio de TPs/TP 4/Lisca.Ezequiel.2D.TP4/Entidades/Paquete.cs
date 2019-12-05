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

        public delegate EEstado DelegadoEstado();
        public event DelegadoEstado InformarEstado;
        string direccionEntrega;
        EEstado estado;
        string trackingID;

        public string DireccionEntrega
        {
            get
            {
                return this.direccionEntrega;
            }
            set
            {
                this.direccionEntrega = value;
            }
        }

        public EEstado Estado
        {
            get
            {
                return this.estado;
            }
            set
            {
                this.estado = value;
            }
        }

        public string TrackingID
        {
            get
            {
                return this.trackingID;
            }
            set
            {
                this.trackingID = value;
            }
        }

        public void MockCicloDeVida()
        {
            while (this.Estado != EEstado.Entregado)
            {
                Thread.Sleep(4000);
                this.Estado++;
                InformarEstado.Invoke();
            }
            PaqueteDAO.Insertar(this);
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
