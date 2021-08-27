using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstracts;
using Business.Abstracts.EfService;
using Business.Constants;
using Business.ValidationRules;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities;

namespace Business.Concretes
{
    public class UserInfoManager : IUserInfoService
    {
        private IUserInfoDal _infoDal;

        public UserInfoManager(IUserInfoDal infoDal)
        {
            _infoDal = infoDal;
        }
        [ValidationAspect(typeof(UserInfoValidator))]
        public Result Add(UserInfo info)
        {
            _infoDal.Add(info);
            return new SuccessResult(Messages.Added);
        }

        public Result Delete (UserInfo info)
        {
            _infoDal.Delete(info);
            return new SuccessResult(Messages.Deleted);
        }

        public DataResult<UserInfo> Get(int id)
        {
            return new SuccessDataResult<UserInfo>(_infoDal.Get(p=>p.UserId==id), Messages.Listed);
        }

        public DataResult<List<UserInfo>> GetAll()
        {
            return new SuccessDataResult<List<UserInfo>>(_infoDal.GetAll(), Messages.Listed);
        }
        [ValidationAspect(typeof(UserInfoValidator))]
        public Result Update(UserInfo info)
        {
            _infoDal.Update(info);
            return new SuccessResult(Messages.Updated);
        }
    }
}
