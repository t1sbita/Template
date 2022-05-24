using Template.Api.Core.Resources;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using System.Diagnostics.CodeAnalysis;

namespace Template.Api.Core.Util
{
    [ExcludeFromCodeCoverage]
    public static class ResourceFactory
    {
        public static Resource Create()
        {
            var localizationOptions = new LocalizationOptions
            {
                ResourcesPath = "Resources"
            };
            var options = Options.Create(localizationOptions);
            var factory = new ResourceManagerStringLocalizerFactory(options, NullLoggerFactory.Instance);

            return new Resource(factory);
        }
    }
}
