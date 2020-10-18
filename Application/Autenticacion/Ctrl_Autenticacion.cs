using L01_Domain.Common;
using L01_Domain.Multimedias;
using L01_Domain.Usuarios;
using L02_Persistence;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace L01_Application.Autenticacion
{
    public class Ctrl_Autenticacion
    {

        /// <summary>
        /// Metodo que se encarga de obtener la informacion basica de la cuenta de Google con la que se accedio a la aplicacion
        /// </summary>
        /// <param name="accessToken">Token de acceso proporcionado por Google para porder obtener la informacion</param>
        /// <returns>Objeto de la clase GoogleOutputData que alamacena la informacion obtenidoa de la API de Google</returns>
        public GoogleUserOutputData obtenerInformacionGoogle(string accessToken)
        {

            GoogleUserOutputData usuario = null;
            HttpClient client = new HttpClient();
            string urlProfile;
            HttpResponseMessage output;

            try
            {
                urlProfile = "https://www.googleapis.com/oauth2/v1/userinfo?access_token=" + accessToken;

                client.CancelPendingRequests();
                output = client.GetAsync(urlProfile).Result;

            }
            catch (Exception)
            {
                throw new TokenInvalidoException("\n" + "No se pudo establecer conexión con Google" + "\n");
            }

            if (output.IsSuccessStatusCode)
            {
                string outputData = output.Content.ReadAsStringAsync().Result;
                usuario = JsonConvert.DeserializeObject<GoogleUserOutputData>(outputData);
            }
            else
            {
                throw new TokenInvalidoException("\n" + "El token ingresado es invalido" + "\n");
            }

            return usuario;
        }

        /// <summary>
        /// Metodo que permite la autenticacion de los usuarios, donde se obtiene la informacion de la cuenta de Google y se comprara 
        /// con la infomracion de la base de datos local para saber si el usuario esta registrado o no.
        /// </summary>
        /// <param name="accessToken">TOken de acceso proporcionado por la API de Google</param>
        /// <returns></returns>
        public bool autenticarUsuario(String accessToken)
        {
            GoogleUserOutputData usuario = obtenerInformacionGoogle(accessToken);

            Usuario usuarioBuscado = buscarUsuario(usuario.id);

            if (usuarioBuscado == null)
            {
                return false;
            }

            return true;
        }


        /// <summary>
        /// Metodo que le permite a un usuario registrar sus datos personales la primera vez que ingresa al sistema
        /// </summary>
        /// <param name="accessToken">Token generado por el API de Google</param>
        /// <param name="nombre">nombre del usuario</param>
        /// <param name="apellido">apellido del usuario</param>
        /// <param name="fechaNacimiento">fecha de nacimiento del usuario</param>
        /// <param name="fotoPerfiL">foto de perfil del usuario</param>
        /// <param name="sexo">sexo del usuario</param>
        /// <param name="ciudad">ciudad de origen del usuario</param>
        /// <param name="pais">pais del usuario</param>
        /// <param name="rol">rol del nuevo usuario</param>
        /// <returns>True si se registro correctamente</returns>
        public bool registrarDatosUsuario(String accessToken, String nombre, String apellido, DateTime fechaNacimiento, Multimedia fotoPerfiL, TipoSexo sexo, String ciudad, String pais, TipoRol rol)
        {
            GoogleUserOutputData usuario = obtenerInformacionGoogle(accessToken);

            Usuario usuarioBuscado = buscarUsuario(usuario.id);

            if (usuarioBuscado != null)
            {
                throw new UsuarioException("El usuario ya existe");
            }

            Usuario nuevoUsuario = new Usuario(usuario.id, nombre, apellido, fechaNacimiento, fotoPerfiL, sexo, usuario.email, ciudad, pais, rol);

            IRepositorioUsuario repositorioUsuarios = FabricaRepositoriosUsuarios.CrearRepositorioUsuarios("json");

            repositorioUsuarios.guardarUsuario(nuevoUsuario);

            return true;
        }


        /*
        public bool registrarDatosUsuario(String accessToken, String nombre, String apellido, DateTime fechaNacimiento,Multimedia fotoPerfiL, TipoSexo sexo,String ciudad, String pais, TipoRol rol, List<Multimedia> certificado, String descripcionExperiencia)
        {
            GoogleUserOutputData usuario = obtenerInformacionGoogle(accessToken);

            Usuario nuevoUsuario = FabricaUsuarios.CrearUsuario(usuario.id, nombre, apellido, fechaNacimiento,fotoPerfiL, sexo, usuario.email, ciudad, pais, rol, certificado, descripcionExperiencia);

            IRepositorioUsuario repositorioUsuarios = FabricaRepositoriosUsuarios.CrearRepositorioUsuarios();

            repositorioUsuarios.guardarUsuario(nuevoUsuario);

            return true;
        }
        */

        /// <summary>
        /// Metodo que permite buscar una usuario para saber si esta en la base de datos
        /// </summary>
        /// <param name="idUsuario">Id del usuario buscado</param>
        /// <returns>Usuario buscado</returns>
        public Usuario buscarUsuario(string idUsuario)
        {
            Usuario usuario = null;
            if (idUsuario is null)
                return null;
            IRepositorioUsuario repoU = FabricaRepositoriosUsuarios.CrearRepositorioUsuarios("json");
            usuario = repoU.buscarUsuario(idUsuario);
            return usuario;
        }

        public List<Usuario> getUsuarios()
        {
            IRepositorioUsuario repoU = FabricaRepositoriosUsuarios.CrearRepositorioUsuarios("json");
            return repoU.getUsuarios();
        }

    }
}
