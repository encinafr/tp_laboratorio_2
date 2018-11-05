using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {

        public bool guardar(string archivo, string datos)
        {
            try
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\";
                using (StreamWriter file = new StreamWriter(path + archivo, false))
                {
                    file.Write(datos);
                    return true;
                }
            }
            catch (ArchivosException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }


        public bool leer(string archivo, out string datos)
        {
            try
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\";
                using (StreamReader file = new StreamReader(archivo + path))
                {
                    datos = file.ReadToEnd();
                    return true;
                }
            }
            catch (ArchivosException e)
            { 
                datos = "";
                Console.WriteLine(e.Message);
                return false;
            }    
        }
    }
}
