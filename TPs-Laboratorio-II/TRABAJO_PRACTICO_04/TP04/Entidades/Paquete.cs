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
        // >> Fields
        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;

        // >> Properties
        public string DireccionEntrega
        {
            get { return this.direccionDeEntrega; }
            set { this.direccionDeEntrega = value; }
        }
        public EEstado Estado
        {
            get { return this.estado; }
            set { this.estado = value; }
        }
        public string TrackingID
        {
            get { return this.trackingID; }
            set { this.trackingID = value; }
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
            return this.MostrarDatos(this);
        }
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            // MostrarDatos utilizará string.Format con el 
            // siguiente formato "{0} para {1}", p.trackingID,
            // p.direccionEntrega para compilar la información 
            // del paquete.

            string s = string.Format("{0} para {1}", this.trackingID, this.direccionEntrega);

            return s;
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
