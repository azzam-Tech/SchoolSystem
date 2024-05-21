using SchoolSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.DAL.Services
{
    public interface IAuthService
    {
        Task<AuthModel> GetTokenAsync(TokenRequestModel model);
    }
}
