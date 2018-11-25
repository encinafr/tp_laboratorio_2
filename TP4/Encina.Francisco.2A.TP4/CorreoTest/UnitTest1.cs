using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using MainCorreo;

namespace CorreoTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestInstancia()
        {
            Correo correo = new Correo();
            Assert.IsNotNull(correo.Paquetes);
        }

        [TestMethod]
        public void TestTrackingId()
        {
            Paquete aux1 = new Paquete("TestRepetido1", "126");
            Paquete aux2 = new Paquete("TestRepetido2", "126");
            Correo correo = new Correo();
            correo += aux1;

            try
            {
                correo += aux2;
                Assert.Fail();
            }
            catch(TrackingIdRepetidoException)
            {
               

            }
        }
    }
}
