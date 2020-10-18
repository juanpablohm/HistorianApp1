using L01_Domain.Multimedias;
using L01_Domain.Usuarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace L01_Domain.Historias
{
    /// <summary>
    /// Mi primera clase de historia :)
    /// </summary>
    public class Historia
    {

        public string id { get; set; }
        public string titulo { get; set; }
        public DateTime fecha { get; set; }
        public string descripcion { get; set; }
        public List<Multimedia> fotos { get; set; }
        public string idContador { get; set; }

        public Historia(string id, string titulo, DateTime fecha, string descripcion, List<Multimedia> fotos, string idContador)
        {
            this.id = id;
            this.titulo = titulo;
            this.fecha = fecha;
            this.descripcion = descripcion;
            this.fotos = fotos;
            this.idContador = idContador;
        }

        public Historia()
        {

        }
    }
}
