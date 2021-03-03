using L01_Application.DTOs;
using L01_Domain.SitiosHistoricos;
using L02_Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace L01_Application.ObtenerSitiosHistoricos
{
    public class Ctrl_SitioHistorico
    {
        /// <summary>
        /// Se obtiene una lista de todos los sitios históricos en el repositorio, para 
        /// después realizar la respectiva transformación a una lista de
        /// DTO's (Data Transfer Object)
        /// </summary>
        /// <returns>Retorna una lista de objetos de la clase SitioHistoricoDTO</returns>
        public List<SitioHistoricoDTO> getSitiosHistoricos()
        {
            IRepositorioSitioHistorico repoU = FabricaRepositorioSitiosHistoricos.CrearRepositorioSitios();
            List<SitioHistorico> sitiosHistoricos = repoU.getSitiosHistoricos();

            List<SitioHistoricoDTO> sitiosHistoricosDTOs = SitioHistoricoDTO.MapperToDTO(sitiosHistoricos);
            return sitiosHistoricosDTOs;
        }
    }
}
