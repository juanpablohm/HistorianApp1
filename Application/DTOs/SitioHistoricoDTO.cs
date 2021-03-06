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
        /// <param name="sitiosHistoricos">Lista a mapear como DTO's</param>
        /// <returns>Retorna una lista de objetos de la clase SitioHistoricoDTO</returns>
        public static List<SitioHistoricoDTO> MapperListToDTO(List<SitioHistorico> sitiosHistoricos)
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


        /// <summary>
        /// Realiza un mapeo al item entrante para convertirlo en un 
        /// sitiosHistoricoDTO (Data Transfer Object)
        /// </summary>
        /// <param name="sitioHistorico">Objeto a mapear como DTO</param>
        /// <returns>Retorna un objeto de la clase SitioHistoricoDTO</returns>
        public static SitioHistoricoDTO MapperOneToDTO(SitioHistorico sitioHistorico)
        {
            SitioHistoricoDTO sitioHistoricoDTO = new SitioHistoricoDTO();

            sitioHistoricoDTO.id = sitioHistorico.id;
            sitioHistoricoDTO.nombre = sitioHistorico.nombre;
            sitioHistoricoDTO.descripcion = sitioHistorico.descripcion;
            sitioHistoricoDTO.contenidoMultimedia = sitioHistorico.contenidoMultimedia;
            sitioHistoricoDTO.posicion = sitioHistorico.posicion;

            return sitioHistoricoDTO;
        }
    }
}
