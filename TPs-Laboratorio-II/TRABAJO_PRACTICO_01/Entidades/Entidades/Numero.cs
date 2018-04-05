using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;
        public void SetNumero(string data)
        {
            numero = ValidarNumero(data);
        }
        public double GetNumero()
        {
            return numero;
        }
        //////////////////////////////////



        private double ValidarNumero(string strNumber)
        {
            int i = 0;

            while(strNumber[i] != 10)
            {
                if(!char.IsDigit(strNumber[i]))
                {
                    return 0;
                }
                i++;
            }
            return double.Parse(strNumber);
        }
        //////////////////////////////////////////////////////

        public static long BinarioDecimal(string strBinario)
        {
            int i = 0, j = 0;
            int number = 0;
            long resultado = 0;

            if(ValidarBinario(strBinario) != null)
            {
                for (i = strBinario.Length; i > 0; i--)
                {
                    number = (int)Char.GetNumericValue(strBinario[i - 1]);
                    resultado = resultado + number * (long)Math.Pow(2, j);
                    j++;
                }
            }
            else
            {
                Console.WriteLine("Valor Invalido");
            }

            return resultado;
        }
        //////////////////////////////////////////////////////

        private static string ValidarBinario(string strUserData)
        {
            int i = 0;

            while (i < strUserData.Length)
            {
                if (strUserData[i] < '0' || strUserData[i] > '1')
                {
                    return null;
                }
                i++;
            }
            return strUserData;
        }


        //////////////////////////////////////////////////////

        public static string DecimalBinario(string userData)
        {
            string returnAux = null;
            int length;
            int data;
            int i;

            if(int.TryParse(userData, out data))
            {
                length = GetArrayLenght(data);
                int[] resultadoBinario = new int[length];

                while (data > 1)
                {
                    resultadoBinario[length - 1] = data % 2;
                    data = data / 2;
                    length--;
                }

                resultadoBinario[length -1] = data;

                StringBuilder builder = new StringBuilder();

                for (i = 0; i < resultadoBinario.Length; i++)
                {
                    builder.Append(resultadoBinario[i]);
                }
                returnAux = builder.ToString();
            }
            else
            {
                Console.WriteLine("Valor Invalido");
                //returnAux = "Valor Invalido";
            }
            return returnAux;
        }

        private static int GetArrayLenght(int integer)
        {
            int length = 0;
            while (integer > 1)
            {
                integer = integer / 2;
                length++;
            }
            return length +1;
        }






    }
}
