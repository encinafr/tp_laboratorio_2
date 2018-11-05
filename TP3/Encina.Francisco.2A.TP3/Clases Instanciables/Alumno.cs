using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Abstractas;
using Excepciones;


namespace Clases_Instanciables
{
    public sealed class Alumno : Universitario
    {
        #region ATRIBUTOS
        private Universidad.EClases _claseQueToma;
        private EEstadoCuenta _estadoCuenta;
        #endregion

        #region CONSTRUCTORES
        public Alumno() : base()
        {

        }


        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._claseQueToma = claseQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this._estadoCuenta = estadoCuenta;
        }

        #endregion

        #region METODOS


        /// <summary>
        /// Muestra todos los datos del alumno
        /// </summary>
        /// <returns>retorna una cadena con los datos del alumno</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("ESTADO DE CUENTA: " + this._estadoCuenta.ToString());
            sb.AppendFormat(base.MostrarDatos(), this.ParticiparEnClase());
            return sb.ToString(); ;
        }


        /// <summary>
        /// Muestra la clase que toma el alumno
        /// </summary>
        /// <returns>Retorna la clases que toma</returns>
        protected override string ParticiparEnClase()
        {
            return "\nTOMA CLASES DE: " + this._claseQueToma;
        }


        /// <summary>
        /// Hace público los datos del Alumno
        /// </summary>
        /// <returns>retorna el metodo MostrarDatos()</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }


        /// <summary>
        /// Un Alumno será igual a un EClase si toma esa clase y su estado de cuenta no es Deudor
        /// </summary>
        /// <param name="a">Alumno a</param>
        /// <param name="clase">Enum.EClases clase</param>
        /// <returns>True si es igual, de lo contrario false</returns>
        public static bool operator ==(Alumno a,Universidad.EClases clase)
        {
            bool retValue = false;
            if (a._claseQueToma == clase && a._estadoCuenta != EEstadoCuenta.Deudor)
            {
                retValue =  true;
            }

            return retValue;
        }


        /// <summary>
        /// Un Alumno será distinto a un EClase sólo si no toma esa clase.
        /// </summary>
        /// <param name="a">Alumno a</param>
        /// <param name="clase">Enum.EClases clase</param>
        /// <returns>Treu si distinto,false en caso contrario</returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            bool retValue = false;
            if (!(a._claseQueToma == clase))
            {
                retValue = true;
            }
            return retValue;

        }

        #endregion
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }

    }
}
