using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;

namespace DEMO_1.Models
{
    //[Table("Student")]
    public class Student
    {
        //[Key]
        public int Id { get; set; }

        //[MaxLength(50)]
        public string Fname { get; set; }

        //[MaxLength(10)]
        public string Lname { get; set; }

        //[MaxLength(100)]
        public string? Address { get; set; }

        [EmailAddress]
        //[RegularExpression("[a-zA-Z0-9]+@[a-z]+.[a-z]{2,4}")]
        [Remote(action: "checkEmail", controller: "Stud",AdditionalFields ="Id",ErrorMessage ="Email already Exists!")]
        public string? Email { get; set; }
        public int? Age { get; set; }

        public int? Dept_Id { get; set; }

        public int? St_super { get; set; }
        // validate password
        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        // ERROR MAESSAGE
        [DisplayName("Student Password")]

        public string password { get; set; }
        [NotMapped]
        [Compare("password")]
        [DisplayName("Confirm Password")]
        [DataType(DataType.Password)]

        public string? cpassword { get; set; }

        //[ForeignKey("Dept_Id")]
        public Department? Department { get; set; }

        //[ForeignKey("St_super")]
        public Student? Supervisor { get; set; }
        public Student()
        {
            //Department = new Department();
            //Supervisor = new Student();
        }
        public override string ToString()
        {
            
            return $"Id: {Id}, Fname: {Fname}, Lname: {Lname}, Address: {Address}, Age: {Age}, Dept_Id: {Dept_Id}, St_super: {St_super}";
        }
         
    }
}