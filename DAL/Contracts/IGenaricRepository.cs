using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities.Common;

namespace DAL.Contracts
{
    public interface IGenaricRepository<TModel, TKey> 
        where TModel : BaseEntity<TKey>
        where TKey : IEquatable<TKey>

    {
        IEnumerable<TModel> GetAll(bool withTracking = false);

        IEnumerable<TModel> GetAll(Expression<Func<TModel, bool>> predicate);
        TModel? Get(int id);
        void Create(TModel entity);
        void Update(TModel entity);
        void Delete(int id);
    }
}
