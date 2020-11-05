using System;

namespace webapi
{
    public class Employee
    {
        public int Id { get; set; }
        public string EName { get; set; }
        public string LastName { get; set; }
        public string Doc { get; set; }
        public string Sector { get; set; }
        public double Salary { get; set; }
        public DateTime DtAdmission { get; set; }
        public Nullable<bool> HealthPlan { get; set; }
        public Nullable<bool> DentalPlan { get; set; }
        public Nullable<bool> Transport { get; set; }
    }
}
