using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities;

namespace Business.Abstracts
{
    public interface IRestaurantInfoService : IService<RestaurantInfo>
    {
        DataResult<List<RestaurantInfo>> GetByRegionId(int id);
    }
}
