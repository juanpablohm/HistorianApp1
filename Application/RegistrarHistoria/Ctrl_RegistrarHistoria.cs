using L01_Domain.Historias;
using L01_Domain.Multimedias;
using L01_Domain.SitiosHistoricos;
using L01_Domain.Usuarios;
using L02_Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace L01_Application.RegistrarHistoria
{
    public class Ctrl_RegistrarHistoria
    {
        /// <summary>
        /// Este metodo crea los repositorios de historia y ejecuta el metodo registrarHistoria mandando la historia para
        /// agregarla.
        /// </summary>
        /// <param name="tituloHistoria">Titulo que tendra la historia</param>
        /// <param name="fecha">Indica la fecha de cuando ocurrio la historia</param>
        /// <param name="descripcion">Descripcion de la historia</param>
        /// <param name="fotos">Fotos que se tomaron cuando paso la historia</param>
        /// <param name="idContador">El identificador de quien conto la historia</param>
        /// <returns>retorna la confirmacion de si fue agreagada o no la historia</returns>
        public bool registrarHistoria(string tituloHistoria, DateTime fecha, string descripcion, List<Multimedia> fotos, string idContador)
        {
            IRepositorioHistoria repoHistoria = FabricaRepositorioHistorias.CrearRepositorioHistorias();
            Historia historia = new Historia(Guid.NewGuid().ToString(), tituloHistoria, fecha, descripcion, fotos, idContador);
            bool registrado = repoHistoria.registrarHistoria(historia);
            return registrado;
        }

        public bool verificarArchivos(List<Multimedia> archivos)
        {
            return true;
        }

        public Historia buscarHistoria(string idHistoria)
        {
            IRepositorioHistoria repoHistoria = FabricaRepositorioHistorias.CrearRepositorioHistorias();
            Historia sitio = repoHistoria.buscarHistoria(idHistoria);
            return sitio;

        }
    }
}
