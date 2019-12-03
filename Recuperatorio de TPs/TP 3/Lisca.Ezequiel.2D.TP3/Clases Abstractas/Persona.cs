using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        /// <summary>
        /// Enumerado para la nacionalidad
        /// </summary>
        public enum ENacionalidad
        { 
            Argentino,
            Extranjero
        }

        string apellido;
        int dni;
        ENacionalidad nacionalidad;
        string nombre;

        /// <summary>
        /// Lectura/Escritura del apellido de la persona
        /// </summary>
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set //Guarda un apellido si supera la validación (que tenga solo letras y que no sea nulo)
            {
                if(ValidarNombreApellido(value) != null)
                {
                    this.apellido = value;
                }
            }
        }

        /// <summary>
        /// Lectura/Escritura de un DNI
        /// </summary>
        public int Dni
        {
            get
            {
                return this.dni;
            }
            set //Guarda un DNI si la validación comprueba que es un número y que el DNI corresponde con la nacionalidad de esta persona
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
                throw new NacionalidadInvalidaException("La nacionalidad no se coincide con el número de DNI");
            }
        }

        int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int auxValDni;

            if (!int.TryParse(dato, out auxValDni))
            {
                throw new DniInvalidoException("La nacionalidad no se coincide con el número de DNI");
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
