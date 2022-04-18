using System.ComponentModel.DataAnnotations.Schema;
using ConnectingToDB_Lab3.Models;
namespace ConnectingToDB_Lab3.Models
{
    public class StudentCourses
    {
        [ForeignKey("student")]
        public int StudentId { get; set; }  
        [ForeignKey("course")]
        public int CrsId { get; set; }
        public int Degree { get; set; }
        public virtual Student student { get; set; }
        public virtual Course course { get; set; }

    }
}
