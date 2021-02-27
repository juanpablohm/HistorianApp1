using System;

namespace L01_Domain.Usuarios
{
    public class UsuarioException : Exception
    {

        public UsuarioException()
        {

        }

        public UsuarioException(string msg) : base(msg)
        {

        }
    }
}
