﻿using System.Collections.Generic;

namespace L01_Domain.SitiosHistoricos
{
    public interface IRepositorioSitioHistorico
    {
        SitioHistorico getSitioHistorico(string nombre, Posicion ubicacion);
        bool registrarSitioHistorico(SitioHistorico sitio);
        List<SitioHistorico> getSitiosHistoricos();
        SitioHistorico getSitioHistoricoById(string id);
    }
}
