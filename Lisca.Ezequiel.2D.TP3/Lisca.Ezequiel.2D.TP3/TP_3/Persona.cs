using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_3
{
    public enum ENacionalidad
    { 
        Argentino,
        Extranjero
    }

    public abstract class Persona
    {
        string apellido;
        int dni;
        ENacionalidad nacionalidad;
        string nombre;

        public string Apellido
        {
            get;
            set;
        }

        public int Dni
        {
            get;
            set;
        }

        public ENacionalidad Nacionalidad
        {
            get;
            set;
        }

        public string Nombre
        {
            get;
            set;
        }

        public string StringToDNI
        {
            set;
        }

        public Persona()
        { }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        { }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
        { }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
        { }

        public override string ToString()
        {
            return base.ToString();
        }

        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            return 0;
        }

        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            return 0;
        }

        private string ValidarNombreApellido(string dato)
        {
            return null;
        }
    }
}
