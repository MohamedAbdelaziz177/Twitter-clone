
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;

namespace Twitter.Services.MailService_dir
{
    public class MailService : IMailService
    {
        private readonly IConfiguration configuration;

        public MailService(IConfiguration configuration) {

            this.configuration = configuration;
        }
        public async Task<bool> SendMailAsync(string To, string Subject, string Body)
        {

            var from = configuration["SmtpSettings:Username"];

            string host = configuration["SmtpSettings:Host"];

            int port = int.Parse(configuration["SmtpSettings:port"]);

            string userName = configuration["SmtpSettings:Username"];

            string password = configuration["SmtpSettings:Password"];

            var msg = new MimeMessage();
            msg.To.Add(new MailboxAddress(To,To));
            msg.From.Add(new MailboxAddress(from,from));
            msg.Subject = Subject;
            msg.Body = new TextPart(TextFormat.Html) { Text = Body };


            using (var smtpClient = new SmtpClient())
            {
                try
                {
                    await smtpClient.ConnectAsync(host, port, SecureSocketOptions.StartTls);
                    await smtpClient.AuthenticateAsync(userName, password);
                    await smtpClient.SendAsync(msg);
                    await smtpClient.DisconnectAsync(true);

                    return true;
                }
                catch (Exception ex) {

                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }
    }
}
