using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Clases_Abstractas
{
   public abstract class Universitario: Persona
    {
       private int _legajo;

       #region CONSTRUCTORES
       public Universitario()
       {

       }

       public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad): base(nombre, apellido, dni, nacionalidad)
       {
         this._legajo = legajo;
       }
       #endregion



       #region METODOS

       protected abstract string ParticiparEnClase();

       /// <summary>
       /// Muestra todos los datos del universitario
       /// </summary>
       /// <returns>Un string con todos los datos</returns>
       protected virtual string MostrarDatos()
       {
             
           return base.ToString() + "\n\nLEGAJO NUMERO:"+ this._legajo.ToString();
       }

       


       /// <summary>
       /// Un universitario es igual al otro si son del mismo tipo, y ademas si el dni o el legajo son iguales.
       /// </summary>
       /// <param name="u1">Universitario u1</param>
       /// <param name="u2">Universitario u2</param>
       /// <returns>True si son iguales, de lo contario false</returns>
       public static bool operator ==(Universitario pg1, Universitario pg2)
       {
           bool retValue = false;
           if(pg1 is Universitario && pg2 is Universitario)
           {
               if(pg1.DNI == pg2.DNI || pg1._legajo == pg2._legajo)
                   {
                       retValue = true;
                   }
           }
           return retValue;
       }

       /// <summary>
       /// Comprueba que un universitario sea distinto del otro
       /// </summary>
       /// <param name="u1">Universitario u1</param>
       /// <param name="u2">Universitario u2</param>
       /// <returns>False si son iguales, de lo contario true</returns>
       public static bool operator !=(Universitario pg1, Universitario pg2)
       {
           return !(pg1 == pg2);
       }


       /// <summary>
       /// Comprueba si un objeto es del tipo Universitario
       /// </summary>
       /// <param name="obj">Object obj</param>
       /// <returns>True si el objeto es universitario, en caso contrario flase</returns>
       public override bool Equals(object obj)
       {
           bool retValue = false;
           if (obj is Universitario)
           {
               retValue = true;
           }
           return retValue;
       }
       #endregion
    }
}
