using System;
using System.Runtime.Serialization;

namespace ITS.PMT.Api.Infrastructue.Exceptions
{
    [Serializable]
    public class ApiNotFoundException : ApiException
    {
        public override int StatusCode => 404;

        public ApiNotFoundException() : base()
        {
        }

        public ApiNotFoundException(string message) : base(message)
        {
        }

        protected ApiNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
