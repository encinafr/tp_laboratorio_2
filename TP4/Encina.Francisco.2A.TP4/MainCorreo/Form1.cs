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
    public partial class Form1 : Form
    {
        private Correo correo;
        public Form1()
        {
            this.correo = new Correo();
            InitializeComponent();
            lstEstadoIngresado.Text = " ";
            lstEstadoEnviaje.Text = " ";
            lstEstadoEntregado.Text = " ";
        }

        private void MostrartoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Paquete paq = new Paquete(this.txtDireccion.Text,this.mTxtTrackingId.Text);
            paq.InformaEstado += paq_InformaEstado;

            try 
            {
                this.correo += paq;
               
                this.ActualizarEstados();
            }
            catch(TrackingIdRepetidoException ep)
            {
              MessageBox.Show(ep.Message);
            }
            
        }

        void paq_InformaEstado(object sender, EventArgs e)
        {
          if (this.InvokeRequired)
          {
              Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
              this.Invoke( d, new object[] {sender, e} ); 
          } else
          {
              this.ActualizarEstados();
          }
        }

        private void ActualizarEstados()
        {
             
            foreach (Control item in this.groupBox1.Controls)
            {
                if (item is ListBox)
                {
                   ((ListBox)item).Items.Clear() ;
                }
            }

            foreach (Paquete item in this.correo.Paquetes)
            {
                switch (item.Estado)
                {
                    case EEstado.Ingresado:
                        this.lstEstadoIngresado.Items.Add(item);
                        break;
                    case EEstado.EnViaje:
                        this.lstEstadoEnviaje.Items.Add(item);
                        break;
                    case EEstado.Entregado:
                        this.lstEstadoEntregado.Items.Add(item);
                        break;
                    default:
                        break;
                }
            }
        }

        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }
       
         void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if (((object)elemento) != null)
            {
                this.rtbMostar.Text = elemento.MostrarDatos(elemento);
            }
            string archivo = " ";
            archivo.Guardar("salida.txt");
             
        }

         private void lstEstadoEntregado_MouseDown(object sender, MouseEventArgs e)
         {
             if (e.Button == MouseButtons.Right)
             { this.mostrarToolStripMenuStrip.Show(Cursor.Position.X, Cursor.Position.Y); }
         }

       

       
    }
}
