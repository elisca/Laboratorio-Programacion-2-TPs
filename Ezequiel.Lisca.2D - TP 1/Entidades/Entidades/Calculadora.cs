using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Realiza la operación matemática solicitada
        /// </summary>
        /// <param name="num1">Número 1</param>
        /// <param name="num2">Número 2</param>
        /// <param name="operador">Operación a realizar</param>
        /// <returns>Resultado de la operación matemática</returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double resultado = 0;
            operador = Calculadora.ValidarOperador(operador);//El operador será el que recibe esta función sólo si es válido, sino sera "+"

            //Realiza la operación solicitada
            switch (operador)
            { 
                case "+":
                    resultado = num1 + num2;
                    break;
                case "-":
                    resultado = num1 - num2;
                    break;
                case "*":
                    resultado = num1 * num2;
                    break;
                case "/":
                    resultado = num1 / num2;
                    break;
                default://Error interno
                    resultado = double.MinValue;
                    break;
            }
            
            return resultado;
        }

        /// <summary>
        /// Valida que el operador que se pide utilizar para representar una operación matemática sea válido
        /// </summary>
        /// <param name="operador">Operador solicitado</param>
        /// <returns>Si el operador es válido, retorna el mismo - Si el operador no es válido, retorna "+"</returns>
        private static string ValidarOperador(string operador)
        {
            //Si el operador no es valido, tomará el operador "+", caso contrario, retorna el operador asignado anteriormente
            if (operador != "+" && operador != "-" && operador != "*" && operador != "/")
            {
                return "+";
            }
            else
            {
                return operador;
            }
        }
    }
}
