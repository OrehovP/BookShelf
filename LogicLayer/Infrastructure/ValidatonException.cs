using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Infrastructure
{
    public class ValidatonException : Exception
    {
        public string Property { get; protected set; }
        public ValidatonException(string message, string property) : base(message)
        {
            Property = property;
        }
    }
}
