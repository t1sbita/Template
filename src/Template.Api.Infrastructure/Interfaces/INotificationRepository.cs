using System.Threading.Tasks;

namespace Template.Api.Infrastructure.Interfaces
{
    public interface INotificationRepository
    {
        Task<bool> SendEmailAsync(string[] emails, string subject, string message, bool isBodyHtml = false);
        bool SendSms(string mumber, string subject, string message);
    }
}
