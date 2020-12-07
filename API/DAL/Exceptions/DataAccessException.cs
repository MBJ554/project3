using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.DAL.Exceptions
{
    public class DataAccessException : Exception
    {
        public DataAccessException(string message, Exception exception) : base(message, exception)
        {

        }
    }
}