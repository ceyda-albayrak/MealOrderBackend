using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.Dapper;
using Entities;

namespace DataAccess.Abstracts.DapDal
{
    public interface IDapRestaurantInfoDal : IDapperRepository<RestaurantInfo>
    {
        public List<RestaurantInfo> GetByRegionId(int id);
    }
}
