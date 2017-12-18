using System;

namespace Ejercicio.ABC.Services.Exceptions
{
    public class DataAccessException : Exception
    {
        public static readonly string EXCEPTION = "Error de datos";

        public DataAccessException() { }
        public DataAccessException(string exception) : base(exception) { }
        public DataAccessException(string message, Exception inner) : base(message, inner) { }
    }
}