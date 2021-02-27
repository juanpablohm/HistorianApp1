using System.Collections.Generic;

namespace L01_Domain.Usuarios
{
    public interface IRepositorioUsuario
    {
        Usuario buscarUsuario(string idUsuario);
        bool actualizarPerfilUsuario(Usuario idUsuario);

        List<Usuario> getUsuarios();
        bool guardarUsuario(Usuario usuario);
    }
}
