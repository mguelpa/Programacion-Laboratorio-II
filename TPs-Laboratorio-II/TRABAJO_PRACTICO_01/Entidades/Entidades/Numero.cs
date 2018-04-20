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
        /// <summary>
        /// Accesor de dato de solo escritura
        /// modifica el unico atributo de la
        /// clase </summary>
        public string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }        
        #endregion

        #region CONSTRUCTORS
        /// <summary>
        /// constructor base </summary>
        public Numero() { }
        /// <summary>
        /// sobrecarga 1 inicializa
        /// con un valor double </summary>
        /// 
        /// <param name="numero"> 
        /// valor a inicializar </param>
        public Numero(double numero)
        {
            this.numero = numero;
        }
        /// <summary>
        /// sobrecarga 2 inicializa
        /// con un valor string </summary>
        /// 
        /// <param name="strNumero">
        /// valor a inicializar </param>
        public Numero(string strNumero)
        {
            this.numero = Convert.ToDouble(strNumero);
        }
        #endregion

        #region METHODS
        /// <summary>
        /// valida que los caracteres 
        /// del string recibido sen numericos </summary>
        /// 
        /// <param name="strNumber">
        /// string a validar </param>
        /// 
        /// <returns>
        /// si los caracteres son numericos retorna
        /// el valor numerico del string recibido 
        /// en formato double caso contrario
        /// retornara 0 </returns>
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

        /// <summary>
        /// valida que los caracteres
        /// del string recibido sean 0 o 1 </summary>
        /// 
        /// <param name="strUserData">
        /// string a validar </param>
        /// 
        /// <returns>
        /// si string OK retorna el mismo string
        /// caso contrario retorna null </returns>
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

        /// <summary>
        /// convierte un string con dato binario
        /// a string con dato decimal </summary>
        /// 
        /// <param name="binario">
        /// dato a convertir </param>
        /// 
        /// <returns>
        /// si OK retorna el string en decimal
        /// caso contrario retorna "valor invalido" </returns>
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

        /// <summary>
        /// recursividad dentro de una metodo
        /// con sobrecargas convierte un double
        /// a string y se llama a si misma para
        /// convertir el dato a binario </summary>
        /// 
        /// <param name="numero">
        /// dato a convertir a decimal </param>
        /// 
        /// <returns>
        /// si OK retorna el string con el dato
        /// convertido a decimal caso contrario
        /// retorba "valor invalido" </returns>
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

        /// <summary>
        /// convierte un string con un dato decimal
        /// a un string con un dato binario </summary>
        /// 
        /// <param name="numero">
        /// string a convertir a binario </param>
        /// 
        /// <returns>
        /// si OK retorna string con dato binario
        /// caso contrario retorna "valor invalido" </returns>
        public static string DecimalBinario(string numero)
        {
            string resultado = null;
            int i = 0, j = 0;
            long data;

            if (long.TryParse(numero, out data))
            {
                if (data > 0)
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
                }
                while (i % 4 != 0 || i == 0)
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
        /// <summary>
        /// suma de datos tipo Numero </summary>
        /// 
        /// <param name="n1">
        /// dato valor A </param>
        /// <param name="n2">
        /// dato valor B </param>
        /// 
        /// <returns>
        /// retorna suma entre datos </returns>
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }
        /// <summary>
        /// resta de datos tipo Numero </summary>
        /// 
        /// <param name="n1">
        /// dato valor A </param>
        /// <param name="n2">
        /// dato valor B </param>
        /// 
        /// <returns>
        /// retorna resta entre datos </returns>
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }
        /// <summary>
        /// productos de datos tipo Numero </summary>
        /// 
        /// <param name="n1">
        /// dato valor A </param>
        /// <param name="n2">
        /// dato valor B </param>
        /// 
        /// <returns>
        /// retorna producto entre datos </returns>
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }
        /// <summary>
        /// division de datos tipo Numero </summary>
        /// 
        /// <param name="n1">
        /// dato valor A </param>
        /// <param name="n2">
        /// dato valor B </param>
        /// 
        /// <returns>
        /// retorna division entre datos </returns>
        public static double operator /(Numero n1, Numero n2)
        {
            return n1.numero / n2.numero;
        }
        #endregion
    }
}
