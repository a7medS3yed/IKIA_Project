using System;
using System.Collections.Generic;
using System.Linq;
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
        TModel? Get(int id);
        int Create(TModel entity);
        int Update(TModel entity);
        int Delete(int id);
    }
}
