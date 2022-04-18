using ConnectingToDB_Lab3.Data;
using ConnectingToDB_Lab3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ConnectingToDB_Lab3.Controllers
{
    public class StudentController : Controller
    {
        ITIDBContext db = new ITIDBContext();
        public IActionResult Index()
        {
            List<Student> students = db.Students.Include(a => a.Department).ToList();
            return View(students);
        }
        public IActionResult Create()
        {
            ViewBag.depts = new SelectList(db.Departments.ToList(), "DeptId", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student student, IFormFile stdimg)
        {
            if (stdimg == null)
            {
                ModelState.AddModelError("", "Img is required");
            }
            if (ModelState.IsValid == true)
            {
                db.Students.Add(student);
                db.SaveChanges();
                string[] arr = stdimg.FileName.Split('.');
                string filename = student.Id.ToString() + "." + arr[arr.Length - 1];
                using (var fs = new FileStream("./wwwroot/images/" + filename, FileMode.Create))
                {
                    stdimg.CopyTo(fs);
                }
                student.StdImg = filename;
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.depts = new SelectList(db.Departments.ToList(), "DeptId", "Name", student.DeptId);
            return View(student);

        }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Student std = db.Students.Include(a => a.Department).FirstOrDefault(a => a.Id == id);
            if (std is null)
            {
                return NotFound();
            }
            return View(std);
        }
        public IActionResult checkusername(string UserName)
        {
            Student std = db.Students.FirstOrDefault(a => a.UserName == UserName);
            if (std == null)
                return Json(true);
            else
                return Json(false);
        }
        public IActionResult editFormOne(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Student std = db.Students.Include(a=>a.Department).FirstOrDefault(a => a.Id == id);
            if (std is null)
            {
                return NotFound();
            }
            ViewBag.depts = new SelectList(db.Departments.ToList(), "DeptId", "Name",std.DeptId);
            return View(std);
        }
        public IActionResult editFormTwo(Student std)
        {
            ViewBag.depts = new SelectList(db.Departments.ToList(), "DeptId", "Name", std.DeptId);
            return View(std);
        }
        public IActionResult editFormThree(Student std)
        {
            return View(std);
        }

        public IActionResult Edit(Student std,IFormFile stdimg)
        {
            if(stdimg == null)
            {
                ModelState.AddModelError("", "image is required");
            }

            if (ModelState.IsValid == true)
            {

                Student studentToBeUpdated = db.Students.FirstOrDefault(a => a.Id == std.Id);
                if (studentToBeUpdated == null)
                {
                    return NotFound();
                }
                else
                {
                    string[] arr = stdimg.FileName.Split('.');
                    string filename = std.Id.ToString() + "." + arr[arr.Length - 1];
                    using (var fs = new FileStream("./wwwroot/images/" + filename, FileMode.Create))
                    {
                        stdimg.CopyTo(fs);
                    }
                    std.StdImg = filename;
                    //Department selectedDept = db.Departments.FirstOrDefault(a => a.DeptId == std.DeptId);
                    
                    studentToBeUpdated.Name = std.Name;
                    studentToBeUpdated.Age = std.Age;
                    studentToBeUpdated.DeptId = std.DeptId;
                    studentToBeUpdated.StdImg = std.StdImg;
                    studentToBeUpdated.Email = std.Email;
                    studentToBeUpdated.Password = std.Password;
                    studentToBeUpdated.UserName = std.UserName;

                    db.Students.Update(studentToBeUpdated);
                    db.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }

            }
            ViewBag.depts = new SelectList(db.Departments.ToList(), "DeptId", "Name", std.DeptId);
            return Json("Modify your data");

        }
        
        public IActionResult Delete(int? id)
        {
            if (id == null) {
                return NotFound();
            }
            Student std = db.Students.FirstOrDefault(a => a.Id == id);

            if (std is null)
            {
                return NotFound();
            }

            return View(std);
        }
        [ActionName("Delete")]
        [HttpPost]
        public IActionResult DeleteConfirmed(int? id)
        {
            if(id == null)
            {
                return NotFound(id);
            }
            Student std = db.Students.FirstOrDefault(x => x.Id == id);
            if (std is null)
            {
                return NotFound();
            }
            db.Students.Remove(std);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
