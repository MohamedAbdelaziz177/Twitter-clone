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
    }
}
