using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   public class Numero
    {


        protected double numero;

        #region Propiedades
        public string SetNumero
        {
            set
            {
                numero = ValidarNumero(value);
            }
        }
        #endregion

        #region Constructores
        public Numero() { }

        public Numero(double numero)
        {
            this.numero = numero;
        }

        public Numero(string numero)
        {
            this.SetNumero = numero;
        }
        #endregion

        #region Metodos
        private double ValidarNumero(string numero)
        {
            double returnAux;
            if (!double.TryParse(numero, out returnAux))
            {
                returnAux = 0;
            }
            return returnAux;
        }

        public static string BinarioDecimal(string numero)
        {


            int i;
            int entero = 0;
            string returnAux = "";
            if (numero == "" || ReferenceEquals(numero, null))
            {
                string mensaje = "Valor Invalido";
                returnAux = mensaje;
            }
            else
            {
                for (i = 1; i < numero.Length; i++)
                {
                    entero += int.Parse(numero[i - 1].ToString()) * (int)Math.Pow(2, numero.Length - i);
                }
                returnAux = entero.ToString();
            }

            return returnAux;
        }

        public static double DecimalBinario(double numero)
        {
            string binario = "";
            while (numero > 0)
            {
                binario = (numero % 2).ToString() + binario;
                numero = numero / 2;
            }
            double returnAux = double.Parse(binario);
            return returnAux;
        }

        public static double DecimalBinario(string numero)
        {
            double returnAux = double.Parse(numero);
            returnAux = DecimalBinario(returnAux);
            return returnAux;
        }

        public static double operator +(Numero n1, Numero n2)
        {
            double returnAux = n1.numero + n2.numero;
            return returnAux;
        }

        public static double operator -(Numero n1, Numero n2)
        {
            double returnAux = n1.numero - n2.numero;
            return returnAux;
        }

        public static double operator *(Numero n1, Numero n2)
        {
            double returnAux = n1.numero * n2.numero;
            return returnAux;
        }

        public static double operator /(Numero n1, Numero n2)
        {
            double returnAux = 0;
            if (n2.numero > 0)
            {
                returnAux = n1.numero / n2.numero;
            }
            return returnAux;
        }
        #endregion
    }
}
