using Microsoft.EntityFrameworkCore.Storage;
using System.Data;
using Twitter.Model;
using Twitter.Repository.BlockRepo;
using Twitter.Repository.BookmarkRepo;
using Twitter.Repository.CommentRepo;
using Twitter.Repository.FollowRepo;
using Twitter.Repository.LikeRepo;
using Twitter.Repository.PostRepo;
using Twitter.Repository.ProfileRepo;
using Twitter.Repository.RefreshTokensRepo;
using Twitter.Repository.UserRepo;

namespace Twitter.Unit_of_work
{
    public interface IUnitOfWork
    {
        
        IRefreshTokenRepo RefreshTokenRepo { get; }

        IBookmarkRepo BookmarkRepo { get; }

        IPostRepo PostRepo { get; }

        ICommentRepo CommentRepo { get; }

        ILikeRepo LikeRepo { get; }

        IFollowRepo FollowRepo { get; }

        IProfileRepo profileRepo { get; }

        IUserRepo UserRepo { get; }

        IBlockRepo BlockRepo { get; }


        Task<int> CompleteAsync();

        Task<IDbContextTransaction> BeginTransaction();
    }
}
