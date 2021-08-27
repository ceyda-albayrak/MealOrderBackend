using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Core.Concretes.EntityFramework;
using Core.DataAccess.Dapper;
using Dapper;
using DataAccess.Abstracts;
using Entities;

namespace DataAccess.Concretes.EntityFramework
{
    public class EfRestaurantInfoDal : EfEntityRepositoryBase<RestaurantInfo, YemekSiparisContext>, IRestaurantInfoDal
    {
        public List<RestaurantInfo> GetByRegionId(int id)
        {

            using (var context = new YemekSiparisContext())
            {

                return context.Set<RestaurantInfo>().Where(p => p.RegionId == id).ToList();


            }
        }
    }
}
