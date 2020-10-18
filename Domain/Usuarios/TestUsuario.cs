using L01_Domain.Common;
using L01_Domain.Multimedias;
using System;
using System.Collections.Generic;
using System.Text;

namespace L01_Domain.Usuarios
{
    public class TestUsuario
    {
        public string id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        //public DateTime fechaNacimiento { get; set; }
        //public Multimedia fotoPerfil { get; set; }
        //public TipoSexo tipoSexo { get; set; }
        public string correoElectronico { get; set; }
        public string ciudad { get; set; }
        public string pais { get; set; }
        //public TipoRol rol { get; set; }


        public TestUsuario(string id, string nombre, string apellido, string correoElectronico, string ciudad, string pais)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellido = apellido;
            //this.fechaNacimiento = fechaNacimiento;
            //this.fotoPerfil = fotoPerfil;
            //this.tipoSexo = tipoSexo;
            this.correoElectronico = correoElectronico;
            this.ciudad = ciudad;
            this.pais = pais;
            //this.rol = rol;
        }
        public TestUsuario()
        {

        }
    }
}
