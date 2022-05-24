using Microsoft.Extensions.Configuration;

namespace Template.Api.Utils
{
    /// <summary>
    /// Para uso da secrets
    /// </summary>
    public class MyOptions
    {
        /// <summary>
        /// Configuração do app.
        /// </summary>
        public IConfiguration Configuration { get; internal set; }
    }
}
