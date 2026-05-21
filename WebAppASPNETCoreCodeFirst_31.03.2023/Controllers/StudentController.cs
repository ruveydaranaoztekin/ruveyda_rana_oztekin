using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppCoreMVCCodeFirst._24._03._2023_22.Models;

namespace WebAppCoreMVCCodeFirst._24._03._2023_22.Controllers
{
    public class StudentController : Controller
    {
        Context c = new Context();

        public IActionResult Index()
        {
            var values = c.Students.Include(s => s.Department).ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult newStudent()
        {
            ViewBag.Departments = c.Departments.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult newStudent(Student s)
        {
            c.Students.Add(s);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult removeStudent(int id)
        {
            var student = c.Students.Find(id);
            if (student == null)
            {
                return RedirectToAction("Index");
            }
            c.Students.Remove(student);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult updateStudent(int id)
        {
            var student = c.Students.Find(id);
            ViewBag.Departments = c.Departments.ToList();
            return View("updateStudent", student);
        }

        public IActionResult updateSaveStudent(Student s)
        {
            var student = c.Students.Find(s.StudentdsID);
            
            student.StudentdsNo = s.StudentdsNo;
            student.StudentdsName = s.StudentdsName;
            student.StudentdsSurname = s.StudentdsSurname;
            student.EMail = s.EMail;
            student.DepartmentID = s.DepartmentID;
            
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult detailStudent(int id)
        {
            var student = c.Students
                           .Include(s => s.Department)
                           .FirstOrDefault(s => s.StudentdsID == id);
            return View(student);
        }
    }
}