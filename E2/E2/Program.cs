using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Ejercicio 2";
            int num;

            if(Program.ObtenerNumeroDelUsuario("ingrese un numero: ", 3, "Ingrese un numero valido", out num))
            {
                Console.WriteLine(Program.MostrarPotencia(num, 2));
                Console.WriteLine(Program.MostrarPotencia(num, 3));
            }
            Console.ReadKey();
        }

        public static bool ObtenerNumeroDelUsuario(string request, int intentos, string msgError, out int numero)
        {
            Console.WriteLine(request);
            while (!int.TryParse(Console.ReadLine(), out numero))
            {
                if (intentos == 0)
                    return false;

                Console.WriteLine(msgError + "({0})", intentos);
                intentos--;
            }
            return true;
        }

        public static string MostrarPotencia(int num, int exponente)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0} elevedo a la {1} = {2}", num, exponente, (long)Math.Pow(num, exponente));

            return sb.ToString();
        }
    }
}
