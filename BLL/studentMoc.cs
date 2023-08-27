using DEMO_1.Models;

namespace DEMO_1.BLL
{
    public class studentMoc : Istudent
    {
        static List<Student> 
            std  = new List<Student>
            {
                new Student
                {
                    Id = 1,
                    Fname = "John",
                    Lname = "Doe",
                    Address = "123 Main St",
                    Email = "john@example.com",
                    Age = 20,
                    Dept_Id = 1,
                    St_super = null,
                    password = "password123",
                    Department = new Department { id = 1, Dept_Name = "Computer Science" }
                },
                new Student
                {
                    Id = 2,
                    Fname = "Jane",
                    Lname = "Smith",
                    Address = "456 Elm St",
                    Email = "jane@example.com",
                    Age = 22,
                    Dept_Id = 2,
                    St_super = 1,
                    password = "abc123xyz",
                    Department = new Department { id = 2, Dept_Name = "Mathematics" }
                },
                new Student
                {
                    Id = 3,
                    Fname = "Michael",
                    Lname = "Johnson",
                    Address = "789 Oak St",
                    Email = "michael@example.com",
                    Age = 25,
                    Dept_Id = 1,
                    St_super = null,
                    password = "mypass456",
                    Department = new Department { id = 1, Dept_Name = "Computer Science" }
                },
                new Student
                {
                    Id = 4,
                    Fname = "Emily",
                    Lname = "Brown",
                    Address = "101 Pine St",
                    Email = "emily@example.com",
                    Age = 21,
                    Dept_Id = 3,
                    St_super = 2,
                    password = "secure789",
                    Department = new Department { id = 3, Dept_Name = "Physics" }
                },
                // Add more dummy students here
            };
        

        public void Add(Student s)
        {
            GetDummyStudents().Add(s);
        }


        public void Delete(Student s)
        {
            GetDummyStudents().Remove(s);
        }

        public List<Student> GetAll()
        {
            return GetDummyStudents();
        }

        public Student GetById(int id)
        {
            return GetDummyStudents().FirstOrDefault(s => s.Id == id);
        }

        public void Update(Student s)
        {
            //GetDummyStudents().Remove(GetById(s.Id));
                var s2= GetById(s.Id);
            s2=s;
        }
        public static List<Student> GetDummyStudents()
        {

            return std;
        }

        public List<Department>? GetDept()
        {
            return GetAll()?.Select(s => s.Department).Distinct().ToList();
        }
          

            
        
    }
}
