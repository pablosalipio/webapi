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
        public bool HealthPlan { get; set; }
        public bool DentalPlan { get; set; }
        public bool Transport { get; set; }
    }
}
