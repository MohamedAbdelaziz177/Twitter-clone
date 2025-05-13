using Microsoft.EntityFrameworkCore;
using Twitter.Data;
using Twitter.Model;
using Twitter.Repository.GenericRepo;

namespace Twitter.Repository.NotificationRepo
{
    public class NotificationRepo : GenericRepo<Notification>, INotificationRepo
    {
        public NotificationRepo(AppDbContext con) : base(con)
        {
        }

        public async Task<List<Notification>?> GetNotificationByUserId(string userId)
        {
            return await dbSet.Where(n => n.UserId == userId).ToListAsync();
        }
    }
}
