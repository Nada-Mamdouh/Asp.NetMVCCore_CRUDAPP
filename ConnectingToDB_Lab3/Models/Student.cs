using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace ConnectingToDB_Lab3.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        [StringLength(10,MinimumLength =3)]
        public string Name { get; set; }
        [Required]
        [Range(20,30)]
        public int Age { get; set; }
        public string StdImg { get; set; }
        [ForeignKey("Department")]
        public int? DeptId { get; set; }
        [RegularExpression(@"[a-zA-Z0-9_]+@[A-Za-z0-9]+.[A-Za-z]{2,4}")]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [NotMapped]
        [Compare("Password")]
        public string CPassword { get; set; }
        [Remote("checkusername","student")]
        public string UserName { get; set; }
        public virtual Department Department { get; set; }
        public virtual List<StudentCourses> MyCourses { get; set; }   

        public Student()
        {
            MyCourses = new List<StudentCourses>();
        }


    }
}
