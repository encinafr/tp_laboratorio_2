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

        private void LaCalculadora_Load(object sender, EventArgs e)
        {

        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            string numero1 = this.txtNumero1.Text;
            string numero2 = this.txtNunero2.Text;
            string operador = this.cmbOperador.Text;
            Numero n1 = new Numero(numero1);
            Numero n2 = new Numero(numero2);
            Calculadora c = new Calculadora();
            double resultAux = c.Operar(n1, n2, operador);
            this.lblRespuesta.Text = resultAux.ToString();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            if (this.lblRespuesta.Text != null)
            {
                this.lblRespuesta.Text = Numero.BinarioDecimal(this.lblRespuesta.Text);
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
            if (this.lblRespuesta.Text != null)
            {
                double returnAux = Numero.DecimalBinario(this.lblRespuesta.Text);
                this.lblRespuesta.Text = returnAux.ToString();
            }
        }
    }
}
