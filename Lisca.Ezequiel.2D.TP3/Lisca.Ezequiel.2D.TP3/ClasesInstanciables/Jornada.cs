using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Archivos;
using ClasesAbstractas;
using ClasesInstanciables;
using Excepciones;


namespace ClasesInstanciables
{
    public class Jornada
    {
        List<Alumno> alumnos;
        EClases clase;
        Profesor instructor;
        static StreamWriter sw;
        static StreamReader sr;

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

        public EClases Clase
        {
            get
            {
                return clase;
            }
            set
            {
                if ((int)value >= 0 && (int)value <= 3)
                {
                    this.clase = value;
                }
                    
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
            using (sw = new StreamWriter("jornada.txt"))
            {
                sw.Write(jornada.ToString());
            }

            return true;
        }

        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        public Jornada(EClases clase, Profesor instructor):this()
        { }

        public static string Leer()
        {
            string datosArchivo;

            using (sr = new StreamReader("jornada.txt"))
            {
                datosArchivo = sr.ReadToEnd();
            }
            
            return datosArchivo;
        }

        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j==a);
        }

        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
            {
                j.alumnos.Add(a);
            }

            return j;
        }

        public static bool operator ==(Jornada j, Alumno a)
        {
            bool alumnoParticipa = false;

            foreach (Alumno auxAlumno in j.Alumnos)
            {
                if (auxAlumno == a)
                {
                    alumnoParticipa = true;
                    break;
                }
            }

            return alumnoParticipa;
        }

        public override string ToString()
        {
            StringBuilder datosJornada = new StringBuilder();

            datosJornada.AppendLine("Clase:");
            datosJornada.AppendLine(this.Clase.ToString());
            datosJornada.AppendLine("Instructor:");
            datosJornada.AppendLine(this.Instructor.ToString());
            datosJornada.AppendLine("Alumnos:");

            foreach (Alumno auxAlumno in this.Alumnos)
            {
                datosJornada.AppendLine(auxAlumno.ToString());
            }

 	        return datosJornada.ToString();
        }
    }
}
