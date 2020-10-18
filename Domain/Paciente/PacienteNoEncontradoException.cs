using System;
using System.Collections.Generic;
using System.Text;

namespace L01_Domain.Paciente
{
    [Serializable]
    public class PacienteNoEncontradoException : Exception
    {
        public PacienteNoEncontradoException()
        {
        }

        public PacienteNoEncontradoException(string message)
            : base(message)
        {
        }

        public PacienteNoEncontradoException(string message, Exception inner)
            : base(message, inner)
        {
        }

    }
}