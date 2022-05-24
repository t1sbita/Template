using Microsoft.Extensions.Logging;

namespace Template.Api.Models.ViewModels
{
    /// <summary>
    /// LogViewModel
    /// </summary>
    public class LogViewModel
    {
        /// <summary>
        /// LogViewModel.Mensagem
        /// </summary>
        public string Mensagem { get; set; }
        /// <summary>
        /// LogViewModel.Mensagem
        /// </summary>
        public LogLevel LogLevel { get; set; }
    }
}
