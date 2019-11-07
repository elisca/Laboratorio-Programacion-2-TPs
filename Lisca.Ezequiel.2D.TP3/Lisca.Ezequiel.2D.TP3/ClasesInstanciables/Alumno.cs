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
    public enum EEstadoCuenta
    { 
        AlDia,
        Deudor,
        Becado
    }

    public sealed class Alumno:Universitario
    {
        EClases claseQueToma;
        EEstadoCuenta estadoCuenta;

        public Alumno()
        {}

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, EClases claseQueToma)
        {}

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, EClases claseQueToma, EEstadoCuenta estadoCuenta)
        {}

        protected override string MostrarDatos()
        {
            StringBuilder datosAlumno = new StringBuilder();

            datosAlumno.AppendLine(base.ToString());
            datosAlumno.AppendLine("Clase tomada: " + this.claseQueToma.ToString());
            datosAlumno.AppendLine("Estado de cuenta: " + this.estadoCuenta.ToString());

            return datosAlumno.ToString();
        }

        public static bool operator !=(Alumno a, EClases clase)//Preguntar
        {
            return !(a==clase);
        }

        public static bool operator ==(Alumno a, EClases clase)
        {
            if (a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        protected override string ParticiparEnClase()
        {
            string claseTomada = "TOMA CLASE DE " + this.claseQueToma.ToString();

            return claseTomada;
        }

        public override string ToString()
        {
 	         return this.MostrarDatos();
        }
    }
}
