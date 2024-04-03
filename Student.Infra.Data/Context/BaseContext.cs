using Microsoft.EntityFrameworkCore;
using Student.Infra.Data.Mapping;

namespace Student.Infra.Data.Context
{
    public class BaseContext : DbContext
    {
        public BaseContext(DbContextOptions<BaseContext> options) : base(options)
        {
        }

        public DbSet<Domain.Entities.Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Domain.Entities.Student>(new StudentMap().Configure);
        }
    }
}
