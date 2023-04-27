using TestFile.Models;

namespace TestFile.Services.FileService
{
    public interface IFileService
    {
        void FileUpload(ImageModel imageModel);
    }
}
