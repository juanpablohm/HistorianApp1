using System;
using System.Collections.Generic;
using System.Text;

namespace L01_Domain.SitiosHistoricos
{
    public class Posicion
    {
        public string id { get; set; }
        public float latitud { get; set; }
        public float longitud { get; set; }
        public string direccion { get; set; }

        public Posicion(string id, float latitud, float longitud, string direccion)
        {
            this.id = id;
            this.latitud = latitud;
            this.longitud = longitud;
            this.direccion = direccion;
        }

        public Posicion()
        {

        }
    }
}
