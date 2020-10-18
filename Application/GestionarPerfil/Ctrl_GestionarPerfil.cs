using L01_Application.Autenticacion;
using L01_Domain.Common;
using L01_Domain.Multimedias;
using L01_Domain.Usuarios;
using L02_Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace L01_Application.GestionarPerfil
{
    public class Ctrl_GestionarPerfil
    {
        public bool actualizarPerfil(string id,string nombre,string apellido,DateTime fechaNac,Multimedia fotoPerfil,
                                    TipoSexo tipoSexo,string correoElectronico,string ciudad,string pais)
        {
            Usuario usuario = buscarUsuario(id);

            usuario.nombre = (nombre != null) ? nombre : usuario.nombre;
            usuario.apellido = (apellido != null) ? apellido : usuario.apellido;
            usuario.fechaNacimiento = (fechaNac != null) ? fechaNac : usuario.fechaNacimiento;
            usuario.fotoPerfil = (fotoPerfil != null) ? fotoPerfil : usuario.fotoPerfil;
            usuario.tipoSexo = (tipoSexo != null) ? tipoSexo : usuario.tipoSexo;
            usuario.correoElectronico = (correoElectronico != null) ? correoElectronico : usuario.correoElectronico;
            usuario.ciudad = (ciudad != null) ? ciudad : usuario.ciudad;
            usuario.pais = (pais != null) ? pais : usuario.pais;

            try
            {
                IRepositorioUsuario repoU = FabricaRepositoriosUsuarios.CrearRepositorioUsuarios("fake");
                repoU.actualizarPerfilUsuario(usuario);
            }
            catch(ActualizarUsuarioException ex)
            {
                throw ex;
            }
            return true;
        }
        public Usuario buscarUsuario(string idUsuario)
        {
            try
            {
                if (idUsuario is null)
                    return null;
                IRepositorioUsuario repoU = FabricaRepositoriosUsuarios.CrearRepositorioUsuarios("fake");
                Usuario usuario = repoU.buscarUsuario(idUsuario);
                return usuario;
            }
            catch (UsuarioException ex)
            {
                throw ex;
            }
        }
    }
}
