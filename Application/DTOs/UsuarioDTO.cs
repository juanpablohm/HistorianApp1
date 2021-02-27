using System;
using System.Collections.Generic;
using System.Text;

namespace L01_Application.DTOs
{
    public class UsuarioDTO
    {
        public string id { set; get; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public DateTime? fechaNac { get; set; }
        public L01_Domain.Multimedias.Multimedia? fotoPerfil { get; set; }
        public L01_Domain.Common.TipoSexo? tipoSexo { get; set; }
        public string correoElectronico { get; set; }
        public string ciudad { get; set; }
        public string pais { get; set; }

        public void TransferirDatosA(L01_Domain.Usuarios.Usuario usuario)
        {
            usuario.nombre = nombre ?? usuario.nombre;
            usuario.apellido = apellido ?? usuario.apellido;
            usuario.fechaNacimiento = fechaNac.GetValueOrDefault(usuario.fechaNacimiento);
            usuario.fotoPerfil = fotoPerfil ?? usuario.fotoPerfil;
            usuario.tipoSexo = tipoSexo.GetValueOrDefault(usuario.tipoSexo);
            usuario.correoElectronico = correoElectronico ?? usuario.correoElectronico;
            usuario.ciudad = ciudad ?? usuario.ciudad;
            usuario.pais = pais ?? usuario.pais;
        }
    }
}
