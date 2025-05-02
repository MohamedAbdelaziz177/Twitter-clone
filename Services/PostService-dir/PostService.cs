using Twitter.DTOs.LikeDtos;
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


            await unitOfWork.PostRepo.InsertAsync(post); 
       

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

            await unitOfWork.PostRepo.UpdateAsync(post); 

            return await GetById(id);
        }

        public async Task Delete(int id, string userId)
        {
            var post = await unitOfWork.PostRepo.GetByIdAsync(id);

            if (post == null)
                throw new NotFoundException("Post not found");

            if (post.UserId != userId)
                throw new UnauthorizedAccessException("U r not authorized to delete this post");

            await unitOfWork.PostRepo.DeleteAsync(id); 
        }

        public async Task LikePost(string userId, int postId)
        {

            Like like = new();

            like.UserId = userId;
            like.PostId = postId;
            
            await unitOfWork.LikeRepo.InsertAsync(like);
        }

        public async Task UnlikePost(string userId, int postId)
        {
            Like? like = await unitOfWork.LikeRepo.GetByUserAndPost(userId, postId);

            if (like == null)
                throw new NotFoundException("You didn't like this post");

            await unitOfWork.LikeRepo.DeleteAsync(like.Id);
        }

        public async Task<bool> IsLikedByUser(string userId, int postId)
        {
            return await 
                unitOfWork.LikeRepo.IsLikedByUser(userId, postId);
        }

        public async Task<List<LikeDto>> GetPostLikes(int postId)
        {
            List<Like>? likes = await unitOfWork.LikeRepo.GetByPostId(postId);

            if (likes == null)
                return new List<LikeDto>();

            var likesDto = likes.Select(x => x.toDto()).ToList();

            return likesDto;
        }

    }
}
