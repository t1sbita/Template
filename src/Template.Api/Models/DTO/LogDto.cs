using Microsoft.Extensions.Logging;

namespace Template.Api.Models.DTO
{
    /// <summary>
    /// LogDto
    /// </summary>
    public class LogDto
    {
        /// <summary>
        /// LogDto.Mensagem
        /// </summary>
        public string Mensagem { get; set; }

        /// <summary>
        /// LogDto.LogLevel
        /// </summary>
        public LogLevel LogLevel { get; set; }
    }
}
