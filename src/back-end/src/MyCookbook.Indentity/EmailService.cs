using MailKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.Globalization;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace MyCookbook.Indentity
{
    public class EmailService : IEmailService
    {
        private const string _errorMessage = "Ocorreu um erro ao tentar enviar o e-mail.";

        private readonly string _host;
        private readonly int _port;
        private readonly SecureSocketOptions _secureSocketOptions;
        private readonly string _fromName;
        private readonly string _fromEmail;
        private readonly string _userName;
        private readonly string _password;

        public EmailService(IConfiguration configuration)
        {
            if (configuration == null)
                throw new ArgumentException("Configuration não pode ser nulo", nameof(configuration));

            _host = configuration["EmailService:Host"];
            _port = int.Parse(configuration["EmailService:Port"], CultureInfo.InvariantCulture);
            _secureSocketOptions = (SecureSocketOptions)int.Parse(configuration["EmailService:SecureSocketOptions"], CultureInfo.InvariantCulture);
            _fromName = configuration["EmailService:FromName"];
            _fromEmail = configuration["EmailService:FromEmail"];
            _userName = configuration["EmailService:UserName"];
            _password = configuration["EmailService:Password"];

            if (string.IsNullOrWhiteSpace(_host))
                throw new ArgumentException("Host obrigatório!", nameof(_host));

            if (_port <= 0)
                throw new ArgumentException("Host obrigatório!", nameof(_host));

            if (string.IsNullOrWhiteSpace(_fromName))
                throw new ArgumentException("_fromName obrigatório!", nameof(_fromName));

            if (string.IsNullOrWhiteSpace(_userName))
                throw new ArgumentException("_userName obrigatório!", nameof(_userName));

            if (string.IsNullOrWhiteSpace(_password))
                throw new ArgumentException("_password obrigatório!", nameof(_password));
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {

            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email obrigatório!", nameof(email));

            if (string.IsNullOrWhiteSpace(subject))
                throw new ArgumentException("Subject obrigatório!", nameof(email));

            if (string.IsNullOrWhiteSpace(htmlMessage))
                throw new ArgumentException("htmlMessage obrigatório!", nameof(htmlMessage));


            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(_fromName, _fromEmail));
            message.To.Add(MailboxAddress.Parse(email));
            message.Subject = subject;

            message.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = htmlMessage
            };

            try
            {
                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync(_host, _port, _secureSocketOptions);

                    await client.AuthenticateAsync(_userName, _password);

                    await client.SendAsync(message);

                    await client.DisconnectAsync(true);
                }
            }
            catch (SocketException ex)
            {
                throw;
            }
            catch (SslHandshakeException ex)
            {
                throw;
            }
            catch (SmtpCommandException ex)
            {
                throw;
            }
            catch (AuthenticationException ex)
            {
                throw;
            }
            catch (ProtocolException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
