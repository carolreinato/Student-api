using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Domain.Interfaces.Repositories
{
    public interface IStudentRepository
    {
        Task<Domain.Entities.Student> GetStudentByHash(CancellationToken cancellationToken, Guid hash);
        Task<int> InsertStudent(CancellationToken cancellationToken, Domain.Entities.Student student);
    }
}
