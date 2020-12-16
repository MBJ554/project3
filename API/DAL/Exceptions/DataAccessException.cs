using System;

namespace API.DAL.Exceptions
{
    public class DataAccessException : Exception
    {
        public DataAccessException(string message, Exception exception) : base(message, exception)
        {
        }
    }
}