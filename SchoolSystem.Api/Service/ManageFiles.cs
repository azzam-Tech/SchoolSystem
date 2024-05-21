using System.Net;

namespace SchoolSystem.Api.Service
{
    public class ManageFiles 
    {
        public class ManageFileService : IManageFiles
        {
            private IWebHostEnvironment environment;
            public ManageFileService(IWebHostEnvironment environment)
            {
                this.environment = environment;
            }
            public async Task<string> SaveFile(IFormFile _IFormFile, string pathCode)
            {
                try
                {
                    string Filepath = GetFilePath(pathCode);
                    if (!System.IO.Directory.Exists(Filepath))
                    {
                        System.IO.Directory.CreateDirectory(Filepath);
                    }
                    FileInfo _FileInfo = new FileInfo(_IFormFile.FileName);
                    string fileName = DateTime.Now.Ticks.ToString() + _FileInfo.Extension;
                    string filePathToSave = Filepath + "/" + fileName;
                    if (System.IO.File.Exists(filePathToSave))
                    {
                        System.IO.File.Delete(filePathToSave);
                    }
                    using (FileStream stream = System.IO.File.Create(filePathToSave))
                    {
                        await _IFormFile.CopyToAsync(stream);

                    }
                    int startIndex = filePathToSave.IndexOf("wwwroot") + "wwwroot".Length + 1;
                    return filePathToSave.Substring(startIndex);
                }
                catch (Exception ex)
                {
                    throw /*new ApiException($"{ex.Message}") { StatusCode = (int)HttpStatusCode.BadRequest }*/;
                }

            }

            public async Task<string> SaveImage(IFormFile _IFormFile, string pathCode)
            {
                try
                {
                    string ImagesPath = GetImagePath(pathCode);

                    if (!System.IO.Directory.Exists(ImagesPath))
                    {
                        System.IO.Directory.CreateDirectory(ImagesPath);
                    }
                    FileInfo _FileInfo = new FileInfo(_IFormFile.FileName);
                    string imageName = DateTime.Now.Ticks.ToString() + _FileInfo.Extension;
                    string imagePathToSave = ImagesPath + "/" + imageName;

                    if (System.IO.File.Exists(imagePathToSave))
                    {
                        System.IO.File.Delete(imagePathToSave);
                    }
                    using (FileStream stream = System.IO.File.Create(imagePathToSave))
                    {
                        await _IFormFile.CopyToAsync(stream);

                    }
                    int startIndex = imagePathToSave.IndexOf("wwwroot") + "wwwroot".Length + 1;
                    return imagePathToSave.Substring(startIndex);
                }
                catch (Exception ex)
                {
                    throw /*new ApiException($"{ex.Message}") { StatusCode = (int)HttpStatusCode.BadRequest }*/;
                }
            }


            private string GetFilePath(string pathCode)
            {
                return environment.WebRootPath + "/files/" + pathCode;
            }

            private string GetImagePath(string pathCode)
            {
                return environment.WebRootPath + "/images/" + pathCode;
            }

            public async Task DeleteImage(string imagePath)
            {
                try
                {
                    string fullPath = Path.Combine(environment.WebRootPath, imagePath);
                    if (File.Exists(fullPath))
                    {
                        await Task.Run(() => File.Delete(fullPath));
                    }
                }
                catch (Exception ex)
                {
                    throw /*new ApiException($"{ex.Message}") { StatusCode = (int)HttpStatusCode.BadRequest }*/;
                }
            }
        }
    }
}
