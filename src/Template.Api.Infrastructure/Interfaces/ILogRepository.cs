using Template.Api.Core.Domain.Entities;

namespace Template.Api.Infrastructure.Interfaces
{
    public interface ILogRepository
    {
        Log AddAsync(Log log);
    }
}
