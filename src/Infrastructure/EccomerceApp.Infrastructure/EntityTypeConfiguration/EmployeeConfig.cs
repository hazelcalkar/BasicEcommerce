using EcommerceApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceApp.Infrastructure.EntityTypeConfiguration
{
    public class EmployeeConfig :BaseEntityConfig<Employee>
    {
        public override void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).IsRequired(true);
            builder.HasOne(x => x.Mall)
                .WithMany(x => x.Employees)
                .HasForeignKey(x => x.MallId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.Employees)
                .WithOne(x=>x.Manager)
                .HasForeignKey(x=>x.ManagerID)
                .OnDelete(DeleteBehavior.Restrict);
            base.Configure(builder);
        }
    }
}
