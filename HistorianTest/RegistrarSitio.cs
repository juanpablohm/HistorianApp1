using L01_Application.RegistrarSitio;
using L01_Domain.Multimedias;
using L01_Domain.SitiosHistoricos;
using L03_FakeDB;
using NUnit.Framework;
using System;
using System.Collections.Generic;
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
            Ctrl_RegistrarSitio controlador = new Ctrl_RegistrarSitio();
            string nombreNuevoSitio = "Louvre";
            string descripcionNuevoSitio = "Artes";
            string idHistoriador = "1033";
   
            bool registrado = controlador.registrarSitio(nombreNuevoSitio,descripcionNuevoSitio, null, idHistoriador);

            Assert.IsTrue(registrado);

            var SitioNuevo = controlador.buscarSitioPorNombre(nombreNuevoSitio);

            Assert.AreEqual(nombreNuevoSitio, SitioNuevo.nombre);
            Assert.AreEqual(descripcionNuevoSitio, SitioNuevo.descripcion);
            Assert.AreEqual(idHistoriador, SitioNuevo.idHistoriador);
      
        }
        
        [Test]
        public void registrarSitioYaExistente()
        {
            Ctrl_RegistrarSitio controlador = new Ctrl_RegistrarSitio();

            string nombreNuevoSitio = "SanAgustin";
            string descripcionNuevoSitio = "Religion";
            string idHistoriador = "1034";

            controlador.registrarSitio(nombreNuevoSitio, descripcionNuevoSitio, null, idHistoriador);
            Assert.That(() => controlador.registrarSitio(nombreNuevoSitio, descripcionNuevoSitio, null, idHistoriador), 
                Throws.TypeOf<SitioExistenteException>());
        }
    }
}