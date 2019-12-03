using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesAbstractas;
using Clases_Instanciables;
using Excepciones;

namespace UnitTestProject1
{
    [TestClass]
    public class PruebaUnitaria
    {
        [TestMethod]
        public void TestAlumnoRepetidoException()
        {
            Universidad uni = new Universidad();
            Alumno alumno1 = new Alumno(1, "Jose", "Lopez", "10123456", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion);
            Alumno alumno2 = alumno1;
            uni += alumno1;

            try
            {
                uni += alumno2;
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(AlumnoRepetidoException));
            }
        }

        [TestMethod]
        public void TestNacionalidadInvalidadException()
        {
            try
            {
                Alumno alumno1 = new Alumno(1, "Jose", "Lopez", "10123456", Persona.ENacionalidad.Extranjero, Universidad.EClases.Programacion);
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));
            }
        }

        [TestMethod]
        public void TestValorNumerico()
        {
            Alumno alumno = new Alumno();
            string dniConfigurado = "10123456";
            int dniRecibido;

            try
            {
                alumno.StringToDNI = dniConfigurado;
                dniRecibido = alumno.Dni;
                Assert.AreEqual(dniRecibido, int.Parse(dniConfigurado));
            }
            catch (DniInvalidoException)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void TestAtributoValorNoNulo()
        {
            Alumno alumno = new Alumno();

            alumno.Nombre = "Rodrigo";
            Assert.AreNotSame(alumno.Nombre, null);
        }
    }
}