using L01_Domain.Common;
using L01_Domain.Multimedias;
using L01_Domain.Usuarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace L02_Persistence
{
    public class FabricaUsuarios
    {

        public static Usuario CrearUsuario(String id, String nombre, String apellido, DateTime fechaNacimiento, Multimedia fotoPerfil, TipoSexo tipoSexo, String correoElectronico, String ciudad , String pais, TipoRol rol, List<Multimedia> certificado, String descripcionExperiencia)
        {
            return rol switch
            {
                TipoRol.Historiador => new Historiador(id, nombre, apellido, fechaNacimiento, fotoPerfil, tipoSexo, correoElectronico, ciudad, pais, rol, certificado, descripcionExperiencia),
                TipoRol.Usuario => new Usuario(id, nombre, apellido, fechaNacimiento, fotoPerfil, tipoSexo, correoElectronico, ciudad, pais, rol),
                TipoRol.ContadorHistorias =>  new ContadorHistorias(id, nombre, apellido, fechaNacimiento, fotoPerfil, tipoSexo, correoElectronico, ciudad, pais, rol),
                _ => null,
            };
        }


    }
}
