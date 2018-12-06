using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enity
{
    public class Purchase
    {
      public int PurchaseID{get;set;}
      public string Serialnumber{get;set;}
      public string Memo{get;set;}
      public DateTime PurchaseDate{get;set;}
      public int  SupplierID{get;set;}
      public string Clerk{get;set;}
      public string Examiner{get;set;}
      public DateTime ExaminerDate{get;set;}
      public string Custodian{get;set;}
      public DateTime StockDate{get;set;}
      public int OnProcess { get; set; }
      public Purchase() { }
    }
}
