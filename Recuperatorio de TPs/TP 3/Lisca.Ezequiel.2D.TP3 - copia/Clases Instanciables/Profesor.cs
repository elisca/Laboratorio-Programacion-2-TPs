using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Abstractas;

namespace Clases_Instanciables
{
    public sealed class Profesor:Universitario
    {
        Queue<Universidad.EClases> clasesDelDia;
        static Random random;

        void _randomClases()
        {
            this.clasesDelDia.Enqueue((Universidad.EClases)random.Next(0, 3));
            this.clasesDelDia.Enqueue((Universidad.EClases)random.Next(0, 3));
        }

        protected string MostrarDatos()
        {
            StringBuilder datosInstructor = new StringBuilder();

            datosInstructor.AppendFormat("NOMBRE COMPLETO: {0}, {1}\n", this.Apellido, this.Nombre);
            datosInstructor.AppendFormat("NACIONALIDAD: {0}\n", this.Nacionalidad);
            datosInstructor.AppendFormat("LEGAJO NÚMERO: {0}", base.MostrarDatos());
            datosInstructor.AppendFormat(this.ParticiparEnClase());

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
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }

        static Profesor()
        {
            random = new Random();
        }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad):base(id, nombre, apellido, dni, nacionalidad)
        { }

        public override string ToString()
        {
            return this.MostrarDatos();
        }
    }
}
