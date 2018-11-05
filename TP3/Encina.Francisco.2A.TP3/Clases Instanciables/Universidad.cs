using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Excepciones;
using Archivos;


namespace Clases_Instanciables
{
    public class Universidad
    {
       
        #region ATRIBUTOS
        private List<Alumno> _alumnos;
        private List<Jornada> _jornada;
        private List<Profesor> _profesores;
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

        public List<Jornada> Jornadas
        {
            get 
            { 
                return this._jornada; 
            }
            set 
            { 
                this._jornada = value;
            }
        }

        public List<Profesor> Instructores
        {
            get
            { 
                return this._profesores;
            }
            set 
            {
                this._profesores = value;
            }
        }

        public Jornada this[int i]
        {
            get
            { 
                return this._jornada[i];
            }
            set 
            { 
                this._jornada[i] = value;
            }
        }

        #endregion

        #region CONSTRUCTORES
        public Universidad()
        {
            this._alumnos = new List<Alumno>();
            this._jornada = new List<Jornada>();
            this._profesores = new List<Profesor>();
        }
        #endregion

        #region METODOS


        /// <summary>
        /// Retorna los datos de las jornadas
        /// </summary>
        /// <param name="gim">Universidad gim</param>
        /// <returns>string datos de las jornadas</returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("JORNADA:");
            for (int i = 0; i < uni._jornada.Count; i++)
            {
                sb.AppendLine(uni._jornada[i].ToString());
                sb.AppendLine("<------------------------------------------------>");
            }

            return sb.ToString();
        }


        /// <summary>
        /// Mustra los datos de las jornadas
        /// </summary>
        /// <returns>Retorna un string con los datos de las jornadas</returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }


        /// <summary>
        /// Una Universidad será igual a un Alumno si el mismo está inscripto en él.
        /// </summary>
        /// <param name="g">Unviersidad g</param>
        /// <param name="a">Alumno a</param>
        /// <returns>true si se encuentra, false de lo contrario</returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            bool retValue = false;
            foreach (Alumno item in g.Alumnos)
            {
                if (item == a)
                {
                    retValue = true;
                }
            }
            return retValue;
        }

        /// <summary>
        /// Una Universidad será distinto a un Alumno si el mismo no está inscripto en él.
        /// </summary>
        /// <param name="g">Unviersidad g</param>
        /// <param name="a">Alumno a</param>
        /// <returns>false si se encuentra, true de lo contrario</returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }


        /// <summary>
        /// Un Universidad será igual a un Profesor si el mismo está dando clases en él.
        /// </summary>
        /// <param name="g">Universidad g</param>
        /// <param name="i">Profesor i</param>
        /// <returns>retorna true si se encuentra, false de lo contrario</returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            bool retValue = false;
            foreach (Profesor item in g._profesores)
            {
                if (item == i)
                {
                    retValue = true;
                }
            }
            return retValue;
        }

        /// <summary>
        /// Un Universidad será distinto a un Profesor si el mismo no está dando clases en él.
        /// </summary>
        /// <param name="g">Universidad g</param>
        /// <param name="i">Profesor i</param>
        /// <returns>retorna false si se encuentra, true de lo contrario</returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// Retorna el primer Profesor capaz de dar esa clase.
        /// </summary>
        /// <param name="g">Universidad a revisar.</param>
        /// <param name="clase">Clase en cuestión.</param>
        /// <returns>Profesor que puede dar la clase.</returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            Profesor auxPro = new Profesor(); 
            foreach (Profesor item in u.Instructores)
            {
                if (item == clase)
                {
                    auxPro = item;
                    break;
                }
                else 
                {
                    throw new SinProfesorException();    
                }
            }
            return auxPro;
            
        }

        /// <summary>
        /// Verifica si hay un profesor en una universidad que no pueda dar una clase.
        /// </summary>
        /// <param name="g">Universidad a revisar.</param>
        /// <param name="clase">Clase en cuestión.</param>
        /// <returns>Profesor que no puede impartir la clase, en caso de no haber retorna null.</returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            Profesor auxPro = new Profesor();
            foreach (Profesor profesor in u.Instructores)
            {
                if (profesor != clase)
                {
                    auxPro = profesor;
                    break;
                }
                else
                {
                    throw new SinProfesorException();
                }
            }
            return auxPro;
            
        }
        /// <summary>
        /// Agregar
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, Universidad.EClases clase)
        {
            foreach (Profesor profesor in g.Instructores)
            {
                if (profesor == clase)
                {
                    Jornada jornada = new Jornada(clase, profesor);

                    foreach (Alumno item in g.Alumnos)
                    {
                        if (item == clase)
                        {
                            jornada.Alumnos.Add(item);
                        }
                    }

                    g.Jornadas.Add(jornada);
                    return g;
                }

            }

            throw new SinProfesorException();

            
        }
        
        /// <summary>
        /// Añade un alumno a la universidad
        /// </summary>
        /// <param name="g">Universidad g</param>
        /// <param name="a">Alumno a</param>
        /// <returns>retorna la universidad u</returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u != a)
            {
                u._alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }
            return u;

        }


        /// <summary>
        /// Añade un profesor a la universidad
        /// </summary>
        /// <param name="g">Universidad g</param>
        /// <param name="i">Profesor i</param>
        /// <returns>retorna la universidad u</returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (u != i)
            {
                u._profesores.Add(i);
            }
            return u;
        }


        /// <summary>
        /// Guarda la clase en formato xml
        /// </summary>
        /// <param name="gim">Universidad gim</param>
        /// <returns>true si se pudo guardar, en caso contrario false</returns>
        public static bool Guardar(Universidad gim)
        {
            XML<Universidad> file = new XML<Universidad>();

            return file.guardar("Universidad.xml", gim);
        }

        #endregion
        public enum EClases
        {
            Programacion,
            Laboratorio, 
            Legislacion,
            SPD
        }
    }


}