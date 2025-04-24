using Twitter.DTOs.PostDtos;
using Twitter.Exceptions;
using Twitter.Mappers;
using Twitter.Model;
using Twitter.Services.ImgService_dir;
using Twitter.Unit_of_work;
using UnauthorizedAccessException = System.UnauthorizedAccessException;

namespace Twitter.Services.PostService_dir
{
    public class PostService : IPostService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IImgService imgService;

        public PostService(IUnitOfWork unitOfWork, IImgService imgService)
        {
            this.unitOfWork = unitOfWork;
            this.imgService = imgService;
        }

        public async Task<PostDto> GetById(int id)
        {
            var post = await unitOfWork.PostRepo.GetPostWithCommentsAndUser(id);

            if (post == null) throw new NotFoundException("No such a post");

            return post.toDto();
        }
  
        public List<PostDto> GetTimeline(string userId) 
        {
            return null; 
        }

        public async Task<PostDto> AddNewPost(CreateUpdatePostDto postDto, string userId)
        {
            Post post = new Post();
            post.UserId = userId;

            post = post.fromDto(postDto);
            
            if(postDto.Img != null)
            post.ImgUrl = await imgService.SaveImageAndGetUrl(postDto.Img);


            try { await unitOfWork.PostRepo.InsertAsync(post); }
            catch (Exception ex) { throw new IOException("Post Not saved - try again"); }

            return post.toDto();
        }

        public async Task<PostDto> UpdatePost(int id, CreateUpdatePostDto postDto, string userId) 
        {
            
            var post = await unitOfWork.PostRepo.GetByIdAsync(id);

            if (post == null) throw new NotFoundException("No such Post");

            if (post.UserId != userId) throw new
                    UnauthorizedAccessException("You are not authorized to acess this post");


            post = post.fromDto(postDto);

            if(post.ImgUrl != null)
            post.ImgUrl = await imgService.SaveImageAndGetUrl(postDto.Img);

            try { await unitOfWork.PostRepo.UpdateAsync(post); }
            catch (Exception e) { throw new IOException("Post Not saved - try again"); }

            return await GetById(id);
        }

        public async Task Delete(int id, string userId)
        {
            try { await unitOfWork.PostRepo.DeleteAsync(id); }
            catch (Exception ex) { throw new IOException("Post Not deleted - try again"); }
        }

    }
}
