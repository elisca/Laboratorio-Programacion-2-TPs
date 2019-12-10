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
        List<Alumno> alumnos; //Lista de alumnos
        Universidad.EClases clase; //Clase que se dicta en la jornada
        Profesor instructor; //Profesor que dicta

        /// <summary>
        /// Lee/Escribe una lista de alumnos
        /// </summary>
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

        //Lee/Escribe cual es la clase que se dicta
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

        //Lee/Escribe quien es el profesor que dicta la jornada
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

        /// <summary>
        /// Guarda los datos de la jornada en un archivo de texto
        /// </summary>
        /// <param name="jornada">Jornada a guardar</param>
        /// <returns>True- Se escribio el archivo, False- No se escribio el archivo, error</returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto archivoTexto = new Texto(); //Instancia de clase que escribe el archivo
            string archivo = "Jornada.txt"; //Ruta completa del archivo
            bool guardarOK = false; //Bandera de estado

            if (archivoTexto.Guardar(archivo, jornada.ToString())) //Si logra escribir el archivo marca la bandera
            {
                guardarOK = true;
            }

            return guardarOK; //Retorna estado de la escritura
        }

        /// <summary>
        /// Constructor por defecto, inicializa una instancia que guarda la lista de alumnos
        /// </summary>
        public Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Sobrecarga de constructor, carga que clase se dicta y por quien, en la jornada
        /// </summary>
        /// <param name="clase">Clase a dictarse</param>
        /// <param name="instructor">Profesor</param>
        public Jornada(Universidad.EClases clase, Profesor instructor)
        {
            this.Clase = clase;
            this.Instructor = instructor;
        }

        /// <summary>
        /// Lee los datos de una jornada desde un archivo de texto
        /// </summary>
        /// <returns>String, datos de la jornada</returns>
        public static string Leer()
        {
            Texto archivoTexto = new Texto(); //Instancia de la clase que lee el archivo
            string archivo = "Jornada.txt"; //Ruta completa del archivo
            string datos = null; //Datos leídos

            if (!(archivoTexto.Leer(archivo, out datos))) //Intenta leer el archivo de texto y retornar sus datos, si no lo logra lanza una excepción
            {
                throw new ArchivosException(null);
            }
            
            return datos;
        }

        /// <summary>
        /// Un alumno no pertece a esa jornada
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno</param>
        /// <returns>True-El alumno no pertenece a esa jornada, False-El alumno pertenece a esa jornada</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Agrega un alumno a una jornada (Comprueba que no esté inscripto previamente)
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno</param>
        /// <returns>Jornada con alumno incluido</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
            {
                j.Alumnos.Add(a);
            }

            return j;    
        }

        /// <summary>
        /// Un alumno pertenece a la jornada
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno</param>
        /// <returns>True- El alumno pertenece a la jornada, False- El alumno no pertenece a la jornada</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            return j.Alumnos.Contains(a);
        }

        /// <summary>
        /// Muestra los datos de una jornada
        /// </summary>
        /// <returns>String, datos de la jornada</returns>
        public override string ToString()
        {
            StringBuilder datosJornada = new StringBuilder();

            //Muestra quien dicta la clase y de que materia es
            datosJornada.AppendLine("JORNADA:");
            datosJornada.AppendFormat("CLASE DE {0} POR {1}", this.Clase.ToString(), this.Instructor.ToString());
            datosJornada.AppendLine("\nALUMNOS:");

            //Recorre la lista de alumnos y muestra sus datos (los alumnos que pertenecen a la jornada)
            foreach (Alumno auxAlumno in this.Alumnos)
            {
                datosJornada.AppendLine(auxAlumno.ToString());
            }

            datosJornada.AppendLine("<------------------------------>");

            return datosJornada.ToString();
        }
    }
}
