using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMVC.Models
{
    public class Products
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public Nullable<int> SupplierID { get; set; }
        public Nullable<decimal> UnitPrice { get; set; }
        public Nullable<short> UnitsInStock { get; set; }
    }
}
