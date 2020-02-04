using System;
using System.Collections.Generic;
using System.Text;

namespace Xam.SqlHelper.Exceptions
{
    public class OptimisationException : SqlHelperException
    {
        private const string ExceptionMessage = "An exception occured during optimisation, consult inner for more details";

        public OptimisationException(Exception ex) : base(ExceptionMessage, ex)
        {

        }
    }
}
