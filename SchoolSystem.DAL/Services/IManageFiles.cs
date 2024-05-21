using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.DAL.Services
{
    public interface IManageFiles
    {

        Task<string> SaveImage(IFormFile _IFormFile, string pathCode);
        Task<string> SaveFile(IFormFile _IFormFile, string pathCode);
        Task DeleteImage(string imagePath);
        // Task<(byte[], string, string)> DownloadFile(string FileName);
    }
}
