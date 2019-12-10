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
        /// <summary>
        /// Lista de clases posibles
        /// </summary>
        public enum EClases
        { 
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }

        List<Alumno> alumnos; //Lista de alumnos inscriptos
        List<Jornada> jornada; //Lista de jornadas de clases que se dictan
        List<Profesor> profesores; //Lista de profesores

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

        /// <summary>
        /// Lee/Escribe una lista de profesores
        /// </summary>
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

        /// <summary>
        /// Lee/Escribe una lista de jornadas
        /// </summary>
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

        /// <summary>
        /// Indexador, maneja las jornadas de la universidad
        /// </summary>
        /// <param name="i">Índice</param>
        /// <returns>Jornada</returns>
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

        /// <summary>
        /// Guarda los datos de la universidad en una archivo XML
        /// </summary>
        /// <param name="uni">Universidad</param>
        /// <returns>True- Escritura correcta, False- No se escribe, error</returns>
        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> xmlUni = new Xml<Universidad>(); //Instancia de clase de escritura de archivo
            bool EscrituraOK = true; //Bandera de estado

            if (!(xmlUni.Guardar("Universidad.xml", uni))) //Si no se logra escribir el archivo se marca la bandera y se lanza una excepción
            {
                EscrituraOK = false;
                throw new ArchivosException(null);
            }

            return EscrituraOK; //Retorna el estado de escritura
        }

        /// <summary>
        /// Lee los datos de una universidad de un archivo XML
        /// </summary>
        /// <returns>Universidad</returns>
        public static Universidad Leer()
        {
            Xml<Universidad> xmlUni = new Xml<Universidad>(); //Instancia de clase de lectura de archivos
            Universidad auxUniversidad; //Datos leídos

            if (!(xmlUni.Leer("Universidad.xml", out auxUniversidad))) //Se intenta deserializar un XML y traer los datos, en caso de error excepción
            { 
                throw new ArchivosException(null);
            }

            return auxUniversidad; //Universidad
        }

        /// <summary>
        /// Muestra los datos de una universidad
        /// </summary>
        /// <param name="uni">Universidad</param>
        /// <returns>String, datos de la universidad</returns>
        static string MostrarDatos(Universidad uni)
        {
            StringBuilder datosUniversidad = new StringBuilder();

            //Recorre las jornadas y muestra sus datos
            foreach (Jornada auxJornada in uni.Jornadas)
            {
                datosUniversidad.AppendFormat(auxJornada.ToString());
            }

            return datosUniversidad.ToString();
        }

        /// <summary>
        /// Un alumno no pertenece a la universidad
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="a">Alumno</param>
        /// <returns>True- El alumno no pertenece a la universidad, False- El alummno pertenece a la universidad</returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// El profesor no pertenece a la universidad
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="i">Profesor</param>
        /// <returns>True- El profesor no pertenece a la universidad, False- El profesor pertenece a la universidad</returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// Primer profesor que no dicta esa clase
        /// </summary>
        /// <param name="u">Universidad</param>
        /// <param name="clase">Clase</param>
        /// <returns>Profesor</returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            foreach (Profesor auxProfesor in u.Instructores) //Recorre lista de profesores
            {
                if (auxProfesor != clase) //Si el profesor actual no da esa clase, lo retorna
                {
                    return auxProfesor;
                }
            }

            throw new SinProfesorException(); //No encontró profesor que no dicte la clase, lanza excepción
        }

        /// <summary>
        /// Agrega una clase a una universidad
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="clase">Clase a ser agregada</param>
        /// <returns>Universidad con clase incluida</returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Jornada auxJornada;
            Profesor auxProfesor;
            List<Alumno> auxListaAlumnos = new List<Alumno>();

            auxProfesor = (g == clase); //Asigna a la universidad al primer profesor que de determinada clase
            auxJornada = new Jornada(clase, auxProfesor); //Crea una jornada auxiliar con el profesor y la clase

            foreach (Alumno auxAlumno in g.Alumnos) //Si el alumno cursa esa clase lo agrega
            {
                if (auxAlumno == clase)
                {
                    auxListaAlumnos.Add(auxAlumno);
                }
            }

            auxJornada.Alumnos = auxListaAlumnos;
            g.Jornadas.Add(auxJornada);

            return g;
        }

        /// <summary>
        /// Agrega un alumno a una universidad
        /// </summary>
        /// <param name="u">Universidad</param>
        /// <param name="a">Alumno</param>
        /// <returns>Universidad</returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u != a) //Si el alumno ya no está inscripto lo agrega
            {
                u.Alumnos.Add(a);
                return u;
            }
            else //Si el alumno está inscripto devuelve una excepción
            {
                throw new AlumnoRepetidoException();
            }
        }

        /// <summary>
        /// Agrega un profesor a una universidad
        /// </summary>
        /// <param name="u">Universidad</param>
        /// <param name="i">Profesor</param>
        /// <returns>Universidad con profesor incluido (si aprueba validación)</returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (u != i) //Si el profesor no estaba inscripto lo inscribe
            {
                u.Instructores.Add(i);
            }

            return u; //Retorna la universidad con el profesor incluido (si aprueba validación)
        }

        /// <summary>
        /// Un alumno está inscripto en una universidad
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="a">Alumno</param>
        /// <returns>True- El alumno está inscripto, False- El alumno no está inscripto</returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            return g.Alumnos.Contains(a);
        }

        /// <summary>
        /// Un profesor está inscripto en la universidad
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="i">Profesor</param>
        /// <returns>True- El profesor está inscripto en la universidad, False- El profesor no está inscripto</returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            return g.Instructores.Contains(i);
        }

        /// <summary>
        /// Una clase se dicta en la universidad
        /// </summary>
        /// <param name="u"Universidad></param>
        /// <param name="clase">Clase</param>
        /// <returns>Profesor que dicta la clase</returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            foreach (Profesor auxProfesor in u.Instructores) //Busca entre los profesores
            {
                if (auxProfesor == clase) //Si el profesor actual dicta la clase retorna
                {
                    return auxProfesor;
                }
            }

            throw new SinProfesorException(); //Como no hay profesor que dicte esta clase, se lanza una excepción
        }

        /// <summary>
        /// Hace públicos los datos de la universidad
        /// </summary>
        /// <returns>String, datos de la universidad</returns>
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }

        /// <summary>
        /// Constructor por defecto, inicializa varias listas
        /// </summary>
        public Universidad()
        {
            this.Alumnos = new List<Alumno>();
            this.Instructores = new List<Profesor>();
            this.Jornadas = new List<Jornada>();
        }
    }
}
