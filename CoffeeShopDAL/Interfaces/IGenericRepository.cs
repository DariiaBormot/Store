using CoffeeShopDAL.Filters.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopDAL.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();
        Task Create(T entity);
        Task Remove(int id);
        Task Update(T entity);
        Task<T> GetEntityByFilter(IFilter<T> expression);
        Task<IEnumerable<T>> GetListByFilter(IFilter<T> expression);
        int Count(IFilter<T> filter);
    }
}
