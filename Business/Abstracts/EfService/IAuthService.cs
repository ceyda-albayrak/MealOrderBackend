using Core.Utilities.Results;
using System;
using System.Text;
using Core.Concretes.Entities;
using Core.Utilities.Security.Jwt;
using Entities.Dtos;

namespace Business.Abstract.DapService
{

    public interface IAuthService
    {
        DataResult<User> Register(UserDto user);
        DataResult<User> Login(UserDto user);
        Result UserExists(string email);
        DataResult<AccessToken> CreateAccessToken(User user);
      


    }
}