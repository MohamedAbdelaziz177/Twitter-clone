namespace Twitter.Services.MailService_dir
{
    public interface IMailService
    {
        Task<bool> SendMailAsync(string To, string Subject, string Body);
    }
}
