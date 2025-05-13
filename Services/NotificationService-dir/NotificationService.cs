using FluentValidation;
using Twitter.DTOs.Notification;
using Twitter.Exceptions;
using Twitter.Mappers;
using Twitter.Model;
using Twitter.Unit_of_work;

namespace Twitter.Services.NotificationService
{
    public class NotificationService : INotificationService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IValidator<NotificationDto> validator;
        private readonly ILogger<NotificationService> logger;

        public NotificationService(IUnitOfWork unitOfWork,
            IValidator<NotificationDto> validator,
            ILogger<NotificationService> logger)
        {
            this.unitOfWork = unitOfWork;
            this.validator = validator;
            this.logger = logger;
        }

        public async Task<List<NotificationDto>> GetMyNotifications(string userId)
        {
            var notifications = await unitOfWork.NotificationRepo.GetNotificationByUserId(userId);

            if (notifications == null)
                throw new NotFoundException("No notifications for this user");

            List<NotificationDto> Dtos = notifications.Select(n => n.toDto()).ToList();

            return Dtos;
        }

        public async Task DeleteTaskById(int id)
        {
            await unitOfWork.NotificationRepo.DeleteAsync(id);
        }

        public async Task AddNotification(NotificationDto dto)
        {
            var res = validator.Validate(dto);

            if (!res.IsValid)
            {
                logger.LogError("Attempted to create invalid notification: {Errors}",
                    string.Join(string.Empty, res.Errors));
                return;
            }
            
            Notification not = new();

            not = not.fromDto(dto);

            await unitOfWork.NotificationRepo.InsertAsync(not);
        }
    }
}
