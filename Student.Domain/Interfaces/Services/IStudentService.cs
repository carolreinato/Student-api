using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Domain.Interfaces.Services
{
    public interface IStudentService
    {
        Task<Domain.Entities.Student> GetAsync(Guid hash);
    }
}
