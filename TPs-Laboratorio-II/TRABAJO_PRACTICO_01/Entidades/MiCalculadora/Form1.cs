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

namespace MiCalculadora
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }



        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Convert.ToString(Numero.DecimalBinario(lblResultado.Text));
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            //Console.Write(lblResultado.Text);
            lblResultado.Text = Convert.ToString(Numero.BinarioDecimal(lblResultado.Text));
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNumero1.Text = "0";
            txtNumero2.Text = "0";
            lblResultado.Text = "";
            cmbOperador.Text = "Operador";
            cmbOperador.Items.Clear();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            int numero1, numero2;

            if (int.TryParse(txtNumero1.Text, out numero1) && int.TryParse(txtNumero2.Text, out numero2))
            {
                lblResultado.Text = Convert.ToString(Entidades.Calculadora.Operar(numero1, numero2, cmbOperador.Text));
            }
            else
            {
                lblResultado.Text = "Error de formato";
            }            
        }

        private void txtNumero1_Click(object sender, EventArgs e)
        {
            if(txtNumero1.Text == "0")
                txtNumero1.Text = "";
        }

        private void txtNumero2_Click(object sender, EventArgs e)
        {
            if (txtNumero2.Text == "0")
                txtNumero2.Text = "";
        }
    }
}
