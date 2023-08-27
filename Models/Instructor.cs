using System.ComponentModel.DataAnnotations;

namespace DEMO_1.Models
{
    public class Instructor
    {
        [Key]
        public int Ins_Id { get; set; }

        // Other instructor properties

        public ICollection<Department> Departments { get; set; }
    }

}