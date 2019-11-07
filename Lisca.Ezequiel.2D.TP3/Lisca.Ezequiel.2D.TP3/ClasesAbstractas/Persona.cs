using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace ClasesAbstractas
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
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = this.ValidarNombreApellido(value);
            }
        }

        public int Dni
        {
            get
            {
                return this.dni;
            }
            set
            {
                if (((value >= 1 && value <= 89999999) && this.Nacionalidad == ENacionalidad.Argentino) || ((value >= 90000000 && value <= 99999999) && this.Nacionalidad == ENacionalidad.Extranjero))
                {
                    this.dni = value;
                }
                else
                {
                    throw new NacionalidadInvalidaException();
                }
            }
        }

        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }

        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = this.ValidarNombreApellido(value);
            }
        }

        public string StringToDNI
        {
            set
            { 
                int auxDni;
                if (int.TryParse(value, out auxDni))
                {
                    this.Dni = auxDni;
                }
                else
                {
                    throw new DniInvalidoException();
                }
            }
        }

        public Persona()
        { }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad):this(nombre, apellido, nacionalidad)
        {
            this.Dni = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad):this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        public override string ToString()
        {
            StringBuilder datosPersona = new StringBuilder();

            datosPersona.AppendLine("Nombre completo: " + this.Nombre + " " + this.Apellido);
            datosPersona.AppendLine("Nacionalidad: " + this.Nacionalidad.ToString() + "DNI: " + this.Dni);

            return datosPersona.ToString();
        }

        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if (((dato >= 1 && dato <= 89999999) && this.Nacionalidad == ENacionalidad.Argentino) || ((dato >= 90000000 && dato <= 99999999) && this.Nacionalidad == ENacionalidad.Extranjero))
            {
                return dato;
            }
            else
            {
                throw new NacionalidadInvalidaException();
            }
        }

        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int auxDni;
            if (!int.TryParse(dato, out auxDni))
            {
                throw new DniInvalidoException();
            }

            return ValidarDni(nacionalidad, auxDni);
        }

        private string ValidarNombreApellido(string dato)
        {
            bool cadenaValida = true;

            foreach (char caracter in dato)
            {
                if (!((caracter >= 'a' && caracter <= 'z') || (caracter >= 'A' && caracter <= 'Z') || caracter == ' '))
                {
                    cadenaValida = false;
                    break;
                }
            }

            if (cadenaValida)
            {
                return dato;
            }
            else
            {
                return "";
            }
        }
    }
}
