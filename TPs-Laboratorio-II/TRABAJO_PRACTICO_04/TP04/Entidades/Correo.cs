using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        #region ** CLASS CORE **
        // >> Fields
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;

        /// <summary>
        /// retorna lista de paquetes
        /// </summary>
        public List<Paquete> Paquetes
        {
            get { return this.paquetes; }
            set { this.paquetes = value; }
        }

        // >> Costructors
        public Correo()
        {
            this.mockPaquetes = new List<Thread>();
            this.paquetes = new List<Paquete>();
        }

        /// <summary>
        /// retorna string con los datos de cada paquete
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elemento)
        {
            string s = string.Empty;
            if (elemento != null && elemento is Correo)
            {
                foreach (Paquete aux in ((Correo)elemento).Paquetes)
                {
                    s += String.Format("{0} para {1} ({2})", aux.TrackingID,
                    aux.DireccionEntrega,
                    aux.Estado.ToString());
                }
            }
            return s;
        }
        #endregion

        /// <summary>
        /// agrega cada paquete en la lista generada en correo verificando que no esten repetidos
        /// </summary>
        /// <param name="c"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Correo operator +(Correo c, Paquete p)
        {
            foreach (Paquete aux in c.Paquetes)
            {
                if(aux == p)
                {
                    throw new TrackingIdRepetidoException("El paquete ya se encuentra en la lista");
                }
            }

            c.Paquetes.Add(p);            
            Thread t = new Thread(p.MockCicloDeVida);
            c.mockPaquetes.Add(t);
            t.Start();
            return c;
        }

        /// <summary>
        /// cierra todos los hilos generaados
        /// </summary>
        public void FinEntregas()
        {
            foreach(Thread t in this.mockPaquetes)
            {
                if(t.IsAlive)
                {
                    try
                    {
                        t.Abort();
                    }
                    catch (Exception e)
                    { }
                }
            }
        }

    }
}
