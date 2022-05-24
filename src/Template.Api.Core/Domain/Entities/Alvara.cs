using Template.Api.Core.Domain.Entities.Base;

namespace Template.Api.Core.Domain.Entities
{
    public class Alvara : BaseEntity
    {
        public string NumeroAlvara { get; set; }
        public DateTime DataEmissao { get; set; }
        public long? EnderecoId { get; set; }
        public Endereco Endereco { get; set; }
        public double? AreaNova { get; set; }
        public double? AreaReformada { get; set; }
        public double? AreaAmpliada { get; set; }
        public double? AreaModificada { get; set; }
        public double? AreaDiscriminada { get; set; }
        public double? AreaConstruida { get; set; }
        public double? AreaOcupada { get; set; }
        public string NaturezaOcupacao { get; set; }
        public string NaturezaOcupacaoDescricao { get; set; }
        public string TipoOcupacao { get; set; }
        public string NumeroProcesso { get; set; }
        public DateTime DataCriacaoProcesso { get; set; }
        public DateTime DataDeferimentoProcesso { get; set; }
        public int? AnoProcesso { get; set; }
        public string CentroInformacaoProcesso { get; set; }
        public List<Pessoa> Pessoas { get; set; }

        public Alvara()
        {
            Pessoas = new List<Pessoa>();
        }

    }
}
