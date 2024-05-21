namespace SchoolSystem.Api.Service
{
    public interface IManageFiles
    {
        Task<string> SaveImage(IFormFile _IFormFile, string pathCode);
        Task<string> SaveFile(IFormFile _IFormFile, string pathCode);
        Task DeleteImage(string imagePath);
    }
}
