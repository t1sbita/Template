using Template.Api.Core.Util;
using Template.Api.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Net.Mail;

namespace Template.Api.Infrastructure.Data.Repository
{
    [ExcludeFromCodeCoverage]
    public class EmailRepository : IEmailRepository
    {
        private readonly ILogger _logger;

        public EmailRepository(ILogger logger)
        {
            _logger = logger;
        }

        public async Task<bool> EnviarEmailAsync(List<string> emails, string subject, string message, bool isBodyHtml = false)
        {
            try 
            {
                _logger.LogInformation($"Method EnviarEmailAsync EmailRepository");

                SmtpClient client = ConfigurarStmpClient();

                MailAddress from = new(SecretsUtil.getToEmailNotificacao());

                MailMessage messageMail = new()
                {
                    Body = message,
                    IsBodyHtml = isBodyHtml,
                    From = from,
                };

                emails.ForEach(email => messageMail.To.Add(new MailAddress(email)));

                var stream = ResourceFactory.Create().ReadResourceAsStream("Resources.image.png");
                var attachments = new Attachment(stream, "image.png")
                {
                    ContentId = "logoTemplate"
                };
                attachments.ContentDisposition.Inline = true;

                string someArrows = new(new char[] { '\u2190', '\u2191', '\u2192', '\u2193' });

                messageMail.BodyEncoding = System.Text.Encoding.UTF8;
                messageMail.Subject = subject + someArrows;
                messageMail.SubjectEncoding = System.Text.Encoding.UTF8;
                messageMail.Attachments.Add(attachments);

                client.SendCompleted += new SendCompletedEventHandler(SendCompletedCallback);

                client.Send(messageMail);
                messageMail.Dispose();

                return await Task.FromResult(true);
            }
            catch(Exception ex)
            {
                _logger.LogInformation($"Erro EnviarEmailAsync: {ex.Message}");
                throw;
            }      
        }

        private SmtpClient ConfigurarStmpClient()
        {
            try
            {
                _logger.LogInformation($"Method ConfigurarStmpClient EmailRepository");

                int.TryParse(SecretsUtil.getEmailServerPort(), out int port);

                bool.TryParse(SecretsUtil.getEmailUseDefaultCredentials(), out bool useSsl);

                SmtpClient client = new SmtpClient(SecretsUtil.getEmailServer(), port)
                {
                    Credentials = new NetworkCredential(SecretsUtil.getEmailUserName(), SecretsUtil.getEmailPassword()),
                    EnableSsl = useSsl
                };

                _logger.LogInformation($"UseSsl: {useSsl}");
                _logger.LogInformation($"Port: {port}");
                _logger.LogInformation($"Server: {SecretsUtil.getEmailServer()}");
                _logger.LogInformation($"UserName: {SecretsUtil.getEmailUserName()}");

                _logger.LogInformation($"Saindo do ConfigurarStmpClient EmailRepository");
                return client;
            }
            catch(Exception ex)
            {
                _logger.LogInformation($"Erro ConfigurarStmpClient: {ex.Message}");
                throw;
            }            
        }

        private void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            String token = (string)e.UserState;

            if (e.Cancelled)
            {
                _logger.LogInformation($"Envio cancelado { token} ");
            }
            if (e.Error != null)
            {
                _logger.LogError(e.Error, $"{token}, {e.Error}");
            }
            else
            {
                Console.WriteLine("Messagem enviada.");
            }
        }
    }
}