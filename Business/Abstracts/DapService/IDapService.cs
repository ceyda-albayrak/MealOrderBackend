using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;

namespace Business.Abstracts.DapService
{
    public interface IDapService<T>
    {
        DataResult<List<T>> GetAll();
        DataResult<T> Get(int id);
        Result Add(T entity);
        Result Update(T entity);
        Result Delete(T entity);
    }
}
