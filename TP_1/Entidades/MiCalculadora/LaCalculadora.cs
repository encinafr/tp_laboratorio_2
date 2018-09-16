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
            cmbOperador.SelectedItem = "+";
        }

        private void LaCalculadora_Load(object sender, EventArgs e)
        {

        }

        private double Operar(string numero1, string numero2, string operador)
        {            
            Numero num = new Numero(numero1);
            Numero num2 = new Numero(numero2);

            double retorno = Calculadora.Operar(num, num2, operador);
            return retorno;
        }

      
        private void btnOperar_Click(object sender, EventArgs e)
        {
            lblRespuesta.Text = this.Operar(txtNumero1.Text, txtNunero2.Text, cmbOperador.Text).ToString();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            if (this.lblRespuesta.Text == null)
            {
                this.lblRespuesta.Text = "Error";
            }
            else 
            {
                this.lblRespuesta.Text = Numero.DecimalBinario(this.lblRespuesta.Text);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            foreach (Control item in this.Controls)
            {
                if (item is TextBox || item is Label)
                {
                    item.Text = "";
                }
            }
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            if (this.lblRespuesta.Text == null)
            {
                this.lblRespuesta.Text = "Error";
            }
            else
            {
                this.lblRespuesta.Text = Numero.BinarioDecimal(this.lblRespuesta.Text);
            }
            
        }
    }
}
