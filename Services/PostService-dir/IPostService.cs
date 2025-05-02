using Twitter.DTOs.PostDtos;
using Twitter.Model;

namespace Twitter.Services.PostService_dir
{
    public interface IPostService
    {
        Task<PostDto> GetById(int id);

        Task<PostDto> AddNewPost(CreateUpdatePostDto postDto, string userId);

        Task<PostDto> UpdatePost(int id, CreateUpdatePostDto postDto, string userId);

        Task Delete(int id, string userId);

        Task<bool> IsLikedByUser(string userId, int PostId);

        Task LikePost(string userId, int postId);

        Task UnlikePost(string userId, int postId);
    }
}
