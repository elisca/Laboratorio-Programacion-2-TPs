using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EntidadesAbstractas;


namespace Clases_Instanciables
{
    public sealed class Profesor:Universitario
    {
        Queue<Universidad.EClases> clasesDelDia; //Cola de clases del dia
        static Random random; //Objeto Random, es para asignar una clase aleatoria

        /// <summary>
        /// Asigna de forma aleatoria dos clases al profesor
        /// </summary>
        void _randomClases()
        {
            this.clasesDelDia.Enqueue((Universidad.EClases)random.Next(0, 3));
            Thread.Sleep(100); //Espera de 100ms para que las clases aleatorias tengan menos posibilidades de ser las mismas
            this.clasesDelDia.Enqueue((Universidad.EClases)random.Next(0, 3));
        }

        /// <summary>
        /// Muestra los datos del profesor
        /// </summary>
        /// <returns>String, datos del profesor</returns>
        protected override string MostrarDatos()
        {
            StringBuilder datosInstructor = new StringBuilder();

            datosInstructor.AppendFormat(base.MostrarDatos());
            datosInstructor.AppendLine("CLASES DEL DÍA:");

            foreach (Universidad.EClases auxClaseDelDia in this.clasesDelDia)
            {
                datosInstructor.AppendLine(auxClaseDelDia.ToString());
            }

            return datosInstructor.ToString();
        }

        /// <summary>
        /// Un profesor no dicta una clase
        /// </summary>
        /// <param name="i">Profesor</param>
        /// <param name="clase">Clase</param>
        /// <returns>True- El profesor no dicta esa clase, False- El profesor dicta esa clase</returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }

        /// <summary>
        /// Un profesor dicta esa clase
        /// </summary>
        /// <param name="i">Profesor</param>
        /// <param name="clase">Clase</param>
        /// <returns>True- El profesor dicta esa clase, False- El profesor no dicta esa clase</returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            return i.clasesDelDia.Contains(clase);
        }

        /// <summary>
        /// Muestra las clases que dicta ese profesor
        /// </summary>
        /// <returns>String, clases dictadas por el profesor</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder datosClase = new StringBuilder();

            datosClase.AppendLine("CLASES DEL DIA:");

            foreach (Universidad.EClases auxClase in this.clasesDelDia)
            {
                datosClase.AppendLine(auxClase.ToString());
            }

            return datosClase.ToString();
        }

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Profesor()
        {
        }

        /// <summary>
        /// Constructor de instancia, inicializa un objeto Random
        /// </summary>
        static Profesor()
        {
            random = new Random();
        }

        /// <summary>
        /// Sobrecarga de constructor
        /// </summary>
        /// <param name="id">Legajo</param>
        /// <param name="nombre">Nombre</param>
        /// <param name="apellido">Apellido</param>
        /// <param name="dni">DNI</param>
        /// <param name="nacionalidad">Nacionalidad (Argentino-Extranjero)</param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad):base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>(); //Inicializa la cola de clases
            this._randomClases(); //Asigna dos clases aleatorias al profesor
        }

        /// <summary>
        /// Muestra los datos del profesor, los hace públicos
        /// </summary>
        /// <returns>String, datos del profesor</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
    }
}
