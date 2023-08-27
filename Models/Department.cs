using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DEMO_1.Models
{
    public class Department
    {
        [Key]
        public int id { get; set; }

        [MaxLength(50)]
        public string Dept_Name { get; set; }

        [MaxLength(100)]
        public string? Dept_Desc { get; set; }

        [MaxLength(50)]
        public string? Dept_Location { get; set; }

        public int? Dept_Manager { get; set; }

        public DateTime? Manager_hiredate { get; set; }

        [ForeignKey("Dept_Manager")]
        //public Instructor DepartmentManager { get; set; } = null!;

        // Navigation property for the students in the department
        public ICollection<Student> Students { get; set; } = null!;
        public Department()
        {
            Students = new HashSet<Student>();
            //DepartmentManager = new Instructor();
        }
        public override string ToString()
        {
         
            return $"id: {id}, Dept_Name: {Dept_Name}, Dept_Desc: {Dept_Desc}, Dept_Location: {Dept_Location}, Dept_Manager: {Dept_Manager}, Manager_hiredate: {Manager_hiredate}";
        }
    }
 
}