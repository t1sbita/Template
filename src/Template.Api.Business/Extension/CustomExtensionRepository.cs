using Template.Api.Infrastructure.Data.Repository;
using Template.Api.Infrastructure.Data.Repository.Base;
using Template.Api.Infrastructure.Interfaces;
using Template.Api.Infrastructure.Interfaces.Base;
using Microsoft.Extensions.DependencyInjection;

namespace Template.Api.Business.Extension
{
    public static class CustomExtensionRepository
    {
        public static IServiceCollection AddScoped(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            
            services.AddScoped<IInfoRepository, InfoRepository>();
            services.AddScoped<ILogRepository, LogRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<IPessoaRepository, PessoaRepository>();
            
            return services;
        }
    }
}
