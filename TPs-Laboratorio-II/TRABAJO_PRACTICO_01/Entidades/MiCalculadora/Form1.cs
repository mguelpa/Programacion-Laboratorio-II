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
    public partial class LaCalculadora : Form
    {
        public LaCalculadora()
        {
            InitializeComponent();
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
            lblResultado.Text = Convert.ToString(Numero.BinarioDecimal(lblResultado.Text));
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNumero1.Text = "0";
            txtNumero2.Text = "0";
            lblResultado.Text = "";
            cmbOperador.Text = "Operador";
            //cmbOperador.Items.Clear();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            Numero numero1 = new Numero(txtNumero1.Text);
            Numero numero2 = new Numero(txtNumero2.Text);
            //MessageBox.Show(cmbOperador.SelectedItem.ToString());

            lblResultado.Text = Convert.ToString(Entidades.Calculadora.Operar(numero1, numero2, cmbOperador.SelectedItem.ToString()));
        }

        private void txtNumero1_Click(object sender, EventArgs e)
        {
            if (txtNumero1.Text == "0")
                txtNumero1.Text = "";
        }

        private void txtNumero2_Click(object sender, EventArgs e)
        {
            if (txtNumero2.Text == "0")
                txtNumero2.Text = "";
        }
    }
}
