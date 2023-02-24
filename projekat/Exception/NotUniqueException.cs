using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjekatKlinika.Exception
{
    public class NotUniqueException : System.Exception
    {
        public NotUniqueException()
        {

        }
        public NotUniqueException(string message) : base(message)
        {

        }

        public NotUniqueException(string message, System.Exception inner) : base(message, inner)
        {

        }
    }
}
