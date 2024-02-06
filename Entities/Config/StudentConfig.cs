using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TestWEBAPI.Entities.Config
{
    public class StudentConfig: IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(n => n.StudentName).IsRequired();
            builder.Property(n => n.StudentName).HasMaxLength(250);
            builder.Property(n => n.Address).IsRequired(false).HasMaxLength(500);
            builder.Property(n => n.Email).IsRequired().HasMaxLength(250);

            builder.HasData(new List<Student>()
            {
               new Student
                {
                    Id= 1,
                    StudentName="Rajesh",
                    Email="rsingh.rajesh01@gmail.com",
                    Address="kathmandu",
                    DOB= new DateTime(2022,12,12)

                },
                new Student
                {
                    Id= 2,
                    StudentName="Suresh Mahato",
                    Email="sureshmahato@gmail.com",
                    Address="satobato",
                    DOB=new DateTime(2015,5,15)
                },
            });
            builder.HasOne(x => x.Department)
                .WithMany(x => x.Students)
                .HasForeignKey(x => x.DepartmentId)
                .HasConstraintName("FK_Student_Deparment");
        }
    }
}
