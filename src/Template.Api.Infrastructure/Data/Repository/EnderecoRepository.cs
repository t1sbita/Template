using Microsoft.Extensions.Logging;
using Template.Api.Core.Domain.Entities;
using Template.Api.Infrastructure.Data.Context;
using Template.Api.Infrastructure.Data.Repository.Base;
using Template.Api.Infrastructure.Interfaces;

namespace Template.Api.Infrastructure.Data.Repository
{
    public class EnderecoRepository : BaseRepository<Endereco>, IEnderecoRepository
    {
        private readonly ILogger<Endereco> _logger;

        public EnderecoRepository(TemplateContext contexto, ILogger<Endereco> logger) : base(contexto)
        {
            _logger = logger;
        }

    }
}
