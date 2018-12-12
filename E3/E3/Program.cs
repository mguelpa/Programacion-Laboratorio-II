using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E3
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Consigna
            /*
                Mostrar por pantalla todos los números primos 
                hasta el número que haya ingresado el usuario
                por consola.
                    Nota: Utilizar estructuras repetitivas, 
                    selectivas y la función módulo (%).
            */
            #endregion
            Console.Title = "Ejercicio 2";

            int num;

            if (Program.ObtenerNumeroDelUsuario("ingrese un numero mayor a 0: ", 3, "Ingrese un numero valido", out num))
                Program.ImprimirResultado(Program.CalcularNumerosPrimos(num), num);
            

            Console.ReadKey();
        }

        public static bool ObtenerNumeroDelUsuario(string request, int intentos, string msgError, out int numero)
        {
            Console.WriteLine(request);
            while (!int.TryParse(Console.ReadLine(), out numero) || numero < 1)
            {
                if (intentos == 0)
                    return false;

                Console.WriteLine(msgError + "({0})", intentos);
                intentos--;
            }
            return true;
        }
        public static List<int> CalcularNumerosPrimos(int tope)
        {
            List<int> listaNumerosPrimos = new List<int>();
            int i = 2, j = 2;

            while(i<=tope)
            {
                while (i % j != 0)                 
                    j++;
               
                if (i == j)
                    listaNumerosPrimos.Add(i);
                i++;
                j = 2;
            }

            if (tope == 1)
                listaNumerosPrimos.Add(0);

            return listaNumerosPrimos;
        }
        public static void ImprimirResultado(List<int> listaNumeros, int tope)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("los numers primos existentes hasta el {0} son: \n", tope);
            foreach(int numero in listaNumeros)
            {
                sb.AppendFormat("{0}, ", numero);
            }
            sb.Remove(sb.Length -2, 2);
            Console.WriteLine(sb.ToString());
        }
    }    
}
