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
            int numero;

            if (int.TryParse(lblResultado.Text, out numero) && numero > -1)
                lblResultado.Text = Convert.ToString(Numero.DecimalBinario(lblResultado.Text));
            else if(lblResultado.Text == "Resultado" || lblResultado.Text == "")
                lblResultado.Text = "Resultado";
            else if (lblResultado.Text == "Valor Invalido" || lblResultado.Text == "Seleccione Operador" || lblResultado.Text == "Seleccione Operador" || lblResultado.Text == "Realice una operacion")
                lblResultado.Text = "Realice una operacion";
            else
                lblResultado.Text = "Solo enteros positivos!!";
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            if (lblResultado.Text == "Resultado" || lblResultado.Text == "")
                lblResultado.Text = "Resultado";
            else if (lblResultado.Text == "Realice una operacion" || lblResultado.Text == "Seleccione Operador")
                lblResultado.Text = "Realice una operacion";
            else
                lblResultado.Text = Convert.ToString(Numero.BinarioDecimal(lblResultado.Text));
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNumero1.Text = "0";
            txtNumero2.Text = "0";
            lblResultado.Text = "";
            lblTextComboBox.Text = "Operador";
            cmbOperador.SelectedItem = null;
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            Numero numero1 = new Numero();
            Numero numero2 = new Numero();

            numero1.SetNumero = txtNumero1.Text;
            numero2.SetNumero = txtNumero2.Text;


            if (cmbOperador.SelectedItem == null)
                lblResultado.Text = "Seleccione Operador";
            else
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

        private void cmbOperador_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbOperador.SelectedItem != null)
            lblTextComboBox.Text = cmbOperador.SelectedItem.ToString();
        }
    }
}
