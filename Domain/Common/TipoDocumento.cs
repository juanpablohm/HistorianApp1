using System;
using System.Collections.Generic;
using System.Text;

namespace L01_Domain.Paciente
{
    /// <summary>
    /// Enumeración para tipos de documentos
    /// </summary>
    public enum TipoDocumento
    {
        /// <summary> Cedula de ciudadanía </summary>
        CC,
        /// <summary> Cedula de extranjería  </summary>
        CE,
        /// <summary> Menor sin identificación  </summary>
        MS,
        /// <summary> Pasaporte </summary>
        PA
    }
}
