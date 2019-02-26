using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Policy_Exception
{
    public class PolicyException : Exception
    {
        public PolicyException(string message) : base(message)
        {

        }
    }
}
