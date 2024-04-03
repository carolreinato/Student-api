using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Infra.Data.Mapping
{
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
