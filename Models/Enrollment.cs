using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ValidationAndModelBuilder.Models
{
    public class Enrollment
    {
        public int Id { get; set; }
        public Student Student { get; set; }
        public int StudentNumber { get; set; }
        public Course Course { get; set; }  
        public int CourseNumber { get; set; }
        public int Grade { get; set; }
        public DateTime EnrollmentDate { get; set; }
    }
}
