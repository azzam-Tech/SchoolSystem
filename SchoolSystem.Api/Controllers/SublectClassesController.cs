using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.DAL.Data;

namespace SchoolSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SublectClassesController : ControllerBase
    {
        //inject the AppDbContext
        private readonly AppDbContext _context;
        public SublectClassesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetSublectClasses()
        {
            var Student = _context.Students.Find(1);
            var sucla = _context.SubjectClasses.Where(s => s.ClassId == 1 /*Student.ClassId*/).ToList();
            return Ok(sucla);


        }


    }
}
