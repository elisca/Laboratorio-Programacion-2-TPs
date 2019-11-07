using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesAbstractas
{
    public abstract class Universitario:Persona
    {
        int legajo;

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        protected virtual string MostrarDatos()
        {
            StringBuilder datosUniversitario = new StringBuilder();

            datosUniversitario.AppendLine(base.ToString());
            datosUniversitario.AppendLine("Legajo: " + this.legajo);

            return datosUniversitario.ToString();
        }

        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1==pg2);
        }

        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            if ((pg1.GetType() == pg2.GetType()) && (pg1.legajo==pg2.legajo || pg1.Dni==pg2.Dni))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected abstract string ParticiparEnClase();

        public Universitario()
        { }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
        { }
    }
}
