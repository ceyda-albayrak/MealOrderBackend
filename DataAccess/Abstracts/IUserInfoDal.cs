using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Concretes.EntityFramework;
using Entities;

namespace DataAccess.Abstracts
{
    public interface IUserInfoDal : IEntityRepository<UserInfo>
    {
    }
}
