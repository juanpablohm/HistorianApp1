using L01_Domain.Paciente;
using L01_Application.GestionarPerfil;
using L02_Persistence;
using System;
using L01_Domain.Usuarios;
using L03_FakeDB;
using L01_Application.RegistrarSitio;
using L01_Domain.SitiosHistoricos;
using System.Globalization;
using L01_Application.Autenticacion;
using L01_Application.RegistrarHistoria;

namespace CoreCmTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Autenticar();
        }

        public static void registrarSitio()
        {
            //Generacion de nuevos sitios y de la tabla
            TablaSitioHistorico.InstanciarSitios(3);
            string sitios = TablaSitioHistorico.ToJSON();
            Console.WriteLine(sitios);

            //// Tests de verificar sitio historico
            //try
            //{
            //    Console.WriteLine("Ingrese el nombre del sitio a buscar: ");
            //    string nombreSitio = Console.ReadLine();
            //    Console.WriteLine("Ingrese la latitud: ");
            //    string latitud = Console.ReadLine();
            //    Console.WriteLine("Ingrese la longitud: ");
            //    string longitud = Console.ReadLine();
            //    Posicion posicion = new Posicion(Guid.NewGuid().ToString(), float.Parse(latitud, CultureInfo.InvariantCulture.NumberFormat), float.Parse(longitud, CultureInfo.InvariantCulture.NumberFormat), "Direccion");
            //    bool encontrado = new Ctrl_RegistrarSitio().verificarSitioExistente(nombreSitio, posicion);
            //    Console.WriteLine(encontrado);
            //}
            //catch (SitioExistenteException ex)
            //{
            //    Console.WriteLine("ERROR-->" + ex.Message);
            //}

            // Tests de crear nuevo sitio historicos
            try
            {
                bool registrado = new Ctrl_RegistrarSitio().registrarSitio("Nombre", "Descripcion", null, "idHistoriador");
                Console.WriteLine(registrado);
                sitios = TablaSitioHistorico.ToJSON();
                Console.WriteLine(sitios);
            }
            catch (SitioExistenteException ex)
            {
                Console.WriteLine("ERROR-->" + ex.Message);
            }

            Console.ReadLine();
        }

        public static void gestionarPerfil()
        {
            /* Test the JSON generetion */
            L03_FakeDB.TablaUsuario.InstanciarUsuarios(20);
            String s = L03_FakeDB.TablaUsuario.ToJSON();
            Console.WriteLine(s);

            /* Test Controladora para buscar Usuario */
            try
            {
                Console.WriteLine("Indique el id del usuario a buscar: ");
                String idUsuario = Console.ReadLine();
                Ctrl_GestionarPerfil controlGestionar = new Ctrl_GestionarPerfil();
                Usuario usuario = controlGestionar.buscarUsuario(idUsuario);
                Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(usuario));

            }
            catch (UsuarioException ex)
            {
                Console.WriteLine("ERROR-->" + ex.Message);
            }

            /* Test Controladora para actualizar Usuario */
            try
            {
                Console.WriteLine("Indique el id del usuario a actualizar: ");
                String idUsuario = Console.ReadLine();
                Ctrl_GestionarPerfil controlGestionar = new Ctrl_GestionarPerfil();

                //Aquí obtengo el valor anterior
                Usuario usuario = controlGestionar.buscarUsuario(idUsuario);
                Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(usuario));

                //Realizar la actualizacion
                bool confirmacion = controlGestionar.actualizarPerfil(idUsuario, "edit", "edit", usuario.fechaNacimiento, null, 0, "edit", "edit", "edit");

                //Verificar actualizacion
                Usuario usu = controlGestionar.buscarUsuario(idUsuario);
                Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(usu));
            }
            catch (UsuarioException ex)
            {
                Console.WriteLine("ERROR-->" + ex.Message);
            }

            Console.ReadLine();
        }

        public static void registrarHistoria()
        {
            Ctrl_RegistrarHistoria controlarHistoria = new Ctrl_RegistrarHistoria();
            DateTime fecha = new DateTime(2020, 08, 08);
            controlarHistoria.registrarHistoria("La historia", fecha, "Que lindo dia", null, "15");


            string historias = TablaHistoria.ToJSON();


            Console.WriteLine(historias);
        }

        public static void Autenticar()
        {
            Ctrl_Autenticacion controlAutenticar = new Ctrl_Autenticacion();

            try
            {
                Console.WriteLine("Ingrese el AccessToken proporcionado por Google: ");
                String accessToken = Console.ReadLine();
                bool registrado = controlAutenticar.autenticarUsuario(accessToken);

                if (registrado)
                {
                    Console.WriteLine("\n" + "El usuario se a autenticado con exitos" + "\n");
                }
                else
                {
                    Console.WriteLine("\n" + "El usuario no esta registrado" + "\n");
                }

            }
            catch (TokenInvalidoException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Ingrese el AccessToken proporcionado por Google: ");
            String accessToken2 = Console.ReadLine();

            Console.WriteLine("Ingrese su nombre ");
            String nombre = Console.ReadLine();


            Console.WriteLine("Ingrese su apellido ");
            String apellido = Console.ReadLine();

            Console.WriteLine("Ingrese su ciudad de origen : ");
            String ciudad = Console.ReadLine();


            var options = new System.Text.Json.JsonSerializerOptions
            {
                WriteIndented = true
            };

            // Prueba crear un usuario normal
            try
            {

                controlAutenticar.registrarDatosUsuario(accessToken2, nombre, apellido, DateTime.Now, null, L01_Domain.Common.TipoSexo.Hombre, ciudad, null, L01_Domain.Common.TipoRol.Usuario);
                Console.WriteLine("Se han registrado sus datos con exito");
                Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(controlAutenticar.getUsuarios(), options));

            }
            catch (UsuarioException ex)
            {
                Console.WriteLine(ex.Message);
            }catch(TokenInvalidoException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

    }
}
