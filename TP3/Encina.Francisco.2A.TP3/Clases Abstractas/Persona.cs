using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;


namespace Clases_Abstractas
{
    public abstract class Persona
    {
        private string _apellido;
        private int _dni;
        private ENacionalidad _nacionalidad;
        private string _nombre;

         #region constructores

        /// <summary>
        /// Constructor por default
        /// </summary>
        public Persona()
        {
 
        }

        /// <summary>
        /// Constructor de persona
        /// </summary>
        /// <param name="nombre"></param> Nombre de la persona
        /// <param name="apellido"></param> Apellido de la persona
        /// <param name="nacionalidad"></param> Nacionalidad de la persona
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this._nombre = nombre;
            this._apellido = apellido;
            this._nacionalidad = nacionalidad;
        }

        /// <summary>
        /// Sobrecarga Constructor de persona con nacionalidad
        /// </summary>
        /// <param name="nombre"></param>Nombre de la persona
        /// <param name="apellido"></param>Apellido de la persona
        /// <param name="dni"></param>DNI de la persona como int
        /// <param name="nacionalidad"></param>Nacionalidad de la persona
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad):this(nombre,apellido,nacionalidad)
        {
            this.DNI = dni;
        }

        /// <summary>
        /// Sobrecarga Constructor de persona con parametro string dni
        /// </summary>
        /// <param name="nombre"></param>Nombre de la persona
        /// <param name="apellido"></param>Apellido de la persona
        /// <param name="dni"></param>DNI de la persona como string
        /// <param name="nacionalidad"></param>Nacionalidad de la persona
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad):this(nombre,apellido,nacionalidad)
        {
            this.StringToDNI = dni;
            
        }
    #endregion

        #region propiedades
        /// <summary>
        /// Propiedad de lectura y escritura, validando el Apellido
        /// </summary>
        public string Apellido
        {
            get
            {
                return this._apellido;
            }
            set
            {
                this._apellido = this.ValidarNombreApellido(value);                
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura, validando la coincidencia del DNI con la nacionalidad
        /// </summary>
        public int DNI
        {
            get
            {
                return this._dni;
            }
            set
            {
                this._dni = this.ValidarDni(this.Nacionalidad, value);
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get
            {
                return this._nacionalidad;
            }
            set
            {
                this._nacionalidad = value;
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura, validando el Nombre
        /// </summary>
        public string Nombre
        {
            get
            {
                return this._nombre;
            }
            set
            {
                this._nombre = this.ValidarNombreApellido(value);
            }
        }

        /// <summary>
        /// Propidad de solo escritura
        /// </summary>
        public string StringToDNI
        {
            set
            {
                this.DNI = this.ValidarDni(this._nacionalidad, value);                
            }
        }
        #endregion

        #region metodos

        /// <summary>
        /// Retorna los datos de la persona
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("NOMBRE COMPLETO: " + this.Apellido + ", \n" + this.Nombre);
            sb.AppendLine("NACIONALIDAD: " + this.Nacionalidad);
            return sb.ToString();
        }


        /// <summary>
        /// Verifica que el DNI coincida con la nacionalidad
        /// </summary>
        /// <param name="nacionalidad">Enum.ENacionalidad nacionalidad</param>
        /// <param name="dato">int dato</param>
        /// <returns>Retorna el dato</returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            switch (nacionalidad)
            {
                case ENacionalidad.Argentino:
                    if (!(dato > 1 && dato < 89999999))
                    {
                        throw new NacionalidadInvalidaException("La nacionalidad no se condice con el número de DNI");         
                    }
                    break;
                case ENacionalidad.Extranjero:
                    if (!(dato > 89999999 && dato < 99999999))
                    {
                        throw new NacionalidadInvalidaException("La nacionalidad no se condice con el número de DNI");
                    }
                    break;
            }
            return dato;
            
        }

        /// <summary>
        /// Verifica que el DNI coincida con la nacionalidad
        /// </summary>
        /// <param name="nacionalidad"></param> Nacionalidad de la persona
        /// <param name="dato"></param> Dni de la persona
        /// <returns>Retorna el dato</returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int dni;
            if (int.TryParse(dato, out dni))
            {
                return this.ValidarDni(nacionalidad, dni);
            }
            else 
            {
                throw new DniInvalidoException("Error, DNI invalido");
            }
           
        }

        /// <summary>
        /// Verifica que los nombres sean cadenas con caracteres válidos para nombres
        /// </summary>
        /// <param name="dato"></param> nombre o apellido a validar
        /// <returns>EL dato recibido</returns>
        private string ValidarNombreApellido(string dato)
        {
            if (string.IsNullOrEmpty(dato))
            {
                dato = " ";
            }
            else
            {
                for (int i = 0; i < dato.Length; i++)
                {
                    if (!char.IsLetter(dato[i]))
                    {
                        dato = " ";
                    }

                }
            }    

            return dato;
        }
        #endregion
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }
    }
    
}
