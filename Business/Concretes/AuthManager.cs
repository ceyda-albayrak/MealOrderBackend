using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Business.Abstract;
using Business.Abstracts;
using Business.Constants;
using Business.ValidationRules;
using Core.Aspects.Autofac.Validation;
using Core.Concretes.Entities;
using Core.Utilities.Results;
using Core.Utilities.Security.Jwt;
using Entities.Dtos;


namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;
     

        public AuthManager(IUserService userService,ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;

        }

        [ValidationAspect(typeof(UserValidator))]
        public DataResult<User> Register(UserDto user)
        {
            var passwordHash=BCrypt.Net.BCrypt.HashPassword(user.Password);
            var users = new User
            {
                Email = user.Email,
                PasswordHash = passwordHash,
                Statu = true,
            };
            _userService.Add(users);
            return new SuccessDataResult<User>(users, "kullanıcı eklendi");
        }

        public DataResult<User> Login(UserDto user)
        {
            var userToCheck = _userService.GetByMail(user.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>("kullanıcı bulunamadı");
            }

            if (!BCrypt.Net.BCrypt.Verify(user.Password,userToCheck.PasswordHash))
            {
                return new ErrorDataResult<User>("şifre hatası");
            }

            return new SuccessDataResult<User>(userToCheck, "başarılı giriş");
        }

        public Result UserExists(string email)
        {
            if (_userService.GetByMail(email) != null)
            {
                return new ErrorResult("kullanıcı zaten var");
            }
            return new SuccessResult();
        }

        public DataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }
    }
}
