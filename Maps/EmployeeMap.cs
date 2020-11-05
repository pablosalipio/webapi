using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace webapi.Maps
{

    public class EmployeeMap
    {
        public EmployeeMap(EntityTypeBuilder<Employee> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.ToTable("employees");

            entityBuilder.Property(x => x.Id).HasColumnName("id");
            entityBuilder.Property(x => x.EName).HasColumnName("ename");
            entityBuilder.Property(x => x.LastName).HasColumnName("lastname");
            entityBuilder.Property(x => x.Doc).HasColumnName("doc");
            entityBuilder.Property(x => x.Sector).HasColumnName("sector");
            entityBuilder.Property(x => x.Salary).HasColumnName("salary");
            entityBuilder.Property(x => x.DtAdmission).HasColumnName("dtadmission");
            entityBuilder.Property(x => x.HealthPlan).HasColumnName("healthplan");
            entityBuilder.Property(x => x.DentalPlan).HasColumnName("dentalplan");
            entityBuilder.Property(x => x.Transport).HasColumnName("transport");
        }
    }

}
