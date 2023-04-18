using System;

namespace ParkingWebApplication.Models
{
    public class EmptyQueryResultExceptionException : Exception
    {
        public EmptyQueryResultExceptionException() { }
        public EmptyQueryResultExceptionException(string message) : base(message) { }
        public EmptyQueryResultExceptionException(string message, Exception inner) : base(message, inner) { }
    }
}