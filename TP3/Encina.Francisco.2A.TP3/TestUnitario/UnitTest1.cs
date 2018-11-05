using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clases_Abstractas;
using Clases_Instanciables;
using Excepciones;

namespace TestUnitario
{
    [TestClass]
    public class UnitTest1
    {
       
        
        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void TestNull()
        {
            Profesor profesor = new Profesor(1, "Pedro", "Picapiedra", null, Persona.ENacionalidad.Extranjero);
            
        }

        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void TestNacionalidad()
        {
            Alumno uno = new Alumno(4, "Marito", "Baracus", "5", Persona.ENacionalidad.Extranjero, Universidad.EClases.SPD);
        }


        [TestMethod]
        public void TestValorNumerico()
        {
            Alumno alumno = new Alumno(1, "Ya", "Termino", "34567987", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);

            Assert.IsInstanceOfType(alumno.DNI, typeof(int));
            
        }
        
    }
}
