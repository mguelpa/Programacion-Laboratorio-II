using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {
        public enum EEstado { Ingresado, EnViaje, Entregado }
        public delegate void DelegadoEstado(object sender, EventArgs e);

        #region ** CLASS CORE **
        // >> Properties
        public string DireccionEntrega
        {
            get { throw new NotFiniteNumberException(); }
            set { throw new NotFiniteNumberException(); }
        }
        public EEstado Estado
        {
            get { throw new NotFiniteNumberException(); }
            set { throw new NotFiniteNumberException(); }
        }
        public string TrackingID
        {
            get { throw new NotFiniteNumberException(); }
            set { throw new NotFiniteNumberException(); }
        }
        // >> Costructors
        public Paquete(string direccionDeEntrega, string trackingID)
        {
            this.DireccionEntrega = direccionDeEntrega;
            this.TrackingID = trackingID;
        }

        // >> Show Data
        public override string ToString()
        {
            return base.ToString();
        }
        public string MostrarDatos(IMostrar<Paquete> elemento)
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

        public static bool operator ==(Paquete p1, Paquete p2)
        {
            throw new NotImplementedException();
        }
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }



        public void MockCicloDeVida()
        {
            throw new NotImplementedException();
            //return;
        }

        public event DelegadoEstado InformarEstado;
        //#endregion
    }
}
