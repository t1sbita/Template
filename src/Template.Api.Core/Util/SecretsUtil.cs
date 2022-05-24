using Microsoft.Extensions.Configuration;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Template.Api.Core.Util
{
    [ExcludeFromCodeCoverage]
    public static class SecretsUtil
    {
        private const string ASPNETCORE_ENVIRONMENT = "ASPNETCORE_ENVIRONMENT";
        private const string ASPNETCORE_ENVIRONMENT_DEFAUT_VALUE = "Development";
        private const string DEFAULT_DATABASE = "ConnectionString:DefaultConnection";
        private const string DEFAULT_SCHEMA = "ConnectionString:Schema";
        private const string SERVER_EMAIL_NOTIFICACAO = "SERVER_EMAIL_NOTIFICACAO";
        private const string PORT_EMAIL_NOTIFICACAO = "PORT_EMAIL_NOTIFICACAO";
        private const string TO_EMAIL_NOTIFICACAO = "TO_EMAIL_NOTIFICACAO";
        private const string EMAIL_USE_SSL = "EMAIL_USE_SSL";
        private const string EMAIL_USER_NAME = "EMAIL_USER_NAME";
        private const string EMAIL_PASSWORD = "EMAIL_PASSWORD";
        private const string FROM_EMAIL_DEVELOPMENT = "FROM_EMAIL_DEVELOPMENT";

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
        public static string GetValue(string parameter) => GetConfigurationRoot().GetSection(parameter)?.Value;
        public static string getEmailServer() => GetConfigurationRoot().GetSection(SERVER_EMAIL_NOTIFICACAO)?.Value;
        public static string getEmailServerPort() => GetConfigurationRoot().GetSection(PORT_EMAIL_NOTIFICACAO)?.Value;
        public static string getToEmailNotificacao() => GetConfigurationRoot().GetSection(TO_EMAIL_NOTIFICACAO)?.Value;
        public static string getEmailUseDefaultCredentials() => GetConfigurationRoot().GetSection(EMAIL_USE_SSL)?.Value;
        public static string getEmailUserName() => GetConfigurationRoot().GetSection(EMAIL_USER_NAME)?.Value;
        public static string getEmailPassword() => GetConfigurationRoot().GetSection(EMAIL_PASSWORD)?.Value;
        public static string getFromEmailDevelopment() => GetConfigurationRoot().GetSection(FROM_EMAIL_DEVELOPMENT)?.Value;

    }

}
