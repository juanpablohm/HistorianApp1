using L01_Application.RegistrarSitio;
using L01_Domain.SitiosHistoricos;
using L03_FakeDB;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.Json;

namespace HistorianTest
{
    public class RegistrarSitio
    {

        [SetUp]
        public void Setup()
        {
            TablaSitioHistorico.InstanciarSitios(3);
        }

        [Test]
        public void verificarSitioHistoricoExistente()
        {
            string sitiosJson = TablaSitioHistorico.ToJSON();
            List<SitioHistorico> sitios = JsonSerializer.Deserialize<List<SitioHistorico>>(sitiosJson);

            SitioHistorico sitioBuscar = sitios.First();

            Posicion posicion = new Posicion(Guid.NewGuid().ToString(), sitioBuscar.posicion.latitud, sitioBuscar.posicion.longitud, "Direccion");
            Assert.That(() => new Ctrl_RegistrarSitio().verificarSitioExistente(sitioBuscar.nombre, posicion), Throws.TypeOf<SitioExistenteException>());
        }

        [Test]
        public void verificarSitioHistoricoNoExistente()
        {
            Posicion posicion = new Posicion(Guid.NewGuid().ToString(), 1, 2, "Direccion");
            bool encontrado = new Ctrl_RegistrarSitio().verificarSitioExistente("SitioInexistente", posicion);
            Assert.That(encontrado, Is.False);
        }

        [Test]
        public void registrarNuevoSitio()
        {
            string nombreNuevoSitio = "Catedral";
            Posicion posicionBuscar = new Posicion("", 1, 1, "Direccion");
            bool registrado = new Ctrl_RegistrarSitio().registrarSitio(nombreNuevoSitio, "Descripcion", null, "idHistoriador");
            Assert.That(() => new Ctrl_RegistrarSitio().verificarSitioExistente(nombreNuevoSitio, posicionBuscar), Throws.TypeOf<SitioExistenteException>(), "El sitio historico no fue registrado");
        }
    }
}