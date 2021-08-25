using System;
using System.Collections.Generic;
using System.Linq;
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
    public class RegionManager : IRegionService
    {
        private IRegionDal _regionDal;

        public RegionManager(IRegionDal regionDal)
        {
            _regionDal = regionDal;
        }
        [ValidationAspect(typeof(RegionValidator))]
        public Result Add(Region region)
        {
            _regionDal.Add(region);
            return new SuccessResult(Messages.Added);
        }

        public Result Delete(Region region)
        {
            _regionDal.Delete(region);
            return new SuccessResult(Messages.Deleted);
        }

        public DataResult<Region> Get(int id)
        {
            return new SuccessDataResult<Region>(_regionDal.Get(id), Messages.Listed);
        }

        public DataResult<List<Region>> GetAll()
        {
            return new SuccessDataResult<List<Region>>(_regionDal.GetAll(), Messages.Listed);
        }
        [ValidationAspect(typeof(RegionValidator))]
        public Result Update(Region region)
        {
            _regionDal.Update(region);
            return new SuccessResult(Messages.Updated);
        }
    }
}
