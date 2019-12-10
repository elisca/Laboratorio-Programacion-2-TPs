using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        int legajo; //También conocido como "id" en las sobrecargas de constructor

        /// <summary>
        /// Compara a la instancia de esta clase con otro objeto para saber si el legajo de ambos es el mismo
        /// </summary>
        /// <param name="obj">Objeto a comparar contra la instancia actual</param>
        /// <returns>True- Ambos objetos tienen el mismo legajo, False- Ambos objetos tienen legajos distintos</returns>
        public override bool Equals(object obj)
        {
            return (this.legajo == ((Universitario)obj).legajo);
        }

        /// <summary>
        /// Retorna datos del universitario (y de su clase base Persona)
        /// </summary>
        /// <returns>Datos del universitario</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder datosUniversitario = new StringBuilder();

            datosUniversitario.AppendFormat("{0}", base.ToString());
            datosUniversitario.AppendFormat("\nLEGAJO NÚMERO: {0}\n", this.legajo);

            return datosUniversitario.ToString();
        }

        /// <summary>
        /// Ambos universitarios son distintos
        /// </summary>
        /// <param name="pg1">Universitario 1</param>
        /// <param name="pg2">Universitario 2</param>
        /// <returns>True- Universitarios distintos, False- Ambos universitarios son el mismo</returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        /// <summary>
        /// Ambos universitarios son del mismo y tienen el mismo legajo
        /// </summary>
        /// <param name="pg1">Universitario 1</param>
        /// <param name="pg2">Universitario 2</param>
        /// <returns>True- Ambos universitarios son del mismo y tienen el mismo legajo, False- Universitarios distintos</returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            return (pg1.Equals(pg2) && pg1.GetType() == pg2.GetType());
        }

        /// <summary>
        /// Abstracto
        /// </summary>
        /// <returns>Retornaría un string en su implementación</returns>
        protected abstract string ParticiparEnClase();

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Universitario()
        { }

        /// <summary>
        /// Crea un universitario con sus datos cargados
        /// </summary>
        /// <param name="legajo">Legajo</param>
        /// <param name="nombre">Nombre</param>
        /// <param name="apellido">Apellido</param>
        /// <param name="dni">DNI</param>
        /// <param name="nacionalidad">Nacionalidad (Argentino-Extranjero)</param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad):base(nombre, apellido, nacionalidad)
        {
            this.legajo = legajo;
            this.StringToDNI = dni;
        }
    }
}
