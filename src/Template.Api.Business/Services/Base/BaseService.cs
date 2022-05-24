using Template.Api.Core.Resources;
using Microsoft.Extensions.Logging;

namespace Template.Api.Business.Services.Base
{
    public class BaseService<T> where T : new()
    {
        protected readonly ILogger<T> _logger;

        protected readonly Resource _resource;

        public BaseService(ILogger<T> logger, Resource resource)
        {
            _logger = logger;
            _resource = resource;
        }
    }
}
