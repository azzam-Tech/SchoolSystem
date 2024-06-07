using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SchoolSystem.DAL.Data;
using SchoolSystem.DAL.Entites;
using SchoolSystem.DAL.Models;
using SchoolSystem.DAL.Settings;
using SchoolSystem.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.DAL.Services
{
    public class AuthService : IAuthService
    {

        private readonly JWT _jwt;
        private readonly IUnitOfWork _unitOfWork;
        private readonly AppDbContext _context;


        public AuthService(IOptions<JWT> jwt , IUnitOfWork unitOfWork , AppDbContext context)
        {
            _jwt = jwt.Value;
            _unitOfWork = unitOfWork;
            _context = context;
        }
        public async Task<AuthModel> GetTokenAsync(TokenRequestModel model)
        {

            var authModel = new AuthModel();



            User? user = await  _context.Users.Include(r => r.Role).SingleOrDefaultAsync(u => u.Userpassword ==  model.Password && u.UserName == model.UserName);
            //if (user is null || user.Userpassword != "a" )
            //{
            //    authModel.Message = "Email or Password is incorrect!";
            //    return authModel;
            //}

            if (user is null )
            {
                authModel.Message = "User Name or Password is incorrect!";
                return authModel;
            }

           // if (!string.IsNullOrEmpty(model.UserName) && !string.IsNullOrEmpty(model.Password)) { }
           if (user.Role.RoleName == "Admin")
            {

            }           
            
            if (user.Role.RoleName == "Manager")
            {

            }

            if (user.Role.RoleName == "Teacher" && user.IsSupervisor == true)
            {
                Class? classs = await _unitOfWork.Classes.GetBYSupervisorIdAsync( user.UserId);
                if (classs != null)
                authModel.ClassId = classs.ClassId;
                authModel.LevelId = classs.LevelId;

            }

            if (user.Role.RoleName == "Teaher" && user.IsSupervisor == false)
            {

            }

            if (user.Role.RoleName == "Student")
            {
                Student? Student = await _unitOfWork.Students.GetByUserId(user.UserId);
                //Student? Student = NewMethod(user);
                if (Student != null)
                {
                    authModel.StudentId = Student.StudentId;
                    authModel.StedentParent = Student.StedentParent;
                    authModel.StudentClassId = Student.ClassId;
  
                }
            }

            if (user.Role.RoleName == "Parent")
            {
               // var children = _context.Students.Where(s => s.Equals(user.UserId)).ToList();
                //var childrensFromDB = _context.Students.Include(s => s.User).Where(s => s.StedentParent == user.UserId).ToList();
                //foreach (var child in childrensFromDB)
                //{
                //    authModel.InitialInfo.Add(child.User.UserName);
                //}
            }



            var role = user.Role.RoleName;
            var jwtSecurityToken = /*await*/ CreateJwtToken(user , role);
            

            authModel.IsAuthenticated = true;
            authModel.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            authModel.Password = user.Userpassword;
            authModel.Username = user.UserName;
            authModel.ExpiresOn = jwtSecurityToken.ValidTo;
            authModel.Role = role;
            authModel.IsSuperVaisor = user.IsSupervisor;
            authModel.UserId = user.UserId;

            return authModel;
        }


        //private async Task<JwtSecurityToken> CreateJwtToken(User user, string role)
        private JwtSecurityToken CreateJwtToken(User user, string role)
        {
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(ClaimTypes.Role, role),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };


            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: DateTime.Now.AddDays(_jwt.DurationInDays),
                signingCredentials: signingCredentials);

            return  jwtSecurityToken;
        }
    }
}
