using L01_Domain.Common;
using L01_Domain.Multimedias;
using System;

namespace L01_Domain.Usuarios
{
    public class ContadorHistorias : Usuario
    {
        public ContadorHistorias(string id, string nombre, string apellido, DateTime fechaNacimiento, Multimedia fotoPerfil, TipoSexo tipoSexo, string correoElectronico, string ciudad, string pais, TipoRol rol) :
            base(id, nombre, apellido, fechaNacimiento, fotoPerfil, tipoSexo, correoElectronico, ciudad, pais, rol)
        {

        }
    }
}
