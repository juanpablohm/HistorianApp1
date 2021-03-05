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

            List<SitioHistoricoDTO> sitiosHistoricosDTOs = SitioHistoricoDTO.MapperListToDTO(sitiosHistoricos);
            return sitiosHistoricosDTOs;
        }

        /// <summary>
        /// Se obtiene un sitio histórico del repositorio, para 
        /// después realizar la respectiva transformación a un DTO (Data Transfer Object)
        /// </summary>
        /// <param name="id">cadena que contiene el id del sitio historico a buscar</param>
        /// <returns>Retorna un objeto de la clase SitioHistoricoDTO</returns>
        public SitioHistoricoDTO getSitioHistorico(string id)
        {
            IRepositorioSitioHistorico repoU = FabricaRepositorioSitiosHistoricos.CrearRepositorioSitios();
            SitioHistorico sitioHistorico = repoU.getSitioHistoricoById(id)
                ?? throw new SitioHistoricoException($"El Sitio Historico con id=\"{id}\" no existe.");

            SitioHistoricoDTO sitioHistoricoDTO = SitioHistoricoDTO.MapperOneToDTO(sitioHistorico);
            return sitioHistoricoDTO;
        }
    }
}
