using System.Collections.Generic;
using System.Threading.Tasks;

namespace Template.Api.Infrastructure.Interfaces
{
    public interface IEmailRepository
    {
        Task<bool> EnviarEmailAsync(List<string> emails, string subject, string message, bool isBodyHtml = false);
    }
}