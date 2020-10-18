using L01_Domain.Usuarios;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace L02_Persistence
{
    public class RepositorioUsuarioJSON : IRepositorioUsuario
    {

        private String path = @"..\..\..\repos\usuarios.json";

        public bool actualizarPerfilUsuario(Usuario idUsuario)
        {
            throw new NotImplementedException();
        }

        public Usuario buscarUsuario(string idUsuario)
        {
            Usuario usuarioBuscado = null;
            List<Usuario> usuarios;

            String jsonString = File.ReadAllText(this.path);

            usuarios = System.Text.Json.JsonSerializer.Deserialize<List<Usuario>>(jsonString);

            usuarioBuscado = usuarios.FirstOrDefault(usuario => usuario.id == idUsuario);

            return usuarioBuscado;
        }

        public List<Usuario> getUsuarios()
        {
            List<Usuario> usuarios;

            String jsonString = File.ReadAllText(this.path);

            usuarios = System.Text.Json.JsonSerializer.Deserialize<List<Usuario>>(jsonString);

            return usuarios;
        }

        public bool guardarUsuario(Usuario usuario)
        {
            List<Usuario> usuarios;

            String jsonString = File.ReadAllText(this.path);

            usuarios = System.Text.Json.JsonSerializer.Deserialize<List<Usuario>>(jsonString);

            usuarios.Add(usuario);

            var options = new System.Text.Json.JsonSerializerOptions
            {
                WriteIndented = true
            };

            jsonString = System.Text.Json.JsonSerializer.Serialize(usuarios, options);

            File.WriteAllText(path, jsonString);

            return true;
        }
    }
}
