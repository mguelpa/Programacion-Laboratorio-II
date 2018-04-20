using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        #region METHODS
        /// <summary> 
        /// Funcion que valida el operador recibido </summary>
        /// 
        /// <param name="operador">
        /// operador recibido </param>
        ///
        /// <returns> 
        /// si op == true retorna el mismo valor recibido
        /// caso contrario retorna "+" (string) </returns>
        private static string ValidarOperador(string operador)
        {
            char aux;
            if (operador != null && operador.Length == 1)
            {
                aux = Convert.ToChar(operador);

                if ((aux != '+' && aux != '-' && aux != '*' && aux != '/'))
                {
                    operador = "+";
                }
            }
            else { operador = "+"; }

            return operador;
        }
        /// <summary>
        /// realiza una operacion entre dos datos
        /// mediante sobrecarga de operadores </summary>
        /// 
        /// <param name="num1">
        /// tipo dato Numero valor A </param>
        /// 
        /// <param name="num2">
        /// tipo dato Numero valor B </param>
        /// 
        /// <param name="operador">
        /// indica al metodo el tipo de operacion 
        /// que se va a realizar </param>
        /// 
        /// <returns> retorna el resultado de la 
        /// operacion seleccionada </returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double resultado = 0;
            string opcion = ValidarOperador(operador);


            switch (opcion[0])
            {
                case '+':
                    resultado = num1 + num2;
                    break;
                case '-':
                    resultado = num1 - num2;
                    break;
                case '/':
                    resultado = num1 / num2;
                    break;
                case '*':
                    resultado = num1 * num2;
                    break;
            }
            return resultado;
        }
        #endregion
    }
}
