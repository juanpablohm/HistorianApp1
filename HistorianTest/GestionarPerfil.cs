using L01_Application.GestionarPerfil;
using L01_Application.RegistrarSitio;
using L01_Domain.Usuarios;
using L03_FakeDB;
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
            string idUsuario = "10008";
            Usuario usuario = controlGestionar.buscarUsuario(idUsuario);
            bool confirmacion = controlGestionar.actualizarPerfil(idUsuario, "edit", "edit", usuario.fechaNacimiento, null, 0, "edit", "edit", "edit");
            Assert.That(confirmacion, Is.True);
        }
    }
}