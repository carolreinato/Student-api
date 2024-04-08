using Microsoft.EntityFrameworkCore;
using Student.Domain.Interfaces.Repositories;
using Student.Infra.Data.Context;

namespace Student.Infra.Data.Repository
{
    public class StudentRepository : BaseRepository<Domain.Entities.Student>, IStudentRepository
    {
        public StudentRepository(StudentContext context) : base(context)
        {
        }

        public async Task<Domain.Entities.Student> GetStudentByHash(CancellationToken cancellationToken, Guid hash)
        {
            return await Get<Domain.Entities.Student>(x => x.Hash == hash)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<int> InsertStudent(CancellationToken cancellationToken, Domain.Entities.Student student)
        {
            await InsertAsync<Domain.Entities.Student>(student, cancellationToken);
            return await SaveChangesAsync();
        }
    }
}
