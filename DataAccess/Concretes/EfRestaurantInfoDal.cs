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

namespace DataAccess.Concretes
{
    public class EfRestaurantInfoDal : DapperRepositoryBase<RestaurantInfo>, IRestaurantInfoDal
    {

        private string configuration = @"Data Source=DESKTOP-OFJU1E2;Database=YemekSiparis;Trusted_Connection=true;MultipleActiveResultSets=True";
        public List<RestaurantInfo> GetByRegionId(int id)
        {
            var columns = GetColumns();
            var query = $"SELECT * FROM {typeof(RestaurantInfo).Name}s WHERE RegionId = @Id";
            var stringOfColumns = string.Join(", ", columns.Select(e => $"{e} = @{e}"));
            using (var connection = new SqlConnection(configuration))
            {
                connection.Open();
                var result = connection.Query<RestaurantInfo>(query, new { Id = id });
                return result.ToList();
            }

        }


        private IEnumerable<string> GetColumns()
        {
            return typeof(RestaurantInfo)
                .GetProperties()
                .Where(e => e.Name != "Id" && !e.PropertyType.GetTypeInfo().IsGenericType)
                .Select(e => e.Name);
        }

    }
}
