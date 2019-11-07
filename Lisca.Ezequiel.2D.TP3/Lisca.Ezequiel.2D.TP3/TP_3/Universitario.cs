using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_3
{
    public class Universitario:Persona
    {
        int legajo;

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        protected string MostrarDatos()
        {
            return null;
        }

        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return false;
        }

        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            return false;
        }

        protected string ParticiparEnClase()
        {
            return false;
        }

        public Universitario()
        { }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
        { }
    }
}
