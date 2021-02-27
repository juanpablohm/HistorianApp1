namespace L01_Domain.Historias
{
    public interface IRepositorioHistoria
    {
        bool registrarHistoria(Historia historia);
        Historia buscarHistoria(string idHistoria);
    }
}
