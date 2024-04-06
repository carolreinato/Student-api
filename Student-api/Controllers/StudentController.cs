using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student.Domain.DTOs;
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
        public async Task<ActionResult<StudentResponse>> GetStudent([FromQuery] StudentRequest request)
        {
            var student = await _studentService.GetAsync(request);
            return student;
        }
    }
}
