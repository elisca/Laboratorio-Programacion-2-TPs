using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace PruebaUnitaria
{
    [TestClass]
    public class PU
    {
        [TestMethod]
        public void ComprobarCorreoListaInstanciada()
        {
            Correo auxCorreo = new Correo();

            Assert.IsTrue(object.ReferenceEquals(auxCorreo, null));
        }

        [TestMethod]
        public void ComprobarTrackingIDRepetido()
        {
            Correo auxCorreo = new Correo();
            Paquete auxPaquete0 = new Paquete("direccion", "100-000-0000");
            Paquete auxPaquete1 = new Paquete("direccion", "100-000-0000");

            try
            {
                auxCorreo += auxPaquete0;
                auxCorreo += auxPaquete1;
            }
            catch (TrackingIdRepetidoException)
            {
                Assert.IsTrue(true);
            }
            finally
            {
                Assert.Fail();
            }
        }
    }
}
