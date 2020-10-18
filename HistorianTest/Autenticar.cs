using L01_Application.Autenticacion;
using L01_Application.RegistrarSitio;
using L01_Domain.Usuarios;
using L03_FakeDB;
using NUnit.Framework;
using System;

namespace HistorianTest
{
    public class Autenticar
    {
        string accessToken = "INGRESA TOKEN";

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void autenticarUsuarioCodigoValidoRegistrado()
        {

            Ctrl_Autenticacion controlAutenticacion = new Ctrl_Autenticacion();


            Assert.That(controlAutenticacion.autenticarUsuario(accessToken), Is.True, "Usuario registrado con exito");
        }

        [Test]
        public void autenticarUsuarioCodigoValidoNoRegistrado()
        {

            Ctrl_Autenticacion controlAutenticacion = new Ctrl_Autenticacion();
            accessToken = "asdfas";

            Assert.That(controlAutenticacion.autenticarUsuario(accessToken), Is.False, "Usuario no registrado");
        }

        [Test]
        public void autenticarUsuarioCodigoInvalido()
        {

            Ctrl_Autenticacion controlAutenticacion = new Ctrl_Autenticacion();

            accessToken = "ABCDF321DA";

            Assert.That(() => controlAutenticacion.autenticarUsuario(accessToken), Throws.TypeOf<TokenInvalidoException>(), "Usuario no registrado");
        }

        [Test]
        public void registrarUsuarioNoExistenteCodigoValido()
        {

            Ctrl_Autenticacion controlAutenticacion = new Ctrl_Autenticacion();

            String accessToken = "ABCDF321";

            bool respuesta = controlAutenticacion.registrarDatosUsuario(accessToken, "Juan", "Molina", DateTime.Now, null, L01_Domain.Common.TipoSexo.Hombre, "Manizales", null, L01_Domain.Common.TipoRol.Usuario);

            Assert.That(respuesta, Is.True, "Usuario no registrado");

        }
    }
}