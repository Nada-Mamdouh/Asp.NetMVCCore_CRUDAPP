using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ConnectingToDB_Lab3.Data;
using ConnectingToDB_Lab3.Models;

namespace ConnectingToDB_Lab3.Controllers
{
    public class StudentTempController : Controller
    {
        ITIDBContext db = new ITIDBContext();
        public IActionResult DoWork1()
        {
            //db.Departments.Add(new Department() { DeptId = 500,Name="Java",Capacity=50 });
            Department dept = db.Departments.SingleOrDefault(a=>a.DeptId == 200); 
            Student std = new Student() { Name = "Ahmed", Age = 21, DeptId = 400 };
            db.Students.Add(std);
            db.SaveChanges();
            dept.Students.Add(std);
            db.SaveChanges();
            return Content("Added");
        }
        public IActionResult DoWork2()
        {
            Student std = db.Students.Include(a=>a.Department).SingleOrDefault(a => a.Id == 1);
            return Content(std.Department.Name);
        }
        public IActionResult DoWork3()
        {
            Student std = db.Students.FirstOrDefault(a => a.Id == 1);
            Course crs = db.Courses.FirstOrDefault(a => a.CrsId == 1);
            crs.MyStudents.Add(new StudentCourses() { student = std });
            db.SaveChanges();
            db.StudentCourses.Add(new StudentCourses() { StudentId = 1, CrsId = 2 });
            db.SaveChanges();
            return Content("Added To relationShip");
        }
    }
}
