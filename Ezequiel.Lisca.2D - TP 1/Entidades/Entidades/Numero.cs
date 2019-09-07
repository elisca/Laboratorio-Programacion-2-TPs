using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        /// <summary>
        /// Valida que un string sea un número double válido y lo asigna al atributo "numero", si no fuese válido asigna cero
        /// </summary>
        private string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }

        /// <summary>
        /// Convierte un string que representa un número binario a uno decimal(sólo enteros positivos y cero)
        /// </summary>
        /// <param name="binario">String que representa a número entero positivo o cero a convertir</param>
        /// <returns>Número decimal convertido</returns>
        public static string BinarioDecimal(string binario)
        {
            bool error = false;
            string resultado;
            ulong acumRes = 0;
            int exponente;

            if (binario.Length > 0)//Comprueba que la cadena no esté vacía
            {
                for (int i = 0; i < binario.Length; i++)//Comprueba que la cadena sólo tenga ceros y unos
                {
                    if (binario[i] != '0' && binario[i] != '1')
                    {
                        error = true;
                        break;
                    }
                }
            }
            else//Si hay algún inconveniente marca la bandera de error
            {
                error = true;
            }

            if (!error)//De no haber error, convierte el número
            {
                exponente = binario.Length - 1;//Esta variable determina a que exponente se eleva el 2, en cada posición de la conversión

                for (int j = 0; j < binario.Length; j++)//Recorre el string para convertir los unos y ceros en el número decimal, se vale de un acumulador para guardar el resultado
                {
                    if (binario[j] == '1')
                    {
                        acumRes += (ulong)(Math.Pow(2, exponente));
                    }
                    exponente--;//Cuando se avanza un dígito hacia la derecha, el exponente para el próximo cálculo debe reducirse
                }

                resultado = acumRes.ToString();
            }
            else
            {
                resultado = "Valor inválido";
            }
            return resultado;
        }

        /// <summary>
        /// Convierte un número decimal positivo o cero a número binario
        /// </summary>
        /// <param name="numero">Número decimal entero positivo o cero a convertir</param>
        /// <returns>Número binario convertido</returns>
        public static string DecimalBinario(double numero)
        {
            ulong dividendo = 0;
            int exponente = 0;
            byte modNum = 0;
            string numBin = "";

            if (ulong.TryParse(numero.ToString(), out dividendo))//Comprueba si el número es un entero positivo o cero, en ese caso lo pasa a otra variable convertido
            {
                while (dividendo >= 1)//Divide recurrentemente mientras el dividendo de la operación actual sea igual a uno o mayor
                {
                    modNum = (byte)(dividendo % 2);
                    dividendo /= 2;

                    numBin = modNum + numBin;
                }
                numBin = (dividendo / 2).ToString() + numBin;//Añade el cociente de la última división al resultado
                numBin = numBin.TrimStart('0');//Si el resultado comenzáse con un cero, lo quita
            }
            else
            {
                numBin = "Valor inválido";
            }

            return numBin;
        }

        /// <summary>
        /// Convierte un número(string) decimal a binario (llama a la otra sobrecarga luego de convertir el string a número)
        /// </summary>
        /// <param name="numero">Número a convertir</param>
        /// <returns>Retorna el número del argumento convertido a binario, el resultado se trae de la otra sobrecarga</returns>
        public static string DecimalBinario(string numero)
        {
            double auxNum;

            if (numero.Length > 0 && double.TryParse(numero, out auxNum))//Comprueba que el string no esté vacío y que corresponda a un número
            {
                return DecimalBinario(auxNum);
            }
            else
            {
                return "Valor inválido";
            }
        }

        /// <summary>
        /// Constructor por defecto, si no se especifica el valor del atributo del objeto, se inicializa en cero
        /// </summary>
        public Numero():this(0)//Llamada a otra sobrecarga
        { }

        /// <summary>
        /// Constructor de instancia, solicita el valor a asignar al atributo del objeto
        /// </summary>
        /// <param name="numero">Valor que se cargará en número</param>
        public Numero(double numero)
        {
            this.numero = numero;
        }

        /// <summary>
        /// Constructor de instancia, previa validación que realiza la propiedad que utiliza y conversión del string a número, asigna un valor al atributo del objeto
        /// </summary>
        /// <param name="strNumero">Cadena que contendría al número a asignar</param>
        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }

        /// <summary>
        /// Sobrecarga de "-", toma dos objetos y los resta
        /// </summary>
        /// <param name="n1">Número 1</param>
        /// <param name="n2">Número 2</param>
        /// <returns>Resultado de la resta de los atributos de ambos números</returns>
        public static double operator -(Numero n1, Numero n2)
        {
            double auxRes = 0;

            auxRes = n1.numero - n2.numero;
            return auxRes;
        }

        /// <summary>
        /// Sobrecarga de "*", toma dos objetos y los multiplica
        /// </summary>
        /// <param name="n1">Número 1</param>
        /// <param name="n2">Número 2</param>
        /// <returns>Resultado del producto de los atributos de ambos números</returns>
        public static double operator *(Numero n1, Numero n2)
        {
            double auxRes = 0;

            auxRes = n1.numero * n2.numero;
            return auxRes;
        }

        /// <summary>
        /// Sobrecarga de "-", toma dos objetos y los divide
        /// </summary>
        /// <param name="n1">Número 1</param>
        /// <param name="n2">Número 2</param>
        /// <returns>Resultado del cociente de los atributos de ambos números</returns>
        public static double operator /(Numero n1, Numero n2)
        {
            double auxRes = double.MinValue;

            if (n2.numero != 0)//Comprueba que no se realice una división por cero antes de calcular el resultado, caso contrario devuelve "double.MinValue"
            {
                auxRes = n1.numero / n2.numero;
            }
            return auxRes;
        }

        /// <summary>
        /// Sobrecarga de "+", toma dos objetos y los suma
        /// </summary>
        /// <param name="n1">Número 1</param>
        /// <param name="n2">Número 2</param>
        /// <returns>Resultado de la suma de los atributos de ambos números</returns>
        public static double operator +(Numero n1, Numero n2)
        {
            double auxRes = 0;

            auxRes = n1.numero + n2.numero;
            return auxRes;
        }

        /// <summary>
        /// Valida que un string sea un número válido para asignar a un objeto "Numero"
        /// </summary>
        /// <param name="strNumero">String que contendría al número</param>
        /// <returns>Número que contenía la cadena</returns>
        private double ValidarNumero(string strNumero)
        {
            double auxNum;

            if (!double.TryParse(strNumero, out auxNum))
            {
                auxNum = 0;
            }
            return auxNum;
        }
    }
}
