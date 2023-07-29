using System;

namespace Escola.API.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) :base (message)
        {
            
        }
    }
}
