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
            int i = 0;

            while (operador[i] != 10)
            {
                if (operador[i] != 43 || operador[i] != 45 || operador[i] != 42 || operador[i] != 47)
                {
                    return "+";
                }
                i++;
            }
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
