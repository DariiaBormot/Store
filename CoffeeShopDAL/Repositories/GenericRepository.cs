using CoffeeShopDAL.Filters;
using CoffeeShopDAL.Filters.Interfaces;
using CoffeeShopDAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopDAL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly CoffeeShopContext _context;

        public GenericRepository(CoffeeShopContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            var result = await _context.Set<T>().ToListAsync();
            return result;
        }

        public async Task<T> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task Create(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Remove(int id)
        {

            var entityToDelete = await _context.Set<T>().FindAsync(id);

            if (entityToDelete != null)
            {
                _context.Set<T>().Remove(entityToDelete);
            }

            await _context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<T> GetEntityByFilter(IFilter<T> expression)
        {
            return await ApplyFilters(expression).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetListByFilter(IFilter<T> expression) 
        {
            return await ApplyFilters(expression).ToListAsync();
        }

        public async Task<int> Count(IFilter<T> filter)
        {
            return await ApplyFilters(filter).CountAsync();
        }

        private IQueryable<T> ApplyFilters(IFilter<T> expression)
        {
            return FilterEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), expression);
        }

    }
}
