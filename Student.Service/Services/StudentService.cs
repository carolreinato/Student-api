using Student.Domain.Interfaces.Repositories;
using Student.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Service.Services
{
    public class StudentService : IStudentService
    {
        private IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
              _studentRepository = studentRepository;
        }

        public async Task<Domain.Entities.Student> GetAsync(Guid hash)
        {
            return await _studentRepository.GetStudentByHash(hash);
        }
    }
}
