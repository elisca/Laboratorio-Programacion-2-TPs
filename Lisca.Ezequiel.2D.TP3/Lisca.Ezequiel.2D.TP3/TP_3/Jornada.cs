using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_3
{
    public class Jornada
    {
        List<Alumno> alumnos;
        EClases clase;
        Profesor instructor;

        public List<Alumno> Alumnos
        {
            get;
            set;
        }

        public EClases Clase
        {
            get;
            set;
        }

        public Profesor Instructor
        {
            get;
            set;
        }

        public bool Guardar(Jornada jornada)
        {
            return false;
        }

        public Jornada(EClases clase, Profesor instructor)
        { }

        public string Leer()
        {
            return null;
        }

        public static bool operator !=(Jornada j, Alumno a)
        {
            return false;
        }

        public static Jornada operator +(Jornada j, Alumno a)
        {
            return j;
        }

        public static bool operator ==(Jornada j, Alumno a)
        {
            return false;
        }

        public string public override string ToString()
        {
 	         return base.ToString();
        }
    }
}
