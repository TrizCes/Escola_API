using System;

namespace Escola.API.Exceptions
{
    public class NotaInvalidaException : Exception
    {
        public NotaInvalidaException(string message) : base(message)
        { }
    }
}
