using L01_Domain.Usuarios;
using System;
using System.Collections.Generic;
using System.Text;

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
