using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Archivos;
using ClasesAbstractas;
using ClasesInstanciables;
using Excepciones;

namespace ClasesInstanciables
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
        List<Jornada> jornadas;
        List<Profesor> profesores;

        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                if (value != null)
                {
                    this.alumnos = value;
                }
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
                if (value != null)
                {
                    this.profesores = value;
                }
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
                if (value != null)
                {
                    this.jornadas = value;
                }
            }
        }

        public Jornada this[int i]
        {
            get
            {
                if (i >= 0 && i < this.jornadas.Count)
                {
                    return this.jornadas[i];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (i >= 0 && i < this.jornadas.Count)
                {
                    this.jornadas[i] = value;
                }
            }
        }

        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> claseXml = new Xml<Universidad>();
            return claseXml.Guardar("universidad.xml", uni);
        }

        public static Universidad Leer()
        {
            Universidad auxUniversidad = new Universidad();
            Xml<Universidad> claseXml = new Xml<Universidad>();

            claseXml.Leer("universidad.xml", out auxUniversidad);
            return auxUniversidad;
        }

        static string MostrarDatos(Universidad uni)
        {
            StringBuilder datosUniversidad = new StringBuilder();

            datosUniversidad.AppendLine("UNIVERSIDAD");
            datosUniversidad.AppendLine("Alumnos:");
            
            foreach(Alumno auxAlumno in uni.Alumnos)
            {
                datosUniversidad.AppendLine(auxAlumno.ToString());
            }

            datosUniversidad.AppendLine("Profesores:");

            foreach (Profesor auxProfesor in uni.Instructores)
            {
                datosUniversidad.AppendLine(auxProfesor.ToString());
            }

            datosUniversidad.AppendLine("Jornadas:");

            foreach (Jornada auxJornada in uni.Jornadas)
            {
                datosUniversidad.AppendLine(auxJornada.ToString());
            }

            return datosUniversidad.ToString();
        }

        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g==a);
        }

        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g==i);
        }

        public static Profesor operator !=(Universidad u, EClases clase)
        {
            foreach (Profesor xProfesor in u.Instructores)
            {
                if (xProfesor != clase)
                {
                    return xProfesor;
                }
            }

            throw new SinProfesorException();
        }

        public static Universidad operator +(Universidad g, EClases clase)
        {
            Jornada auxJornada;
            Profesor auxProfesor = null;
            List<Alumno> auxAlumnos;

            foreach (Profesor xProfesor in g.Instructores)
            {
                if (xProfesor == clase)
                {
                    auxProfesor = xProfesor;
                    break;
                }
            }

            if (auxProfesor != null)
            {
                auxJornada = new Jornada(clase, auxProfesor);
                auxAlumnos = new List<Alumno>();

                foreach (Alumno xAlumno in g.Alumnos)
                {
                    if (xAlumno == clase)
                    {
                        auxAlumnos.Add(xAlumno);
                    }
                }

                auxJornada.Alumnos = auxAlumnos;

                g.jornadas.Add(auxJornada);
            }
            
            return g;
        }

        public static Universidad operator +(Universidad u, Alumno a)
        {
            List<Alumno> listaAlumnos;

            if (u != a)
            {
                listaAlumnos = u.Alumnos;
                listaAlumnos.Add(a);
                u.Alumnos = listaAlumnos;

                return u;
            }
            else
            {
                throw new AlumnoRepetidoException();
            }

        }

        public static Universidad operator +(Universidad u, Profesor i)
        {
            List<Profesor> listaProfesores;

            if (u != i)
            {
                listaProfesores = u.Instructores;
                listaProfesores.Add(i);
                u.Instructores = listaProfesores;
            }

            return u;
        }

        public static bool operator ==(Universidad g, Alumno a)
        {
            bool alumnoInscripto = false;

            foreach (Alumno auxAlumno in g.Alumnos)
            {
                if (auxAlumno == a)
                {
                    alumnoInscripto = true;
                    break;
                }
            }

            return alumnoInscripto;
        }

        public static bool operator ==(Universidad g, Profesor i)
        {
            bool profesorHabilitado = false;

            foreach (Profesor auxProfesor in g.Instructores)
            {
                if (auxProfesor == i)
                {
                    profesorHabilitado = true;
                    break;
                }
            }

            return profesorHabilitado;
        }

        public static Profesor operator ==(Universidad u, EClases clase)
        {
            foreach (Profesor xProfesor in u.Instructores)
            {
                if (xProfesor == clase)
                {
                    return xProfesor;
                }
            }

            throw new SinProfesorException();
        }

        public override string ToString()
        {
 	         return Universidad.MostrarDatos(this);
        }

        public Universidad()
        {}
    }
}
