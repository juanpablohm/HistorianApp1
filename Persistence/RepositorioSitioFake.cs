using L01_Domain.SitiosHistoricos;
using L01_Domain.Usuarios;
using L03_FakeDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using static L03_FakeDB.TablaSitioHistorico;

namespace L02_Persistence
{
    public class RepositorioSitioFake : IRepositorioSitioHistorico
    {
        /// <summary>
        /// Obtiene el sitio historico solicitado
        /// </summary>
        /// <param name="nombre">Nombre del sitio historico a buscar</param>
        /// <param name="ubicacion">Ubicacion del sitio historico a buscar</param>
        /// <returns>Retorna el sitio historico si existe, sino retorna null</returns>
        public SitioHistorico getSitioHistorico(string nombre, Posicion ubicacion)
        {
            String jsonString = TablaSitioHistorico.ToJSON();

            List<SitioHistorico> sitios = JsonSerializer.Deserialize<List<SitioHistorico>>(jsonString);

            SitioHistorico sitio = (from S in sitios where S.nombre == nombre || (S.posicion.latitud == ubicacion.latitud && S.posicion.longitud == ubicacion.longitud) select S).FirstOrDefault();
            
            return sitio;
        }

        /// <summary>
        /// Registra un nuevo sitio historico en la tabla de sitios historicos
        /// </summary>
        /// <param name="sitio">Sitio historico a registrar</param>
        /// <returns>Retorna true si el sitio historico se pudo añadir</returns>
        public bool registrarSitioHistorico(SitioHistorico sitio)
        {
            List<AtributosSitio> sitios = TablaSitioHistorico.getTablaSitios();
            AtributosSitio sitioNuevo = new AtributosSitio(sitio.id, sitio.nombre, sitio.descripcion, sitio.contenidoMultimedia, sitio.validez, sitio.historias, sitio.posicion);
            sitios.Add(sitioNuevo);
            return true;
        }

    }
}