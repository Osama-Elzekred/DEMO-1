using DEMO_1.BLL;
using DEMO_1.Data;
using DEMO_1.Models;
//using DEMO_1.Scaffold;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DEMO_1.Controllers
{
    public class StudController : Controller
    {
        //ITIContext itiContext = new ITIContext();

        Istudent studentBLL;
        public StudController(Istudent std)
        {
            studentBLL = std;
        }
        public IActionResult Index()
        {
            
            return View(studentBLL.GetAll());
        }
        public IActionResult Details(int id)
        {
            //return Redirect("url?q=clientserver");
            //int id = int.Parse(Request.Query["id"].ToString());
            var std = studentBLL.GetById(id);
            if (TempData is null)
                return BadRequest();
            return View(std);
        }
        [HttpPost]
        public IActionResult Create(Student model)
        {         
            studentBLL.Add(model);
            return RedirectToAction("index");
            //return Content($"Student {std.Name} is added successfully");
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Dept = new SelectList(studentBLL.GetDept(), "id", "Dept_Name");
            return View();
        }
        public IActionResult Delete(int id)
        {
            var std = studentBLL.GetById(id);
            studentBLL.Delete(std);
            return RedirectToAction("index");
        }
        public IActionResult EditStud(int id)
        {
           
            var std = studentBLL.GetById(id);
            //TempData.Keep();
            ViewBag.Dept  = new SelectList(studentBLL.GetDept(), "id", "Dept_Name");
            return View(std);
        }
        [HttpPost]
        public IActionResult EditStud([Bind("Id, Fname, Lname, Address, Email,Age,Dept_Id")] Student s)
        {

            //if (int.TryParse(Request.Query["id"], out int deptId))
            //{
            //    s.Dept_Id = deptId;
            //}
            var std = studentBLL.GetById(s.Id);
            std.Fname = s.Fname;
            std.Lname = s.Lname;
            std.Address = s.Address;
            std.Email = s.Email;
            std.Age = s.Age;
            std.Dept_Id = s.Dept_Id;
            ModelState["password"].ValidationState= ModelValidationState.Valid;
            if (!ModelState.IsValid)
            {
                return RedirectToAction("index");
            }
            studentBLL.Update(std);

            //studentBLL.Update(s);
            //Console.WriteLine($"{s.Department.Dept_Name}");
            return RedirectToAction("index");
        }
        [AcceptVerbs("Get", "Post")]
        public JsonResult checkEmail(string email,int Id)
        {
            return Json(!studentBLL.IsEmailExist(email,Id));
        }
        //public ViewResult Details()
        //{
        //    // Code-frist approach
        //    using (studentBLL)
        //    {

        //        var std = studentBLL.Students.Where(s => s.Id > 0).ToList();
        //        return View(std);
        //    }


        //    // DB -first approach
        //    //return View(new Scaffold.ItisContext().Students.Where(s => s.StId > 0));
        //}
        /*   public ViewResult Details2()
           {
               // Code-frist approach
               //using (var studentBLL = new ITIContext())
               //{

               //    var std = studentBLL.Students.Where(s => s.Id > 0).ToList();
               //    return View(std);
               //}


               // DB -first approach
               return View("Details",new Scaffold.ItisContext().Students.Where(s => s.StId > 0).AsEnumerable());
           }*/
    }
}
