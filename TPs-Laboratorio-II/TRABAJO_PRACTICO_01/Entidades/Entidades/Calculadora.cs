using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
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
    }
}
