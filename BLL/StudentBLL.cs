using DEMO_1.Data;
using DEMO_1.Models;
using Microsoft.EntityFrameworkCore;

namespace DEMO_1.BLL
{
    public class StudentBLL : Istudent
    {
        ITIContext ITIContext = new ITIContext();
        public void Add(Student student)
        {
            ITIContext.Students.Add(student);
            ITIContext.SaveChanges();
        }
        public void Update(Student student)
        {
            ITIContext.Students.Update(student);
            ITIContext.SaveChanges();
        }
        public void Delete(Student student)
        {
            ITIContext.Students.Remove(student);
            ITIContext.SaveChanges();
        }
        public List<Student> GetAll()
        {
            return ITIContext.Students.Include(s=>s.Department).ToList();
        }
        public Student GetById(int id)
        {
            return ITIContext.Students?.Include(s => s.Department).FirstOrDefault(s=>s.Id==id);
        }

        public List<Department>? GetDept()
        {
            return GetAll()?.Select(s => s.Department)?.Distinct().ToList();
        }
        public bool IsEmailExist(string email)
        {
            return ITIContext.Students.Any(s => (s.Email ?? "").ToLower() == email.ToLower());
        }
        public bool IsEmailExist(string email,int id)
        {
           return ITIContext.Students.Any(s => (s.Email??"").ToLower() == email.ToLower() &&s.Id!=id);
        }
    }
}
