using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading; //Sobra
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Estructura de datos del paquete
    /// </summary>
    public class Paquete : IMostrar<Paquete>
    {
        public enum EEstado //Estados posibles en el circuito de envio de un paquete
        { 
            Ingresado,
            EnViaje,
            Entregado
        }

        public delegate void DelegadoEstado(object a, EventArgs e); //Delegado para indicar el estado de un paquete
        public delegate void DelegadoErrorBD(string mensaje); //Delegado para indicar error al intentar escribir SQL
        public event DelegadoEstado InformarEstado; //Evento para informar estado de enviok de un paquete
        public event DelegadoErrorBD EventoErrorBD; //Evento para informar error en conexion a base de datos
        string direccionEntrega; //Direccion de entrega
        EEstado estado; //Estado de envio actual
        string trackingID; //Tracking ID

        /// <summary>
        /// Escribe/Lee la direccion de entrega
        /// </summary>
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

        /// <summary>
        /// Escribe/Lee el estado en el circuito de envio
        /// </summary>
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

        /// <summary>
        /// Escribe/Lee el tracking ID
        /// </summary>
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

        /// <summary>
        /// Simula el ciclo de envio de un paquete, cambiando su estado,
        /// informando en que parte del envio se encuentra e insertando datos en la base
        /// </summary>
        public void MockCicloDeVida()
        {
            //Mientras el estado de un paquete no sea entregado se
            //hacen esperas y se avanza su estado de envio, se informa mediante un evento
            while (this.Estado != EEstado.Entregado)
            {
                Thread.Sleep(4000);
                this.Estado++;
                InformarEstado.Invoke(new object { }, EventArgs.Empty);
            }
            try //Se intenta guardar la informacion en la base de datos
            {
                PaqueteDAO.Insertar(this);
            }
            catch (Exception) //En caso de error mediante un evento se avisa que no pudo actualizarse la informacion
            {
                this.EventoErrorBD.Invoke("Error al intentar guardar datos del paquete en la base de datos");
            }
        }

        /// <summary>
        /// Muestra direccion y tracking ID de un paquete
        /// </summary>
        /// <param name="elemento">Paquete</param>
        /// <returns>Direccion y tracking ID del paquete</returns>
        public string MostrarDatos(IMostrar<Paquete> elemento) //Distinto
        {
            return string.Format("{0} para {1}", ((Paquete)elemento).TrackingID, ((Paquete)elemento).DireccionEntrega);
        }

        /// <summary>
        /// Comprueba si los tracking IDs de los paquetes son distintos
        /// </summary>
        /// <param name="p1">Paquete 1</param>
        /// <param name="p2">Paquete 2</param>
        /// <returns>True-Sus tracking IDs son distintos, False-Son iguales</returns>
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }

        /// <summary>
        /// Comprueba si los tracking IDs de los paquetes son iguales
        /// </summary>
        /// <param name="p1">Paquete 1</param>
        /// <param name="p2">Paquete 2</param>
        /// <returns>True-Sus tracking IDs son iguales, False-Son distintos</returns>
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            return p1.TrackingID == p2.TrackingID;
        }

        /// <summary>
        /// Instancia un paquete con direccion de entrega y tracking ID seteados
        /// </summary>
        /// <param name="direccionEntrega">Direccion de entrega</param>
        /// <param name="trackingID">Tracking ID</param>
        public Paquete(string direccionEntrega, string trackingID)
        {
            this.DireccionEntrega = direccionEntrega;
            this.TrackingID = trackingID;
        }

        /// <summary>
        /// Muestra informacion de un paquete, incluye su estado en el circuito de envio
        /// </summary>
        /// <returns>Informacion del paquete (direccion de entrega, tracking ID y estado)</returns>
        public override string ToString()
        {
            return string.Format("{0} Estado: {1}", this.MostrarDatos((Paquete)this), this.Estado.ToString());
        }
    }
}
