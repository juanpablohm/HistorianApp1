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
            var idUsuario = "10008";
            var usuario = controlGestionar.buscarUsuario(idUsuario);
            var nuevoNombre = (usuario.nombre == null || usuario.nombre == "edit") ? "new" : "edit";

            var usuarioDTO = new L01_Application.DTOs.UsuarioDTO() {
                id = idUsuario,
                nombre = nuevoNombre
            };
            bool confirmacion = controlGestionar.ActualizarPerfil(usuarioDTO);
            Assert.IsTrue(confirmacion);

            var usuarioModificado = controlGestionar.buscarUsuario(idUsuario);
            Assert.AreEqual(nuevoNombre, usuarioModificado.nombre);
        }

        [Test]
        public void actualizarUsuarioNoExistente()
        {
            var usuarioDTO = new L01_Application.DTOs.UsuarioDTO()
            {
                id = "666",
                nombre = "edit"
            };
            Assert.Throws<UsuarioException>(() => controlGestionar.ActualizarPerfil(usuarioDTO));
        }
    }
}