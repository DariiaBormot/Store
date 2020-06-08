using CofeeShopDAL.Entities;
using CofeeShopDAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CofeeShopDAL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private CoffeShopContext _context;
        public ProductRepository(CoffeShopContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetById(int id)
        {
            return await _context.Products.FindAsync(id);
        }
    }
}
