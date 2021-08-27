using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Abstract.EfService;
using Business.Abstracts;
using Business.Constants;
using Core.Concretes.Entities;

using Core.Utilities.Results;

using DataAccess.Abstracts;
using Entities;



namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public Result Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.Added);

        }

        public Result Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.Deleted);
        }

        public DataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.Listed);
        }

        public Result Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.Updated);
        }

        public User GetByMail(string email)
        {
            return _userDal.GetByMail(email);
        }

        public DataResult<User> GetUserByMail(string email)
        {
            return new SuccessDataResult<User>(_userDal.GetByMail(email),Messages.Listed);
        }

        public DataResult<User> GetByUserId(int userId)
        {
            return new SuccessDataResult<User>(_userDal.Get(p=>p.Id==userId), Messages.Listed);
        }

        public DataResult<User> Get(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(p=>p.Id==id), Messages.Listed);
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }
    }
}
