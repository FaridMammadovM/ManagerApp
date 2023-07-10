using System;
using System.Runtime.Serialization;

namespace ITS.PMT.Api.Infrastructue.Exceptions
{
    [Serializable]
    public class ApiException : Exception
    {
        public virtual int StatusCode => 400;




        public ApiException() : base()
        {
        }

        public ApiException(string message) : base(message)
        {

        }

        protected ApiException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
