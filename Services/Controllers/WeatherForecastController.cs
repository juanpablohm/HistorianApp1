using L01_Application;
using L01_Domain.Paciente;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Services.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        [HttpGet("{id}")]
        public String Get(string id)
        {
            CtrlAsignarCita ctrlC = new CtrlAsignarCita();
            try
            {

                return ctrlC.BuscarPaciente(id);
            }
            catch (PacienteNoEncontradoException ex)
            {
                return "{" + ex.Message + "}";
            }
        }
    }
}
