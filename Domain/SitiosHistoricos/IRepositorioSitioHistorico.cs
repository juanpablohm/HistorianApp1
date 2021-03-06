namespace L01_Domain.SitiosHistoricos
{
    public interface IRepositorioSitioHistorico
    {
        SitioHistorico getSitioHistoricoByName(string nombre);
        bool registrarSitioHistorico(SitioHistorico sitio);
    }
}
