using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E4
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Consigna
            /*
                Un número perfecto es un entero positivo, que es igual a 
                la suma de todos los enteros positivos (excluido el mismo) 
                que son divisores del número. El primer número perfecto es 6, 
                ya que los divisores de 6 son 1, 2 y 3; y 1 + 2 + 3 = 6.
                Escribir una aplicación que encuentre los 4 primeros números 
                perfectos.
                
                Nota: Utilizar estructuras repetitivas, selectivas y la 
                función módulo (%).
            */
            #endregion
            List<int> lista = Program.CalcularPrimerosCuatroNrosPerfectos();

            if (lista != null)
                Console.WriteLine(Program.MostrarNumeros(lista, "Los primeros 4 numeros perfectos son: "));        
        }

        public static string MostrarNumeros(List<int> numeros, string msg)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(msg);

            foreach (int n in numeros)
            {
                sb.AppendFormat("{0}, ", n);
            }
            sb.Remove(sb.Length - 2, 2);
            return sb.ToString();
        }
        public static List<int> CalcularPrimerosCuatroNrosPerfectos()
        {
            List<int> listaNumerosPerfectos = new List<int>();
            int dividendo = 6, divisor = 1, sum = 0;

            while(listaNumerosPerfectos.Count < 4)
            {
                while (divisor < dividendo)
                {
                    while (dividendo % divisor != 0)
                        divisor++;
                    
                    if (dividendo == divisor)
                        break;

                    sum += divisor;
                    divisor++;
                }

                if (sum == dividendo)
                    listaNumerosPerfectos.Add(dividendo);
                
                sum = 0;
                divisor = 1;
                dividendo++;
            }
            return listaNumerosPerfectos;
        }
    }
}
