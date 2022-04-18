namespace ConnectingToDB_Lab3.Models
{
    public class Course
    {
        public int CrsId { get; set; }
        public string CrsName { get; set;}
        public virtual List<StudentCourses> MyStudents { get; set; }
        public Course()
        {
            MyStudents = new List<StudentCourses>();
        }
    }
}
