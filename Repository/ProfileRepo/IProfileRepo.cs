using Twitter.Model;
using Twitter.Repository.GenericRepo;

namespace Twitter.Repository.ProfileRepo
{
    public interface IProfileRepo : IGenericRepo<Profile>
    {
        Task<Profile?> GetByUserIdAsync(string userId);
    }
}
