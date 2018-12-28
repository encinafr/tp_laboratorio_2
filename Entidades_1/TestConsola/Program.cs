﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;


namespace TestConsola
{
    class Program
    {
        
        static bool _continue = true;
        static void Main(string[] args)
        {

            FileSystemWatcher watcher = new FileSystemWatcher();
            //Console.WriteLine("Ingrese la ubicación del archivo que desea inspeccionar");
           // string ruta = Console.ReadLine();
            watcher.Path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

           // watcher.Filter = "*.txt";
            watcher.IncludeSubdirectories = false;
            watcher.Changed += new FileSystemEventHandler(OnCreated);
            watcher.Deleted += new FileSystemEventHandler(OnCreated);
            watcher.Created += new FileSystemEventHandler(OnCreated);
        //    watcher.Renamed += new FileSystemEventHandler(OnCreated1);
            watcher.EnableRaisingEvents = true;
           // WaitForChangedResult result =
     //    watcher.WaitForChanged(WatcherChangeTypes.Renamed);
          // Console.WriteLine("Se ha creado el archivo '{0}'.", result.Name);
           while (_continue)
            {
                Console.WriteLine("Monitoreando... ");
                Thread.Sleep(1000);
            }
 
            Console.ReadKey(true);
         }
 
        static void OnCreated(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("Se ha creado el archivo '{0}'", e.Name);

         
          
            System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();

            //Direccion de correo electronico a la que queremos enviar el mensaje
            mmsg.To.Add("encinajavier7@gmail.com");

            //Nota: La propiedad To es una colección que permite enviar el mensaje a más de un destinatario

            //Asunto
            mmsg.Subject = "Cambios en el directorio";
            mmsg.SubjectEncoding = System.Text.Encoding.UTF8;


            //Cuerpo del Mensaje
            mmsg.Body = "Archivo modificado"+ e.Name;
            mmsg.BodyEncoding = System.Text.Encoding.UTF8;
            mmsg.IsBodyHtml = false; //Si no queremos que se envíe como HTML

            //Correo electronico desde la que enviamos el mensaje
            mmsg.From = new System.Net.Mail.MailAddress("encinajavier7@gmail.com");


            /*-------------------------CLIENTE DE CORREO----------------------*/

            //Creamos un objeto de cliente de correo
            System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();

            //Hay que crear las credenciales del correo emisor
            cliente.Credentials =
                new System.Net.NetworkCredential("encinajavier7@gmail.com", "iwalkbesideyou");

            //Lo siguiente es obligatorio si enviamos el mensaje desde Gmail
            
            cliente.Port = 587;
            cliente.EnableSsl = true;


            cliente.Host = "smtp.gmail.com"; //Para Gmail "smtp.gmail.com";


           

            try
            {
                    
                cliente.Send(mmsg);
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                //Aquí gestionamos los errores al intentar enviar el correo
            }
        }


        static void OnCreated1(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("Se ha renombrado el archivo '{0}'", e.Name);
            _continue = false;
        }
      }
    
}
