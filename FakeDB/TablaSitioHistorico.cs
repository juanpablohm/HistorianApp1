using L01_Domain.Historias;
using L01_Domain.Multimedias;
using L01_Domain.SitiosHistoricos;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace L03_FakeDB
{
    public class TablaSitioHistorico
    {
        private static List<AtributosSitio> sitios = new List<AtributosSitio>();

        public class AtributosSitio
        {
            public string id { get; set; }
            public string nombre { get; set; }
            public string descripcion { get; set; }
            public List<Multimedia> contenidoMultimedia { get; set; }
            public float validez { get; set; }
            public List<Historia> historias { get; set; }
            public Posicion posicion { get; set; }

            /// <summary>
            /// Instancia un nuevo sitio historico
            /// </summary>
            /// <param name="id"></param>
            public AtributosSitio(string id)
            {
                Random random = new Random();
                this.id = id;
                nombre = "Sitio Historico " + id;
                descripcion = "Descripcion del sitio historico " + id;
                contenidoMultimedia = new List<Multimedia>();
                validez = random.Next(0, 10);
                historias = new List<Historia>();
                posicion = new Posicion(Guid.NewGuid().ToString(), random.Next(1, 10), random.Next(1, 10), "Direccion de la posicion");
            }

            public AtributosSitio(string id, string nombre, string descripcion, List<Multimedia> contenidoMultimedia, float validez, List<Historia> historias, Posicion posicion) : this(id)
            {
                this.nombre = nombre;
                this.descripcion = descripcion;
                this.contenidoMultimedia = contenidoMultimedia;
                this.validez = validez;
                this.historias = historias;
                this.posicion = posicion;
            }

            public string ToJSON()
            {
                return JsonSerializer.Serialize(this);
            }
        }

        /// <summary>
        /// Instancia una cantidad de sitios historicos definida
        /// </summary>
        /// <param name="numeroSitios">Numero de sitios historicos a instanciar</param>
        public static void InstanciarSitios(int numeroSitios)
        {
            for(int i = 0; i < numeroSitios; i++)
            {
                sitios.Add(new AtributosSitio(Guid.NewGuid().ToString()));
            }
        }

        public static String ToJSON()
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            return JsonSerializer.Serialize(sitios, options);
        }

        public static List<AtributosSitio> getTablaSitios()
        {
            return sitios;
        }

    }
}
