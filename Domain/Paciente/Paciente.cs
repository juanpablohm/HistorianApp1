using L01_Domain.Common;
using System;
using System.Reflection.Emit;

namespace L01_Domain.Paciente
{
    /// <summary>
    /// la clase Paciente contiene todos los métodos necesarios
    /// para manejar los atributos del paciente general de la EPS
    /// </summary>
    /// <remarks>
    /// Esta es una clase base para los otros tipos de pacientes
    /// sin embargo no es abstracta ya que representa a los pacientes
    /// de la EPS
    /// </remarks>
    public class Paciente : IPacienteCita
    {
        public int DocumentoId { get; set; }
        public TipoDocumento TipoDocumento { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string NombreCompleto { get { return Nombre + " " + Apellidos; } }
        public string Telefono1 { get; set; }
        public string Telefono2 { get; set; }
        public TipoSexo TipoSexo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string CorreoElectronico { get; set; }
        public string Direccion { get; set; }
        public string Departamento { get; set; }
        public string Municipio { get; set; }
        public EstadoCivil  EstadoCivil { get; set; }
        public string Ocupacion { get; set; }
        public string Religion { get; set; }
        public GradoEscolaridad GradoEscolaridad{ get; set; }
        public TipoSanguineo TipoSanguineo { get; set; }
        public string EPS { get; set; }

        public Paciente()
        {
            TipoSexo = TipoSexo.Hombre;
        }
    }
}
