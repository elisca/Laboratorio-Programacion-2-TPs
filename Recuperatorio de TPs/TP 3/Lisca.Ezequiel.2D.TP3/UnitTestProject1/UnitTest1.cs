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
        /// <summary>
        /// Registra dos alumnos idénticos en una universidad, debe lanzar una excepcion AlumnoRepetidoException y pasar por Assert
        /// </summary>
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

        /// <summary>
        /// Crea un alumno con DNI de Argentino y nacionalidad extranjera, debe lanzar NacionalidadInvalidaException
        /// </summary>
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

        /// <summary>
        /// A un alumno le ingresa un DNI tipo string, y lo lee como int comprobando que sean el mismo número
        /// </summary>
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

        /// <summary>
        /// Nombre del alumno no nulo, se comprueba que tenga esa condición
        /// </summary>
        [TestMethod]
        public void TestAtributoValorNoNulo()
        {
            Alumno alumno = new Alumno();

            alumno.Nombre = "Rodrigo";
            Assert.AreNotSame(alumno.Nombre, null);
        }
    }
}