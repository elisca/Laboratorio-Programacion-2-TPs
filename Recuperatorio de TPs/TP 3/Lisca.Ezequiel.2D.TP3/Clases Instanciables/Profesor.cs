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
        Queue<Universidad.EClases> clasesDelDia;
        static Random random;

        void _randomClases()
        {
            this.clasesDelDia.Enqueue((Universidad.EClases)random.Next(0, 3));
            Thread.Sleep(100);
            this.clasesDelDia.Enqueue((Universidad.EClases)random.Next(0, 3));
        }

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

        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }

        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            return i.clasesDelDia.Contains(clase);
        }

        protected string ParticiparEnClase()
        {
            StringBuilder datosClase = new StringBuilder();

            datosClase.AppendLine("CLASES DEL DIA:");

            foreach (Universidad.EClases auxClase in this.clasesDelDia)
            {
                datosClase.AppendLine(auxClase.ToString());
            }

            return datosClase.ToString();
        }

        public Profesor()
        {
        }

        static Profesor()
        {
            random = new Random();
        }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad):base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }
    }
}
