using L01_Domain.SitiosHistoricos;

namespace L02_Persistence
{
    public class FabricaRepositorioSitiosHistoricos
    {
        /// <summary>
        /// Crea el repositorio de sitios historicos
        /// </summary>
        /// <returns>Retorna el repositorio</returns>
        public static IRepositorioSitioHistorico CrearRepositorioSitios()
        {
            //var repo = ConfigurationManager.AppSettings["repositoryUsuarios"];
            var repo = "fake";

            return repo switch
            {
                "fake" => new RepositorioSitioFake(),
                _ => null,
            };
        }
    }
}
