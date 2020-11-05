using System.Collections.Generic;

namespace webapi.Models
{
    public class Paycheck
    {
        public string Month { get; set; }
        public List<Entry> Entrys { get; set; }
        public double GrossSalary { get; set; }
        public double TotalDiscount { get; set; }
        public double NetSalary { get; set; }
    }
}
