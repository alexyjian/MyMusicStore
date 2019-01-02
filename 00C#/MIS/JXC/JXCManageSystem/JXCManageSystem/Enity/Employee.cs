using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enity
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string CardNo { get; set; }
        public byte[] PassWord { get; set; }
        public int BaseFunction { get; set; }
        public int PurchaseFunction { get; set; }
        public int EmployeeFunction { get; set; }
        public string EmployeeName { get; set; }
        public bool Sex { get; set; }
        public string Phone { get; set; }
        public string Memo { get; set; }
        public Employee()
        { }
    }
}
