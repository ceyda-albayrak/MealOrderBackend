using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Core.Concretes.Entities;
using Core.Concretes.EntityFramework;
using Core.DataAccess.Dapper;
using Dapper;
using DataAccess.Abstracts;
using DataAccess.Abstracts.DapDal;
using Entities;

namespace DataAccess.Concretes.Dapper
{
    public class DapUserDal : DapperRepositoryBase<User>, IDapUserDal
    {
        

      
        private string configuration = @"Data Source=DESKTOP-OFJU1E2;Database=YemekSiparis;Trusted_Connection=true;MultipleActiveResultSets=True";
        public User GetByMail(string email)
        {
            var columns = GetColumns();
            var query = $"SELECT * FROM {typeof(User).Name}s WHERE Email = @Email";
            var stringOfColumns = string.Join(", ", columns.Select(e => $"{e} = @{e}"));
            using (var connection = new SqlConnection(configuration))
            {
                connection.Open();
                var result = connection.Query<User>(query, new { Email = email });
                return result.SingleOrDefault(p=>p.Email==email);
            }

        }

        public User GetByUserId(int id)
        {
            var columns = GetColumns();
            var query = $"SELECT * FROM {typeof(User).Name}s WHERE Id = @Id";
            var stringOfColumns = string.Join(", ", columns.Select(e => $"{e} = @{e}"));
            using (var connection = new SqlConnection(configuration))
            {
                connection.Open();
                var result = connection.Query<User>(query, new { Id = id });
                return result.SingleOrDefault(p => p.Id==id);
            }

        }


        private IEnumerable<string> GetColumns()
        {
            return typeof(RestaurantInfo)
                .GetProperties()
                .Where(e => e.Name != "Id" && !e.PropertyType.GetTypeInfo().IsGenericType)
                .Select(e => e.Name);
        }


        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new YemekSiparisContext())
            {
                var result = from operationClaim in context.OperationClaims
                    join userOperationClaim in context.UserOperationClaims
                        on operationClaim.Id equals userOperationClaim.OperationClaimId
                    where userOperationClaim.UserId == user.Id
                    select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();

            }
        }


    }
}
