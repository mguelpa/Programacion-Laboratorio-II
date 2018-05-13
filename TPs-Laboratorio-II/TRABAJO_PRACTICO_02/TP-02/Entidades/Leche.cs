using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades_2017
{
    public class Leche : Producto
    {
        public enum ETipo { Entera, Descremada }

        #region - Fields -
        ETipo _tipo;
        #endregion

        #region - Properties -
        /// <summary>
        /// Las leches tienen 20 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return (short)20;
            }
        }
        #endregion

        #region - Constructors -
        /// <summary>
        /// Por defecto, TIPO será ENTERA
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="patente"></param>
        /// <param name="color"></param>
        public Leche(EMarca marca, string codigo, ConsoleColor color)
            : base(codigo, marca, color)
        {
            this._tipo = ETipo.Entera;
        }
        public Leche(EMarca marca, string codigo, ConsoleColor color, ETipo tipo)
            : this(marca, codigo, color)
        {
            this._tipo = tipo;
        }
        #endregion

        #region - Methods -
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("LECHE");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("CALORIAS: {0}", this.CantidadCalorias);
            sb.AppendLine("\tTIPO: " + this._tipo);
            //sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion
    }
}
