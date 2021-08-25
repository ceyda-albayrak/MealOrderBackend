using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Concretes.Entities;
using Core.Concretes.EntityFramework;
using DataAccess.Abstracts;
using Entities;

namespace DataAccess.Concretes
{
    public class EfUserDal : EfEntityRepositoryBase<User, YemekSiparisContext>, IUserDal
    {
        public User GetByMail(string email)
        {
            using (var context = new YemekSiparisContext())
            {

                return context.Set<User>().SingleOrDefault(p => p.Email == email);


            }
        }

        public User GetByUserId(int id)
        {
            using (var context = new YemekSiparisContext())
            {

                return context.Set<User>().SingleOrDefault(p => p.Id == id);


            }
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
