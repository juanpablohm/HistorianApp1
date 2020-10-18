using System;
using System.Collections.Generic;
using System.Text;

namespace L01_Domain.Usuarios
{
    public class TokenInvalidoException: Exception
    {

        public TokenInvalidoException(String message): base(message)
        {

        }

    }
}
