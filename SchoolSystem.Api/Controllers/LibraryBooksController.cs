using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.DAL.Models;
using AutoMapper;
using SchoolSystem.DAL.UnitOfWork;
using SchoolSystem.BLL.DTOs.GetDto;
using SchoolSystem.BLL.DTOs.PostDto;
using SchoolSystem.BLL.DTOs.EditDto;
using SchoolSystem.Api.FileServices;
using SchoolSystem.DAL.Entites;



namespace SchoolSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryBooksController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IManageFiles manageFiles;
        public LibraryBooksController(IUnitOfWork unitOfWork, IMapper mapper, IManageFiles manageFiles)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            this.manageFiles = manageFiles;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetLevels()
        {
            try
            {
                var laibaryBooks = await _unitOfWork.LaibaryBooks.GetAllAsync();
                var laibaryBooksDto = _mapper.Map<IEnumerable<GetLaibaryBookDto>>(laibaryBooks);

                ApiResponse6<IEnumerable<GetLaibaryBookDto>> response = new(laibaryBooksDto);

                return Ok(response);
            }
            catch (System.Exception ex)
            {
                ApiResponse4 response = new ApiResponse4(message: ex.Message);
                return StatusCode(500, response);
            }
        }

        [HttpGet("GetBySectionId/{id}")]
        public async Task<IActionResult> GetBySectionId(int id)
        {
            try
            {
                var laibaryBooks = await _unitOfWork.LaibaryBooks.GetBySectionId(id);



                var laibaryBooksDto = _mapper.Map<IEnumerable<GetLaibaryBookDto>>(laibaryBooks);

                ApiResponse6<IEnumerable<GetLaibaryBookDto>> response = new(laibaryBooksDto);

                return Ok(response);
            }
            catch (System.Exception ex)
            {
                ApiResponse4 response = new ApiResponse4(message: ex.Message);
                return StatusCode(500, response);
            }
        }
    }
}
