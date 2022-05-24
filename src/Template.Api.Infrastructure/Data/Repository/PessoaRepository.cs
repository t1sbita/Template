using Microsoft.Extensions.Logging;
using Template.Api.Core.Domain.Entities;
using Template.Api.Infrastructure.Data.Context;
using Template.Api.Infrastructure.Data.Repository.Base;
using Template.Api.Infrastructure.Interfaces;

namespace Template.Api.Infrastructure.Data.Repository
{
    public class PessoaRepository : BaseRepository<Pessoa>, IPessoaRepository
    {
        private readonly ILogger<Pessoa> _logger;

        public PessoaRepository(TemplateContext contexto, ILogger<Pessoa> logger) : base(contexto)
        {
            _logger = logger;
        }

    }
}
