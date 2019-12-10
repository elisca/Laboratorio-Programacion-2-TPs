using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Guarda la estructura de datos de los paquetes a enviar y sus hilos que indican en que proceso del envio se encuentran
    /// </summary>
    public class Correo : IMostrar<List<Paquete>>
    {
        List<Thread> mockPaquetes; //Lista de hilos activos de paquetes
        List<Paquete> paquetes; //Lista de paquetes

        /// <summary>
        /// Devuelve/Guarda una lista de paquetes
        /// </summary>
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

        /// <summary>
        /// Inicializa la lista de paquetes y de hilos de la instancia
        /// </summary>
        public Correo()
        {
            this.Paquetes = new List<Paquete>();
            this.mockPaquetes = new List<Thread>();
        }
        
        /// <summary>
        /// Revisa todos los hilos generados, todos los que se encuentren activos se abortan
        /// </summary>
        public void FinEntregas()
        {
            foreach (Thread auxThread in this.mockPaquetes)
            {
                if (auxThread.IsAlive)
                {
                    auxThread.Abort();
                }
            }
        }

        /// <summary>
        /// Muestra datos de paquetes (direccion, tracking ID y estado)
        /// </summary>
        /// <param name="elementos">Correo</param>
        /// <returns>Retorna una cadena de texto con los datos de todos los paquetes</returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            StringBuilder datosPaquetes = new StringBuilder();

            foreach (Paquete auxPaquete in ((Correo)elementos).Paquetes)
            {
                datosPaquetes.AppendLine(auxPaquete.ToString());
            }

            return datosPaquetes.ToString();
        }

        /// <summary>
        /// Agrega un paquete al correo, siempre y cuando no exista previamente
        /// </summary>
        /// <param name="c">Correo al que se agrega</param>
        /// <param name="p">Paquete a sumar</param>
        /// <returns>Correo con el nuevo paquete incluido(en caso de poder agregarse)</returns>
        public static Correo operator +(Correo c, Paquete p)
        {
            foreach(Paquete auxPaquete in c.Paquetes) //Comprueba que el paquete a agregar no se encuentre en la lista de paquetes anteriormente
            {
                if (auxPaquete == p)
                {
                    throw new TrackingIdRepetidoException("El paquete que se intenta agregar ya existe.");
                }
            }
            c.Paquetes.Add(p); //Añade el paquete a la lista
            Thread hiloPaquete = new Thread(p.MockCicloDeVida); //Genera un nuevo hilo
            c.mockPaquetes.Add(hiloPaquete); //Agrega este hilo a la lista de su tipo
            hiloPaquete.Start(); //Ejecuta hilo

            return c; //Retorna un correo con el nuevo paquete agregado en caso de agregarlo
        }
    }
}
