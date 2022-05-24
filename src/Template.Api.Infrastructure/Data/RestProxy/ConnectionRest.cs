using RestSharp;
using Template.Api.Core.Domain.Constants;
using Template.Api.Core.Domain.dto;
using Template.Api.Core.Util;

namespace Template.Api.Infrastructure.Data.RestProxy
{
    public static  class SedurRest
    {
        public static async Task<List<EnderecoDto>> GoFindSedur(string parameter)
        {
            var client = new RestClient(SecretsUtil.GetValue(Constant.URL_WEBSERVICE));

            var request = new RestRequest(parameter);
            var response = await client.GetAsync<List<EnderecoDto>>(request);

           return response;
        }
    }
}
