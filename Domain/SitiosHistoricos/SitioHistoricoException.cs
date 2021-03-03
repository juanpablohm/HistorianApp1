using System;

namespace L01_Domain.SitiosHistoricos
{
    public class SitioHistoricoException : Exception
    {
        public SitioHistoricoException()
        {

        }

        public SitioHistoricoException(string message) : base(message)
        {

        }
    }
}