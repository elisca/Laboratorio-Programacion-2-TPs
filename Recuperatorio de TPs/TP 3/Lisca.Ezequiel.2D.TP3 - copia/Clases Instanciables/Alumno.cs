using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Abstractas;

namespace Clases_Instanciables
{
    public sealed class Alumno:Universitario
    {
        public enum EEstadoCuenta
        { 
            AlDia,
            Deudor,
            Becado
        }

        Universidad.EClases claseQueToma;
        EEstadoCuenta estadoCuenta;

        public Alumno()
        { }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
        { }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
        { }

        protected override string MostrarDatos()
        {
            StringBuilder datosAlumno = new StringBuilder();

            datosAlumno.AppendFormat("ESTADO DE CUENTA: {0}\n", this.estadoCuenta.ToString());
            datosAlumno.AppendFormat("{0}\n", this.ParticiparEnClase());
            
            return datosAlumno.ToString();
        }

        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return !(a == clase);
        }

        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            return (a.claseQueToma == clase && a.estadoCuenta != Alumno.EEstadoCuenta.Deudor);
        }

        protected string ParticiparEnClase()
        {
            StringBuilder datosClase = new StringBuilder();

            datosClase.AppendFormat("TOMA CLASES DE {0}", this.claseQueToma.ToString());

            return datosClase.ToString();
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }
    }
}
