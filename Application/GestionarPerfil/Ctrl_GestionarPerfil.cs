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
        /// <summary>
        /// Modifica la información almacenada del usuario identificado con <paramref name="id"/>.
        /// </summary>
        /// <param name="id">El ID del usuario cuya información se desea modificar. No debe ser <c>null</c>.</param>
        /// <param name="nombre">El nuevo nombre del usuario, o <c>null</c> si se desea conservar el actual.</param>
        /// <param name="apellido">El nuevo apellido del usuario, o <c>null</c> si se desea conservar el
        /// actual.</param>
        /// <param name="fechaNac">La nueva fecha de nacimiento del usuario, o <c>null</c> si se desea conservar la
        /// actual.</param>
        /// <param name="fotoPerfil">La nueva foto de perfil del usuario, o <c>null</c> si se desea conservar la
        /// actual.</param>
        /// <param name="tipoSexo">El nuevo sexo del usuario, o <c>null</c> si se desea conservar el actual.</param>
        /// <param name="correoElectronico">El nuevo correo electrónico del usuario, o <c>null</c> si se desea
        /// conservar el actual.</param>
        /// <param name="ciudad">La nueva ciudad de residencia del usuario, o <c>null</c> si se desea conservar la
        /// actual.</param>
        /// <param name="pais">El nuevo país de residencia del usuario, o <c>null</c> si se desea conservar el
        /// actual.</param>
        /// <returns>Un valor booleano indicando si la operación fue exitosa.</returns>
        /// <exception cref="NullReferenceException">Arrojada cuando <paramref name="id"/> es <c>null</c>.</exception>
        /// <exception cref="UsuarioException">Arrojada cuando <paramref name="id"/> no corresponde a un usuario
        /// existente.</exception>
        /// <exception cref="ActualizarUsuarioException">Arrojada cuando ocurre un error indeterminado al modificar la
        /// información del usuario.</exception>
        public bool actualizarPerfil(string id,string nombre,string apellido,DateTime fechaNac,Multimedia fotoPerfil,
                                    TipoSexo tipoSexo,string correoElectronico,string ciudad,string pais)
        {
            Usuario usuario = buscarUsuario(id); // FIXME: se debería comprobar que id != null
                                                 // y que el usuario obtenido != null

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
                // FIXME: el repositorio fake arroja UsuarioException si el usuario no existe, mientras que el
                // repositorio json retorna null
                return usuario;
            }
            catch (UsuarioException ex)
            {
                throw ex;
            }
        }
    }
}
