using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using L01_Domain.Historias;
using L03_FakeDB;
using static L03_FakeDB.TablaHistoria;

namespace L02_Persistence
{
    public class RepositorioHistoriaFake:IRepositorioHistoria
    {
        /// <summary>
        /// Busca una historia existente
        /// </summary>
        /// <param name="idHistoria">Id de la historia a buscar</param>
        /// <returns>Retorna la historia encontrado, sino la encuentra null</returns>
        public Historia buscarHistoria(string idHistoria)
        {
            List<Historia> historias;
            String jsonString = TablaHistoria.ToJSON();
            historias = JsonSerializer.Deserialize<List<Historia>>(jsonString);
            Historia historia = historias.FirstOrDefault(h => h.id == idHistoria);

            return historia;
        }

        /// <summary>
        /// Este metodo trae la tabla de historias y adiciona a dicha a la tabla la nueva historia
        /// </summary>
        /// <param name="historia">CEste atributo es un objeto historia que contiene todos los datos
        /// necesarios para registrar la historia</param>
        /// <returns>retorna si se pudo agregar corrrectamente la historia a la tabla</returns>
        public bool registrarHistoria(Historia historia)
        {
            List<AtributosHistoria> historias = TablaHistoria.getTablaHistorias();
            AtributosHistoria historiaNueva = new AtributosHistoria(historia.id, historia.titulo, historia.fecha, historia.descripcion, historia.fotos, historia.idContador);
            historias.Add(historiaNueva);
            return true;
        }
    }
}
