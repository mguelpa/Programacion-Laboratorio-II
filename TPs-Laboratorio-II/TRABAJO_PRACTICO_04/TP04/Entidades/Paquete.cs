using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;

namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {
        public enum EEstado { Ingresado, EnViaje, Entregado }

        public delegate void DelegadoEstado(object sender, EventArgs e);
        public event DelegadoEstado InformarEstado;


        #region ** CLASS CORE **
        // >> Fields
        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;

        // >> Properties
        public string DireccionEntrega
        {
            get { return this.direccionEntrega; }
            set { this.direccionEntrega = value; }
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
        /// <summary>
        /// retorna un string con los datos del paquete
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos(this);
        }
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            string s = string.Empty;

            if (elemento != null && elemento is Paquete)
            {
                s += String.Format("{0} para {1}", ((Paquete)elemento).TrackingID, ((Paquete)elemento).DireccionEntrega);
            }

            return s;
        }
        #endregion

        /// <summary>
        /// compara dos trackingID y retorna si coinciden o no
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            if(p1.TrackingID == p2.TrackingID)
            {
                return true;
            }
            return false;
        }
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }


        /// <summary>
        /// simula el ciclo de vida de un paquete desde el despacho 
        /// hasta la entrega del mismo generando un hilo por cada
        /// paquete
        /// </summary>
        public void MockCicloDeVida()
        {
            while (this.estado != EEstado.Entregado)
            {
                Thread.Sleep(10000);
                this.estado++;
                InformarEstado(this, EventArgs.Empty);

            }
            PaqueteDAO pDAO = new PaqueteDAO();
            pDAO.Insertar(this);
        }

    }
}
