using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Products
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int? SupplierId { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
    }
}
