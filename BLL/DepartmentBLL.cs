using DEMO_1.Data;
using DEMO_1.Models;

namespace DEMO_1.BLL
{

    public class DepartmentBLL
    {
    ITIContext ItisContext = new ITIContext();
        public void Add(Department department)
        {
        ItisContext.Departments.Add(department);
        ItisContext.SaveChanges();
        }
        public void Update(Department department)
        {
            ItisContext.Departments.Update(department);
            ItisContext.SaveChanges();
        }
        public void Delete(Department department)
        {
            ItisContext.Departments.Remove(department);
            ItisContext.SaveChanges();
        }
        public List<Department> GetAll()
        {
            return ItisContext.Departments.ToList();
        }
        public Department GetById(int id)
        {
            return ItisContext.Departments?.FirstOrDefault(s=>s.id==id);
        }
        
       
    }
}
