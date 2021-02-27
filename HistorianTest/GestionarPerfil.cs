using L01_Application.GestionarPerfil;
using L01_Domain.Usuarios;
using NUnit.Framework;

namespace HistorianTest
{
    public class GestionarPerfil
    {
        Ctrl_GestionarPerfil controlGestionar = new Ctrl_GestionarPerfil();

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void buscarUsuarioExistente()
        {
            Usuario usuario = controlGestionar.buscarUsuario("10008");
            Assert.That(usuario.id, Is.EqualTo("10008"));
        }
        [Test]
        public void buscarUsuarioNoExistente()
        {
            Assert.That(() => controlGestionar.buscarUsuario("10"), Throws.TypeOf<UsuarioException>(), "El usuario buscado no existe");
        }

        [Test]
        public void actualizarUsuarioExistente()
        {
            var usuarioDTO = new L01_Application.DTOs.UsuarioDTO()
            {
                id = "10008",
                nombre = "edit",
                apellido = "edit"
            };
            bool confirmacion = controlGestionar.ActualizarPerfil(usuarioDTO);
            Assert.That(confirmacion, Is.True);
        }

        [Test]
        public void actualizarUsuarioNoExistente()
        {
            var usuarioDTO = new L01_Application.DTOs.UsuarioDTO()
            {
                id = "666",
                nombre = "edit",
                apellido = "edit"
            };
            Assert.Throws<UsuarioException>(() => controlGestionar.ActualizarPerfil(usuarioDTO));
        }
    }
}