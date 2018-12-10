using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "EJERCICIO 01";

            string[] numeros = new string[5];

            numeros = solicitarNumeros(5, 3, "reingrese un valor numerico");

            if (numeros != null)
            {
                Console.WriteLine("\n\nSe ingreso: ");
                foreach (string s in numeros)
                    Console.WriteLine(s);
            }

        }

        public static string[] solicitarNumeros(int ingresos, int intentos, string msgError)
        {
            int i, j = intentos;
            string[] aux = new string[ingresos];

            Console.WriteLine("ingrese {0} numero(s)", ingresos);
            for (i = 0; i < ingresos; i++)
            {
                aux[i] = Console.ReadLine();
                while (!IsNumeric(aux[i]) && intentos > 0)
                {
                    Console.WriteLine(msgError + "({0})", intentos);
                    aux[i] = Console.ReadLine();
                    intentos--;
                }

                if (intentos == 0)
                    return null;

                intentos = j;
            }
            return aux;
        }

        public static bool IsNumeric(string number)
        {
            int i = 0;

            foreach (char c in number)
            {
                if (c == '-' && i > 0)
                    return false;

                if ((c < '0' || c > '9') && (c != '-'))
                    return false;
                i++;
            }
            return true;
        }
    }
}




