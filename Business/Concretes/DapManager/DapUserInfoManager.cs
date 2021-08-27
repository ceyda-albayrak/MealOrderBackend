using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstracts;
using Business.Abstracts.DapService;
using Business.Constants;
using Business.ValidationRules;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using DataAccess.Abstracts.DapDal;
using Entities;

namespace Business.Concretes
{
    public class DapUserInfoManager : IDapUserInfoService
    {
        private IDapUserInfoDal _infoDal;

        public DapUserInfoManager(IDapUserInfoDal infoDal)
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
            return new SuccessDataResult<UserInfo>(_infoDal.Get(id), Messages.Listed);
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
