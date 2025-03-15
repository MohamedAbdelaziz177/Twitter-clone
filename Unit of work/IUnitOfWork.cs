using Twitter.Model;
using Twitter.Repository.RefreshTokensRepo;

namespace Twitter.Unit_of_work
{
    public interface IUnitOfWork
    {
        
        IRefreshTokenRepo RefreshTokenRepo { get; }
        Task<int> CompleteAsync();
    }
}
