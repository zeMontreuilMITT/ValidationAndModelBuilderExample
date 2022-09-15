using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ValidationAndModelBuilder.Models
{
    public class Course
    {
        public int CourseNumber { get; set; }
        public string Title { get; set; }
        public int Capacity { get; set; }
        public int Hours { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; } = new HashSet<Enrollment>();

        public Staff? TeachingStaff { get; set; }
        public int? TeachingStaffNumber { get; set; }
        public Staff? AssistingStaff { get; set; }
        public int? AssistingStaffNumber { get; set;}

        public Course()
        {

        }
    }
}
