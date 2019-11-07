using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_3
{
    public enum EEstadoCuenta
    { 
        AlDia,
        Deudor,
        Becado
    }

    public sealed class Alumno:Universitario
    {
        EClases claseQueToma;e
        EEstadoCuenta estadoCuenta;

        public Alumno()
        {}

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, EClases claseQueToma)
        {}

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, EClases claseQueToma, EEstadoCuenta estadoCuenta)
        {}

        protected string MostrarDatos()
        {
            return false;
        }

        public static bool operator !=(Alumno a, EClases clase)
        {
            return false;
        }

        public static bool operator ==(Alumno a, EClases clase)
        {
            return false;
        }
        
        protected string ParticiparEnClase()
        {
            return null;
        }

        public override string ToString()
        {
 	         return base.ToString();
        }
    }
}
