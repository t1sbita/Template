using Autofac.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using NLog.Web;
using System.Reflection;
using Template.Worker.Extensions;
using Template.Worker.Background;
using Template.Worker.Data.Context;

namespace Template.Worker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole().AddEventLog();
            });

            var logger = loggerFactory.CreateLogger<Program>();
            IConfiguration _configuration = null;
            string executablePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            return Host.CreateDefaultBuilder(args)
                .UseNLog()
                .UseEnvironment("Development")
                .UseWindowsService()
                .ConfigureLogging(logging =>
                {
                    logging.AddConfiguration(_configuration.GetSection("Logging"));
                    logging
                        .AddConsole()
                        .AddDebug()
                        .AddEventLog();
                })
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureHostConfiguration(configHost =>
                {
                    configHost.SetBasePath(executablePath);
                    configHost.AddJsonFile("hostsettings.json", optional: true);
                    configHost.AddEnvironmentVariables(prefix: "PREFIX_");
                    configHost.AddCommandLine(args);
                })
                .ConfigureAppConfiguration((hostContext, config) =>
                {
                    string secretsPath = executablePath + Path.DirectorySeparatorChar + "Configurations" + Path.DirectorySeparatorChar;

                    var builderHost = new ConfigurationBuilder()
                      .SetBasePath(executablePath)
                      .AddJsonFile("hostsettings.json", optional: false, reloadOnChange: true)
                      .AddEnvironmentVariables();

                    var configurationHost = builderHost.Build();

                    string ambiente = hostContext.HostingEnvironment.EnvironmentName = configurationHost.GetSection("Enviroment")?.Value ?? hostContext.HostingEnvironment.EnvironmentName;

                    var builder = new ConfigurationBuilder()
                        .SetBasePath(executablePath)
                        .AddJsonFile("hostsettings.json", optional: false, reloadOnChange: true)
                        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                        .AddJsonFile($"appsettings.{ambiente}.json", optional: false, reloadOnChange: true)
                        .AddJsonFile($"{secretsPath}secrets.json", optional: true, reloadOnChange: true)
                        .AddJsonFile($"Configurations{Path.DirectorySeparatorChar}secrets.json", optional: false, reloadOnChange: true)
                        .AddJsonFile($"{secretsPath}secrets.{ambiente}.json", optional: true, reloadOnChange: true)
                        .AddJsonFile($"Configurations{Path.DirectorySeparatorChar}secrets.{ambiente}.json", optional: false, reloadOnChange: true);

                    builder.AddEnvironmentVariables();

                    var configuration = builder.Build();

                    config.AddConfiguration(configuration);
                    _configuration = configuration;

                    foreach (var de in configuration.AsEnumerable())
                    {
                        logger.LogTrace("{0} = {1}", de.Key, de.Value);
                    }
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddLocalization(o => o.ResourcesPath = "Resources");
                    services.AddSingleton<IConfiguration>(provider => _configuration);
                    
                    services.AddScoped<UpdateFromJob>();

                    services.AddHostedService<QuartzHostedService>();
                    
                    services.ConfigureQuartz(_configuration);

                    var connectionString = _configuration["ConnectionString:DefaultConnection"];
                    services.AddDbContext<TemplateContext>(options =>
                options.UseSqlServer(connectionString));

                });
        }
    }
}
