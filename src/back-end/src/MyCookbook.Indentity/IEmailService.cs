using System.Threading.Tasks;

namespace MyCookbook.Indentity
{
    public interface IEmailService
    {
        Task SendEmailAsync(string emailTo, string subject, string htmlMessage);
    }
}
