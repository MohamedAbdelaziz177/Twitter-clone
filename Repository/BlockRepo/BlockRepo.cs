using Microsoft.EntityFrameworkCore;
using Twitter.Data;
using Twitter.Model;
using Twitter.Repository.GenericRepo;

namespace Twitter.Repository.BlockRepo
{
    public class BlockRepo : GenericRepo<Block>, IBlockRepo
    {
        public BlockRepo(AppDbContext con) : base(con)
        {
        }

        public async Task<Block?> GetByBlockerAndBlocked(string blockerId, string blockedId)
        {
            return await dbSet.FirstOrDefaultAsync(b => b.BlockerId == blockerId &&
            b.BlockedId == blockedId);
        }
    }
}
