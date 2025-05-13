using Microsoft.EntityFrameworkCore.Storage;
using System.Data;
using Twitter.Data;
using Twitter.Model;
using Twitter.Repository.BlockRepo;
using Twitter.Repository.BookmarkRepo;
using Twitter.Repository.CommentRepo;
using Twitter.Repository.FollowRepo;
using Twitter.Repository.LikeRepo;
using Twitter.Repository.NotificationRepo;
using Twitter.Repository.PostRepo;
using Twitter.Repository.ProfileRepo;
using Twitter.Repository.RefreshTokensRepo;
using Twitter.Repository.UserRepo;

namespace Twitter.Unit_of_work
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext context;
        public IRefreshTokenRepo RefreshTokenRepo { get; private set; }

        public IBookmarkRepo BookmarkRepo { get; private set; }

        public IPostRepo PostRepo { get; private set; }

        public ICommentRepo CommentRepo { get; private set; }

        public ILikeRepo LikeRepo { get; private set; }

        public IFollowRepo FollowRepo { get; private set; }

        public IProfileRepo profileRepo { get; private set; }

        public IUserRepo UserRepo { get; private set; }

        public IBlockRepo BlockRepo { get; private set; }

        public INotificationRepo NotificationRepo { get; private set; }

        public UnitOfWork(AppDbContext context) {

            this.context = context;

            RefreshTokenRepo = new RefreshTokenRepo(context);
            BookmarkRepo = new BookmarkRepo(context);
            PostRepo = new PostRepo(context);
            CommentRepo = new CommentRepo(context);
            LikeRepo = new LikeRepo(context);
            FollowRepo = new FollowRepo(context);
            profileRepo = new ProfileRepo(context);
            UserRepo = new UserRepo(context);
            BlockRepo = new BlockRepo(context);

        }
       
        public async Task<int> CompleteAsync()
        {
            return await context.SaveChangesAsync();
        }

        public async Task<IDbContextTransaction> BeginTransaction()
        {
            return await context.Database.BeginTransactionAsync();
        }
    }
}
