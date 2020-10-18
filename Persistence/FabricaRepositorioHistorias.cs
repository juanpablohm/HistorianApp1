using System;
using System.Collections.Generic;
using System.Text;
using L01_Domain.Historias;

namespace L02_Persistence
{
    public class FabricaRepositorioHistorias
    {
        public static IRepositorioHistoria CrearRepositorioHistorias()
        {
            var repo = "fake";

            return repo switch
            {
                "fake" => new RepositorioHistoriaFake(),
                _ => null,
            };
        }
    }
}
