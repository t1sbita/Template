namespace Template.Api.Core.Domain.Constants
{
    public static class Constant
    {
        public const string SYSTEM_NAME = "Template";

        public const string FORMAT_LONG_DATE_TIME = "yyyy-MM-dd HH:mm:ss.fff";
        public const string FORMAT_DATE_TIME = "yyyy-MM-dd HH:mm:ss";
        public const string FORMAT_CNPJ = @"{0:00\.000\.000\/0000\-00}";
        public const string FORMAT_CPF = @"{0:000\.000\.000\-00}";

        public const string CEP_REGEX = @"^[0-9]{5}[\d]{3}$";

        public const string ENVIRONMENT_DEVELOPMENT = "Development";
        public const string ENVIRONMENT_HOMOLOGATION = "Homologation";

        public const string ASPNETCORE_ENVIRONMENT = "ASPNETCORE_ENVIRONMENT";

        public const string OPENID_CLIENT_ID = "OpenId:ClientId";
        public const string OPENID_CLIENT_SECRET = "OpenId:ClientSecret";
        public const string AUTENTICADOR_GERACAO_TOKEN = "WebService:AutenticadorToken";
        public const string AUTENTICADOR_ESEFAZ = "WebService:AutenticadorESefaz";

        public const string URL_WEBSERVICE = "WebService:Url";
    }
}
