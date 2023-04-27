using Azure.Core;
using Microsoft.Extensions.Hosting;
using TestFile.Models;

namespace TestFile.Services.FileService
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _hostEnvironment;

        public FileService(IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }
        public async void FileUpload(ImageModel imageModel)
        {

            string wwwRootPath = _hostEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(imageModel.ImageFile.FileName);
            string extension = Path.GetExtension(imageModel.ImageFile.FileName);
            imageModel.ImageName = fileName = fileName + Guid.NewGuid().ToString().Substring(0, 4) + '_' + DateTime.Now.ToString("dd" + '-' + "MM" + '-' + "yy") + extension;
            string path = Path.Combine(wwwRootPath + "/Image/", fileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await imageModel.ImageFile.CopyToAsync(fileStream);
            }
        }
    }
}
