using Twitter.DTOs.PostDtos;
using Twitter.Model;

namespace Twitter.Services.PostService_dir
{
    public interface IPostService
    {
        PostDto toDto(Post post);

        Post fromDto(PostDto dto);
    }
}
