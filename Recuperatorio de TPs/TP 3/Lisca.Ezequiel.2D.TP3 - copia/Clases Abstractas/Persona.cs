using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Clases_Abstractas
{
    public abstract class Persona
    {
        public enum ENacionalidad
        { 
            Argentino,
            Extranjero
        }

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
                if(ValidarNombreApellido(value) != null)
                {
                    this.apellido = value;
                }
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
                this.dni = ValidarDni(this.Nacionalidad, value);
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
                if (ValidarNombreApellido(value) != null)
                {
                    this.nombre = value;
                }
            }
        }

        public string StringToDNI
        {
            get
            {
                return this.Dni.ToString();
            }
            set
            {
                this.Dni = ValidarDni(this.Nacionalidad, value);
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
            
            datosPersona.AppendFormat("NOMBRE COMPLETO: {0}, {1}\n", this.Apellido, this.Nombre);
            datosPersona.AppendFormat("NACIONALIDAD: {0}\n", this.Nacionalidad);

            return datosPersona.ToString();
        }

        int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if ((nacionalidad == ENacionalidad.Argentino && dato >= 1 && dato <= 89999999) || (nacionalidad == ENacionalidad.Extranjero && dato >= 90000000 && dato <= 99999999))
            {
                return dato;
            }
            else
            {
                throw new NacionalidadInvalidaException("Nacionalidad es incorrecta con respecto al DNI que se intenta ingresar.");
            }
        }

        int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int auxValDni;

            if (!int.TryParse(dato, out auxValDni))
            {
                throw new DniInvalidoException("El formato de DNI que se intenta ingresar no es válido.");
            }
            else
            {
                return auxValDni;
            }
        }

        string ValidarNombreApellido(string dato)
        {
            bool esValido = true;
            string auxDato = dato;

            if (auxDato.Length > 0)
            {
                auxDato = auxDato.ToUpper();

                foreach (char auxCharacter in auxDato)
                {
                    if ((auxCharacter < 'A' || auxCharacter > 'Z') && auxCharacter != ' ' && auxCharacter != 'Ñ')
                    {
                        esValido = false;
                        break;
                    }
                }
            }
            else
            {
                esValido = false;
            }

            if (esValido)
            {
                return dato;
            }
            else
            {
                return null;
            }
        }
    }
}
