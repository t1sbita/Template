using System;
using System.Runtime.Serialization;

namespace Template.Api.Core.Exceptions
{
    [Serializable]

    public class PersistenceException : Exception
    {
        protected PersistenceException(SerializationInfo info, StreamingContext context) : base(info, context) { }
        public PersistenceException(string message) : base(message) { }
    }
}
