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

        /// <summary>
        /// Lee/Escribe la nacionalidad
        /// </summary>
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

        /// <summary>
        /// Lee/escribe el nombre (comprueba que sean letras y que no sea nulo el valor)
        /// </summary>
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                if (ValidarNombreApellido(value) != null) //Si supera la validación de que sean letras y no nulo, guarda el nombre
                {
                    this.nombre = value;
                }
            }
        }

        /// <summary>
        /// Lee/escribe el DNI (comprueba que sean números y que el valor corresponda con la nacionalidad)
        /// </summary>
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

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Persona()
        { }

        /// <summary>
        /// Sobrecarga de constructor
        /// </summary>
        /// <param name="nombre">Nombre</param>
        /// <param name="apellido">Apellido</param>
        /// <param name="nacionalidad">Nacionalidad (Argentino-Extranjero)</param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        /// <summary>
        /// Sobrecarga de constructor
        /// </summary>
        /// <param name="nombre">Nombre</param>
        /// <param name="apellido">Apellido</param>
        /// <param name="dni">DNI</param>
        /// <param name="nacionalidad">Nacionalidad (Argentino-Extranjero)</param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad):this(nombre, apellido, nacionalidad)
        {
            this.Dni = dni;
        }

        /// <summary>
        /// Sobrecarga de constructor
        /// </summary>
        /// <param name="nombre">Nombre</param>
        /// <param name="apellido">Apellido</param>
        /// <param name="dni">DNI</param>
        /// <param name="nacionalidad">Nacionalidad (Argentino-Extranjero)</param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad):this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        /// <summary>
        /// Retorna nombre completo y nacionalidad de una persona
        /// </summary>
        /// <returns>String, datos de una persona</returns>
        public override string ToString()
        {
            StringBuilder datosPersona = new StringBuilder();
            
            datosPersona.AppendFormat("NOMBRE COMPLETO: {0}, {1}\n", this.Apellido, this.Nombre);
            datosPersona.AppendFormat("NACIONALIDAD: {0}\n", this.Nacionalidad);

            return datosPersona.ToString();
        }

        /// <summary>
        /// Método para validación de DNI. Comprueba que el número de DNI sea congruente con respecto a la nacionalidad de la persona
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad (Argentino-Extranjero)</param>
        /// <param name="dato">Número de posible DNI</param>
        /// <returns>Número de DNI</returns>
        int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            //Comprueba nacionalidad con respecto al número de DNI ingresado
            if ((nacionalidad == ENacionalidad.Argentino && dato >= 1 && dato <= 89999999) || (nacionalidad == ENacionalidad.Extranjero && dato >= 90000000 && dato <= 99999999))
            {
                return dato;
            }
            //En caso de error en el dato ingresado, lanza una excepción ya que la nacionalidad sería incorrecta con respecto al DNI
            else
            {
                throw new NacionalidadInvalidaException("La nacionalidad no se coincide con el número de DNI");
            }
        }

        /// <summary>
        /// Método de validación. Comprueba que el dato ingresado como posible DNI corresponda a un número
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad (Argentino-Extranjero)</param>
        /// <param name="dato">Posible número de DNI</param>
        /// <returns>Número de DNI</returns>
        int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int auxValDni;

            //Intenta convertir el dato a un número y si no es posible lanza una excepción
            if (!int.TryParse(dato, out auxValDni))
            {
                throw new DniInvalidoException("La nacionalidad no se coincide con el número de DNI");
            }
            //Si el dato es un número lo retorna
            else
            {
                return auxValDni;
            }
        }

        /// <summary>
        /// Método de validación. Comprueba que el dato ingresado sean letras o un espacio para asignar al nombre o apellido de una persona
        /// </summary>
        /// <param name="dato">Dato a validar</param>
        /// <returns>Dato validado (con error retorna "null")(</returns>
        string ValidarNombreApellido(string dato)
        {
            bool esValido = true; //Bandera de dato validado
            string auxDato = dato; //Variable auxiliar para analizar el dato

            if (auxDato.Length > 0) //La cadena debe tener una longitud mayor a cero
            {
                auxDato = auxDato.ToUpper(); //Convierte cualquier letra a mayúscula

                foreach (char auxCharacter in auxDato) //Recorre como array de caracteres al dato, comprobando si son letras o espacios, en caso de encontrar algun otro caracter indica el inconveniente
                {
                    if ((auxCharacter < 'A' || auxCharacter > 'Z') && auxCharacter != ' ' && auxCharacter != 'Ñ')
                    {
                        //Como se encontró un caracter no válido se marca la bandera, posterior a esto se sale de la iteración
                        esValido = false;
                        break;
                    }
                }
            }
            else
            {
                esValido = false;
            }

            if (esValido) //Si el dato es válido lo retorna
            {
                return dato;
            }
            else //Si el dato es incorrecto retorna "null"
            {
                return null;
            }
        }
    }
}
