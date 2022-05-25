using System;
using System.Collections.Generic;
using System.Text;

namespace Practical
{
    public class NotFound : Exception
    {
        public NotFound(string message) : base(message) { }
    }
}
