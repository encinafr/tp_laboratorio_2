using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        
        public static double Operar(Numero numero1, Numero numero2, string operador) 
        {
            double retorno;
            string valido;
            valido = ValidarOperador(operador);

            switch (valido)
            {
                case "/":
                    retorno = numero1 / numero2;
                    break;
                case "-":
                    retorno = numero1 - numero2;
                    break;      
                case "+":
                    retorno = numero1 + numero2;
                    break;
                default:
                    retorno = numero1 * numero2;
                    break;
            }
            
            return retorno;
        }
        
        private static string ValidarOperador(string operador)
        {
            if (operador != "+" && operador != "-" && operador != "/" && operador != "*")
            {
                operador = "+";
            }

            return operador;
        }
    }
    
}
