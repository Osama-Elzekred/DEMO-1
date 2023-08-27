using DEMO_1.Models;

namespace DEMO_1.BLL
{
    public interface Istudent
    {
        public List<Student> GetAll();
        public Student GetById(int id);
        public void Add(Student s);
        public void Update(Student s);
        public void Delete(Student s);
        public List<Department>? GetDept();
    }
}
