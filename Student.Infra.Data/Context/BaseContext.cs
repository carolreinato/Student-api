using NetDevPack.Data;
using Microsoft.EntityFrameworkCore;
using Student.Infra.Data.Mapping;
using NetDevPack.Messaging;
using System.Reflection;

namespace Student.Infra.Data.Context
{
    public class BaseContext : DbContext, IUnitOfWork
    {
        //public BaseContext(DbContextOptions<BaseContext> options) : base(options)
        //{
        //    ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        //    ChangeTracker.AutoDetectChangesEnabled = false;
        //}

        public BaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Domain.Entities.Student> Students { get; set; }

        public Task<bool> Commit()
        {
            throw new NotImplementedException();
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<Domain.Entities.Student>(new StudentMap().Configure);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            MapEntity(modelBuilder);
            DesableDeleteCascade(modelBuilder);

            modelBuilder.Ignore<Event>();

            base.OnModelCreating(modelBuilder);
        }

        private static void DesableDeleteCascade(ModelBuilder modelBuilder)
        {
            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(t => t.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

        private static void MapEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
