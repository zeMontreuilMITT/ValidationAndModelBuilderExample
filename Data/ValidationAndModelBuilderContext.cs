using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ValidationAndModelBuilder.Models;

namespace ValidationAndModelBuilder.Data
{
    public class ValidationAndModelBuilderContext : DbContext
    {
        public ValidationAndModelBuilderContext (DbContextOptions<ValidationAndModelBuilderContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            new StudentEntityTypeConfiguration().Configure(modelBuilder.Entity<Student>());
            new StaffEntityTypeConfiguration().Configure(modelBuilder.Entity<Staff>());
        }

        public DbSet<Course> Course { get; set; } = default!;
        public DbSet<Staff> Staff { get; set; } = default!;
        public DbSet<Enrollment> Enrollment { get; set; } = default!;
        public DbSet<Student> Student { get; set; } = default!;
    }
}
