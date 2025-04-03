namespace Twitter.Services.ImgService_dir
{
    public interface IImgService
    {
        Task<string> SaveImageAndGetUrl(IFormFile img);
    }
}
