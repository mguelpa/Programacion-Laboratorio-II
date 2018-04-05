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

            while(operador[i] != 10)
            {
                if (operador[i] != '+' || operador[i] != '-' || operador[i] != '/' || operador[i] != '*')
                {
                    return char.ToString('+'); 
                }
                i++;
            }
            return operador;
        }

        public static double Operar(int valueA, int valueB, string operador)
        {
            double resultado = 0;

            switch(operador[0])
            {
                case '+':
                    resultado = valueA + valueB;
                    break;
                case '-':
                    resultado = valueA - valueB;
                    break;
                case '/':
                    resultado = valueA / valueB;
                    break;
                case '*':
                    resultado = valueA * valueB;
                    break;
            }
            return resultado;
        }
    }
}


