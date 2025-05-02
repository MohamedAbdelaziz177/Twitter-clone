using Twitter.Model;
using Twitter.Repository.GenericRepo;

namespace Twitter.Repository.BlockRepo
{
    public interface IBlockRepo : IGenericRepo<Block>
    {
        Task<Block?> GetByBlockerAndBlocked(string blockerId, string blockedId);
    }
}
