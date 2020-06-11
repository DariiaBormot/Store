using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopBL.Interfaces
{
    public interface IGenericService<BLModel> where BLModel: class
    {
        Task<BLModel> GetById(int id);
        Task<IEnumerable<BLModel>> GetAll();
        Task Create(BLModel model);
        Task Remove(int id);
        Task Update(BLModel model); 
    }
}
