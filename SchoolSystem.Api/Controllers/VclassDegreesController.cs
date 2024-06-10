using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.DAL.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.BLL.DTOs.GetDto;
using SchoolSystem.BLL.DTOs.Students;
using SchoolSystem.DAL.Entites;
using SchoolSystem.DAL.Models;
using SchoolSystem.DAL.UnitOfWork;
using SchoolSystem.DAL.Data;


namespace SchoolSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VclassDegreesController : ControllerBase
    {
        public partial class VclassDegreeDto
        {
            public string StudentName { get; set; } = null!;

            public string ClassName { get; set; } = null!;

            public decimal? TotalMarks { get; set; }
        }

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;
        public VclassDegreesController(IUnitOfWork unitOfWork, IMapper mapper, AppDbContext context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public IActionResult GetALL()
        {
            try
            {
                IEnumerable<VclassDegree> vclassDegreesfDB = _context.VclassDegrees.ToList();

                IEnumerable<VclassDegreeDto> vclassDegreeDtos = new List<VclassDegreeDto>();
                //IEnumerable<VclassDegreeDto> vclassDegreeDtos = [];

                foreach (VclassDegree vclassDegree in vclassDegreesfDB)
                {
                    VclassDegreeDto vclassDegreeDto = new VclassDegreeDto
                    {
                        ClassName = vclassDegree.ClassName,
                        StudentName = vclassDegree.StudentName,
                        TotalMarks = vclassDegree.TotalMarks

                    };
                    vclassDegreeDtos.Append(vclassDegreeDto);
                }

                Response<IEnumerable<VclassDegreeDto>> response = new(vclassDegreeDtos);

                return Ok(response);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                string message = ex.Message;
                Response<IEnumerable<VclassDegree>> response = new(null, message, error);

                return BadRequest(ex.Message);
            }
        }
    }
}
