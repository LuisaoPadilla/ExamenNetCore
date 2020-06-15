using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Services
{
    public class ProductsRepository : IProductsRepository
    {
        private AppDbContext context;
        public ProductsRepository(AppDbContext context)
        {
            this.context = context;
        }
        public List<Products> GetProducts()
        {
            return this.context.Products.ToList();
        }
    }
}
