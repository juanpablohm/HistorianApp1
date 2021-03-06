using NUnit.Framework;
using L01_Application.ObtenerSitiosHistoricos;
using System;
using System.Collections.Generic;
using System.Text;

namespace L01_Application
{
    [TestFixture()]
    public class ObtenerSitiosHistoricosTests
    {
        /// <summary>
        /// El repositorio de prueba cuenta con sitios históricos, así que el método
        /// <c>Ctrl_SitioHistorico.getSitiosHistoricos()</c> no debería retornar una lista vacía.
        /// </summary>
        [Test()]
        public void getSitiosHistoricosRetornaListaNoVaciaTest()
        {
            var ctrlSitios = new Ctrl_SitioHistorico();
            List<DTOs.SitioHistoricoDTO> sitios = ctrlSitios.getSitiosHistoricos();
            Assert.IsNotNull(sitios);
            Assert.IsTrue(sitios.Count > 0);
        }

        [Test()]
        public void getSitioHistoricoExistenteTest()
        {
            var ctrlSitios = new Ctrl_SitioHistorico();
            var idSitio = "1";
            var sitio = ctrlSitios.getSitioHistorico(idSitio);
            Assert.NotNull(sitio);
            Assert.AreEqual(idSitio, sitio.id);
        }

        [Test()]
        public void getSitioHistoricoNoExistenteTest()
        {
            var ctrlSitios = new Ctrl_SitioHistorico();
            var idSitio = "666";
            Assert.Throws<L01_Domain.SitiosHistoricos.SitioHistoricoException>(
                () => ctrlSitios.getSitioHistorico(idSitio));
        }
    }
}