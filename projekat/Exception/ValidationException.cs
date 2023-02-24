using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjekatKlinika.Exception
{
    public class ValidationException : System.Exception
    {
        public ValidationException()
        {

        }

        public ValidationException(string message) : base(message)
        {

        }

        public ValidationException(string message, System.Exception inner) : base(message, inner)
        {

        }
    }
}
