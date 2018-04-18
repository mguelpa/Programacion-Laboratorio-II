using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    class Program
    {
        static void Main(string[] args)
        {
            Numero num1 = new Numero("456");
            Numero num2 = new Numero(284);

            Console.WriteLine("suma = {0}", Calculadora.Operar(num1, num2, "+"));
            Console.WriteLine("resta = {0}", Calculadora.Operar(num1, num2, "-"));
            Console.WriteLine("producto = {0}", Calculadora.Operar(num1, num2, "*"));
            Console.WriteLine("division = {0}", Calculadora.Operar(num1, num2, "/"));
            Console.WriteLine("h = {0}", Calculadora.Operar(num1, num2, "h"));

            
            Console.WriteLine("{0}", Numero.ValidarBinario("0110 0100"));
            Console.WriteLine("{0}", Numero.BinarioDecimal("0100 0100 1100 0111 0101"));


            Console.ReadKey();
        }
    }
}
