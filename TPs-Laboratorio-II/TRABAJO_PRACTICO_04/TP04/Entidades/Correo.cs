using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Correo
    {
        #region ** CLASS CORE **

        // >> Properties
        public List<Paquete> Paquetes
        {
            get { throw new NotFiniteNumberException(); }
            set { throw new NotFiniteNumberException(); }
        }
        // >> Costructors
        public Correo()
        {

        }

        // >> Show Data
        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            StringBuilder sb = new StringBuilder();
            //sb.AppendLine("" + this.attribute1);
            //sb.AppendLine("" + this.attribute2);
            //sb.AppendLine("" + this.attribute3);
            //sb.AppendLine("" + this.attribute4);

            return sb.ToString();
        }
        #endregion

        //#region ** CLASS METHODS **
        public static Correo operator +(Correo c, Paquete p)
        {
            throw new NotImplementedException();
        }

        public void FinEntregas()
        {
            throw new NotImplementedException();
            //return;
        }
        //#endregion
    }
}
