using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Template.Worker.Utils
{
    [ExcludeFromCodeCoverage]
    public static class SecretsUtil
    {
        private const string ASPNETCORE_ENVIRONMENT = "ASPNETCORE_ENVIRONMENT";
        private const string ASPNETCORE_ENVIRONMENT_DEFAUT_VALUE = "Development";
        private const string DEFAULT_DATABASE = "ConnectionString:DefaultConnection";
        private const string DEFAULT_SCHEMA = "ConnectionString:Schema";

        private static IConfigurationRoot GetConfigurationRoot()
        {
            string ambiente = Environment.GetEnvironmentVariable(ASPNETCORE_ENVIRONMENT) ?? ASPNETCORE_ENVIRONMENT_DEFAUT_VALUE;
            string executablePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string secretsFile = executablePath + Path.DirectorySeparatorChar + "Configurations" + Path.DirectorySeparatorChar + "secrets.json";

            var builder = new ConfigurationBuilder()
                .SetBasePath(executablePath)
                .AddJsonFile($"appsettings.{ambiente}.json")
                .AddJsonFile(secretsFile, optional: true, reloadOnChange: true);
            return builder.Build();
        }

        public static IConfigurationRoot GetConfiguration() => GetConfigurationRoot();
        public static string GetBanco() => GetConfigurationRoot().GetSection(DEFAULT_DATABASE)?.Value;
        public static string GetSchema() => GetConfigurationRoot().GetSection(DEFAULT_SCHEMA)?.Value;
    }

}
