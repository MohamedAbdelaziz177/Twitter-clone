using Twitter.DTOs.PostDtos;
using Twitter.Unit_of_work;

namespace Twitter.Services.PostService_dir
{
    public class PostService
    {
        private readonly IUnitOfWork unitOfWork;

        public PostService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public PostDto GetById(int id)
        {
            return null;
        }

        public List<PostDto> GetTimeline(string userId) 
        {
            return null; 
        }

        public PostDto AddNewPost(CreateUpdatePostDto postDto)
        {
            return null;
        }

        public PostDto UpdatePost(CreateUpdatePostDto postDto) 
        {
            return null;
        }

        public void Delete(int id, string userId) 
        {
        }


    }
}
