using Template.Api.Core.Domain.Entities;

namespace Template.Api.Test.Config
{
    public static class PessoaTestSeed
    {
        public static Pessoa GetPessoa()
        {
            return new Pessoa
            {
                Nome = "Fulano",
                Cnpj = "123456789101112",
                Endereco = EnderecoTestSeed.GetEndereco()
            };
        }
    }
}
