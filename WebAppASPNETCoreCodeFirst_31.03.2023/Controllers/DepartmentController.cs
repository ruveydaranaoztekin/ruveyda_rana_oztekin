using Microsoft.AspNetCore.Mvc;
using WebAppCoreMVCCodeFirst._24._03._2023_22.Models;
using Microsoft.EntityFrameworkCore;

namespace WebAppCoreMVCCodeFirst._24._03._2023_22.Controllers
{
    public class DepartmentController : Controller
    {
        Context c = new Context();

        public IActionResult Index()
        {
            var values = c.Departments.ToList();

            return View(values);
        }
        [HttpGet]
        public IActionResult newDepartment()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult newDepartment(Department d)
        {
            c.Departments.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult removeDepartment(int id)
        {
            var dept = c.Departments.Find(id);
            if (dept == null)
            {
                return RedirectToAction("Index");
            }
            else {
                
                c.Departments.Remove(dept);
                c.SaveChanges();
                return RedirectToAction("Index");
            }
            
        }
        public IActionResult updateDepartment(int id)
        {
            var dept = c.Departments.Find(id);
            //c.Departments.Remove(dept);
            //c.SaveChanges();
            return View("updateDepartment", dept);
        }
           public IActionResult updateSaveDepartment(Department d)
        {
            var dept = c.Departments.Find(d.DeptID);
            dept.DeptName = d.DeptName;
            c.SaveChanges();

            return RedirectToAction("Index");
        }
        
        public IActionResult detailDepartment(int id)
        {
            var dept = c.Departments.Include(d => d.Students)
                .FirstOrDefault(d => d.DeptID == id);
            return View(dept);
        }
    }
}
