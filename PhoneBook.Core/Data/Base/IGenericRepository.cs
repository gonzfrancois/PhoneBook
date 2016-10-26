using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Core.Data.Base
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> Get();

        IEnumerable<TEntity> Find(string propertyName, string discriminent);
        IEnumerable<TEntity> FindInAllProperties(string where);

        TEntity Insert(TEntity entity);

        void DeleteAll(Predicate<TEntity> predicate);

        void Delete(TEntity entityToDelete);
        
    }
}
