using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Clases_Instanciables
{
    public class Universidad
    {
        public enum EClases
        { 
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }

        List<Alumno> alumnos;
        List<Jornada> jornada;
        List<Profesor> profesores;

        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }

            set
            {
                this.alumnos = value;
            }
        }

        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }

            set
            {
                this.profesores = value;
            }
        }

        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornada;
            }

            set
            {
                this.jornada = value;
            }
        }

        public Jornada this[int i]
        {
            get
            {
                return this.jornada[i];
            }

            set
            {
                this.jornada[i] = value;
            }
        }

        public bool Guardar(Universidad uni)
        {
            return false;
        }

        public Universidad Leer()
        {
            return null;
        }

        static string MostrarDatos(Universidad uni)
        {
            StringBuilder datosUniversidad = new StringBuilder();

            foreach (Jornada auxJornada in uni.Jornadas)
            {
                datosUniversidad.AppendFormat(auxJornada.ToString());
            }

            return datosUniversidad.ToString();
        }

        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        public static Profesor operator !=(Universidad u, EClases clase)
        {
            foreach (Profesor auxProfesor in u.Instructores)
            {
                if (auxProfesor != clase)
                {
                    return auxProfesor;
                }
            }

            throw new SinProfesorException();
        }

        public static Universidad operator +(Universidad g, EClases clase)
        {
            Jornada auxJornada;
            Profesor auxProfesor;
            List<Alumno> auxListaAlumnos = new List<Alumno>();

            auxProfesor = (g == clase);
            auxJornada = new Jornada(clase, auxProfesor);

            foreach (Alumno auxAlumno in g.Alumnos)
            {
                if (auxAlumno == clase)
                {
                    auxListaAlumnos.Add(auxAlumno);
                }
            }

            if (auxListaAlumnos != null)
            {
                auxJornada.Alumnos = auxListaAlumnos;
            }
            g.Jornadas.Add(auxJornada);

            return g;
        }

        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u != a)
            {
                u.Alumnos.Add(a);
                return u;
            }
            else
            {
                throw new AlumnoRepetidoException();
            }
        }

        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (u != i)
            {
                u.Instructores.Add(i);
            }

            return u;
        }

        public static bool operator ==(Universidad g, Alumno a)
        {
            return g.Alumnos.Contains(a);
        }

        public static bool operator ==(Universidad g, Profesor i)
        {
            return g.Instructores.Contains(i);
        }

        public static Profesor operator ==(Universidad u, EClases clase)
        {
            foreach (Profesor auxProfesor in u.Instructores)
            {
                if (auxProfesor == clase)
                {
                    return auxProfesor;
                }
            }

            throw new SinProfesorException();
        }

        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }

        public Universidad()
        {
            this.Alumnos = new List<Alumno>();
            this.Instructores = new List<Profesor>();
            this.Jornadas = new List<Jornada>();
        }
    }
}
