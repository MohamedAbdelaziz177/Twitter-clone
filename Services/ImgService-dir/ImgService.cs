using Microsoft.AspNetCore.Hosting;

namespace Twitter.Services.ImgService_dir
{
    public class ImgService : IImgService
    {
        private readonly IWebHostEnvironment webHostEnvironment;

        public ImgService(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }
        public async Task<string> SaveImageAndGetUrl(IFormFile img)
        {
            string imgName = Guid.NewGuid().ToString() + Path.GetExtension(img.FileName);

            string folder = Path.Combine(webHostEnvironment.WebRootPath, "Images", "posts");

            string fullImgPath = Path.Combine(folder, imgName);

            using (var fileStream = new FileStream(fullImgPath, FileMode.Create))
            {
                await img.CopyToAsync(fileStream);
            }

            return fullImgPath;

        }
    }
}
