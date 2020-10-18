using L01_Domain.SitiosHistoricos;
using System;
using System.Collections.Generic;
using System.Text;

namespace L01_Application.RegistrarSitio
{
    public class Ctrl_Georeferenciador
    {
        /// <summary>
        /// Obtiene la ubicacion geografica del usuario
        /// </summary>
        /// <returns>Retorna la posicion del usuario</returns>
        public Posicion obtenerUbicacion()
        {
            Random random = new Random();
            Posicion posicion = new Posicion(Guid.NewGuid().ToString(), random.Next(1, 10), random.Next(1, 10), "Direccion de la posicion");
            return posicion;
        }
    }
}