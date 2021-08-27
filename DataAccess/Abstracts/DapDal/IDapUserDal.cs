using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Concretes.Entities;
using Core.DataAccess.Dapper;
using Entities;

namespace DataAccess.Abstracts.DapDal
{
    public interface IDapUserDal : IDapperRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
        User GetByMail(string email);
        User GetByUserId(int id);
    }
}
