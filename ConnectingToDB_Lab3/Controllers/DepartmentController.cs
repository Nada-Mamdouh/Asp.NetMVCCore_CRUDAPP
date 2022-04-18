using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer;
using ConnectingToDB_Lab3.Data;
using ConnectingToDB_Lab3.Models;

namespace ConnectingToDB_Lab3.Controllers
{
    public class DepartmentController : Controller
    {
        ITIDBContext db = new ITIDBContext();
        //display all departments
        public IActionResult Index()
        {
            List<Department> departments = db.Departments.ToList();
            return View(departments);
        }

        //display adding form
        public IActionResult Create()
        {
            return View();
        }
        //savingData in database
        [HttpPost]
        public IActionResult Create(Department dept)
        {
            db.Departments.Add(dept);
            db.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Department dept = db.Departments.FirstOrDefault(a => a.DeptId == id);
            if (dept == null)
            {
                return NotFound();
            }
            return View(dept);
        }
        [HttpPost]
        public IActionResult Edit(Department dept)
        {
            db.Departments.Update(dept);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Department Dept = db.Departments.FirstOrDefault(a => a.DeptId == id);
            if(Dept == null)
            {
                return NotFound();
            }
            return View(Dept);
        }

        [ActionName("Delete")]

        [HttpPost] 
        public IActionResult DeleteConfirmed(int? deptid)          
        {
            //dept id because it's coming from form input with asp-for="deptid"
            //if we depended on id sent with route we would use param named id instead
            Department dept = db.Departments.FirstOrDefault(a => a.DeptId == deptid);
            db.Departments.Remove(dept);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult ShowDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Department dept = db.Departments.FirstOrDefault(a => a.DeptId == id);
            if (dept == null)
            {
                return NotFound();
            }
            return View(dept);
        }

    }
}
