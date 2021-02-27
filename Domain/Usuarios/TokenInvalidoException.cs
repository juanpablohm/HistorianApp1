using System;

namespace L01_Domain.Usuarios
{
    public class TokenInvalidoException : Exception
    {

        public TokenInvalidoException(String message) : base(message)
        {

        }

    }
}
