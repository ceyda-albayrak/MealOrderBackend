using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities;

namespace Business.Abstracts.EfService
{
    public interface IProductService : IService<Product>
    {
        DataResult<List<Product>> GetByRestaurantId(int id);
    }
}
