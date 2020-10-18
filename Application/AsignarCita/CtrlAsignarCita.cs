using System;
using L01_Domain;
using L01_Domain.Paciente;
using L02_Persistence;

namespace L01_Application
{
    public class CtrlAsignarCita
    {
        
        public String BuscarPaciente(String idPaciente)
        {
            try
            {   if(idPaciente is null)
                    return "{null}";
                IPacienteCita paciente = RepositorioPacientes.GetPaciente(int.Parse(idPaciente));
                return System.Text.Json.JsonSerializer.Serialize(paciente);
            }
            catch (PacienteNoEncontradoException ex)
            {
                throw ex;
            }
         
        }

    }
}
