using System;
using System.Collections.Generic;
using System.Text;

namespace L01_Domain.Usuarios
{
    public class ActualizarUsuarioException : Exception
    {

        public ActualizarUsuarioException()
        {

        }

        public ActualizarUsuarioException(string msg): base(msg)
        {

        }
    }
}
