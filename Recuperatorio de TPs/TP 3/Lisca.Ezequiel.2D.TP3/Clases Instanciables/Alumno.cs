using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace Clases_Instanciables
{
    public sealed class Alumno:Universitario
    {
        /// <summary>
        /// Posibles estados de cuenta del alumno
        /// </summary>
        public enum EEstadoCuenta
        { 
            AlDia,
            Deudor,
            Becado
        }

        Universidad.EClases claseQueToma; //Clase que cursa actualmente
        EEstadoCuenta estadoCuenta; //Estado de cuenta

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Alumno()
        { }

        /// <summary>
        /// Crea un alumno con sus datos cargados
        /// </summary>
        /// <param name="id">Legajo</param>
        /// <param name="nombre">Nombre</param>
        /// <param name="apellido">Apellido</param>
        /// <param name="dni">DNI</param>
        /// <param name="nacionalidad">Nacionalidad (Argentino-Extranjero)</param>
        /// <param name="claseQueToma">Clase que cursa actualmente</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma):base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        /// <summary>
        /// Similar a la sobrecarga con datos anterior, incluye también el estado de cuenta del alumno
        /// </summary>
        /// <param name="id">Legajo</param>
        /// <param name="nombre">Nombre</param>
        /// <param name="apellido">Apellido</param>
        /// <param name="dni">DNI</param>
        /// <param name="nacionalidad">Nacionalidad (Argentino/Extranjero)</param>
        /// <param name="claseQueToma">Clase que cursa actualmente</param>
        /// <param name="estadoCuenta">Estado de cuenta del alumno</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta):this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }

        /// <summary>
        /// Muestra los datos del alumno
        /// </summary>
        /// <returns>String, datos personales y académicos del alumno</returns>
        protected override string MostrarDatos()
        {
            StringBuilder datosAlumno = new StringBuilder();

            datosAlumno.AppendLine(base.MostrarDatos());
            datosAlumno.AppendLine("ESTADO DE CUENTA: " + this.estadoCuenta.ToString());
            datosAlumno.AppendLine(this.ParticiparEnClase());
            
            return datosAlumno.ToString();
        }

        /// <summary>
        /// El alumno no pertece a una cursada
        /// </summary>
        /// <param name="a">Alumno</param>
        /// <param name="clase">Clase</param>
        /// <returns>True- El alumno no pertenece a esa cursada, False- El alumno pertenece a esa cursada</returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return (a.claseQueToma != clase);
        }

        /// <summary>
        /// El alumno pertece a una cursada y no es deudor
        /// </summary>
        /// <param name="a">Alumno</param>
        /// <param name="clase">Clase</param>
        /// <returns>True- El alumno pertenece a esa cursada y no es deudor, False- El alumno no pertenece a esa cursada y/o es deudor</returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            return (a.claseQueToma == clase && a.estadoCuenta != Alumno.EEstadoCuenta.Deudor);
        }

        /// <summary>
        /// Muestra la clase que toma un alumno
        /// </summary>
        /// <returns>String, clase que toma un alumno</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder datosClase = new StringBuilder();

            datosClase.AppendFormat("TOMA CLASES DE {0}", this.claseQueToma.ToString());

            return datosClase.ToString();
        }

        /// <summary>
        /// Permite acceso público a los datos del alumno
        /// </summary>
        /// <returns>String, datos del alumno</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
    }
}
