using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics.CodeAnalysis;

namespace Student.Infra.Data.Mapping
{
    [ExcludeFromCodeCoverage]
    public class StudentMap : IEntityTypeConfiguration<Domain.Entities.Student>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Student> builder)
        {
            builder.ToTable("Students");
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Hash);
        }
    }
}
