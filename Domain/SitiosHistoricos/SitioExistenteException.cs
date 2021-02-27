using System;

namespace L01_Domain.SitiosHistoricos
{
    public class SitioExistenteException : Exception
    {
        public SitioExistenteException()
        {

        }

        public SitioExistenteException(string message) : base(message)
        {

        }
    }
}
