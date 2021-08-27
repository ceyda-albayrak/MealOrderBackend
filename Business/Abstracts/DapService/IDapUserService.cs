using System.Collections.Generic;
using Business.Abstracts;
using Business.Abstracts.DapService;
using Core.Concretes.Entities;
using Core.Utilities.Results;
using Entities;


namespace Business.Abstract.DapService
{
    public interface IDapUserService:IDapService<User>
    {
        List<OperationClaim> GetClaims(User user);
        User GetByMail(string email);
        DataResult<User> GetUserByMail(string email);
        DataResult<User> GetByUserId(int userId);
    }
}