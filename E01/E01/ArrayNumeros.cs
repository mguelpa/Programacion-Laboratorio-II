using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E01
{
    public static class ArrayNumeros
    {
        public static string[] SolicitarNumeros(int ingresos, int intentos, string msgError)
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

                if (intentos < 0)
                    return null;

                intentos = j;
            }
            return aux;
        }


        public static bool IsNumeric(string number)
        {
            bool auxReturn = true;
            int count = 0;
            int flag = 0;

            foreach (char c in number)
            {            
                if (c == '-' && count == 0)
                {
                    flag++;
                    continue;
                }
                if ((c < '0' || c > '9'))
                    auxReturn = false;
                count++;
            }
            if(flag > 0 && count == 0)
            {
                auxReturn = false;
            }
            return auxReturn;
        }

        public static void MostrarNumeros(string[] numeros)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Se ingreso el conjunto: { ");
            foreach (string s in numeros)
            {
                sb.Append(s + ", ");
            }
            sb.Remove(sb.Length-2, 2);
            sb.Append(" }");
            Console.WriteLine(sb.ToString());
        }

    }
}
