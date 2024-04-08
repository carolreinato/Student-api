using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student.Domain.DTOs;
using Student.Domain.Interfaces.Services;
using System.Diagnostics.CodeAnalysis;

namespace Student_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ExcludeFromCodeCoverage]
    public class StudentController : ApiController
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
             _studentService = studentService;
        }

        [HttpGet("/getStudent")]
        public async Task<IActionResult> GetStudent(CancellationToken cancellationToken, [FromQuery] StudentRequest request)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _studentService.GetAsync(cancellationToken, request));
        }

        [HttpPost("/addStudent")]
        public async Task<IActionResult> AddStudent(CancellationToken cancellationToken, [FromBody] AddStudentRequest request)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _studentService.InsertAsync(cancellationToken, request));
        }
    }
}
