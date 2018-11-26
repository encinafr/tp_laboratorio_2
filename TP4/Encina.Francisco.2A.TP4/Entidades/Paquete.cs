using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    

    public class Paquete : IMostrar<Paquete>
    {
        public delegate void DelegadoEstado(object sender, EventArgs e);
        public event DelegadoEstado InformaEstado;

        #region Attributes
        private string direccionDeEntrega;
        private EEstado estado;
        private string trackingID;
        #endregion

        #region Properties
        public string DireccionDeEntrega
        {
            get
            { 
                return this.direccionDeEntrega;
            }
            set 
            { 
                this.direccionDeEntrega = value;
            }
        }

        public EEstado Estado     
        {
            get 
            {
                return this.estado; 
            }
            set
            { 
                this.estado = value; 
            } 
        }

        public string TrackingID
        {
            get 
            {
                return this.trackingID;
            } 
            set 
            {
                this.trackingID = value; 
            }
        }
        #endregion

        #region Biulders

        public Paquete(string direccionDeEntrega, string trackingID)
        {
            this.TrackingID = trackingID;
            this.DireccionDeEntrega = direccionDeEntrega;
            this.Estado = EEstado.Ingresado;
        }

        #endregion

        #region Methods
        public void MockCicloDeVida()
        {
            while (this.Estado != EEstado.Entregado)
            {
                Thread.Sleep(4000);
                this.Estado++;
                this.InformaEstado(this.Estado, EventArgs.Empty);
            }
            PaqueteDAO.Insertar(this);
        }

        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            return String.Format("{0} para {1}", this.trackingID, this.direccionDeEntrega);
        }
        #endregion

        #region Overload
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            bool retValue = false;
            if (p1.TrackingID == p2.TrackingID) 
            {
                retValue = true;
            }
            return retValue;
        }

        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }

        
        public override string ToString()
        {
            return this.MostrarDatos(this);
        }
        #endregion


    }
}
