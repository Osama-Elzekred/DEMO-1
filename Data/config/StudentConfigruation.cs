using DEMO_1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace DEMO_1.Data.config
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        void IEntityTypeConfiguration<Student>.Configure(EntityTypeBuilder<Student> builder)
        {
          builder.ToTable("Students");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).HasColumnName("St_Id");
            builder.Property(s => s.Fname).HasColumnName("St_Fname").IsRequired();
            builder.Property(s => s.Lname).HasColumnName("St_Lname").IsRequired();
            builder.Property(s => s.Address).HasColumnName("St_Address");
            builder.Property(s => s.Age).HasColumnName("St_Age");
            builder.Property(s=>s.Fname).HasMaxLength(50);
            builder.Property(s=>s.Lname).HasMaxLength(50);
            builder.Property(s=>s.Address).HasMaxLength(100);
            builder.HasOne(s => s.Department).WithMany(d => d.Students).HasForeignKey(s => s.Dept_Id);
            builder.HasOne(s => s.Supervisor).WithMany().HasForeignKey(s => s.St_super);


        }
    }
}
