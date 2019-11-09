using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;

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

        private List<Alumno> alumnos;
        private List<Jornada> jornadas;
        private List<Profesor> profesores;

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
                return this.jornadas;
            }
            set
            {
                this.jornadas = value;
            }
        }

        public Jornada this[int i]
        {
            get
            {
                if (i < 0)
                {
                    return this.Jornadas[0];
                }
                else if (i >= this.Jornadas.Count)
                {
                    return this.Jornadas[this.Jornadas.Count - 1];
                }
                else
                {
                    return this.Jornadas[i];
                }
            }
            set
            {
                if (i >= 0 && i < this.Jornadas.Count)
                {
                    this.Jornadas[i] = value;
                }
            }
        }

        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> archivoXml = new Xml<Universidad>();

            if (archivoXml.Guardar("universidad.xml", uni))
            {
                return true;
            }
            else
            {
                throw new ArchivosException();
            }
        }

        public static Universidad Leer()
        {
            Universidad auxUniversidad = null;
            Xml<Universidad> archivoXml = new Xml<Universidad>();

            if(archivoXml.Leer("universidad.xml", out auxUniversidad))
            {
                return auxUniversidad;
            }
            else
            {
                throw new ArchivosException();
            }
        }

        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder datosUniversidad = new StringBuilder();

            datosUniversidad.AppendLine("UNIVERSIDAD:");
            datosUniversidad.AppendLine("PROFESORES:");

            foreach (Profesor auxProfesor in uni.Instructores)
            {
                datosUniversidad.AppendLine(auxProfesor.ToString());
            }

            datosUniversidad.AppendLine("ALUMNOS:");

            foreach (Alumno auxAlumno in uni.Alumnos)
            {
                datosUniversidad.AppendLine(auxAlumno.ToString());
            }

            datosUniversidad.AppendLine("JORNADAS:");

            foreach (Jornada auxJornada in uni.Jornadas)
            {
                datosUniversidad.AppendLine(auxJornada.ToString());
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
            Jornada auxJornada = new Jornada(clase, g == clase);

            foreach (Alumno auxAlumno in g.Alumnos)
            {
                if (auxAlumno == clase)
                {
                    auxJornada.Alumnos.Add(auxAlumno);
                }
            }
            g.Jornadas.Add(auxJornada);

            return g;
        }

        public static Universidad operator +(Universidad g, Alumno a)
        {
            if (g != a)
            {
                g.Alumnos.Add(a);
                return g;
            }
            else
            {
                throw new AlumnoRepetidoException();
            }
        }

        public static Universidad operator +(Universidad g, Profesor i)
        {
            if (g != i)
            {
                g.Instructores.Add(i);
            }

            return g;
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
            return MostrarDatos(this);
        }

        public Universidad()
        { }
    }
}
