using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TestWEBAPI.Entities.Config
{
    public class DepartmentConfig: IEntityTypeConfiguration<Department>
    {
       public void Configure(EntityTypeBuilder<Department> builder)
        {

            builder.ToTable("Departments");
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Id).IsRequired();
            builder.Property(x=>x.DepartmentName).IsRequired().HasMaxLength(200);
            builder.Property(x=>x.Description).HasMaxLength(500);
            builder.HasData(new List<Department>()
            {
                new Department()
                {
                    Id = 1,
                    DepartmentName="IT",
                    Description="IT Department handle New technology "
                },
                new Department()
                {
                    Id = 2,
                    DepartmentName="Account",
                    Description="Account Deparmten Handle the cash transaction"
                }
            }) ;
        }

    }
}
