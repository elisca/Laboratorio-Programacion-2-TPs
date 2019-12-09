using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace UnitTestProject1
{
    /// <summary>
    /// Test de pruebas unitarias
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Comprueba que un elemento correo se encuentre instanciado
        /// </summary>
        [TestMethod]
        public void ComprobarCorreoListaInstanciada()
        {
            Correo auxCorreo = new Correo();

            Assert.IsTrue(!object.ReferenceEquals(auxCorreo, null));
        }

        /// <summary>
        /// Comprueba que en caso de querer ingresar dos paquetes con el mismo tracking ID se lance una excepcion
        /// </summary>
        [TestMethod]
        public void ComprobarTrackingIDRepetido()
        {
            Correo auxCorreo = new Correo();
            Paquete auxPaquete0 = new Paquete("direccion", "1000000000");
            Paquete auxPaquete1 = auxPaquete0;

            try
            {
                auxCorreo += auxPaquete0;
                auxCorreo += auxPaquete1;
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(TrackingIdRepetidoException));
            }
        }
    }
}
