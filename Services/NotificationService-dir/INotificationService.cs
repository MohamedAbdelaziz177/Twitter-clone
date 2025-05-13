using Twitter.DTOs.Notification;

namespace Twitter.Services.NotificationService
{
    public interface INotificationService
    {

        Task<List<NotificationDto>> GetMyNotifications(string userId);
        Task DeleteTaskById(int id);
        Task AddNotification(NotificationDto dto);
    }
}
