using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Template.Api.Core.Resources
{
    [ExcludeFromCodeCoverage]
    public class Resource
    {
        private readonly IStringLocalizer localizer;
        private readonly Assembly assembly;
        private readonly ILogger<Resource> _logger;

        public Resource(IStringLocalizerFactory factory, ILogger<Resource> logger = null)
        {
            _logger = logger;

            var type = typeof(Resource);
            var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);

            localizer = factory.Create("Resource", assemblyName.Name);
            _logger?.LogInformation($"assemblyName: {assemblyName}");
            assembly = type.GetTypeInfo().Assembly;
        }

        public string GetMessage(string resource, params string[] parameters)
        {
            _logger?.LogInformation($"Method GetMessage");
            _logger?.LogInformation($"resouce {resource}");
            _logger?.LogInformation($"condicao: {(parameters?.Length ?? 0) > 0}");

            if ((parameters?.Length ?? 0) > 0)
            {
                _logger?.LogInformation($"localizador: {string.Format(localizer[resource].Value, parameters)}");
                return string.Format(localizer[resource].Value, parameters);
            }

            _logger?.LogInformation($"msg resource: {localizer[resource].Value}");
            return localizer[resource].Value;
        }

        public Stream ReadResourceAsStream(string name)
        {
            string formattedResourceName = FormatResourceName(this.assembly, name);

            Stream manifestResourceStream = assembly.GetManifestResourceStream(formattedResourceName);

            return manifestResourceStream;
        }

        private string FormatResourceName(Assembly assembly, string resourceName)
        {
            return $"{assembly.GetName().Name}.{resourceName.Replace(" ", "_").Replace("\\", ".").Replace("/", ".")}";
        }

        public const string FIELD_REQUIRED = "FieldRequired";
        public const string EMAIL_MESSAGE = "EmailMessage";
        public const string EMAIL_TITLE = "EmailTitle";
        public const string ENTITY_NOT_EXIST = "EntityNotExist";
        public const string REQUERIMENTO_NAO_ABERTO = "RequerimentoNaoAberto";
        public const string ENTITY_EXIST = "EntityExist";
        public const string FUTURE_DATE = "Não é possivel realizar cargas com data futura";
        public const string RETURN_EMPTY = "Endpoint não retornou dados";
        public const string MSG_AVISO_CEP_NAO_LOCALIZADO = "CepNaoLocalizado";
        public const string MSG_ADD_SUCCESSO_ARQUIVOS = "AddSuccessoArquivos";
        public const string MSG_ADD_ERROR_ARQUIVOS = "ErroAddArquivos";
        public const string MSG_FORMATO_INVALIDO = "FormatoInvalido";
        public const string MSG_VALOR_IGUAL_A = "ValorIgualA";
        public const string MSG_VALOR_NO_MAXIMO = "IgualOuMenor";
        public const string MSG_DOCUMENTO_INVALIDO = "DocumentoInvalido";
        public const string MSG_VALOR_INVALIDO = "ValorInvalido";
        public const string TEMPLATE_EMAIL_FORMULARIO = "TemplateFormulario";
        public const string TEMPLATE_EMAIL_FORMULARIO_FINALIZADO = "TemplateFormularioFinalizado";
        public const string SUBJECT_EMAIL_FORMULARIO = "SubjectFormulario";
        public const string DOCUMENT_NOT_FOUND = "DocumentoNaoEncontrado";
        public const string EM_ATENDIMENTO = "EmAtendimento";
        public const string DELETE_SUCCESS = "EntityDelete";
        public const string NOT_AUTHORIZED = "NotAuthorized";
        public const string ALREADY_REGISTERED = "AlreadyRegistered";
        public const string TAMANHO_MAXIMO_ULTRAPASSADO = "TamanhoMaximoUltrapassado";
        public const string CADASTRO_NAO_ENCONTRADO = "CadastroNaoEncontrado";
        public const string ACAO_NAO_PERMITIDA = "AcaoNaoPermitida";
        public const string UPDATEDB_SERVICE = "UpdateDbService-Background";
        public const string JUSTIFICATIVA_NAO_PERMITIDA = "JustificativaNaoPermitida";
    }
}
