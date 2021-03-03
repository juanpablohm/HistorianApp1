using L01_Domain.Multimedias;
using L01_Domain.SitiosHistoricos;
using System;
using System.Collections.Generic;
using System.Text;

namespace L01_Application.DTOs
{
    public class SitioHistoricoDTO
    {
        public string id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public List<Multimedia>? contenidoMultimedia { get; set; }
        public Posicion? posicion { get; set; }

        /// <summary>
        /// Realiza un mapeo a cada item de la lista entrante para convertirlo en una lista de 
        /// sitiosHistoricoDTO (Data Transfer Object)
        /// </summary>
        /// <param name="sitiosHistoricos"></param>
        /// <returns>Retorna una lista de objetos de la clase SitioHistoricoDTO</returns>
        public static List<SitioHistoricoDTO> MapperToDTO(List<SitioHistorico> sitiosHistoricos)
        {
            List<SitioHistoricoDTO> sitiosHistoricosDTOs = new List<SitioHistoricoDTO>();
            foreach(SitioHistorico sitioHistorico in sitiosHistoricos){
                
                SitioHistoricoDTO sitioHistoricoDTO = new SitioHistoricoDTO();
                sitioHistoricoDTO.id = sitioHistorico.id;
                sitioHistoricoDTO.nombre = sitioHistorico.nombre;
                sitioHistoricoDTO.descripcion = sitioHistorico.descripcion;
                sitioHistoricoDTO.contenidoMultimedia = sitioHistorico.contenidoMultimedia;
                sitioHistoricoDTO.posicion = sitioHistorico.posicion;

                sitiosHistoricosDTOs.Add(sitioHistoricoDTO);
            }
            return sitiosHistoricosDTOs;
        }
    }
}
