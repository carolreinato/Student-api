using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student.Domain.DTOs;
using Student.Domain.Interfaces.Services;

namespace Student_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ApiController
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
             _studentService = studentService;
        }

        [HttpGet("/getStudent")]
        public async Task<IActionResult> GetStudent([FromQuery] StudentRequest request)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _studentService.GetAsync(request));
        }

        [HttpPost("/addStudent")]
        public async Task<IActionResult> AddStudent([FromBody] AddStudentRequest request)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _studentService.InsertAsync(request));
        }
    }
}
