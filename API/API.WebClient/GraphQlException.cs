using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.WebClient
{
    public class GraphQlException : ApplicationException
    {
        public GraphQlException(string message) : base(message)
        {
        }
    }
}
