using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        int legajo;

        public bool Equals(object obj)
        {
            return (this.GetType() == obj.GetType());
        }

        protected virtual string MostrarDatos()
        {
            StringBuilder datosUniversitario = new StringBuilder();

            datosUniversitario.AppendFormat("{0}", base.ToString());
            datosUniversitario.AppendFormat("\nLEGAJO NÚMERO: {0}\n", this.legajo);

            return datosUniversitario.ToString();
        }

        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            return (pg1.Equals(pg2) && pg1.Dni == pg2.Dni);
        }

        protected abstract string ParticiparEnClase();

        public Universitario()
        { }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad):base(nombre, apellido, nacionalidad)
        {
            this.legajo = legajo;
            this.StringToDNI = dni;
        }
    }
}
