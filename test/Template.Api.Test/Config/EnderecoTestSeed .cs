using Template.Api.Core.Domain.dto;
using Template.Api.Core.Domain.Entities;

namespace Template.Api.Test.Config
{
    public static class EnderecoTestSeed
    {
        public static EnderecoDto GetEnderecoDto()
        {
            return new EnderecoDto
            {
                Cep = 40000000,
                Bairro = "Teste",
                Cidade = "Salvador"
            };
        }

        public static Endereco GetEndereco()
        {
            return new Endereco
            {
                Cep = 40000000,
                Bairro = "Teste",
                Cidade = "Salvador"
            };
        }
       
    }
}
