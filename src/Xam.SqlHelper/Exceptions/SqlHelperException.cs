using System;
using System.Collections.Generic;
using System.Text;

namespace Xam.SqlHelper.Exceptions
{
    public class SqlHelperException : Exception
    {
        public SqlHelperException()
        {

        }

        public SqlHelperException(string message) : base(message)
        {
            
        }

        public SqlHelperException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}
