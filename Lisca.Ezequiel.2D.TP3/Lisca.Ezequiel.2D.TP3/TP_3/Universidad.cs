using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_3
{
    public enum EClases
    {
        Programacion,
        Laboratorio,
        Legislacion,
        SPD
    }

    public class Universidad
    {
        List<Alumno> alumnos;
        List<Jornada> jornada;
        List<Profesor> profesores;

        public List<Alumno> Alumnos
        {
            get;
            set;
        }

        public List<Profesor> Instructores
        {
            get;
            set;
        }

        public List<Jornada> Jornadas
        {
            get;
            set;
        }

        public Jornada this[int i]
        {
            get;
            set;
        }

        public bool Guardar(Universidad uni)
        {
            return false;
        }

        public Universidad Leer()
        {
            return this;
        }

        string MostrarDatos(Universidad uni)
        {
            return false;
        }

        public static bool operator !=(Universidad g, Alumno a)
        {
            return false;
        }

        public static bool operator !=(Universidad g, Profesor i)
        {
            return false;
        }

        public static Profesor operator !=(Universidad u, EClases clase)
        {
            return null;
        }

        public Universidad operator +(Universidad g, EClases clase)
        {
            return g;
        }

        public Universidad operator +(Universidad u, Alumno a)
        {
            return u;
        }

        public Universidad operator +(Universidad u, Profesor i)
        {
            return u;
        }

        public bool operator ==(Universidad g, Alumno a)
        {
            return false;
        }

        public bool operator ==(Universidad g, Profesor i)
        { 
            return false;
        }

        public static Profesor operator ==(Universidad u, EClases clase)
        {
            return null;
        }

        public string public override string ToString()
        {
 	         return base.ToString();
        }

        public Universidad()
        {}
    }
}
