using System;
using System.Runtime.Serialization;

namespace ITS.PMT.Api.Infrastructue.Exceptions
{
    [Serializable]
    public class ApiServiceException : ApiException
    {
        public ApiServiceException() : base()
        {
        }

        public ApiServiceException(string message) : base(message)
        {
        }

        protected ApiServiceException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
