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
        {
            return _dbContext.Set<TModel>().Where(predicate).ToList();
        }

        public TModel? Get(int id)
        {
            var model = _dbContext.Set<TModel>().Find(id);
            if (model == null)
                return null;

            // if model is not null, return the TModel
            return model;
        }

        public int Create(TModel model)
        {
            var addModel = _dbContext.Set<TModel>().Add(model);
            return _dbContext.SaveChanges();
        }

        public int Update(TModel model)
        {
            var updatedModel = _dbContext.Set<TModel>().Update(model);
            return _dbContext.SaveChanges();
        }

        public int Delete(int id)
        {
            var model = _dbContext.Set<TModel>().Find(id);

            if (model == null)
                return 0;

            _dbContext.Set<TModel>().Remove(model);
            return _dbContext.SaveChanges();
        }

    }
}
