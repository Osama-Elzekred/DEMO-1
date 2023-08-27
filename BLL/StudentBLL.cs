using DEMO_1.Data;
using DEMO_1.Models;
using Microsoft.EntityFrameworkCore;

namespace DEMO_1.BLL
{
    public class StudentBLL : Istudent
    {
        ITIContext ItisContext = new ITIContext();
        public void Add(Student student)
        {
            ItisContext.Students.Add(student);
            ItisContext.SaveChanges();
        }
        public void Update(Student student)
        {
            ItisContext.Students.Update(student);
            ItisContext.SaveChanges();
        }
        public void Delete(Student student)
        {
            ItisContext.Students.Remove(student);
            ItisContext.SaveChanges();
        }
        public List<Student> GetAll()
        {
            return ItisContext.Students.Include(s=>s.Department).ToList();
        }
        public Student GetById(int id)
        {
            return ItisContext.Students?.Include(s => s.Department).FirstOrDefault(s=>s.Id==id);
        }

        public List<Department>? GetDept()
        {
            return GetAll()?.Select(s => s.Department)?.Distinct().ToList();
        }

    }
}
