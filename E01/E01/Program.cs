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
            //////////////////////////////



            string[] numeros = new string[5];

            numeros = ArrayNumeros.SolicitarNumeros(5, 3, "ha ingresado un valor no valido, intente nuevamente: ");

            if (numeros != null)
                ArrayNumeros.MostrarNumeros(numeros);

        }
    }
}




