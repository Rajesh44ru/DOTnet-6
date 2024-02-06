using Microsoft.EntityFrameworkCore;
using TestWEBAPI.Entities;
using TestWEBAPI.Entities.Config;

namespace TestWEBAPI.Repository
{
    public class CollegeDB:DbContext
    {
        public CollegeDB(DbContextOptions<CollegeDB> dbContextOptions):base(dbContextOptions) 
        {
                
        }
       public  DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration( new StudentConfig());
            modelBuilder.ApplyConfiguration( new DepartmentConfig());
            #region Configuration
            //modelBuilder.Entity<Student>().HasData(new List<Student>()
            //{
            //    new Student
            //    {
            //        Id= 1,
            //        StudentName="Rajesh",
            //        Email="rsingh.rajesh01@gmail.com",
            //        Address="kathmandu",
            //        DOB= new DateTime(2022,12,12)

            //    },
            //    new Student
            //    {
            //        Id= 2,
            //        StudentName="Suresh Mahato",
            //        Email="sureshmahato@gmail.com",
            //        Address="satobato",
            //        DOB=new DateTime(2015,5,15)
            //    },

            //});
            //modelBuilder.Entity<Student>(entity =>
            //{
            //    entity.Property(n => n.StudentName).IsRequired();
            //    entity.Property(n => n.StudentName).HasMaxLength(250);
            //    entity.Property(n => n.Address).IsRequired(false).HasMaxLength(500);
            //    entity.Property(n=>n.Email).IsRequired().HasMaxLength(300);
            //}) ; 
            #endregion 
        }
    }
}
