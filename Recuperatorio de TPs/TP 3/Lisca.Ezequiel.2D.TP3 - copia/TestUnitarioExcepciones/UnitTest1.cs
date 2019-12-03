using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clases_Instanciables;
using EntidadesAbstractas;
using Excepciones;
using Principal;

namespace TestUnitarioExcepciones
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAlumnoRepetidoException()
        {
            try
            {
                Universidad uni = new Universidad();
                Alumno a1 = new Alumno(1, "Jose", "Lopez", "10123456", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
                Alumno a2 = a1;
                uni += a1;
                uni += a2;
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(AlumnoRepetidoException));
            }
        }
    }
}
