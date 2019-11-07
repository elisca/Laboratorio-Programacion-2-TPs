using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_3
{
    public sealed class Profesor:Universitario
    {
        Queue<EClases> clasesDelDia;
        Random random;

        private void _randomClases()
        { }

        protected string MostrarDatos()
        {
            return null;
        }

        public static bool operator !=(Profesor i, EClases clase)
        {
            return false;
        }

        public static bool operator ==(Profesor i, EClases clase)
        {
            return false;
        }

        protected string ParticiparEnClase()
        {
            return null;
        }

        public Profesor()
        { }

        private Profesor()
        { }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
        { }

        public string public override string ToString()
        {
 	         return base.ToString();
        }
    }
}
