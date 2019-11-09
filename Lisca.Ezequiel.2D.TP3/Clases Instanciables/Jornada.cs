using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;

namespace Clases_Instanciables
{
    public class Jornada
    {
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;

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

        public Universidad.EClases Clase
        {
            get
            {
                return this.clase;
            }
            set
            {
                this.clase = value;
            }
        }

        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                this.instructor = value;
            }
        }

        public static bool Guardar(Jornada jornada)
        {
            Texto archivoTexto = new Texto();

            if (!(archivoTexto.Guardar("jornada.txt", jornada.ToString())))
            {
                throw new ArchivosException();
            }
            else
            {
                return true;
            }
        }

        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor):this()
        {
            this.Clase = clase;
            this.Instructor = instructor;
        }

        public static string Leer()
        {
            Texto archivoTexto = new Texto();
            string datosArchivo = null;

            if (archivoTexto.Leer("jornada.txt", out datosArchivo))
            {
                return datosArchivo;
            }
            else
            {
                throw new ArchivosException();
            }
        }

        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        public static Jornada operator +(Jornada j, Alumno a)
        {
            List<Alumno> auxListaAlumnos;

            if (j != a)
            {
                auxListaAlumnos = j.Alumnos;
                auxListaAlumnos.Add(a);
                j.Alumnos = auxListaAlumnos;
            }
            return j;
        }

        public static bool operator ==(Jornada j, Alumno a)
        {
            return (j.Alumnos.Contains(a));
        }

        public override string ToString()
        {
            StringBuilder datosJornada = new StringBuilder();

            datosJornada.AppendLine("JORNADA:");
            datosJornada.AppendLine("CLASE DE " + this.Clase.ToString() + " POR " + this.Instructor.ToString());
            datosJornada.AppendLine("ALUMNOS:");
            foreach (Alumno auxAlumno in this.Alumnos)
            {
                datosJornada.AppendLine(auxAlumno.ToString());
            }

            return datosJornada.ToString();
        }
    }
}
