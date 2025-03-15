using Twitter.Data;
using Twitter.Model;
using Twitter.Repository.RefreshTokensRepo;

namespace Twitter.Unit_of_work
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext context;
        public IRefreshTokenRepo RefreshTokenRepo { get; private set; }

        public UnitOfWork(AppDbContext context) {

            this.context = context;
            RefreshTokenRepo = new RefreshTokenRepo(context);
        }
       
        public async Task<int> CompleteAsync()
        {
            return await context.SaveChangesAsync();
        }
    }
}
