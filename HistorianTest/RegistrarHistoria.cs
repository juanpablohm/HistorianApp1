using L01_Application.GestionarPerfil;
using L01_Application.RegistrarHistoria;
using L01_Application.RegistrarSitio;
using L01_Domain.Usuarios;
using L03_FakeDB;
using NUnit.Framework;
using System;

namespace HistorianTest
{
    public class RegistrarHistoria
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void registrarNuevaHistoria()
        {
            DateTime fecha = new DateTime(2020, 08, 08);
            bool registrado = new Ctrl_RegistrarHistoria().registrarHistoria("La historia", fecha, "Que lindo dia", null, "15");
            Assert.That(registrado, Is.True);
        }
        [Test]
        public void verificarQueExisteElContador()
        {
            bool registrado = false;
            Ctrl_GestionarPerfil controladora = new Ctrl_GestionarPerfil();
            TablaUsuario.InstanciarUsuarios(1);
            Usuario usuarioBuscado = controladora.buscarUsuario("10000");

            
            if(usuarioBuscado != null)
            {
                DateTime fecha = new DateTime(2020, 08, 08);
                registrado = new Ctrl_RegistrarHistoria().registrarHistoria("La historia", fecha, "Que lindo dia", null, "10000");
            }

            Assert.That(registrado, Is.True);
        }
    }
}