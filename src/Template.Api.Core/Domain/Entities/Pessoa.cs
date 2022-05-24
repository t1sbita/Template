using Template.Api.Core.Domain.Entities.Base;

namespace Template.Api.Core.Domain.Entities
{
    public class Pessoa : BaseEntity
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Cnpj { get; set; }
        public string Cga { get; set; }
        public string Email { get; set; }
        public int? DddCelular { get; set; }
        public string Celular { get; set; }
        public int? DddTelefone { get; set; }
        public string Telefone { get; set; }
        public Endereco Endereco{ get; set; }
        public long? EnderecoId { get; set; }
        public Alvara Alvara { get; set; }
        public long? AlvaraId { get; set; }


    }
}
