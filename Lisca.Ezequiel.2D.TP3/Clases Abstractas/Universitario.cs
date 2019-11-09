using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Abstractas
{
    public abstract class Universitario:Persona
    {
        private int legajo;

        public override bool Equals(object obj)
        {
            Universitario auxObj = null;

            if (obj is Universitario)
            {
                auxObj = (Universitario)obj;
            }

            return ((this.DNI == auxObj.DNI) || (this.legajo == auxObj.legajo));
        }

        protected virtual string MostrarDatos()
        {
            StringBuilder datosUniversitario = new StringBuilder();

            datosUniversitario.AppendLine(base.ToString());
            datosUniversitario.AppendLine("LEGAJO NÚMERO: " + this.legajo);

            return datosUniversitario.ToString();
        }

        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            return (pg1.Equals(pg2));
        }

        protected abstract string ParticiparEnClase();

        public Universitario()
        { }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad):base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }
    }
}
