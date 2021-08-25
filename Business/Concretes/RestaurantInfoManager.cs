using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using Business.Abstracts;
using Business.Constants;
using Business.ValidationRules;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities;

namespace Business.Concretes
{
    public class RestaurantInfoManager:  IRestaurantInfoService
    {
        private IRestaurantInfoDal _infoDal;
        private IRegionDal _regionDal;
        private IUserDal _userDal;

        public RestaurantInfoManager(IRestaurantInfoDal infoDal,IRegionDal regionDal,IUserDal userDal)
        {
            _infoDal = infoDal;
            _regionDal = regionDal;
            _userDal = userDal;
        }
       
        public Result Add(RestaurantInfo info)
        {
            var rid = _regionDal.Get(info.RegionId);
            var uid = _userDal.Get(info.UserId);
            if (rid!=null)
            {
                if (uid!=null)
                {
                    _infoDal.Add(info);
                    return new SuccessResult(Messages.Added);
                }

                return new ErrorResult("Kullanıcı id boş olamaz");
            }
            return new ErrorResult("Region id boş olamaz");


        }

        public Result Delete(RestaurantInfo info)
        {
            _infoDal.Delete(info);
            return new SuccessResult(Messages.Deleted);
        }

        public DataResult<RestaurantInfo> Get(int id)
        {
            return new SuccessDataResult<RestaurantInfo>(_infoDal.Get(id), Messages.Listed);
        }

        public DataResult<List<RestaurantInfo>> GetAll()
        {
            return new SuccessDataResult<List<RestaurantInfo>>(_infoDal.GetAll(), Messages.Listed);
        }

        public DataResult<List<RestaurantInfo>> GetByRegionId(int id)
        {
            return new SuccessDataResult<List<RestaurantInfo>>(_infoDal.GetByRegionId(id), Messages.Listed);
        }

        [ValidationAspect(typeof(RestaurantInfoValidator))]
        public Result Update(RestaurantInfo info)
        {
            _infoDal.Update(info);
            return new SuccessResult(Messages.Updated);
        }
    }
}
