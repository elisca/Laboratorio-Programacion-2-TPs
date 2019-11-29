using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;

namespace Clases_Instanciables
{
    public class Jornada
    {
        List<Alumno> alumnos;
        Universidad.EClases clase;
        Profesor instructor;

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

        public bool Guardar(Jornada jornada)
        {
            Texto archivoTexto = new Texto();
            string archivo = "BaseDatos.txt";
            string datos;
            bool guardarOK = false;

            if (archivoTexto.Guardar(archivo, jornada.ToString()))
            {
                guardarOK = true;
            }

            return guardarOK;
        }

        public Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor)
        {
            this.Clase = clase;
            this.Instructor = instructor;
        }

        public string Leer()
        {
            Texto archivoTexto = new Texto();
            string archivo = "BaseDatos.txt";
            string datos = null;

            if (!(archivoTexto.Leer(archivo, out datos)))
            {
                Console.WriteLine("Error al intentar leer el archivo .");
            }
            
            return datos;
        }

        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
            {
                j.Alumnos.Add(a);
            }

            return j;    
        }

        public static bool operator ==(Jornada j, Alumno a)
        {
            return j.Alumnos.Contains(a);
        }

        public override string ToString()
        {
            StringBuilder datosJornada = new StringBuilder();

            datosJornada.AppendLine("JORNADA:");
            datosJornada.AppendFormat("CLASE DE {0} POR {1}", this.Clase.ToString(), this.Instructor.ToString());
            datosJornada.AppendLine("\nALUMNOS:");

            foreach (Alumno auxAlumno in this.Alumnos)
            {
                datosJornada.AppendLine(auxAlumno.ToString());
            }

            datosJornada.AppendLine("<------------------------------>");

            return datosJornada.ToString();
        }
    }
}
