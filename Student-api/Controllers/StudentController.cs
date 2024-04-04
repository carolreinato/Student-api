using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student.Domain.Interfaces.Services;

namespace Student_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
             _studentService = studentService;
        }
        [HttpGet("/aluno")]
        public async Task<ActionResult<Student.Domain.Entities.Student>> GetStudent(Guid hash)
        {
            var student = await _studentService.GetAsync(hash);
            return student;
        }
    }
}
