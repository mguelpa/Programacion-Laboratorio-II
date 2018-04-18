using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        #region FIELDS
        private double numero;
        #endregion

        #region PROPERTIES
        private void SetNumero(string strValue)
        {
            this.numero = ValidarNumero(strValue);
        }
        #endregion

        #region CONSTRUCTORS
        public Numero() { }
        public Numero(double numero)
        {
            this.numero = numero;
        }
        public Numero(string strNumero)
        {
            SetNumero(strNumero);
        }
        #endregion

        #region METHODS
        private double ValidarNumero(string strNumber)
        {
            int i = 0;

            for (i = 0; i < strNumber.Length; i++)
            {
                if (!char.IsDigit(strNumber[i]))
                {
                    return 0;
                }
            }
            return double.Parse(strNumber);
        }

        public static string ValidarBinario(string strUserData)
        {
            int i = 0;

            while (i < strUserData.Length)
            {
                if (strUserData[i] != ' ' || (strUserData[i] == ' ' && strUserData[i-1] == ' '))
                {
                    if (strUserData[i] != '0')
                    {
                        if (strUserData[i] != '1')
                        {
                            return null;
                        }
                    }
                }               
                i++;
            }
            return strUserData;
        }

        public static string BinarioDecimal(string binario)
        {
            int i = 0, j = 0;
            int aux = 0;
            long resultado = 0;

            if (ValidarBinario(binario) != null)
            {
                for (i = binario.Length; i > 0; i--)
                {
                    if (binario[i-1] == ' ')
                    {
                        continue;
                    }
                    aux = (int)Char.GetNumericValue(binario[i - 1]);
                    resultado = resultado + aux * (long)Math.Pow(2, j);
                    j++;
                }
            }
            else
            {
                return ("Valor Invalido");
            }

            return Convert.ToString(resultado);
        }

        public static string DecimalBinario(double numero)
        {
            string aux = Convert.ToString(numero);

            if (aux != null)
            {
                return DecimalBinario(aux);
            }
            else
            {
                return ("Valor Invalido");
            }
        }

        public static string DecimalBinario(string numero)
        {
            string resultado = null;
            long data;
            int i = 0, j = 0;

            if (long.TryParse(numero, out data))
            {
                while (data > 1)
                {
                    resultado = Convert.ToString(data % 2) + resultado;
                    data = data / 2;
                    i++;
                    if (i == 4)
                    {
                        i = 0;
                        j++;
                        resultado = " " + resultado;
                    }
                }
                resultado = "1" + resultado;
                i = resultado.Length - j;
                while (i % 4 != 0)
                {
                    resultado = "0" + resultado;
                    i++;
                }
            }
            else
            {
                return ("Valor Invalido");
            }
            return resultado;
        }


        #endregion

        #region OVERLOADED OPERATORS
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }
        public static double operator /(Numero n1, Numero n2)
        {
            return n1.numero / n2.numero;
        }
        #endregion
    }
}
