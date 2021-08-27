using System.Collections.Generic;
using Business.Abstracts;
using Business.Abstracts.EfService;
using Core.Concretes.Entities;
using Core.Utilities.Results;
using Entities;


namespace Business.Abstract.EfService
{
    public interface IUserService:IService<User>
    {
        List<OperationClaim> GetClaims(User user);
        User GetByMail(string email);
        DataResult<User> GetUserByMail(string email);
        DataResult<User> GetByUserId(int userId);
    }
}