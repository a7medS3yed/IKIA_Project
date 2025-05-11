using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAL.Contracts;
using DAL.Entities.Common;
using DAL.Persistance.Data;
using Microsoft.EntityFrameworkCore;

namespace DAL.Persistance.Repository
{
    public class GenaricRepository<TModel, TKey>(ApplicationDbContext _dbContext) : IGenaricRepository<TModel, TKey>
        where TModel : BaseEntity<TKey>
        where TKey : IEquatable<TKey>
    {

        public IEnumerable<TModel> GetAll(bool tracking = false)
        {
            if (!tracking)
                return _dbContext.Set<TModel>().AsNoTracking().ToList();

            // if tracking is true, return the TModels with tracking
            return _dbContext.Set<TModel>().ToList();
        }
        public IEnumerable<TModel> GetAll(Expression<Func<TModel, bool>> predicate)
           => _dbContext.Set<TModel>().Where(predicate).ToList();
        
        public TModel? Get(int id)
        {
            var model = _dbContext.Set<TModel>().Find(id);
            if (model == null)
                return null;

            // if model is not null, return the TModel
            return model;
        }

        public void Create(TModel model)
            => _dbContext.Set<TModel>().Add(model);
                   
        public void Update(TModel model)
            => _dbContext.Set<TModel>().Update(model);
                 
        public void Delete(int id)
        {
            var model = _dbContext.Set<TModel>().Find(id);

            if (model != null)
                _dbContext.Set<TModel>().Remove(model);
            
        }

    }
}
