using System;
using System.Collections.Generic;
using System.Text;

namespace L01_Domain.Multimedias
{
    public class Multimedia
    {

		public string id { get; set; }
		public string nombreArchivo { get; set; }
		public string tamano { get; set; }
		public string url { get; set; }
		public string tipo { get; set; }
		public string formato { get; set; }


        public Multimedia(string id, string nombreArchivo, string tamano, string url, string tipo, string formato)
        {
            this.id = id;
            this.nombreArchivo = nombreArchivo;
            this.tamano = tamano;
            this.url = url;
            this.tipo = tipo;
            this.formato = formato;
        }
        public Multimedia()
        {

        }
    }
}
