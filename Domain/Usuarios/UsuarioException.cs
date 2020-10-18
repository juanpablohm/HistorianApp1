using System;
using System.Collections.Generic;
using System.Text;

namespace L01_Domain.Usuarios
{
    public class UsuarioException : Exception
    {

        public UsuarioException()
        {

        }

        public UsuarioException(string msg): base(msg)
        {

        }
    }
}
