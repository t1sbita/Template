using Template.Api.Core.Domain.Entities;

namespace Template.Api.Business.Reports.DataSets
{
    public class DataSetAlvaraDetailed
    {
        public string NumeroAlvara { get; set; }
        public string DataEmissao { get; set; }
        public EnderecoDataSet Endereco { get; set; }
        public string AreaNova { get; set; }
        public string AreaReformada { get; set; }
        public string AreaAmpliada { get; set; }
        public string AreaModificada { get; set; }
        public string AreaDiscriminada { get; set; }
        public string AreaConstruida { get; set; }
        public string AreaOcupada { get; set; }
        public string NaturezaOcupacao { get; set; }
        public string TipoOcupacao { get; set; }
        public string NumeroProcesso { get; set; }
        public string DataCriacao { get; set; }
        public string DataDeferimento { get; set; }
        public string AnoProcesso { get; set; }
        public string CentroInformacao { get; set; }
        public RequerenteDataSet Requerente { get; set; }
        public ProprietarioDataSet Proprietario { get; set; }


        public DataSetAlvaraDetailed(Alvara alvara)
        {
            SetAlvara(alvara);
            SetProcesso(alvara);
            SetProprietario(alvara.Pessoas);
            SetRequerente(alvara.Pessoas);
        }

        private void SetAlvara(Alvara alvara)
        {
            NumeroAlvara = alvara.NumeroAlvara ?? "";
            DataEmissao = alvara?.DataEmissao.ToShortDateString();
            Endereco = SetEndereco(alvara.Endereco);
            AreaNova = alvara.AreaNova != 0 ? alvara.AreaNova.ToString() : "\n";
            AreaReformada = alvara.AreaReformada != 0 ? alvara.AreaReformada.ToString() : "\n";
            AreaAmpliada = alvara.AreaAmpliada != 0 ? alvara.AreaAmpliada.ToString() : "\n";
            AreaModificada = alvara.AreaModificada != 0 ? alvara.AreaModificada.ToString() : "\n";
            AreaDiscriminada = alvara.AreaDiscriminada != 0 ? alvara.AreaDiscriminada.ToString() : "\n";
            AreaConstruida = alvara.AreaConstruida != 0 ? alvara.AreaConstruida.ToString() : "\n";
            AreaOcupada = alvara.AreaOcupada != 0 ? alvara.AreaOcupada.ToString() : "\n";
            NaturezaOcupacao = $"{alvara.NaturezaOcupacao} - {alvara.NaturezaOcupacaoDescricao}";
            TipoOcupacao = alvara.TipoOcupacao ?? "";
        }

        private EnderecoDataSet SetEndereco(Endereco endereco)
        {
            return new EnderecoDataSet
            {
                Cep = endereco.Cep.ToString(),
                Logradouro = endereco.Logradouro ?? "",
                Numero = endereco.Numero ?? "",
                Bairro = endereco.Bairro ?? "",
                Complemento = endereco.Complemento ?? "",
                PontoReferencia = endereco.PontoReferencia ?? "",
                Cidade = endereco.Cidade ?? "",
                Estado = endereco.Estado ?? "",
                Pais = endereco.Pais ?? ""
            };
        }

        private EnderecoDataSet SetEnderecoEmpty()
        {
            return new EnderecoDataSet
            {
                Cep = "",
                Logradouro = "",
                Numero = "",
                Bairro = "",
                Complemento = "",
                PontoReferencia = "",
                Cidade = "",
                Estado = "",
                Pais = ""
            };
        }

        private void SetProcesso(Alvara alvara)
        {
            NumeroProcesso = alvara.NumeroProcesso ?? "";
            DataCriacao = alvara.DataCriacaoProcesso.ToShortDateString();
            DataDeferimento = alvara.DataDeferimentoProcesso.ToShortDateString();
            AnoProcesso = alvara.AnoProcesso != 0 ? alvara.AnoProcesso.ToString() : "";
            CentroInformacao = alvara.CentroInformacaoProcesso ?? "";
        }

        private void SetProprietario(List<Pessoa> pessoas)
        {
            var proprietario = pessoas.FirstOrDefault();

            if (proprietario != null)
            {
                Proprietario = new ProprietarioDataSet
                {
                    Nome = proprietario.Nome ?? "",
                    NumeroDocumento = proprietario.Cnpj ?? proprietario.Cpf ?? "",
                    Cga = proprietario.Cga ?? "",
                    Email = proprietario.Email ?? "",
                    DddCelular = proprietario.DddCelular != 0 ? proprietario.DddCelular.ToString() : "",
                    Celular = proprietario.Celular ?? "",
                    DddTelefone = proprietario.DddTelefone != 0 ? proprietario.DddTelefone.ToString() : "",
                    Telefone = proprietario.Telefone ?? "",
                    Endereco = SetEndereco(proprietario.Endereco)
                };
            }
            else
            {
                Proprietario = new ProprietarioDataSet
                {
                    Nome = "",
                    NumeroDocumento = "",
                    Cga = "",
                    Email = "",
                    DddCelular = "",
                    Celular = "",
                    DddTelefone = "",
                    Telefone = "",
                    Endereco = SetEnderecoEmpty()
                };
            }



        }

        private void SetRequerente(List<Pessoa> pessoas)
        {
            var requerente = pessoas.LastOrDefault();

            if (requerente != null)
            {
                Requerente = new RequerenteDataSet
                {
                    Nome = requerente.Nome ?? "",
                    NumeroDocumento = requerente.Cnpj ?? requerente.Cpf ?? "",
                    Cga = requerente.Cga ?? "",
                    Email = requerente.Email ?? "",
                    DddCelular = requerente.DddCelular != 0 ? requerente.DddCelular.ToString() : "",
                    Celular = requerente.Celular ?? "",
                    DddTelefone = requerente.DddTelefone != 0 ? requerente.DddTelefone.ToString() : "",
                    Telefone = requerente.Telefone ?? "",
                    Endereco = SetEndereco(requerente.Endereco)
                };
            }
            else
            {
                Requerente = new RequerenteDataSet
                {
                    Nome = "",
                    NumeroDocumento = "",
                    Cga = "",
                    Email = "",
                    DddCelular = "",
                    Celular = "",
                    DddTelefone = "",
                    Telefone = "",
                    Endereco = SetEnderecoEmpty()
                };
            }

        }
    }

    public class AlvaraDataSet
    {
        public string NumeroAlvara { get; set; }
        public string DataEmissao { get; set; }
        public EnderecoDataSet Endereco { get; set; }
        public string AreaNova { get; set; }
        public string AreaReformada { get; set; }
        public string AreaAmpliada { get; set; }
        public string AreaModificada { get; set; }
        public string AreaDiscriminada { get; set; }
        public string AreaConstruida { get; set; }
        public string AreaOcupada { get; set; }
        public string NaturezaOcupacao { get; set; }
        public string TipoOcupacao { get; set; }
    }

    public class EnderecoDataSet
    {
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public string PontoReferencia { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }

    }

    public class ProcesTemplatetaSet
    {
        public string NumeroProcesso { get; set; }
        public string DataCriacao { get; set; }
        public string DataDeferimento { get; set; }
        public string Ano { get; set; }
        public string CentroInformacao { get; set; }

    }

    public class PessoaDataSet
    {
        public string Nome { get; set; }
        public string NumeroDocumento { get; set; }
        public string Cga { get; set; }
        public string Email { get; set; }
        public string DddCelular { get; set; }
        public string Celular { get; set; }
        public string DddTelefone { get; set; }
        public string Telefone { get; set; }
        public EnderecoDataSet Endereco { get; set; }

    }

    public class RequerenteDataSet : PessoaDataSet
    {

    }

    public class ProprietarioDataSet : PessoaDataSet
    {

    }
}
