using L01_Domain.Common;
using System;

namespace L01_Domain.Paciente
{
    public interface IPacienteCita
    {
        public string NombreCompleto { get; }
        public TipoSexo TipoSexo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string CorreoElectronico { get; set; }
    }
}
