using L01_Domain.Common;
using L01_Domain.Multimedias;
using L01_Domain.SitiosHistoricos;
using System;
using System.Collections.Generic;
using System.Text;

namespace L01_Domain.Usuarios
{
    public class Historiador : Usuario
    {

        public List<Multimedia> certificado { get; set; }
        public String descripcionExperiencia { get; set; }
        public bool autorizado { get; set; }
        public List<SitioHistorico> sitiosHistoricos { get; set; }

        public Historiador(string id, string nombre, string apellido, DateTime fechaNacimiento, Multimedia fotoPerfil, TipoSexo tipoSexo, string correoElectronico, string ciudad, string pais, TipoRol rol, List<Multimedia> certificado, string descripcionExperiencia) :
            base(id, nombre, apellido, fechaNacimiento, fotoPerfil, tipoSexo, correoElectronico, ciudad, pais, rol)
        {
            this.certificado = certificado;
            this.descripcionExperiencia = descripcionExperiencia;
            this.autorizado = false;
            this.sitiosHistoricos = new List<SitioHistorico>();
        }

        public bool agregarSitio(string nombre, string descripcion, List<Multimedia> archivos, Posicion ubicacion)
        {
            return false;
        }

    }
}
