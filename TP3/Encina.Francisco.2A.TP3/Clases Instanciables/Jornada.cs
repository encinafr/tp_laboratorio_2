using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Abstractas;
using Archivos;

namespace Clases_Instanciables
{
    public class Jornada
    {
        #region ATRIBUTOS
        private List<Alumno> _alumnos;
        private Universidad.EClases _clase;
        private Profesor _instructor;
        #endregion

        #region PROPIEDADES
        public List<Alumno> Alumnos
        {
            get 
            {
                return this._alumnos; 
            }
            set 
            { 
                this._alumnos = value;
            }
        }

        public Universidad.EClases Clase
        {
            get 
            { 
                return this._clase;
            }
            set 
            { 
                this._clase = value;
            }
        }

        public Profesor Instructor
        {
            get 
            { 
                return this._instructor; 
            }
            set
            {
                this._instructor = value;
            }
        }
        #endregion

        #region CONSTRUCTORES
        private Jornada()
        {
            this._alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor)
            : this()
        {
            this._clase = clase;
            this._instructor = instructor;

        }

        #endregion

        #region METODOS


        /// <summary>
        /// Muestra todos los datos de la Jornada.
        /// </summary>
        /// <returns>retorna un string con los datos de la jornada</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CLASE DE " + this._clase.ToString() + " POR " + this._instructor.ToString());
            sb.AppendLine( "\nAlumnos: \n");
            foreach (Alumno item in this.Alumnos)
            {
                sb.AppendLine( item.ToString());
            }
            sb.AppendLine("\n----------------------------------------\n");
            return sb.ToString();
        }


        /// <summary>
        /// Una Jornada será igual a un Alumno si el mismo participa de la clase.
        /// </summary>
        /// <param name="jornada">Jornada jornada</param>
        /// <param name="alu">Alumno alu</param>
        /// <returns>true si se encuentra, de lo contrario false</returns>
        public static bool operator ==(Jornada jornada, Alumno alu)
        {
            foreach (Alumno item in jornada._alumnos)
            {
                if (item == alu)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Una Jornada será distinta a un Alumno si el alumno no participa de la clase.
        /// </summary>
        /// <param name="jornada">Jornada jornada</param>
        /// <param name="alu">Alumno alu</param>
        /// <returns></returns>
        public static bool operator !=(Jornada jornada, Alumno alu)
        {
            return !(jornada == alu);
        }


        /// <summary>
        /// Aregar Alumnos a la clase, validando que no estén previamente cargados.
        /// </summary>
        /// <param name="j">Jornada j</param>
        /// <param name="a">Alumno a</param>
        /// <returns>returna la jornada j</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
            {
                j._alumnos.Add(a);
            }
            return j;
        }


        /// <summary>
        /// Guarda los datos de la jornada en formato txt
        /// </summary>
        /// <param name="jornada">Jornada jornada</param>
        /// <returns></returns>
        public static bool Guardar(Jornada jornada)
        {
             bool retValue = false;
            Texto text = new Texto();
            if (text.guardar("Jornada.txt", jornada.ToString()))
            {
                retValue = true;
            }
            return retValue;
        }


        /// <summary>
        /// Retorna los datos de la Jornada
        /// </summary>
        /// <returns>string con los datos</returns>
        public static string Leer()
        {
            string dato = "";
            Texto text = new Texto();
            text.leer("Jornada.txt", out dato);
            return dato;
        }

        #endregion
    }
}
