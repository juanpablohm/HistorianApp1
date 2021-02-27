using L01_Application.Autenticacion;
using L01_Application.DTOs;
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
        /// Modifica la información del usuario identificado con <c>usuarioDTO.id</c>, reemplazando los valores de los
        /// atributos del usuario con los valores del DTO diferentes a <c>null</c>.
        /// </summary>
        /// <param name="usuarioDTO">DTO con el ID del usuario cuya información se desea modificar, y los nuevos 
        /// valores de los atributos que se desean modificar. Si un atributo no se desea modificar, no se debe
        /// modificar su valor inicial de <c>null</c> en el DTO.</param>
        /// <returns>Un valor booleano indicando si la operación fue exitosa.</returns>
        /// <exception cref="ArgumentNullException">Arrojada cuando <c>usuarioDTO.id</c> es <c>null</c>.</exception>
        /// <exception cref="UsuarioException">Arrojada cuando <c>usuarioDTO.id</c> no corresponde a un usuario
        /// existente.</exception>
        /// <exception cref="ActualizarUsuarioException">Arrojada cuando ocurre un error indeterminado al modificar la
        /// información del usuario.</exception>
        public bool ActualizarPerfil(DTOs.UsuarioDTO usuarioDTO)
        {
            string id = usuarioDTO.id ?? throw new ArgumentNullException(nameof(usuarioDTO.id));
            var usuario = buscarUsuario(id) ?? throw new UsuarioException($"El usuario con id=\"{id}\" no existe.");
            usuarioDTO.TransferirDatosA(usuario);

            IRepositorioUsuario repoU = FabricaRepositoriosUsuarios.CrearRepositorioUsuarios("fake");
            repoU.actualizarPerfilUsuario(usuario);

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
