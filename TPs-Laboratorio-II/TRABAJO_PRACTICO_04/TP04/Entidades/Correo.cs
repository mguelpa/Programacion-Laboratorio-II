using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public class Correo
    {
        #region ** CLASS CORE **
        // >> Fields
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;

        // >> Properties
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

        // >> Show Data
        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            // MostrarDatos utilizará string.Format con el siguiente 
            // formato "{0} para {1} ({2})", p.TrackingID, p.DireccionEntrega, 
            // p.Estado.ToString() para retornar los datos de todos 
            // los paquetes de su lista.
            string s = string.Empty;

            foreach (Paquete p in this.Paquetes)
            {
                s += String.Format("{0} para {1} ({2})", 
                                   p.TrackingID, 
                                   p.DireccionEntrega, 
                                   p.Estado.ToString());
            }

            return s;
        }
        #endregion

        //#region ** CLASS METHODS **
        public static Correo operator +(Correo c, Paquete p)
        {

            // Crear un hilo para el método MockCicloDeVida del paquete, y agregar dicho hilo a
            // mockPaquetes.

            // Ejecutar el hilo.

            foreach (Paquete aux in c.Paquetes)
            {
                if(aux == p)
                {
                    throw new TrackingIdRepetidoException("El paquete ya se encuentra en la lista");
                }
            }
            c.Paquetes.Add(p);            
            Thread t = new Thread(new ThreadStart(p.MockCicloDeVida));
            t.Start();
            c.mockPaquetes.Add(t);

            return c;
        }

        public void FinEntregas()
        {
            //int i = 0;
            foreach(Thread t in this.mockPaquetes)
            {
                try
                {
                    t.Abort();
                }
                catch (Exception)
                { }
            }
        }
        //#endregion
    }
}
