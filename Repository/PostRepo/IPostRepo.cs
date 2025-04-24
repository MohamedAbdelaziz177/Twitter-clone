using Twitter.Model;
using Twitter.Repository.GenericRepo;

namespace Twitter.Repository.PostRepo
{
    public interface IPostRepo : IGenericRepo<Post>
    {
        Task<Post?> GetPostWithCommentsAndUser(int id);
    }
}
