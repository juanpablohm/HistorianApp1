using L01_Domain.Usuarios;
using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
namespace L02_Persistence
{
    public class FabricaRepositoriosUsuarios
    {
        public static IRepositorioUsuario CrearRepositorioUsuarios(string repo)
        {
            //var repo = ConfigurationManager.AppSettings["repositoryUsuarios"];
            //var repo = "json";

            return repo switch
            {
                "fake" => new RepositorioUsuarioFake(),
                "json" => new RepositorioUsuarioJSON(),
                _ => null,
            };
        }
    }
}
