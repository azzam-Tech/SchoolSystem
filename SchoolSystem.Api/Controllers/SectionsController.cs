using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.DAL.Entites;
using SchoolSystem.DAL.Models;
using AutoMapper;
using SchoolSystem.DAL.UnitOfWork;
using SchoolSystem.BLL.DTOs.GetDto;
using SchoolSystem.BLL.DTOs.PostDto;
using SchoolSystem.BLL.DTOs.EditDto;
using SchoolSystem.Api.FileServices;

namespace SchoolSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectionsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IManageFiles manageFiles;
        public SectionsController(IUnitOfWork unitOfWork, IMapper mapper, IManageFiles manageFiles)
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
                var sections = await _unitOfWork.Sections.GetAllAsync();
                var sectionDto = _mapper.Map<IEnumerable<GetSectionDto>>(sections);

                ApiResponse6<IEnumerable<GetSectionDto>> response = new(sectionDto);

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
