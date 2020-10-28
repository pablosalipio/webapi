using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;

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

    public class Entry
    {
        public string Type { get; set; }
        public double Value { get; set; }
        public string Descprition { get; set; }
    }
}
