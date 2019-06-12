using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;

namespace MH_Control
{
    class ConnectionException : Exception
    {
        public ConnectionException() : base()
        {
        }

        public ConnectionException(string message) : base(message)
        {
        }

        public ConnectionException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public ConnectionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

    }
}
