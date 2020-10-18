using L01_Domain.Usuarios;
using L03_FakeDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using static L03_FakeDB.TablaUsuario;

namespace L02_Persistence
{
    public class RepositorioUsuarioFake:IRepositorioUsuario
    {
        public Usuario buscarUsuario(string idUsuario)
        {
            List<Usuario> usuarios;

            String jsonString = TablaUsuario.ToJSON();

            usuarios = JsonSerializer.Deserialize<List<Usuario>>(jsonString);

            Usuario usuario = usuarios.FirstOrDefault(u => u.id == idUsuario);

            if (usuario is null)
            {
                throw new UsuarioException("El Usuario con Id-->" + idUsuario + ", no esta registrado");
            }
            return usuario;
        }
        public bool actualizarPerfilUsuario(Usuario usuario)
        {
            try
            {
                List<AtributosUsuario> usuarios;
                usuarios = TablaUsuario.getTablaUsuarios();

                for(int i = 0; i < usuarios.Count; i++)
                {
                    if(usuarios[i].id == usuario.id)
                    {
                        usuarios[i].nombre = usuario.nombre;
                        usuarios[i].apellido = usuario.apellido;
                        usuarios[i].fotoPerfil = usuario.fotoPerfil;
                        usuarios[i].tipoSexo = usuario.tipoSexo;
                        usuarios[i].correoElectronico = usuario.correoElectronico;
                        usuarios[i].ciudad = usuario.ciudad;
                        usuarios[i].pais = usuario.pais;
                    }
                }
            }
            catch
            {
                throw new ActualizarUsuarioException("Hubo un error al actualizar el perfil");
            }
            return true;
        }

        public List<Usuario> getUsuarios()
        {
            throw new NotImplementedException();
        }

        public bool guardarUsuario(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}
