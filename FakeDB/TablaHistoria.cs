using L01_Domain.Usuarios;
using L01_Domain.Multimedias;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace L03_FakeDB
{
    public static class TablaHistoria
    {
        private static List<AtributosHistoria> historias = new List<AtributosHistoria>();
        public class AtributosHistoria
        {
            public string id { get; set; }
            public string titulo { get; set; }
            public DateTime fecha { get; set; }
            public string descripcion { get; set; }
            public List<Multimedia> fotos { get; set; }
            public string idContador { get; set; }

            public AtributosHistoria(string id, string titulo, DateTime fecha, string descripcion, List<Multimedia> fotos, string idContador)
            {
                this.id = id;
                this.titulo = titulo;
                this.fecha = fecha;
                this.descripcion = descripcion;
                this.fotos = fotos;
                this.idContador = idContador;
            }

            public string ToJSON()
            {
                return JsonSerializer.Serialize(this);
            }
        }

        public static String ToJSON()
        {
            
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            return JsonSerializer.Serialize(historias, options);
        }

        public static List<AtributosHistoria> getTablaHistorias()
        {
            return historias;
        }
    }
}
