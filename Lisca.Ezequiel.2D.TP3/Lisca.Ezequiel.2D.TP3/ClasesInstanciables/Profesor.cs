using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using ClasesAbstractas;
using ClasesInstanciables;
using Excepciones;


namespace ClasesInstanciables
{
    public sealed class Profesor:Universitario
    {
        Queue<EClases> clasesDelDia;
        static Random random;

        private void _randomClases()
        {
            this.clasesDelDia.Enqueue((EClases)Profesor.random.Next(0, 3));
        }

        protected override string MostrarDatos()
        {
            StringBuilder datosProfesor = new StringBuilder();

            datosProfesor.AppendLine(base.ToString());
            foreach (EClases auxClase in clasesDelDia)
            {
                datosProfesor.AppendLine("Clase: " + auxClase.ToString());
            }

            return datosProfesor.ToString();
        }

        public static bool operator !=(Profesor i, EClases clase)
        {
            return false;
        }

        public static bool operator ==(Profesor i, EClases clase)
        {
            bool perteneceClase = false;

            foreach (EClases auxClase in i.clasesDelDia)
            {
                if (auxClase == clase)
                {
                    perteneceClase = true;
                    break;
                }
            }
            return perteneceClase;
        }

        protected override string ParticiparEnClase()
        {
            StringBuilder clasesDia = new StringBuilder();

            clasesDia.AppendLine("CLASES DEL DIA:");
            foreach (EClases auxClase in clasesDelDia)
            {
                clasesDia.AppendLine("Clase: " + auxClase.ToString());
            }

            return clasesDia.ToString();
        }

        public Profesor()
        {
            this.clasesDelDia = new Queue<EClases>();
            for (int i = 1; i <= 2; i++)
            {
                this._randomClases();
            }
        }

        static Profesor()
        {
            Profesor.random = new Random();
        }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
        { }

        public override string ToString()
        {
 	         return this.MostrarDatos();
        }
    }
}
