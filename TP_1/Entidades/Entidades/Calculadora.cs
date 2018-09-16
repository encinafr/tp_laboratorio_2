using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        
        public double Operar(Numero numero1, Numero numero2, string operador) 
        {
            double returnAux = 0;

            switch (ValidarOperador(operador))
            {
                case "+":
                    returnAux = numero1 + numero2;
                    break;
                case "-":
                    returnAux = numero1 - numero2;
                    break;
                case "*":
                    returnAux = numero1 * numero2;
                    break;
                case "/":
                    returnAux = numero1 / numero2;
                    break;
            }

            return returnAux;
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
