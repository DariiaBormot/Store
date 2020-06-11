using CoffeeShopBL.Interfaces;
using CoffeeShopDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopBL.Services
{
    public abstract class GenericService<BLModel, DALModel> : IGenericService<BLModel>
       where BLModel : class
       where DALModel : class
    {
        private readonly IGenericRepository<DALModel> _repository;
        public GenericService(IGenericRepository<DALModel> repository)
        {
            _repository = repository;
        }
        public async Task Create(BLModel item)
        {
            var model = Map(item);
            await _repository.Create(model);
        }

        public async Task<IEnumerable<BLModel>> GetAll()
        {
            var models = await _repository.GetAll();
            var list = models.ToList();
            return Map(list);
        }

        public async Task<BLModel> GetById(int id)
        {
            var model = await _repository.GetById(id);
            return Map(model);
        }

        public async Task Remove(int id)
        {
            await _repository.Remove(id);
        }

        public async Task Update(BLModel item)
        {
            var model = Map(item);
            await _repository.Update(model);
        }

        public abstract BLModel Map(DALModel entity);
        public abstract DALModel Map(BLModel blmodel);

        public abstract IEnumerable<BLModel> Map(IList<DALModel> entities);
        public abstract IEnumerable<DALModel> Map(IList<BLModel> models);
    }
}
