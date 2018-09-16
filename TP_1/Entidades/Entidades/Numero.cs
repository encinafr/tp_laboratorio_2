using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   public class Numero
   {
       #region Atributo

       private double _numero;
       #endregion

       #region Propiedades
       public string SetNumero
        {
            set
            {
                _numero = ValidarNumero(value);
            }
        }
        #endregion

       #region Constructores
       
        public Numero() 
        {

        }

        public Numero(double numero)
        {
            this._numero = numero;
        }

        public Numero(string numero)
        {
            this.SetNumero = numero;
        }
        #endregion

       #region Metodos
        private double ValidarNumero(string numero)
        {
            double retorno;
            bool valido = double.TryParse(numero, out retorno);
            if (!valido)
            {
                retorno = 0;
            }
            return retorno;
        }

        public static string BinarioDecimal(string numero)
        {

            int entero = 0;
            int binario;
            string retorno="";
            if (int.TryParse(numero, out binario))
            {
                for (int i = 1; i <= numero.Length; i++)
                {
                    entero += int.Parse(numero[i - 1].ToString()) * (int)Math.Pow(2, numero.Length - i);
                    retorno = entero.ToString();
                }
            }
            else
            {
                retorno = "Valor invalido";
            }

            return retorno ;
        }

        public static string DecimalBinario(double binario)
        {
            return DecimalBinario(binario.ToString());
        }

        public static string DecimalBinario(string binario)
        {
            int numero;
            string retorno = "";

            if (int.TryParse(binario, out numero))
            {
                while (numero > 0)
                {
                    retorno = (numero % 2).ToString() + retorno;
                    numero = numero / 2;
                }
            }
            else
                retorno = "Valor inválido";

            return retorno;
        }

        public static double operator +(Numero n1, Numero n2)
        {
            double retorno = n1._numero + n2._numero;
            return retorno;
        }

        public static double operator -(Numero n1, Numero n2)
        {
            double retorno = n1._numero - n2._numero;
            return retorno;
        }

        public static double operator *(Numero n1, Numero n2)
        {
            double retorno = n1._numero * n2._numero;
            return retorno;
        }

        public static double operator /(Numero n1, Numero n2)
        {
            double retorno = 0;
            if (n2._numero > 0)
            {
                retorno = n1._numero / n2._numero;
            }
            return retorno;
        }
        #endregion
    }
}
