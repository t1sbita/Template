using System.Collections.Generic;

namespace Template.Api.Infrastructure.Interfaces
{
    public interface IInfoRepository
    {
        List<string> GetInfosVersionBanco();
    }
}
