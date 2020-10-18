using L01_Domain.Multimedias;
using L01_Domain.SitiosHistoricos;
using L02_Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace L01_Application.RegistrarSitio
{
    public class Ctrl_RegistrarSitio
    {

        /// <summary>
        /// Registra un nuevo sitio historico
        /// </summary>
        /// <param name="nombre">Nombre del sitio historico</param>
        /// <param name="descripcion">Descripcion del sitio historico</param>
        /// <param name="archivos">Archivos multimedia que se van añadir al sitio</param>
        /// <param name="idHistoriador">Id del historiador que registra el sitio</param>
        /// <returns></returns>
        public bool registrarSitio(string nombre, string descripcion, List<Multimedia> archivos, string idHistoriador)
        {
            Posicion posicionActual = new Ctrl_Georeferenciador().obtenerUbicacion();
            bool existe = verificarSitioExistente(nombre, posicionActual);
            bool archivosCorrectos = verificarArchivos(archivos);

            if (existe == false && archivosCorrectos == true)
            {
                IRepositorioSitioHistorico repoSitio = FabricaRepositorioSitiosHistoricos.CrearRepositorioSitios();
                SitioHistorico sitio = new SitioHistorico(Guid.NewGuid().ToString(), nombre, descripcion, archivos, 0, null, posicionActual);
                bool registrado = repoSitio.registrarSitioHistorico(sitio);
                return registrado;
            }
            return false;
        }

        /// <summary>
        /// Verifica que los archivos enviados esten correctos
        /// </summary>
        /// <param name="archivos">Archivos a verificar</param>
        /// <returns>Retorna true si los archivos enviados son correctos</returns>
        public bool verificarArchivos(List<Multimedia> archivos)
        {
            return true;
        }

        /// <summary>
        /// Verifica si un sitio historico ya existe previamente
        /// </summary>
        /// <param name="nombre">Nombre del sitio historico a verificar</param>
        /// <param name="ubicacion">Ubicacion del sitio historioc a verificar</param>
        /// <returns>Returna false si el sitio historico no existe previamente, sino retorna la excepcion SitioExistenteException</returns>
        public bool verificarSitioExistente(string nombre, Posicion ubicacion)
        {
            IRepositorioSitioHistorico repoSitio = FabricaRepositorioSitiosHistoricos.CrearRepositorioSitios();
            SitioHistorico sitio = repoSitio.getSitioHistorico(nombre, ubicacion);

            if (sitio != null)
            {
                throw new SitioExistenteException("El sitio historio " + nombre + " ya esta registrado");
            }
            else
            {
                return false;
            }
        }
    }
}
