using System.Reflection;

namespace Template.Api.Extension
{
    public static class ReadSecrets
    {
        public static ConfigurationManager GetSecrets(this ConfigurationManager configuration)
        {
            string executablePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string secretsFile = executablePath + Path.DirectorySeparatorChar + "Configurations" + Path.DirectorySeparatorChar + "secrets.json";

            configuration.AddJsonFile(secretsFile, optional: true, reloadOnChange: true);

            return configuration;
        }
    }
}
