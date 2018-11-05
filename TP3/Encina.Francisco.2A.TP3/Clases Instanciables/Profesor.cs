using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Abstractas;

namespace Clases_Instanciables
{
    public sealed class Profesor : Universitario
    {
        #region ATRIBUTOS

        private Queue<Universidad.EClases> _clasesDelDia;
        private static Random _random;

        #endregion

        #region CONSTRUCTORES

        static Profesor()
        {
            _random = new Random();
        }

        public Profesor(): this (111,"","","",ENacionalidad.Argentino)
        {

        }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad) 
        {
            this._clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }
        #endregion

        #region METODOS

        /// <summary>
        /// Asigna dos clases al azar al profesor
        /// </summary>
        private void _randomClases()
        {    
            for (int i = 0; i < 2; i++)
            {
               int clase = Profesor._random.Next(1, 4);

                switch (clase)
                {
                    case 1:
                        this._clasesDelDia.Enqueue(Universidad.EClases.Programacion);
                        break;
                    case 2:
                        this._clasesDelDia.Enqueue(Universidad.EClases.Laboratorio);
                        break;
                    case 3:
                        this._clasesDelDia.Enqueue(Universidad.EClases.Legislacion);
                        break;
                    case 4:
                        this._clasesDelDia.Enqueue(Universidad.EClases.SPD);
                        break;
                    default:
                        break;
                }
            }
        }


        
        /// <summary>
        /// Mustra los datos del profesor
        /// </summary>
        /// <returns>Una cadena con los datos del profesor</returns>
        protected override string MostrarDatos()
        {
            return base.MostrarDatos() + this.ParticiparEnClase();
        }


        /// <summary>
        /// Devuelve las clases del dia
        /// </summary>
        /// <returns>string clases del dia</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            foreach (Universidad.EClases item in _clasesDelDia)
            {
                sb.AppendLine("\nCLASES DEL DÍA:"+ item.ToString());
            }

            return sb.ToString(); ;
        }


        /// <summary>
        /// Hace publico los datos del profesor
        /// </summary>
        /// <returns>string datos del profesor</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }


  


        /// <summary>
        /// Un profesor es igual a una clase si, da esa clase
        /// </summary>
        /// <param name="p">Profesor p</param>
        /// <param name="clase">Enum.EClases clase</param>
        /// <returns>true si da la clase, false de lo contrario</returns>
        public static bool operator ==(Profesor p, Universidad.EClases clase)
        {
            bool retValue = false;
            foreach (Universidad.EClases item in p._clasesDelDia)
            {
                if (item == clase)
                {
                    retValue = true;
                }
            }
            return retValue;
        }

        /// <summary>
        /// Un profesor es distinto de a una clase, si no da esa clase
        /// </summary>
        /// <param name="p">Profesor p</param>
        /// <param name="clase">Enum.EClases clase</param>
        /// <returns>false si da la clase, true de lo contrario</returns>
        public static bool operator !=(Profesor p, Universidad.EClases clase)
        {
            return !(p == clase);
        }

        #endregion
    }
}