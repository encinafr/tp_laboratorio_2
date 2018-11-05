using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Archivos
{
   public class XML<T>: IArchivo<T>
    {
        /// <summary>
        /// Guarda un archivo XML.
        /// </summary>
        /// <param name="archivo">Nombre del archivo</param>
        /// <param name="datos">El dato a guardar</param>
        /// <returns>True si logra guardar, false de lo contrario</returns>
        public bool guardar(string archivo, T datos)
        {
            try
            {
                TextWriter file = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + archivo);
                XmlSerializer serializador = new XmlSerializer(typeof(T));

                serializador.Serialize(file, datos);
                file.Close();
                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
                return false;
            }

            
        }

        /// <summary>
        /// Lectura de un archivo XML.
        /// </summary>
        /// <param name="archivo">Nombre del archivo</param>
        /// <param name="datos">El dato a recuperar</param>
        /// <returns>True si logra leer, false de lo contrario</returns>
        public bool leer(string archivo, out T datos)
        {
            try
            {
                TextReader file = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + archivo);
                XmlSerializer serializador = new XmlSerializer(typeof(T));

                datos = (T)serializador.Deserialize(file);
                file.Close();
                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
                return false;
            }

            
        }
        
        
    }
}
    

