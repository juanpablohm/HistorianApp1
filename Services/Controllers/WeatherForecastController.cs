using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using L01_Application;
using L01_Domain.Paciente;

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
            catch(PacienteNoEncontradoException ex)
                {
                return "{"+ ex.Message+"}";
            }
        }
    }
}
