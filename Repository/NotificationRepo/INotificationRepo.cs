using Twitter.Model;
using Twitter.Repository.GenericRepo;

namespace Twitter.Repository.NotificationRepo
{
    public interface INotificationRepo : IGenericRepo<Notification>
    {
        Task<List<Notification>?> GetNotificationByUserId(string UserId);
    }
}
