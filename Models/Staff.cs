using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace ValidationAndModelBuilder.Models
{
    public class Staff
    {
        public int StaffNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double? Salary { get; set; }
        public JobTitle JobTitle { get; set; }
        
        public Course? TeachingCourse { get; set; }
        public int? TeachingCourseNumber { get; set; }

        public Course? AssistingCourse { get; set; }
        public int? AssistingCourseNumber { get; set; }
    }

    public class StaffEntityTypeConfiguration : IEntityTypeConfiguration<Staff>
    {
        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            builder.HasKey(s => s.StaffNumber);
            builder.Property(s => s.FirstName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(s => s.LastName)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasOne(s => s.TeachingCourse).WithOne(c => c.TeachingStaff)
                .HasForeignKey<Staff>(s => s.TeachingCourseNumber)
                .HasPrincipalKey<Course>(c => c.TeachingStaffNumber);

            builder.HasOne(s => s.AssistingCourse).WithOne(c => c.AssistingStaff)
                .HasForeignKey<Staff>(s => s.AssistingCourseNumber)
                .HasPrincipalKey<Course>(c => c.AssistingStaffNumber);
        }
    }

    public enum JobTitle
    {
        Instructor,
        Maintenance,
        TeachingAssistant,
        Advisor
    }
}
