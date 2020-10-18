using L01_Domain.Historias;
using L01_Domain.Multimedias;
using System;
using System.Collections.Generic;
using System.Text;

namespace L01_Domain.SitiosHistoricos
{
    public class SitioHistorico
    {
        public string id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public List<Multimedia> contenidoMultimedia { get; set; }
        public float validez { get; set; }
        public List<Historia> historias { get; set; }
        public Posicion posicion { get; set; }


        public SitioHistorico(string id, string nombre, string descripcion, List<Multimedia> contenidoMultimedia, float validez, List<Historia> historias, Posicion posicion)
        {
            this.id = id;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.contenidoMultimedia = contenidoMultimedia;
            this.validez = validez;
            this.historias = historias;
            this.posicion = posicion;
        }

        public SitioHistorico()
        {

        }

    }
}
