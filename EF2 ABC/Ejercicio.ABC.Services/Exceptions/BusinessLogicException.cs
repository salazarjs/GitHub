using System;

namespace Ejercicio.ABC.Services.Exceptions
{
    public class BusinessLogicException : Exception
    {
        public static readonly string EXCEPTION = "Error de logica";

        public BusinessLogicException() { }
        public BusinessLogicException(string message) : base(message) { }
        public BusinessLogicException(string message, Exception inner) : base(message, inner) { }
    }
}