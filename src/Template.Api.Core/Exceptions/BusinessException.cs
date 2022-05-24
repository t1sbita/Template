using Template.Api.Core.Error;
using System;
using System.Runtime.Serialization;

namespace Template.Api.Core.Exceptions
{
    [Serializable]
    public class BusinessException : Exception
    {
        public Problem _problem { get; set; }

        public Problem Problem { get { return _problem; } }

        protected BusinessException(SerializationInfo info, StreamingContext context) : base(info, context) { }
        public BusinessException(string message) : base(message) { }

        public BusinessException(Problem problema) : base()
        {
            _problem = problema;
        }

        public BusinessException(string message, Problem problem) : base(message)
        {
            _problem = problem;
        }
    }
}
