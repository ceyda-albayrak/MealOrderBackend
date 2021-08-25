using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Concretes.EntityFramework
{
    public interface IEntityRepository<T> where T: class, new()
    {
        T Get(int id);
        List<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
