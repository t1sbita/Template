using Template.Api.Business.Extension;

namespace Template.Api.Extension
{
    /// <summary>
    /// CustomExtensionID
    /// </summary>
    public static class CustomExtensionID
    {
        /// <summary>
        /// CustomExtensionID.AddSingleton
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddSingletons(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            return services;
        }

        /// <summary>
        /// CustomExtensionID.AddScoped
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddScopeds(this IServiceCollection services)
        {
            CustomExtensionRepository.AddScoped(services);
            
            return services;
        }

    }
}
