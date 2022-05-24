using Microsoft.Extensions.Logging;

namespace Template.Api.Core.Domain.Entities
{
    public class Log
    {
        public string Mensagem { get; set; }
        public LogLevel LogLevel { get; set; }
    }
}
