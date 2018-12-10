using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "EJERCICIO 1";

            int[] numeros = new int[5];

            numeros = Program.SolicitarNumeros(5, 3, "\nha ingresado un valor no valido, intente nuevamente: ");

            if (numeros != null)
            {
                Console.WriteLine(Program.MostrarNumeros(numeros));
                Console.WriteLine(Program.MostrarMaxMin(numeros));
            }
        }
        /////////////////////////////////////////////////////////////////////////////////
        public static int[] SolicitarNumeros(int ingresos, int intentos, string msgError)
        {
            int i, j = intentos;
            int[] aux = new int[ingresos];

            Console.WriteLine("ingrese {0} numero(s)", ingresos);
            for (i = 0; i < ingresos; i++)
            {
                while (!int.TryParse(Console.ReadLine(), out aux[i]))
                {
                    if (intentos == 0)
                        return null;

                    Console.WriteLine(msgError + "({0})", intentos);
                    intentos--;
                }
                intentos = j;
            }
            return aux;
        }
        /////////////////////////////////////////////////
        public static string MostrarMaxMin(int[] numeros)
        {
            int max = numeros[0], min = numeros[0];
            StringBuilder sb = new StringBuilder();
            foreach (int i in numeros)
            {
                if (i > max)
                    max = i;

                if (i < min)
                    min = i;
            }
            sb.AppendLine("El valor Maximo del conjunto es: " + max);
            sb.AppendLine("El valor Minimo del conjunto es: " + min);
            return sb.ToString();
        }
        //////////////////////////////////////////////////
        public static string MostrarNumeros(int[] numeros)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("\n\nSe ingreso el conjunto: { ");
            foreach (int i in numeros)
            {
                sb.Append(i + ", ");
            }
            sb.Remove(sb.Length - 2, 2);
            sb.Append(" }");
            return sb.ToString();
        }
    }
}
