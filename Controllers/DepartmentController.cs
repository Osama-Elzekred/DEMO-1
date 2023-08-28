using DEMO_1.BLL;
using DEMO_1.Data;
using DEMO_1.Models;
using Microsoft.AspNetCore.Mvc;

namespace DEMO_1.Controllers
{
    public class DepartmentController : Controller
    {
        DepartmentBLL deptBLL = new DepartmentBLL();


        public IActionResult Index()
        {
            return View(new DepartmentBLL().GetAll());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department model)
        {
            //ITIContext context = new ITIContext();
            //Department Dept = new ()
            //{
            //    id = model.id,
            //    Dept_Name = model.Dept_Name,
            //    Dept_Location = model.Dept_Location,
            //    Dept_Desc=model.Dept_Desc

            //};
            //context.Departments.Add(Dept);
            //context.SaveChanges();
            deptBLL.Add(model);
            return RedirectToAction("index");
        }
        public IActionResult Delete(int id)
        {
            var dept = deptBLL.GetById(id);
            deptBLL.Delete(dept);
            return RedirectToAction("index");
        }

        
        public IActionResult EditDepartment(int id)
        {
            var dept = deptBLL.GetById(id);
            deptBLL.Update(dept);
            return View(dept);
        }
        [HttpPost]
        public IActionResult EditDepartment(Department d)
        {
           // var dept = context.Departments.Where(x => x.id == d.id).FirstOrDefault();
           //dept.Dept_Name= d.Dept_Name;
           // dept.Dept_Location = d.Dept_Location;
           // dept.Dept_Desc = d.Dept_Desc;
           // context.SaveChanges();
           deptBLL.Update(d);
            return RedirectToAction("index");
        }

        //public ViewResult Details()
        //{
        //    using (var context = new ITIContext())
        //    {

        //        var std = context.Departments.Where(d => d.id > 1).ToList();
        //        return View(std);
        //    }
        //}
        public IActionResult Details(int id)
        {
            //return Redirect("url?q=clientserver");
            //int id = int.Parse(Request.Query["id"].ToString());
            var Dept = deptBLL.GetById(id);
            ViewBag.Student_Name = HttpContext.Session.GetString("Student_Name");
            if (TempData is null)
                return NotFound("Department not Found");
            return View(Dept);
        }
    }
}
