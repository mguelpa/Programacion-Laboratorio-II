using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E5
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Consigna
            /*
                Un centro numérico es un número que separa una lista 
                de números enteros(comenzando en 1) en dos grupos de 
                números, cuyas sumas son iguales. El primer centro 
                numérico es el 6, el cual separa la lista(1 a 8) en 
                los grupos: (1; 2; 3; 4; 5) y(7; 8) cuyas sumas son 
                ambas iguales a 15. El segundo centro numérico es el 
                35, el cual separa la lista(1 a49) en los grupos: 
                (1 a 34) y(36 a 49) cuyas sumas son ambas iguales a 
                595. Se pide elaborar una aplicación que calcule los 
                centros numéricos entre 1 y el número que el
                usuario ingrese por consola.
                
                Nota: Utilizar estructuras repetitivas, selectivas y 
                      la función módulo(%).
            */
            #endregion
            int numero = 0;
            List<int> centrosNumericos = null;

            if(Program.ObtenerNumeroDelUsuario("ingrese un valor mayor a 0", 3, "el valor ingresado es incorrecto o esta fuera del rango permitido: ",out numero))
                centrosNumericos = Program.CalcularCentrosNumericos(numero);

            if(centrosNumericos != null)
                Console.WriteLine(Program.MostrarNumeros(centrosNumericos, string.Format("Los centros numericos existentes hasta el nuemero {0} son:", numero)));
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
        public static List<int> CalcularCentrosNumericos(int tope)
        {
            List<int> listaCentrosNumericos = new List<int>();
            int i = 1, centroNumerico = 3, j = 4;
            int sumaDerecha = 0;
            int sumaIzquierda = 0;

            while(centroNumerico != tope)
            {
                while (i < centroNumerico){
                    sumaDerecha += i;
                    i++;
                }

                while (sumaIzquierda < sumaDerecha){
                    sumaIzquierda += j;
                    j++;
                }

                if (sumaDerecha == sumaIzquierda)
                    listaCentrosNumericos.Add(centroNumerico);
                
                centroNumerico++;
                sumaDerecha = 0;
                sumaIzquierda = 0;
                i = 1;
                j = centroNumerico + 1;
            }
            return listaCentrosNumericos;
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
    }
}
