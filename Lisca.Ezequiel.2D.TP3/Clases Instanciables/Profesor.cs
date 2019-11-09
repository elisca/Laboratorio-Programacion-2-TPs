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
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;

        private void _randomClases()
        {
            int valClaseRandom;

            for (int i = 1; i <= 2; i++)
            {
                valClaseRandom = random.Next(0, 3);
                this.clasesDelDia.Enqueue((Universidad.EClases)valClaseRandom);
            }
        }

        protected override string MostrarDatos()
        {
            StringBuilder datosProfesor = new StringBuilder();

            datosProfesor.AppendLine(base.MostrarDatos());
            datosProfesor.AppendLine(this.ParticiparEnClase());

            return datosProfesor.ToString();
        }

        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }

        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            return i.clasesDelDia.Contains(clase);
        }

        protected override string ParticiparEnClase()
        {
            StringBuilder datosClasesDelDia = new StringBuilder();

            datosClasesDelDia.AppendLine("CLASES DEL DIA:");

            foreach (Universidad.EClases auxClaseDelDia in this.clasesDelDia)
            {
                datosClasesDelDia.AppendLine("\t" + auxClaseDelDia.ToString());
            }

            return datosClasesDelDia.ToString();
        }

        public Profesor()
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
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
