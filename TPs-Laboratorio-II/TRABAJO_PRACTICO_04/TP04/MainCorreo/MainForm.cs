using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Entidades;

namespace MainCorreo
{
    public partial class MainForm : Form
    {
        private Correo correo;

        public MainForm()
        {
            InitializeComponent();
            this.correo = new Correo();
        }

        private void ActualizarEstados()
        {
            foreach (Paquete p in correo.Paquetes)
            {
                this.lstEstadoIngresado.Items.Remove(p);
                this.lstEstadoEnViaje.Items.Remove(p);
                this.lstEstadoEntregado.Items.Remove(p);

                switch (p.Estado)
                {
                    case Paquete.EEstado.Ingresado:
                        this.lstEstadoIngresado.Items.Add(p);
                        break;
                    case Paquete.EEstado.EnViaje:
                        this.lstEstadoEnViaje.Items.Add(p);
                        break;
                    case Paquete.EEstado.Entregado:
                        this.lstEstadoEntregado.Items.Add(p);
                        break;

                }
            }
        }


        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if (elemento != null && elemento is Paquete)
            {
                this.rtbMostrar.Text = ((Paquete)elemento).MostrarDatos( (Paquete)Convert.ChangeType(elemento, typeof(Paquete)));
                GuardaString.GaurdarString(rtbMostrar.Text, Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\salida.txt");
            }
            if (elemento != null && elemento is Correo)
            {
                this.rtbMostrar.Text = ((Correo)elemento).MostrarDatos((Correo)Convert.ChangeType(elemento, typeof(Correo)));
                GuardaString.GaurdarString(rtbMostrar.Text, Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\salida.txt");
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Paquete p = new Paquete(this.txtDireccion.Text, this.mtxtTrackingID.Text);
            p.InformarEstado += paq_InformaEstado;

            try
            {
                this.correo += p;
                this.ActualizarEstados();
            }
            catch (TrackingIdRepetidoException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                ActualizarEstados();
            }
        }

        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            try
            {
                this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.correo.FinEntregas();
        }

        private void MostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
