using L01_Domain.Common;
using L01_Domain.Multimedias;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace L03_FakeDB
{
    public static class TablaUsuario
    {
        private static List<AtributosUsuario> usuarios = new List<AtributosUsuario>();
        public class AtributosUsuario
        {
            public string id { get; set; }
            public string nombre { get; set; }
            public string apellido { get; set; }
            public DateTime fechaNacimiento { get; set; }
            public Multimedia fotoPerfil { get; set; }
            public TipoSexo tipoSexo { get; set; }
            public string correoElectronico { get; set; }
            public string ciudad { get; set; }
            public string pais { get; set; }
            public TipoRol rol { get; set; }

            public AtributosUsuario(int id)
            {
                Random random = new Random();
                this.id = "" + (10000 + id);
                nombre = "NombreUsuario " + id;
                apellido = "ApellidosUsuario " + id;
                fechaNacimiento = DateTime.Now;
                fotoPerfil = new Multimedia(""+id, "foto" + id,id + "kb","url/" + id,"imagen","jpg");
                tipoSexo = TipoSexo.Hombre;
                correoElectronico = "usuario" + id + "@historian.com";
                ciudad = "ciudadUsuario " + id;
                pais = "paisUsuario " + id;
                rol = TipoRol.Usuario;
            }

            public String ToJSON()
            {
                return System.Text.Json.JsonSerializer.Serialize(this);
            }

        }
        public static void InstanciarUsuarios(int numeroUsuarios)
        {
            for (int i = 0; i < numeroUsuarios; i++)
            {
                usuarios.Add(new AtributosUsuario(i));
            }
        }
        public static String ToJSON()   
        {
            if (usuarios.Count == 0)
            {
                InstanciarUsuarios(10);
            }

            var options = new System.Text.Json.JsonSerializerOptions
            {
                WriteIndented = true
            };

            return System.Text.Json.JsonSerializer.Serialize(usuarios, options);
        }
        public static List<AtributosUsuario> getTablaUsuarios()
        {
            return usuarios;
        }
    }



}
