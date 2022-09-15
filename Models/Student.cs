using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace ValidationAndModelBuilder.Models
{
    public class Student
    {
        public int StudentNumber { get; set; }
        public string FullName { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; } = new HashSet<Enrollment>();
    }

    public class StudentEntityTypeConfiguration: IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(s => s.StudentNumber);
            builder.Property(s => s.FullName).HasMaxLength(100)
                .IsRequired();
        }
    }
}
