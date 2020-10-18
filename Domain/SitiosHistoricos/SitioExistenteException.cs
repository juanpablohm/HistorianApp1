using System;
using System.Collections.Generic;
using System.Text;

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
