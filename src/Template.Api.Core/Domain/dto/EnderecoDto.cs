namespace Template.Api.Core.Domain.dto
{
    public class EnderecoDto
    {
        public int Cep { get; set; }
        public int CodLogradouro { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public string PontoReferencia { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        
    }
}
