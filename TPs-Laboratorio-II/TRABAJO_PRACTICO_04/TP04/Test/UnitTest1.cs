using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Entidades;
using System.Collections.Generic;


namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// verifica que la lista de 
        /// Paquetes del Correo esté 
        /// instanciada
        /// </summary>
        [TestMethod]
        public void Verifica_Instancia_Lista_Paquetes_Correo()
        {
            // arrange  
            List<Paquete> actual = null;

            // act
            Correo correo = new Correo();
            actual = correo.Paquetes;

            // assert
            Assert.IsNotNull(actual);
        }


        /// <summary>
        /// verifica que no se puedan cargar dos 
        /// Paquetes con el mismo Tracking ID
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(TrackingIdRepetidoException))]
        public void Verificacio_TrackingID_Repetido()
        {
            // arrange  
            Correo correo = new Correo();
            Paquete p1 = new Paquete("Av. Mitre 750.", "111");
            Paquete p2 = new Paquete("Av. Mitre 750.", "111");

            // act  
            correo += p1;
            correo += p2;

            // assert es manejado en el ExpectedException  
        }

    }
}
