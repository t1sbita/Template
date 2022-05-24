using Quartz;
using System.Diagnostics.CodeAnalysis;

namespace Template.Worker.Extensions
{
    /// <summary>
    /// ExtensionQuartz
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class ExtensionQuartz
    {
        private const string NamespaceOfService = "Template.Worker.Background";
        private const string AssemblyNameOfService = "Template.Worker";
        /// <summary>
        /// ExtensionQuartz.StartScheduler
        /// </summary>
        /// <returns></returns>
        public static IServiceCollection ConfigureQuartz(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<QuartzOptions>(configuration.GetSection("Quartz"));
            services.AddQuartz(q =>
            {
                q.SchedulerId = "UpdateDbService-Background";
                q.UseMicrosoftDependencyInjectionJobFactory();
                q.UseSimpleTypeLoader();
                q.UseInMemoryStore();
                q.UseDefaultThreadPool(tp =>
                {
                    tp.MaxConcurrency = 5;
                });
            });
            var serviceProvider = services.BuildServiceProvider();

            ScheduleJobs(services, configuration);

            return services;
        }

        /// <summary>
        /// ExtensionQuartz.StartQuartzScheduler
        /// </summary>
        /// <returns></returns>
        private static void ScheduleJobs(this IServiceCollection services, IConfiguration config)
        {
            var schedulers = config.GetSection("QuartzJobs").GetChildren();

            if (schedulers == null)
                throw new MissingFieldException($"Appsettings not configured properly");

            foreach (var scheduler in schedulers)
            {
                var type = Type.GetType($"{NamespaceOfService}.{scheduler.Key},{AssemblyNameOfService}");

                if (type == null)
                    throw new MissingFieldException($"Scheduler {scheduler.Key} isn't been configured");

                services.AddSingleton(new JobSchedule(
                jobType: type,
                cronExpression: scheduler.Value
                ));
            }
            
        }

    }
}
