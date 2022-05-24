using System.Runtime.Serialization;

namespace Template.Api.Core.Exceptions
{
    [Serializable]
    public class AuthorizationException : Exception
    {
        protected AuthorizationException(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AuthorizationException() : base() { }

        public AuthorizationException(string message) : base(message) { }
    }
}
